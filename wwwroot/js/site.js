// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function formatCurrency(input) {
    let value = input.value.replace(/,/g, '').trim(); // Remove commas
    if (!isNaN(value) && value) {
        // Preserve the caret position
        const caretPosition = input.selectionStart;

        // Format the number
        let formatted = parseFloat(value).toLocaleString('en-MW', {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2
        });

        // Update the input value with the formatted string
        input.value = formatted;

        // Adjust caret position to account for formatting changes
        const decimalIndex = formatted.indexOf('.');
        if (decimalIndex >= 0 && caretPosition > decimalIndex) {
            input.setSelectionRange(decimalIndex + 3, decimalIndex + 3); // Move cursor past decimal
        } else {
            input.setSelectionRange(caretPosition, caretPosition);
        }
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
    input.addEventListener('input', () => {
        const cursorBefore = input.selectionStart;
        formatCurrency(input);
        const cursorAfter = input.selectionStart;
        input.setSelectionRange(cursorBefore, cursorAfter); // Maintain cursor
    });
});
