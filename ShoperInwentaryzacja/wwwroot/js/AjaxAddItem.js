let a = [];
var eventify = function (arr, callback) {
    arr.push = function (e) {
        Array.prototype.push.call(arr, e);
        callback(arr);
    };
};
(function () {
    const formElement = document.forms[0];

    const addNewItem = async (shopid, inventoryid) => {
        const formData = new FormData(formElement);
        const formValues = {
            sku: formData.get("Item2.Sku"),
            inventoryId: inventoryid
        };
        const requestData = {
            method: "POST",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify(formValues),
        };
        const response = await fetch('/api/ApiAjax', requestData);
        const responseJson = await response.json();
        if (responseJson.isSet == "false") {
            var item = await getItemFromShoper(shopid, responseJson.sku, inventoryid);

            let displayItem = {
                Name: item.name,
                Sku: item.sku,
                Stock: item.stock,
                ProductId: item.product_id,
                Price: item.price,
                ExpectedStock: item.expectedStock
            }
            a.push(displayItem);
        }
        else {
            var table = document.querySelector("#results");
            var className = "." + responseJson.sku;
            var row = table.querySelector(className.toUpperCase());
            table.deleteRow(row.rowIndex);
            var found = a.find(element => element.Sku.toUpperCase() == responseJson.sku.toUpperCase());
            found.Stock+=1;
            drawRow(found);
        }
        

    };
    const getItemFromShoper = async (shopid,sku,inventoryId) => {
        const requestData = {
            method: "Get"
        };
        const response = await fetch('/api/ApiAjax/Get?shopid=' + shopid + '&sku=' + sku + '&inventoryid=' + inventoryId, requestData);
        const responseJson = await response.json();
        if (responseJson.success) {
            alertElement.style.display = 'block';
        }
        return responseJson;
    };
    const getSavedItems = async (shopid, inventoryId) => {
        const requestData = {
            method: "Get"
        };
        const response = await fetch('/api/ApiAjax/GetItems?inventoryid=' + inventoryId + "&shopid=" + shopid, requestData);
        const responseJson = await response.json();
        for (var i = 0; i < responseJson.length; i++) {
            let displayItem = {
                Name: responseJson[i].name,
                Sku: responseJson[i].sku,
                Stock: responseJson[i].stock,
                ProductId: responseJson[i].product_id,
                Price: responseJson[i].price,
                ExpectedStock: responseJson[i].expectedStock
            }
            a.push(displayItem);
        }
    };

    window.addEventListener("DOMContentLoaded", () => {
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);


        eventify(a, function (updatedArr) {
            drawRow(updatedArr[updatedArr.length - 1]);
        });
        getSavedItems(urlParams.get("shopId"), urlParams.get("inventoryId"));

        formElement.addEventListener("submit",
            event => {
                event.preventDefault();
                addNewItem(urlParams.get("shopId"), urlParams.get("inventoryId"));
            });
    });
})();
function drawRow(updatedElement) {
    var table = document.querySelector("#results");
    var tbody = table.querySelector("tbody");
    var row = tbody.insertRow(0);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);
    var cell6 = row.insertCell(5);
    let newText = document.createTextNode(updatedElement.Name);
    cell1.appendChild(newText);
    newText = document.createTextNode(updatedElement.Price);
    cell2.appendChild(newText);
    var input = document.createElement("INPUT");
    input.setAttribute("type", "number");
    input.value = updatedElement.Stock;
    cell3.appendChild(input);
    newText = document.createTextNode(updatedElement.ExpectedStock);
    cell4.appendChild(newText);
    newText = document.createTextNode(updatedElement.Sku);
    cell5.appendChild(newText);
    var newElement = document.createElement("button");
    newElement.textContent = "Ustaw Ilość";
    newElement.classList.add("btn");
    newElement.classList.add("btn-primary");

    newElement.addEventListener("click", () => {
        updateCount(updatedElement.Sku);
    });
    cell6.appendChild(newElement);
    row.classList.add(updatedElement.Sku.toUpperCase());
    cell1.classList.add("Name");
    cell2.classList.add("Price");
    cell3.classList.add("Stock");
    cell4.classList.add("ExpectedStock");
    cell5.classList.add("Sku");
}
async function updateCount(sku) {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    var inventoryid = urlParams.get("inventoryId");
    var shopid = urlParams.get("shopId");

    var table = document.querySelector("#results");
    var row = table.querySelector("." + sku.toUpperCase());
    var counter = row.querySelector(".Stock");
    var value = counter.querySelector("input").value;

    const requestData = {
        method: "Get"
    };
    const response = await fetch('/api/ApiAjax/SetCounter?inventoryid=' + inventoryid + "&shopid=" + shopid+"&sku="+sku+"&value="+value, requestData);
    const responseJson = await response.json();
}

