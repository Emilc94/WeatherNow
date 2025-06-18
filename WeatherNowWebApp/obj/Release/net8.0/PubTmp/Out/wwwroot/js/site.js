document.addEventListener('DOMContentLoaded', function () {
    const originalNavbar = document.querySelector('.navbar-original');
    const aboutusNavbar = document.querySelector('.navbar-aboutus');
    const documentationNavbar = document.querySelector('.navbar-documentation');

    const trigger0 = document.querySelector('.trigger0');
    const trigger1 = document.querySelector('.trigger1');

    const triggerHeight0 = trigger0.getBoundingClientRect().top + window.scrollY;
    const triggerHeight1 = trigger1.getBoundingClientRect().top + window.scrollY;

    let lastScrollY = window.scrollY;

    function handleScroll() {
        const scrollPosition = window.scrollY;

        if (scrollPosition < triggerHeight0) {
            // Vis original navbar
            originalNavbar.classList.add('visible');
            originalNavbar.classList.remove('hidden');
            aboutusNavbar.classList.add('hidden');
            aboutusNavbar.classList.remove('visible');
            documentationNavbar.classList.add('hidden');
            documentationNavbar.classList.remove('visible');
        } else if (scrollPosition >= triggerHeight0 && scrollPosition < triggerHeight1) {
            // Vis dokumentasjonsnavbar
            originalNavbar.classList.add('hidden');
            originalNavbar.classList.remove('visible');
            aboutusNavbar.classList.add('hidden');
            aboutusNavbar.classList.remove('visible');
            documentationNavbar.classList.add('visible');
            documentationNavbar.classList.remove('hidden');
        } else {
            originalNavbar.classList.add('hidden');
            originalNavbar.classList.remove('visible');
            aboutusNavbar.classList.add('visible');
            aboutusNavbar.classList.remove('hidden');
            documentationNavbar.classList.add('hidden');
            documentationNavbar.classList.remove('visible');
        }

        lastScrollY = scrollPosition;
    }

    // Bruke setInterval for å sjekke scrollposisjon
    setInterval(function () {
        if (window.scrollY !== lastScrollY) {
            handleScroll();
        }
    }, 100); // Juster intervallet etter behov

    handleScroll(); // Initial sjekk
});
