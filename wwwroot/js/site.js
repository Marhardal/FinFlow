// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function formatCurrency(input) {
    let value = input.value.replace(/,/g, '').trim();
    if (!isNaN(value) && value) {
        let formatted = parseFloat(value).toLocaleString('en-MW', {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        });
        input.value = formatted;
    }
}

// Format inputs on page load
document.addEventListener('DOMContentLoaded', () => {
    const currencyInputs = document.querySelectorAll('.currency-input');
    currencyInputs.forEach(input => {
        formatCurrency(input);
    });
});

// Format as the user types
document.querySelectorAll('.currency-input').forEach(input => {
    input.addEventListener('input', () => formatCurrency(input));
});

