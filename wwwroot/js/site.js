(function () {
    'use strict';

    let lightboxIndex = 0;

    function lightboxItems() {
        return Array.from(document.querySelectorAll('[data-lightbox]'));
    }

    function showLightbox(index) {
        const items = lightboxItems();
        const dialog = document.getElementById('lightbox');
        if (!dialog || items.length === 0) return;

        lightboxIndex = (index + items.length) % items.length;
        const item = items[lightboxIndex];

        const image = dialog.querySelector('[data-lightbox-image]');
        image.src = item.dataset.src;
        image.alt = item.dataset.alt || '';
        dialog.querySelector('[data-lightbox-caption]').textContent = item.dataset.caption || '';
        dialog.querySelector('[data-lightbox-count]').textContent = (lightboxIndex + 1) + ' / ' + items.length;

        if (!dialog.open) dialog.showModal();
    }

    // One delegated click handler, so it keeps working after Blazor page navigation
    document.addEventListener('click', function (event) {
        const target = event.target;
        if (!(target instanceof Element)) return;

        // Close the mobile menu after picking a link
        if (target.closest('#mobile-menu a')) {
            const toggle = document.getElementById('menu-toggle');
            if (toggle) toggle.checked = false;
        }

        // Gallery lightbox
        const tile = target.closest('[data-lightbox]');
        if (tile) { showLightbox(lightboxItems().indexOf(tile)); return; }
        if (target.closest('[data-lightbox-prev]')) { showLightbox(lightboxIndex - 1); return; }
        if (target.closest('[data-lightbox-next]')) { showLightbox(lightboxIndex + 1); return; }

        // Generic dialogs (flavor details)
        const opener = target.closest('[data-dialog-open]');
        if (opener) {
            const dialog = document.getElementById(opener.dataset.dialogOpen);
            if (dialog && !dialog.open) dialog.showModal();
            return;
        }

        if (target.closest('[data-dialog-close]')) {
            const dialog = target.closest('dialog');
            if (dialog) dialog.close();
            return;
        }

        // Click on the dark backdrop closes the dialog
        if (target instanceof HTMLDialogElement && target.open) {
            target.close();
            return;
        }

        // Back to top
        if (target.closest('[data-scroll-top]')) {
            window.scrollTo({ top: 0, behavior: 'smooth' });
        }
    });

    // Arrow keys move through the lightbox (Esc is handled by <dialog>)
    document.addEventListener('keydown', function (event) {
        const dialog = document.getElementById('lightbox');
        if (!dialog || !dialog.open) return;
        if (event.key === 'ArrowRight') showLightbox(lightboxIndex + 1);
        if (event.key === 'ArrowLeft') showLightbox(lightboxIndex - 1);
    });

    // Show the back-to-top button after scrolling
    window.addEventListener('scroll', function () {
        const button = document.getElementById('back-to-top');
        if (button) button.classList.toggle('hidden', window.scrollY < 600);
    }, { passive: true });
})();