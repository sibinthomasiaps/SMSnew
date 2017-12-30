var form = $(".validationa-wizard").show();

$(".validationa-wizard").steps({
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

        var fname = $('#firstName').val();
        var Department = $('#Department').val();
        var JoiningDate = $('#JoiningDate').val();
        var Address = $('#Address').val();
        var Address1 = $('#Address1').val();
        var City = $('#City').val();
        var State = $('#State').val();
        var PINcode = $('#PINcode').val();
        var Country = $('#Country').val();
        var ContactNumber = $('#ContactNumber').val();
        var TotalExperience = $('#TotalExperience').val();
        var Qualification = $('#Qualification').val();
        var ExperienceInfo = $('#ExperienceInfo').val();
        // var val = $("#Gender:checked").val();
        var username = $('#username').val();
        var Mailid = $('#Mailid').val();
        var val = $('input:radio[name="Gender"]:checked').val();



        window.location = "adminprofile0?fname=" + fname + "&Department=" + Department + "&JoiningDate=" + JoiningDate + "&Department=" + Department + "&Address=" + Address + "&Address1=" + Address1 + "&City=" + City + "&State=" + State + "&PINcode=" + PINcode + "&Country=" + Country + "&ContactNumber=" + ContactNumber + "&TotalExperience=" + TotalExperience + "&Qualification=" + Qualification + "&Department=" + Department + "&ExperienceInfo=" + ExperienceInfo + "&PINcode=" + PINcode + "&Gender=" + val + "&username=" + username + "&Mailid=" + Mailid;
        //"&TeacherLastName=" + wlastName2;






        //var id = $('#StudentID').val();
        //var fname = $('#StudFirstName').val();
        //var lname = $('#StudLastName').val();
        //var gender = $('input:radio[name="Gender"]:checked').val();
        //var bloodgroup = $('#StudBloodGroup').val();
        //var dob = $('#StudDOB').val();
        //var joindate = $('#StudJoinDate').val();
        //var contactno = $('#StudContactNumber').val();
        //var email = $('#StudEmail').val();
        //var address1 = $('#StudAddress1').val();
        //var address2 = $('#StudAddress2').val();
        //var city = $('#StudCity').val();
        //var state = $('#StudState').val();
        //var country = $('#StudCountry').val();
        //var postcode = $('#StudPINcode').val();
        //var studclass = $('#StudClass').val();
        //var studivision = $('#StudDivision').val();
        //var studmodidescription = $('#StudModifiedDescription').val();
        ////  window.location = "TeacherInsert?address1=" + address1 + "&address2" + address2 + "&city" + city + "&state" + state + "&postcode" + postcode + "&country" + country + "&experience" + experience + "&qualification" + qualification + "&expdescription" + expdescription;
        //window.location = "/Student/StudentEdit?lname=" + lname + "&fname=" + fname + "&gender=" + gender + "&bloodgroup=" + bloodgroup + "&dob=" + dob + "&joindate=" + joindate + "&contactno=" + contactno + "&email=" + email + "&address1=" + address1 + "&address2=" + address2 + "&city=" + city + "&state=" + state + "&postcode=" + postcode + "&country=" + country + "&studclass=" + studclass + "&studivision=" + studivision + "&modidescription=" + studmodidescription + "&id=" + id;
    }
}),


$(".validationa-wizard").validate({
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