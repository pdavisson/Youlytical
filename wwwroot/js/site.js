// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Simple functions that controls the yes no checkboxes when one is checked.
function myPeformanceCheckbox(id){
    var myCheckbox = document.getElementsByName("PerformanceCheck");
    Array.prototype.forEach.call(myCheckbox,function(el){
      el.checked = false;
    });
    id.checked = true;
  }
  function myApprovedCheckbox(id){
    var myCheckbox = document.getElementsByName("SearchCheck");
    Array.prototype.forEach.call(myCheckbox,function(el){
      el.checked = false;
    });
    id.checked = true;
  }
  function myExpansionCheck(id){
    var myCheckbox = document.getElementsByName("ExpansionCheck");
    Array.prototype.forEach.call(myCheckbox,function(el){
      el.checked = false;
    });
    id.checked = true;
  }
  function IncludedCheck(id){
    var myCheckbox = document.getElementsByName("ShippingIncluded");
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