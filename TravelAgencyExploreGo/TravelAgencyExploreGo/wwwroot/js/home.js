document.addEventListener("DOMContentLoaded", () => {
    const slides = document.querySelectorAll(".hero-slide");
    const dots = document.querySelectorAll(".hero-dot");
    const previousButton = document.querySelector(".hero-prev");
    const nextButton = document.querySelector(".hero-next");

    if (!slides.length) {
        return;
    }

    let currentSlide = 0;
    let intervalId;

    function showSlide(index) {
        slides[currentSlide].classList.remove("active");
        dots[currentSlide].classList.remove("active");

        currentSlide = (index + slides.length) % slides.length;

        slides[currentSlide].classList.add("active");
        dots[currentSlide].classList.add("active");
    }

    function startSlider() {
        clearInterval(intervalId);
        intervalId = setInterval(() => {
            showSlide(currentSlide + 1);
        }, 2000);
    }

    previousButton.addEventListener("click", () => {
        showSlide(currentSlide - 1);
        startSlider();
    });

    nextButton.addEventListener("click", () => {
        showSlide(currentSlide + 1);
        startSlider();
    });

    dots.forEach((dot, index) => {
        dot.addEventListener("click", () => {
            showSlide(index);
            startSlider();
        });
    });
    startSlider();
})