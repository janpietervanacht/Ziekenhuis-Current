// Eigen javascript
// NIET labels <script> en </script> eromheen zetten, dat gaat fout!!

// Window.Unload NIET hier zetten, maar in de betrokken view zetten. 


//------------------------------------------------- 

function berekenTotaal(className)
{
    // Tel alle bedragen van elementen op met dezelfde class-name 
    // Retourneer het totaal als een opgemaakte string
    var totalAmt = 0.00;
    var amtList = document.getElementsByClassName(className);
    for (var i = 0; i < amtList.length; i++)
    {
        // parsefloat werkt met punten, niet met komma's:
        amtList[i].innerText = amtList[i].innerText.replace(',', '.');
        totalAmt += parseFloat(amtList[i].innerText);
    }

    var totalAmtAlfa = totalAmt
        .toString()
        .replace('.', ',');

    // Als het bedrag bijv "200" is, maak er "200,00" van. 
    if (totalAmtAlfa.indexOf(',') == -1)  // geen komma gevonden
    {
        totalAmtAlfa += ",00";
    }

    // Knikker alle overbodige decimalen weg, bewaar er slechts 2
    var index = totalAmtAlfa.indexOf(',');
    totalAmtAlfa = totalAmtAlfa.substring(0, index + 3);   // 0 doet mee, index + 3 doet niet mee

    return totalAmtAlfa; 
};

