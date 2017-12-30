var form = $(".validationt-wizard").show();

$(".validationt-wizard").steps({
    headerTag: "h6"
    , bodyTag: "section"
    , transitionEffect: "fade"
    , titleTemplate: '<span class="step">#index#</span> #title#'
    , labels: {
        finish: "Submit"
    }
    , onStepChanging: function (event, currentIndex, newIndex) {

        return currentIndex > newIndex || !(3 === newIndex && Number($("#age-2").val()) < 18) && (currentIndex < newIndex && (form.find(".body:eq(" + newIndex + ") label.error").remove(), form.find(".body:eq(" + newIndex + ") .error").removeClass("error")), form.validate().settings.ignore = ":disabled,:hidden", form.valid())
    }
    , onFinishing: function (event, currentIndex) {
        return form.validate().settings.ignore = ":disabled", form.valid()
    }
    //, onFinished: function (event, currentIndex) {
    //    alert($('#tfirstname').val);
    //alert("event"+event);
    , onFinished: function (onclick, currentIndex) {
        //var value = $("#tfirstname").val();
        //alert(value);
        var address1 = $('#taddress1').val();
        var address2 = $('#taddress2').val();
        var city = $('#tcity').val();
        var state = $('#tstate').val();
        var country = $('#tcountry').val();
        var postcode = $('#tpostcode').val();
        var fname = $('#tfirstname').val();
        var lname = $('#tlastname').val();
        //var gender = $('#tgender').val();
        var gender = $('input:radio[name="Gender"]:checked').val();
        var bloodgroup = $('#TeacherBloodGroup').val();
        var dob = $('#mdate1').val();
        var joindate = $('#mdate2').val();
        var contactno = $('#tcontactno').val();
        var email = $('#temail').val();
        var experience = $('#texperience').val();
        var qualification = $('#tqualification').val();
        var expdescription = $('#texpdescription').val();
        //  window.location = "TeacherInsert?address1=" + address1 + "&address2" + address2 + "&city" + city + "&state" + state + "&postcode" + postcode + "&country" + country + "&experience" + experience + "&qualification" + qualification + "&expdescription" + expdescription;
        window.location = "TeacherInsert?lname=" + lname + "&fname=" + fname + "&gender=" + gender + "&bloodgroup=" + bloodgroup + "&dob=" + dob + "&joindate=" + joindate + "&contactno=" + contactno + "&email=" + email + "&address1=" + address1 + "&address2=" + address2 + "&city=" + city + "&state=" + state + "&postcode=" + postcode + "&country=" + country + "&experience=" + experience + "&qualification=" + qualification + "&expdescription=" + expdescription;

    }
}),


$(".validationt-wizard").validate({
    ignore: "input[type=hidden]"
    , errorClass: "text-danger"
    , successClass: "text-success"
    , highlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , unhighlight: function (element, errorClass) {
        $(element).removeClass(errorClass)
    }
    , errorPlacement: function (error, element) {
        error.insertAfter(element)
    }
    , rules: {
        email: {
            email: !0
        }
    }
});

