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
      // .click(function () {
      //   var Clicked_Id = $(this).text();
        
      // });
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

    