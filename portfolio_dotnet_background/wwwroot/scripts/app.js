$( document ).ready( () => {

  NavBarButtonScale();
  $( window ).resize( () => {
    AutoPaddingContent();
  });
});

// To scale navbar button icon.
var NavBarButtonScale = () => {
  $( "button.navbar-toggler" ).each( () => {
    var $thisParagraph = $( ".navbar-toggler" );
    $thisParagraph.click( () => {
      $thisParagraph.toggleClass( "navbar-toggler-icon-scalein" );
      var $menu = $("div.collapse-content");
      if ($($menu).hasClass("show")) {
        $($menu).removeClass("show").addClass("hide");
        setTimeout( () => {
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
var AutoPaddingContent = () => {
  $("header.page-header").each( ($headerObj) => {
    var headerHeight = $($headerObj).height() + 10;
    $("div.base").css('padding-top', headerHeight);
    $("div.portfolio").css('padding-top', headerHeight);
    $("div.contact-form-container").css('padding-top', headerHeight);
  });
};