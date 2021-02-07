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
        for (var i = 0; i < items.length; i += 100) {
            postResult = await Promise.resolve($.post('DoActions', { list: items.slice(i, i + 100), num: i, shopid: urlParams.get("shopId"), inventoryid: urlParams.get("inventoryId")},
                function (data) {
                    results.push(data)
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
            document.querySelector(".edit").classList.remove("disabled");
        }
    });
});
