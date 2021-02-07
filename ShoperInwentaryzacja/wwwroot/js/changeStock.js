window.addEventListener("DOMContentLoaded", () => {
    document.querySelector("#accept").addEventListener("click", async () => {
        var items = [];
        $('table#items tbody tr').each(function () {
            var row = $(this);
            var item = {};
            item.accepted = row.find("input").is(":checked");
            item.sku = row.find(".sku").text();
            item.name = row.find(".name").text();
            item.difference_of_stock = row.find(".difference_of_stock").text();
            item.product_id = row.find(".id").text();
            item.realStock = row.find(".realStock").text();
            items.push(item);
        });

        const urlParams = new URLSearchParams(window.location.search);
        var results = [];
        var table = document.querySelector("#items");
        table.classList.remove("table-striped");
        for (var i = 0; i < items.length; i++) {
            postResult = await Promise.resolve($.post('ChangeStock', { id: items[i].product_id, num: i, stock: items[i].realStock, shopid: urlParams.get("shopId"), inventoryid: urlParams.get("inventoryId")},
                function (data) {
                    if (data == true) {
                        results.push(data);
                        var row = table.querySelector("." + items[i].sku);
                        row.classList.add("alert-success");
                    }
                    else {
                        
                        var row = table.querySelector("." + items[i].sku);
                        row.classList.add("alert-danger");
                        i--; 
                    }
                }));
        }
        let result = true;
        for (let i = 0; i < results.length; i++) {
            if (results[i] != true) {
                result = false;
                break;
            }
        }
        if (result == true) {
            postResult = await Promise.resolve($.post('ChangeStatus', { shopId: urlParams.get("shopId"), inventoryId: urlParams.get("inventoryId")},
                function (data) {
                   
                }));
        }
    });
});
