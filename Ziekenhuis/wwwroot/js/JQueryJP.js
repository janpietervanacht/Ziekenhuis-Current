
// JQUERY uitgetest op view invoice --> Index.cshtml ------------------------

// Onderstaande geeft alle <p> een paarse border in alle schermen
//  $("p").css("outline", "4px solid purple");    // werkt voor alle paragrafen in alle schermen 

// Hieronder: zie index view van Invoice
$("h4 #bruinViaJQuery").css("color", "brown").css("font-style", "bold");  // werkt, via CHILD element!!
$("h6 .paarsViaJQuery").css("color", "purple").css("font-style", "italic");  // werkt, moet via child in html



$(".blauwViaJquery").css("color", "blue"); // werkt
$("#uniekRoodViaJQuery").css("color", "red") // werkt
    .css("outline", "1px dashed purple"); // werkt
// $("[name]").css("border", "2px dashed black"); // Werkt, overal waar attribute "name" wordt gebruikt
// Dit raakt veel andere schermen, dus code weg-gestreept
$("[name='naam1']").css("padding", "10px"); // Werkt, overal waar attribute name = "naam1" wordt gebruikt

$("[name='naam2']")
    .css("font-style", "italic")
    .css("color", 'red')
    .css("padding", "20px")
    .css("border-radius", '20px');  // Werkt, overal waar name = 'naam2' wordt gebruikt




// Hieronder: JQUERY uitgetest op view clientJavaScript --> Index.cshtml ------------------------

$(document).ready(function () {
    $('.muisHoofer').hover
        (    // hover combineert mouseenter en mouseleave
            function ()    // mouseenter
            {
                $(this).css("border", "dashed 2px red");
            },
            function ()    // mouseleave
            {
                $(this).css("border", "none");
            }
    );
    $('#muisHoeffer').hover
        (    // hover combineert mouseenter en mouseleave
            function ()    // mouseenter
            {
                $(this).css("font-style", "italic");
            },
            function ()    // mouseleave
            {
                $(this).css("font-style", "normal"); 
            }
        );



})


