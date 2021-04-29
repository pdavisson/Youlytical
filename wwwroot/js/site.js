// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Simple functions that controls the yes no checkboxes when one is checked.
// function myPeformanceCheckbox(id){
//     var myCheckbox = document.getElementsByName("PerformanceCheck");
//     Array.prototype.forEach.call(myCheckbox,function(el){
//       el.checked = false;
//     });
//     id.checked = true;
//   }
//   function myApprovedCheckbox(id){
//     var myCheckbox = document.getElementsByName("SearchCheck");
//     Array.prototype.forEach.call(myCheckbox,function(el){
//       el.checked = false;
//     });
//     id.checked = true;
//   }
//   function myExpansionCheck(id){
//     var myCheckbox = document.getElementsByName("ExpansionCheck");
//     Array.prototype.forEach.call(myCheckbox,function(el){
//       el.checked = false;
//     });
//     id.checked = true;
//   }
  function RoleFunction(id){
    var myCheckbox = document.getElementsByName("RoleCheckBox");
    Array.prototype.forEach.call(myCheckbox,function(el){
      el.checked = false;
    });
    id.checked = true;
}
  $('#checkmark-svg').on('click', function(){
    svg = $(this);
    svg.removeClass('run-animation').width();
    svg.addClass('run-animation');
    return false;
  })
  
  $(function(){
    $("#AllUsersTable")
      .dataTable();
      .click(function () {
        var Clicked_Id = $(this).text();
        
      });
    $("#AdminTable").dataTable();
    $("#MembersTable").dataTable();
  })   
$(document).ready(function () {
  $('.SelectedUser').on('click', function () {
    // var GUID = $(this).children("td:eq(0)").text();
    document.getElementById("jsGUID").value=$(this).children("td:eq(0)").text();
    document.getElementById("jsFirstName").value=$(this).children("td:eq(2)").text();
    document.getElementById("jsLastName").value=$(this).children("td:eq(3)").text();
    document.getElementById("jsEmail").value=$(this).children("td:eq(4)").text();
    document.getElementById("jsFranchise").value=$(this).children("td:eq(5)").text();
    var role=$(this).children("td:eq(6)").text();
    if (role=="Member"){document.getElementById("jsRoleMember").checked=true;}else{document.getElementById("jsRoleMember").checked=false;}
    if (role=="Admin"){document.getElementById("jsRoleAdmin").checked=true;}else{document.getElementById("jsRoleAdmin").checked=false;}
    if (role=="Manager"){document.getElementById("jsRoleManager").checked=true;}else{document.getElementById("jsRoleManager").checked=false;}
  })
})
$('.add').on('click', add);
function add() {
    var new_Email_No = parseInt($('#total_email').val()) + 1;
    var new_Email = "<div id='Email_" + new_Email_No + "' class='form-group row'><div class='form-group col-sm-1 text-center'><label class='text-center'>Primary</label><label class='custom-control custom-checkbox text-center'> <input type='checkbox' asp-for='EmailData.Primary' name='chbxTerms' id='Email_" + new_Email_No + "' class='custom-control-input text-center'> <span class='custom-control-label text-center' asp-for='EmailData.Primary'></span> </label></div><div class='form-group col-sm-3'> <Select class='form-control form-control-dropdown custom-form-Element' asp-for='EmailData.EmailType style='height:50px' id='Email_" + new_Email_No + "'><option value='' >Email Type</option><option value='Personal'>Personal</option><option value='Business'>Business</option> </Select></div><div class='form-group col-sm-6'> <input asp-for='EmailData.Email' id='Email_" + new_Email_No + "' class='form-control form-control-user custom-form-Element' placeholder='Email Address' /></div><div class='form-group col-sm-1'><button class='btn btn-register custom-form-Element' id='Email_" + new_Email_No + "' onClick='removeItem(this.id)'><i class='fas fa-trash-alt fa-lg'></i></button></div></div>";
    $('#new_Email').append(new_Email);
    $('#total_email').val(new_Email_No);
    return false;
}
function removeItem(clicked_id) {
    document.getElementById(clicked_id).remove();
}

    