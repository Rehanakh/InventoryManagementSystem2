$(document).ready(function () {
    $(".click").click(function () {
        //var proName = $("[name='ProductName']").val();
        //var proBarCode = $("[name='ProductBarcode']").val();
        //var proExpiry = $("[name='exdatePicker']").val();
        //var proCartons = $("[name='CartonTxt']").val();
        //var proPerCart = $("[name='pieceTxt']").val();
        //var proBuying = $("[name='buyingTxt']").val();

        var proName = $("#ProductName").val();
        var proBarCode = $("#ProductBarcode").val();
        var proExpiry = $("#exdatePicker").val();
        var proCartons = $("#CartonTxt").val();
        var proPerCart = $("#pieceTxt").val();
        var proBuying = $("#buyingTxt").val();

        var code = "<tr><td><input type='checkbox' name='record'/></td><td>" + proName + "</td><td>" + proBarCode + "</td><td>" + proExpiry + "</td><td>" + proCartons + "</td><td>" + proPerCart + "</td><td>" + proBuying + "</td></tr>";

        $("table tBody").append(code);

    })
    $(".del").click(function () {
        $("table .tbody").find('input[name="record"]').each(function () {

            if ($(this).is(":checked"))
            {
                $(this).parents("tr").remove();
            }

        })
     });
});