// Main role: Open the booking window and fill it with information about the trip selected by the duser
document.addEventListener("DOMContentLoaded", function () {
    const modal = document.getElementById("bookingModal");
    const peopleInput = document.getElementById("peopleCount");
    const plusButton = document.getElementById("increasePeople");
    const minusButton = document.getElementById("decreasePeople");

    let price = 0;
    let availableSeats = 0;

    const bookButtons = document.querySelectorAll(".book-trip-button");

    bookButtons.forEach(function (button) {

        button.addEventListener("click", function ()
        {
            price = Number(button.dataset.price);
            availableSeats = Number(button.dataset.seats);

            document.getElementById("bookingImage").src = button.dataset.image;
            document.getElementById("bookingTripTitle").textContent = button.dataset.title;
            document.getElementById("bookingLocation").textContent = button.dataset.location;

            document.getElementById("bookingDates").textContent =
                button.dataset.start + " - " + button.dataset.end;

            if (peopleInput != null)
            {
                document.getElementById("bookingTripId").value = button.dataset.id;
                document.getElementById("bookingPrice").textContent = "$" + price.toFixed(2);

                peopleInput.value = 1;
                peopleInput.max = Math.min(availableSeats, 500);

                document.getElementById("bookingSeats").textContent =
                    availableSeats + " seats available";

                updateTotal();
            }

            modal.classList.add("open");
        });
    });

    function updateTotal() {

        if (peopleInput == null)
        {
            return;
        }
        let people = Number(peopleInput.value);

        document.getElementById("bookingTotal").textContent = "$" + (price * people).toFixed(2);

        plusButton.disabled = people >= availableSeats || people >= 500;
        minusButton.disabled = people <= 1;
    }

    if (plusButton != null)
   {

        plusButton.addEventListener("click", function () {

            let people = Number(peopleInput.value);

            if (people < availableSeats && people < 500) {
                peopleInput.value = people + 1;
                updateTotal();
            }
        });
    }
    // Calculate the total booking price based on the number of travelers
    // Also enable or disable the buttons depending on the available seats
    if (minusButton != null)
    {
        minusButton.addEventListener("click", function () {

            let people = Number(peopleInput.value);

            if (people > 1) {
                peopleInput.value = people - 1;
                updateTotal();
            }
        });
    }
    function closeModal() {
        modal.classList.remove("open");
    }

    document.getElementById("closeBooking").addEventListener("click", function () {
        closeModal();
    });

    modal.addEventListener("click", function (event) {

        if (event.target == modal)
        {
            closeModal();
        }
    });

    document.addEventListener("keydown", function (event) {

        if (event.key == "Escape") {
            closeModal();
        }
    });

});