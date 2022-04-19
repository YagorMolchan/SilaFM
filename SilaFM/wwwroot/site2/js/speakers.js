// $(document).ready(sb.init);
$(function() {
  $(".order-element").on("click", function(e) {
      $(this).addClass("active-make-order").siblings().removeClass("active-make-order");
  });
})
$(".custom-selects").each(function() {
  var classes = $(this).attr("class"),
      id      = $(this).attr("id"),
      name    = $(this).attr("name");
  var template =  '<div class="' + classes + '">';
      template += '<span class="custom-select-trigger">' + $(this).attr("placeholder") + '</span>';
      template += '<div class="custom-options">';
      $(this).find("option").each(function() {
        template += '<span class="custom-option ' + $(this).attr("class") + '" data-value="' + $(this).attr("value") + '">' + $(this).html() + '</span>';
      });
  template += '</div></div>';
  
  $(this).wrap('<div class="custom-select-wrapper"></div>');
  $(this).hide();
  $(this).after(template);
});
$(".custom-option:first-of-type").hover(function() {
  $(this).parents(".custom-options").addClass("option-hover");
}, function() {
  $(this).parents(".custom-options").removeClass("option-hover");
});
$(".custom-select-trigger").on("click", function() {
  $('html').one('click',function() {
    $(".custom-selects").removeClass("opened");
  });
  $(this).parents(".custom-selects").toggleClass("opened");
  event.stopPropagation();
});
$(".custom-option").on("click", function() {
  $(this).parents(".custom-select-wrapper").find("select").val($(this).data("value"));
  $(this).parents(".custom-options").find(".custom-option").removeClass("selection");
  $(this).addClass("selection");
  $(this).parents(".custom-selects").removeClass("opened");
  $(this).parents(".custom-selects").find(".custom-select-trigger").text($(this).text());
});

//popup OnlineCalculator
var elementtss = $('.modal-overlay-calculator, .modal-calculator');

$('.modal-btn-calculator').click(function () {
  elementtss.addClass('active-calculator');
});

function openTab(tabname) {
  var i;
  var x = document.getElementsByClassName("product");
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";  
  }
  document.getElementById(tabname).style.display = "block";  
}
function myFunction() {
  var input, filter, table, tr, td, i, txtValue;
  input = document.getElementById("site-search");
  filter = input.value.toUpperCase();
  table = document.getElementById("audio-table");
  tr = table.getElementsByTagName("tr");
  for (i = 0; i < tr.length; i++) {
    td = tr[i].getElementsByTagName("td")[1];
    if (td) {
      txtValue = td.textContent || td.innerText;
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        tr[i].style.display = "";
      } else {
        tr[i].style.display = "none";
      }
    }       
  }
}


document.addEventListener('play', function(e){
  var audios = document.getElementsByTagName('audio');
  for(var i = 0, len = audios.length; i < len;i++){
      if(audios[i] != e.target){
          audios[i].pause();
      }
  }
}, true);
$('.close-modal-calculator').click(function () {
  elementtss.removeClass('active-calculator');
});
var elementtss = $('.modal-overlay-speakers, .modal-speakers');

$('.modal-btn-speakers').click(function () {
  elementtss.addClass('active-speakers');
});

$('.close-modal-speakers').click(function () {
  elementtss.removeClass('active-speakers');
});
//make an order
var elementtsm = $('.modal-overlay-order, .modal-order');

/*$('.modal-btn-order').click(function () {
  elementtsm.addClass('active-order');
});

$('.close-modal-order').click(function () {
  elementtsm.removeClass('active-order');
});*/


/*
$(document).ready( function () {
  $('#audio-table').DataTable();
} );*/
