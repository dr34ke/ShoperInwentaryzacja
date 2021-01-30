let a = [];
var eventify = function (arr, callback) {
    arr.push = function (e) {
        Array.prototype.push.call(arr, e);
        callback(arr);
    };
};
(function () {
    const alertElement = document.getElementById("success-alert");
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

        if (responseJson.success) {
            alertElement.style.display = 'block';
        }
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
            var found = a.find(element => element.Sku == responseJson.sku.toUpperCase());
            console.log(found, a, responseJson.sku.toUpperCase());
            found.stock++;
            
            drawRow(found);
        }
        

    };
    const getItemFromShoper = async (shopid,sku,inventoryId) => {
        const requestData = {
            method: "Get"
        };
        const response = await fetch('/api/ApiAjax/Get?shopid=' + shopid + '&sku=' + sku + '&inventoryid=' + inventoryId, requestData);
        const responseJson = await response.json();
        console.log(responseJson);
        if (responseJson.success) {
            alertElement.style.display = 'block';
        }
        return responseJson;
    };
    const getSavedItems = async (shopid, inventoryId) => {
        const requestData = {
            method: "Get"
        };
        const response = await fetch('/api/ApiAjax/GetItems?&inventoryid=' + inventoryId, requestData);
        const responseJson = await response.json();
        console.log(responseJson);
        for (var i = 0; i < responseJson.length; i++) {
            var item =await  getItemFromShoper(shopid, responseJson[i].sku, inventoryId);
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
    };

    window.addEventListener("DOMContentLoaded", () => {
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);


        eventify(a, function (updatedArr) {
            drawRow(updatedArr[updatedArr.length - 1]);
        });
        getSavedItems(urlParams.get("ShopId"), urlParams.get("InventoryId"));

        formElement.addEventListener("submit",
            event => {
                event.preventDefault();
                addNewItem(urlParams.get("ShopId"), urlParams.get("InventoryId"));
            });
    });
})();
function drawRow(updatedElement) {
    var table = document.querySelector("#results");
    var row = table.insertRow(0);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);
    let newText = document.createTextNode(updatedElement.Name);
    cell1.appendChild(newText);
    newText = document.createTextNode(updatedElement.Price);
    cell2.appendChild(newText);
    newText = document.createTextNode(updatedElement.Stock);
    cell3.appendChild(newText);
    newText = document.createTextNode(updatedElement.ExpectedStock);
    cell4.appendChild(newText);
    newText = document.createTextNode(updatedElement.Sku);
    cell5.appendChild(newText);
    row.classList.add(updatedElement.Sku);
    cell1.classList.add("Name");
    cell2.classList.add("Price");
    cell3.classList.add("Stock");
    cell4.classList.add("ExpectedStock");
    cell5.classList.add("Sku");
}

