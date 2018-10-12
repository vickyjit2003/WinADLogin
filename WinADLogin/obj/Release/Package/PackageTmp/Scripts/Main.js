//Combo
function Downbtnclick(domid) {
    setTimeout(function () {
        $("#" + domid).find(".hidelist").removeClass("hidelist");
        $("#" + domid).parent().find(".c-text").focus();
        if ($("#" + domid).is(':visible') && $("#" + domid).height() > 10) {
            $("#" + domid).slideUp(30);
        }
        else {
            $(".divitems").hide();
            $("#" + domid).slideDown(30, function () {
                var scroldom = $("#" + domid).find(".selected").children()[0];
                var Comboid = "#" + domid;
                var txtfieldid = $("#" + domid).parent().find(".c-divtxtbox > .c-text ")
                ScrollToItems(scroldom, Comboid, txtfieldid)
            });
        }
    }, 30);
}
function listclick(e) {
    var FieldValue = $(e).find(".serchfield").text();
    $(e).parent().find(".selected").removeClass("selected");
    $(e).addClass("selected");
    $(e).parent().parent().find(".c-text").val(FieldValue);
    $(e).parent().parent().find(".c-text").attr("title", FieldValue);//for title
    $(e).parent().slideUp(30);
}

function ScrollToItems(dom, comboboxid, txtfeld) {
    if (dom != undefined) {
        $(comboboxid).scrollTop(0);
        var currentpos = $(comboboxid).offset().top;
        var childTop = $(dom).offset().top;
        $(dom).parent().addClass("selected");
        var Flxpixcel = 10;
        var moveto = childTop - currentpos - Flxpixcel;
        $(comboboxid).animate({ scrollTop: moveto }, 0);
        var textval = $(dom).find(".serchfield").text();
        txtfeld.val(textval);
        txtfeld.attr("title", textval)
    }
}
/*remove first selected and selecte if the data matches with list*/
function SetInitData(id, txtid, txtvalue) {
    $("#" + txtid).val(txtvalue);
    $("#" + txtid).attr("title", txtvalue);
    var value = txtvalue.toLowerCase();
    //$("#" + id + " .c-item").filter(function () {
    //    if ($(this).find(".serchfield").text().toLowerCase() == value) {
    //        $(this).addClass("selected");
    //    }
    //    else
    //        $(this).removeClass("selected");
    //});
    $("#" + id + " .c-item").removeClass("selected"); //remove all selected 
    $("#" + id + " .c-item").each(function () {
        if ($(this).find(".serchfield").text().toLowerCase() == value) {
            $(this).addClass("selected"); // select if the input matches with the list
            return false;
        }
        else
            $(this).removeClass("selected");
    });
}

function KeyDownOn(e) {
    if (e.keyCode === 13) {
        return false;
        e.preventdefault();
        e.stopPropagation();
    }
    var value = $(e.target).val().toLowerCase();
    var Divitemsid = "#" + $(e.target).parent().parent().find(".divitems").attr("id");
    var singledivdom;
    if (e.keyCode === 40) {

        singledivdom = $(Divitemsid).find('.selected').next().children()[0];

    }
    else if (e.keyCode === 38) {
        singledivdom = $(Divitemsid).find('.selected').prev().children()[0];
    }

    if (singledivdom !== undefined) {
        $(Divitemsid).find('.selected').removeClass("selected");
        ScrollToItems(singledivdom, Divitemsid, $(e.target))
    }
}

function InputOn(e) {
    var value = $(e.target).val().toLowerCase();
    var Divitemsid = "#" + $(e.target).parent().parent().find(".divitems").attr("id");
    $(Divitemsid + " .c-item").removeClass("selected");
    $(Divitemsid + " .c-item").filter(function () {
        if ($(this).find(".serchfield").text().toLowerCase().indexOf(value) > -1)
            $(this).removeClass("hidelist").addClass('show');
        else
            $(this).addClass("hidelist").removeClass('show');
    });
    $(e.target).attr("title", value);
    if ($(Divitemsid + " .c-item.show ").length > 0) {
        $(Divitemsid).slideDown(30);//ethu
    }
    else {
        $(Divitemsid).hide();
    }
}

function BindEvent(inp) {
    inp.removeEventListener("keydown", KeyDownOn);
    inp.removeEventListener("input", InputOn);
    inp.addEventListener("keydown", KeyDownOn);
    inp.addEventListener("input", InputOn);
}


BindBtnEvent = function (btndom, divlistid) {
    //    btndom[0].removeEventListener("click", BtnClick(divlistid));
    btndom[0].addEventListener("click", function () {
        Downbtnclick(divlistid);
    });
}

function BindEventByID(comboid, listitmeid, txtid, txtinitval) {

    var i = 200;
    function CheckDomReady(comboid, listitmeid, txtid, txtinitval) {
        if ($("#" + comboid).length > 0) {
            clearInterval(interval);
            SetInitData(listitmeid, txtid, txtinitval); //to set the initial text to the combo box
            BindEvent($("#" + comboid + " > .c-divtxtbox > .c-text")[0]);
            BindBtnEvent($("#" + comboid + " > .c-divtxtbox > .c-btn"), listitmeid);
        }
        console.log("CheckDomReady: " + (i + 200));
    }
    var interval = setInterval(CheckDomReady, 200, comboid, listitmeid, txtid, txtinitval);
}
function InitBindEvent(comboid, listitmeid, txtid, txtinitval) {
    SetInitData(listitmeid, txtid, txtinitval);
    BindEvent($("#" + comboid + " > .c-divtxtbox > .c-text")[0]);
    BindBtnEvent($("#" + comboid + " > .c-divtxtbox > .c-btn"), listitmeid);
}
/*From C# method*/
function BindEventByIDTest(pageName, CsharParam, Scrollto) {
    var data = JSON.parse(CsharParam);
    var firstobj = data[0];
    function CheckDom(divid) {
        if ($("#" + divid).length > 0) {
            clearInterval(Inter);
            RenderComboBox(data);
            if (Scrollto > 0) {
                $("#divparentscroll").scrollTop(Scrollto);
                console.log("Scroll to the " + Scrollto);
            }
            if (pageName.toLowerCase() == "addcdr") { //&& DisableDt != 'undefined'
                BootControls();
            }
        }
        else {
            console.log("Interval running....");
        }
    }
    var Inter = setInterval(CheckDom, 100, firstobj["divComboid"]);
}
function RenderComboBox(data) {
    data.map(function (value, index) {
        InitBindEvent(value["divComboid"], value["combotxtid"], value["divcomboItemsid"], value["defaultvalue"]);
    })
}

function BootControls() {
    var CDRtoday = new Date();
    console.log("The Date is :" + CDRtoday);
    var startdate = moment().subtract(1, "days");
    $("#dtEntered").datetimepicker({
        // minDate: startdate,
        format: "MM/DD/YYYY",
        //defaultDate: CDRtoday
        // defaultDate: new Date("01/11/2017")
        // ignoreReadonly: true
    });
    // $('#dtEntered').data("DateTimePicker").disable();
    $("#dtMeetingDate").datetimepicker({
        format: "MM/DD/YYYY",
        //defaultDate: CDRtoday
        //ignoreReadonly: true
    });
    var DateTimeFormate = moment().format("lll");//("LT","LTS ,lll")
    $("#dtTime").datetimepicker({
        format: "LT", //"HH:mm:ss"
        //  defaultDate: DateTimeFormate
        //  disabledHours: [0, 1, 2, 3, 4, 5, 6, 7, 8, 18, 19, 20, 21, 22, 23, 24]
        // ignoreReadonly: true
    });

}



