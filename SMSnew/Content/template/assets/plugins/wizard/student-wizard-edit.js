var form = $(".validationsedit-wizard").show();

$(".validationsedit-wizard").steps({
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
    , onFinished: function (onclick, currentIndex) {
        var id = $('#StudentID').val();
        var fname = $('#StudFirstName').val();
        var lname = $('#StudLastName').val();
        var gender = $('input:radio[name="Gender"]:checked').val();
        var bloodgroup = $('#StudBloodGroup').val();
        var dob = $('#StudDOB').val();
        var joindate = $('#StudJoinDate').val();
        var contactno = $('#StudContactNumber').val();
        var email = $('#StudEmail').val();
        var address1 = $('#StudAddress1').val();
        var address2 = $('#StudAddress2').val();
        var city = $('#StudCity').val();
        var state = $('#StudState').val();
        var country = $('#StudCountry').val();
        var postcode = $('#StudPINcode').val();
        var studclass = $('#StudClass').val();
        var studivision = $('#StudDivision').val();
        var studmodidescription = $('#StudModifiedDescription').val();
        //  window.location = "TeacherInsert?address1=" + address1 + "&address2" + address2 + "&city" + city + "&state" + state + "&postcode" + postcode + "&country" + country + "&experience" + experience + "&qualification" + qualification + "&expdescription" + expdescription;
        window.location = "/Student/StudentEdit?lname=" + lname + "&fname=" + fname + "&gender=" + gender + "&bloodgroup=" + bloodgroup + "&dob=" + dob + "&joindate=" + joindate + "&contactno=" + contactno + "&email=" + email + "&address1=" + address1 + "&address2=" + address2 + "&city=" + city + "&state=" + state + "&postcode=" + postcode + "&country=" + country + "&studclass=" + studclass + "&studivision=" + studivision + "&modidescription=" + studmodidescription + "&id=" + id;
    }
}),


$(".validationsedit-wizard").validate({
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
})