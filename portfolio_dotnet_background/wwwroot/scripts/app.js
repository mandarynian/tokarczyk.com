$( document ).ready(function() {

  NavBarButtonScale();
  $( window ).resize(function() {
    AutoPaddingContent();
  });
});

// To scale navbar button icon.
var NavBarButtonScale = function() {
  $( "button.navbar-toggler" ).each(function() {
    var $thisParagraph = $( ".navbar-toggler" );
    $thisParagraph.click(function() {
      $thisParagraph.toggleClass( "navbar-toggler-icon-scalein" );
      var $menu = $("div.collapse-content");
      if ($($menu).hasClass("show")) {
        $($menu).removeClass("show").addClass("hide");
        setTimeout(function() {
          $($menu).removeClass("hide");
        }, 500);
      }
      else {
        $($menu).removeClass("hide").addClass("show");
      }
    });
  });
};

// Autoset padding of header container.
var AutoPaddingContent = function() {
  $("header.page-header").each(function() {
    var headerHeight = $(this).height() + 10;
    $("div.base").css('padding-top', headerHeight);
    $("div.portfolio").css('padding-top', headerHeight);
    $("div.contact-form-container").css('padding-top', headerHeight);
  });
};