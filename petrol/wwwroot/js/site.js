var consumption = document.getElementById("consumption");
var distance = document.getElementById("distance");
var gasPrice = document.getElementById("gasPrice");
var cost = document.getElementById("cost");
var totalCost = document.getElementById("totalCost");

function parseNum(val) {
    return parseFloat(val.replace(",", "."));
}
function updateCost() {
    var c = parseNum(consumption.value);
    var d = parseNum(distance.value);
    var g = parseNum(gasPrice.value);

    if (c > 0 && d > 0 && g > 0) {
        var toPay = c * d * g / 100;
        cost.innerHTML = toPay.toFixed(2).replace(".", ",") + " €";
        totalCost.style.visibility = "visible";
    }
}

consumption.addEventListener("input", updateCost);
distance.addEventListener("input", updateCost);
gasPrice.addEventListener("input", updateCost);