document.addEventListener("click", function (event) {
    const button = event.target.closest("[data-password-target]");

    if (!button) {
        return;
    }

    const inputId = button.dataset.passwordTarget;
    const passwordInput = document.getElementById(inputId);

    if (!passwordInput) {
        return;
    }

    const isPasswordHidden = passwordInput.type === "password";

    passwordInput.type = isPasswordHidden ? "text" : "password";

    button.textContent = isPasswordHidden ? "Hide" : "Show";
    button.setAttribute(
        "aria-label",
        isPasswordHidden ? "Hide password" : "Show password"
    );
});
