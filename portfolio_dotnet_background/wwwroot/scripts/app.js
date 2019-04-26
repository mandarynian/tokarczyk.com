$( document ).ready( () => {
  Gallery();
  NavBarButtonScale();
  $( window ).resize( () => {
    AutoPaddingContent();
  });
  CheckForEscPress();
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

// Collection for Portfolio gallery method.
var Gallery = () => {
  $(".gallery-link").click( (e) => {
    e.preventDefault();
    var url = e.currentTarget.attributes.href.nodeValue;
    LoadImage($("section.gallery-preview"), url);
  });
};

var LoadImage = (e, u) => {
  $(e).empty().html($("<img>").attr("src", u));
  $(e).addClass("show");
};

var CheckForEscPress = () => {
  $(document).keyup( (e) => {
    if (e.keyCode === 27) 
      $("section.gallery-preview").removeClass("show");
  });
};

// <---