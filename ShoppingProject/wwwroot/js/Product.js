 var ipd = mbp = atv = vga = 0;
var Ttlatv = Ttlvga = 0;
$(".BtnAdd").click(function () {
    var x = $(this).closest("tr").find(".SKU").text();


    if (x.trim() == "ipd") {
        ipd++;
    }
    else if (x.trim() == "mbp") {
        mbp++;
    }
    else if (x.trim() == "atv") {
        atv++;
    }
    else if (x.trim() == "vga") {
        vga++;
    }
    if (atv % 3 == 0) {
        Ttlatv = 2 * (atv / 3);
    }
    else {
        Ttlatv = (Math.floor(atv / 3)) * 2 + atv % 3;
    }
    if (mbp > 0 && vga > 0) {
        if (mbp > vga) {
            Ttlvga = 0;
        }
        else {
            Ttlvga = vga - mbp;
        }
    }
    if (mbp == 0 && vga > 0) {
        Ttlvga = vga;
    }

    $("#ProdPur").val("Super iPad:" + ipd + " ,MacBook Pro:" + mbp + " ,Apple TV:" + atv + " ,VGA adapter:" + vga);
    $.ajax({
        type: "post",
        url: '/Home/CalculatePrice',
        data: { ipd: ipd, atv: Ttlatv, mbp: mbp, vga: Ttlvga },
        dataType: "text",
        success: function (html) {
            $("#TotalPrice").val("$ " + html);
        }
    });
});
$("#BtnReset").click(function () {
    ipd = mbp = atv = vga = 0;
    $("#TotalPrice").val("");
    $("#ProdPur").val("");
});