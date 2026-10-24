document.addEventListener("DOMContentLoaded", () => {
    const slides = document.querySelectorAll(".hero-slide");
    const dots = document.querySelectorAll(".hero-dot");
    const previousButton = document.querySelector(".hero-prev");
    const nextButton = document.querySelector(".hero-next");

    let currentSlide = 0;
    let intervalId;

    if (!slides.length) {
        return;
    }
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

document.addEventListener("DOMContentLoaded", function () {
    const carousel = document.querySelector(".deals-carousel");
    let active = 1;

    if (!carousel) {
        return;
    }
    const cards = carousel.querySelectorAll(".deal-card");

    if (cards.length !== 3) {
        return;
    }

    function updateCards() {
        cards.forEach(card => {
            card.classList.remove("card-left", "card-center", "card-right");
        });

        cards[(active + 2) % 3].classList.add("card-left");
        cards[active].classList.add("card-center");
        cards[(active + 1) % 3].classList.add("card-right");
    }
    function nextCard() {
        active = (active + 1) % 3;
        updateCards();
    }
    updateCards();
    let intervar = setInterval(nextCard, 1000);

    carousel.addEventListener("mouseenter", function () {
        clearInterval(intervar);
    });

    carousel.addEventListener("mouseleave", function () {
        clearInterval(intervar);
        intervar = setInterval(nextCard, 1000);
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const reviews =
        [
            {
                text: "Our trip to Santorini was absolutely amazing! From the moment we booked until the day we returned home, everything was perfectly organized. The hotel had a breathtaking sea view, and the entire experience exceeded our expectations. We can't wait to plan our next adventure with ExploreGo!",
                name: "Emily Johnson",
                place: "Santorini, Greece"
            },
            {
                text: "We had an unforgettable holiday in Istanbul thanks to ExploreGo! The accommodation was excellent, the location was perfect, and we had plenty of time to explore the beautiful city. Everything went smoothly, and the whole experience was stress-free. I would definitely recommend ExploreGo to anyone looking for a wonderful vacation!",
                name: "Daniel Smith",
                place: "Istanbul, Turkey"
            },
            {
                text: "Our vacation in Rome was a dream come true! We explored incredible historical places, enjoyed delicious Italian food, and created so many wonderful memories. The booking process was simple, the price was great, and everything was exactly as described. We are already looking forward to our next trip with ExploreGo!",
                name: "Sophie Williams",
                place: "Rome, Italy"
            }
        ];


    const reviewText = document.getElementById("reviewText");
    const reviewName = document.getElementById("reviewName");
    const reviewPlace = document.getElementById("reviewPlace");
    const dots = document.querySelectorAll(".review-dot");

    let current = 0;

    function showReview() {
        reviewText.textContent = reviews[current].text;
        reviewName.textContent = reviews[current].name;
        reviewPlace.textContent = reviews[current].place;

        dots.forEach((dot, index) => {
            dot.classList.toggle("active", index === current);
        });
    }
    document.querySelector(".review-next").addEventListener("click", function () {
        current = (current + 1) % reviews.length;
        showReview();
    });
    document.querySelector(".review-prev").addEventListener("click", function () {
        current = (current - 1 + reviews.length) % reviews.length;
        showReview();
    });
});