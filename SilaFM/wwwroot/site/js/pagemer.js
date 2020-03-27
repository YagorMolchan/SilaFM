var ForCalc_Koef = 120;
var ForCalc_Val1 = 450;
var ForCalc_Val2 = 350;
var ForCalc_Val3 = 200;
var ForCalc_Val4 = 420;
var ForCalc_Val5 = 330;
var ForCalc_Val6 = 195;
var ForCalc_Val7 = 350;
var ForCalc_Val8 = 265;
var ForCalc_Val9 = 170;



var divKoefActive = 0;
var hmrHistory = new Array();
var hmrHistoryIndex = 0;
var sFontName = "";
var sFontSize = "";

function setHistoryStep(step) {
    hmrHistoryIndex = step;
    if (hmrHistoryIndex >= 0) {
        document.getElementById('tText').value = hmrHistory[hmrHistoryIndex];
    }
    else {
        document.getElementById('tText').value = "";
    }
    CalculateText('2');
    var HmrBackObj = document.getElementById('hmrback');
    var HmrForwardObj = document.getElementById('hmrforward');
    HmrBackObj.onclick = function () { setHistoryStep(hmrHistoryIndex - 1); }
    HmrForwardObj.onclick = function () { setHistoryStep(hmrHistoryIndex + 1); }

    if (hmrHistoryIndex > 0) {
        HmrBackObj.disabled = false;
    }
    else {
        HmrBackObj.disabled = true;
    }
    if (hmrHistoryIndex < hmrHistory.length - 1) {
        HmrForwardObj.disabled = false;
    }
    else {
        HmrForwardObj.disabled = true;
    }
}

function isNumber(str) {
    var re = /^[0-9]*$/;
    if (!re.test(str))
        return false;
    else
        return true;
}

function strreplace(strObj, need) {
    var re = new RegExp(need, "g");
    //console.log(strObj + ' ' + need);
    var newstrObj = strObj.replace(re, " ");
    return newstrObj;
}

function strcount(strObj, need, count) {
    var index = 0;
    var indexstart = 0;
    while (index != -1) {
        index = strObj.indexOf(need, indexstart);
        if (index >= 0) { indexstart = index + 1; count++; }
    }
    return count;
}


function precalculate() {
    var txtObj = document.getElementById('tText').value;
    var re = new RegExp('\n', "g"); txtObj = txtObj.replace(re, " ");
    var re = new RegExp('\r', "g"); txtObj = txtObj.replace(re, " ");

    var tarray = txtObj.split(" ");
    var wrdsCount = 0;
    var index = 0;
    var indexstart = 0
    var ltrsCount = 0;

    wrdsCount = strcount(txtObj, "№", wrdsCount);
    txtObj = strreplace(txtObj, "№");
    wrdsCount = strcount(txtObj, "@", wrdsCount);
    txtObj = strreplace(txtObj, "@");
    wrdsCount = strcount(txtObj, "$", wrdsCount);
    txtObj = strreplace(txtObj, "$");
    wrdsCount = strcount(txtObj, "%", wrdsCount);
    txtObj = strreplace(txtObj, "%");
    wrdsCount = strcount(txtObj, "&", wrdsCount);
    txtObj = strreplace(txtObj, "&");
    wrdsCount = strcount(txtObj, "Є", wrdsCount);
    txtObj = strreplace(txtObj, "Є");
    wrdsCount = strcount(txtObj, " пр.", wrdsCount);
    txtObj = strreplace(txtObj, " пр\\.");
    wrdsCount = strcount(txtObj, " ул.", wrdsCount);
    txtObj = strreplace(txtObj, " ул\\.");
    wrdsCount = strcount(txtObj, " г.", wrdsCount);
    txtObj = strreplace(txtObj, " г\\.");
    wrdsCount = strcount(txtObj, " т.", wrdsCount);
    txtObj = strreplace(txtObj, " т\\.");
    wrdsCount = strcount(txtObj, " д.", wrdsCount);
    txtObj = strreplace(txtObj, " д\\.");
    wrdsCount = strcount(txtObj, " кв.", wrdsCount);
    txtObj = strreplace(txtObj, " кв\\.");
    wrdsCount = strcount(txtObj, " кг.", wrdsCount);
    txtObj = strreplace(txtObj, " кг\\.");
    wrdsCount = strcount(txtObj, " см.", wrdsCount);
    txtObj = strreplace(txtObj, " см\\.");
    wrdsCount = strcount(txtObj, " гр.", wrdsCount);
    txtObj = strreplace(txtObj, " гр\\.");

    for (el in tarray) {
        if (isNumber(tarray[el])) {
            wrdsCount += tarray[el].length;
            continue;
        }

        tmpStrArr = tarray[el].split("");
        for (tmpel in tmpStrArr) {
            if (isNumber(tmpStrArr[tmpel])) {
                wrdsCount += 1;
                continue;
            }
        }

        txtObj = strreplace(txtObj, '0');
        txtObj = strreplace(txtObj, '1');
        txtObj = strreplace(txtObj, '2');
        txtObj = strreplace(txtObj, '3');
        txtObj = strreplace(txtObj, '4');
        txtObj = strreplace(txtObj, '5');
        txtObj = strreplace(txtObj, '6');
        txtObj = strreplace(txtObj, '7');
        txtObj = strreplace(txtObj, '8');
        txtObj = strreplace(txtObj, '9');
    }


    var txarray = txtObj.split(" ");
    for (el in txarray) {
        var sElement = txarray[el].toString();
        index = sElement.indexOf('.', 0);
        if (index >= 1 && index < (sElement.length - 1)) {
            tmpStrArr2 = sElement.split('.');
            wrdsCount += tmpStrArr2.length;
            wrdsCount += tmpStrArr2.length - 1;
        }
        else {
            if (sElement.length > 2 && sElement.length <= 14) wrdsCount += 1;
            if (sElement.length > 14) wrdsCount += 2;
            if ((sElement.length < 3) && (sElement != "-") && (sElement != " ")
                && (sElement != ".") && (sElement != ",") && (sElement != "№")
                && (sElement != "@") && (sElement != "Є") && (sElement != "$")
                && (sElement != "%") && (sElement != "&") && (sElement != "")) {
                ltrsCount++;
            }
        }
    }

    if (ltrsCount > 0) wrdsCount += Math.ceil(ltrsCount / 4);
    wrdsCount = wrdsCount.toFixed(0);

    if (txtObj == '') wrdsCount = '0';
    return wrdsCount;
}


function ClearInput() {
    var WrdsCntObj = document.getElementById('wrdscnt');
    var WrdsActionObj = document.getElementById('wrdsaction');

    WrdsActionObj.innerHTML = '';
    WrdsCntObj.innerHTML = '';

    document.forms.frmStranicemer.iFunctionType[1].checked = true;

    document.forms.frmStranicemer.iKoefH.value = '0';
    document.forms.frmStranicemer.iKoefM.value = '0';
    document.forms.frmStranicemer.iKoefS.value = '0';

    document.forms.frmStranicemer.tText.value = '';
    document.forms.frmStranicemer.tText.focus();
    return (true);
}


function activeTimeField() {
    if (document.forms.frmStranicemer.iFunctionType[0].checked) {
        divKoefActive = 1;
        document.forms.frmStranicemer.iKoefH.disabled = false;
        document.forms.frmStranicemer.iKoefM.disabled = false;
        document.forms.frmStranicemer.iKoefS.disabled = false;
        document.forms.frmStranicemer.tText.disabled = true;
    } else {
        divKoefActive = 0;
        document.forms.frmStranicemer.iKoefH.disabled = true;
        document.forms.frmStranicemer.iKoefM.disabled = true;
        document.forms.frmStranicemer.iKoefS.disabled = true;
        document.forms.frmStranicemer.tText.disabled = false;
    }
}


function GetWordsEnd(iCount) {
    var sText = "";
    var iSubCount = 0;
    iSubCount = Math.abs((iCount - Math.floor(iCount)) * 10);
    if (((iSubCount % 10) == 1) | ((iSubCount % 10) == 2) | ((iSubCount % 10) == 3) | ((iSubCount % 10) == 4)) { sText = "страницы"; }
    else if (((iSubCount % 10) == 5) | ((iSubCount % 10) == 6) | ((iSubCount % 10) == 7) | ((iSubCount % 10) == 8) | ((iSubCount % 10) == 9)) { sText = "страниц"; }
    else {
        if ((iCount >= 5) & (iCount <= 20)) { sText = "страниц"; }
        else if ((iCount % 10) == 1) { sText = "страница"; }
        else if (((iCount % 10) == 2) | ((iCount % 10) == 3) | ((iCount % 10) == 4)) { sText = "страницы"; }
        else { sText = "страниц"; }
    }
    return sText;
}


function GetFormalWordsCountOnPage() {
    var iCount = 1;
    switch (document.forms.frmStranicemer.selFont.value) {
        case '1': sFontName = "Times New Roman"; switch (document.forms.frmStranicemer.selFontSize.value) {
            case '1': iCount = ForCalc_Val1; sFontSize = "12"; break;
            case '2': iCount = ForCalc_Val2; sFontSize = "14"; break;
            case '3': iCount = ForCalc_Val3; sFontSize = "18"; break;
        }break;
        case '2': sFontName = "Arial"; switch (document.forms.frmStranicemer.selFontSize.value) {
            case '1': iCount = ForCalc_Val4; sFontSize = "12"; break;
            case '2': iCount = ForCalc_Val5; sFontSize = "14"; break;
            case '3': iCount = ForCalc_Val6; sFontSize = "18"; break;
        }break;
        case '3': sFontName = "Courier New"; switch (document.forms.frmStranicemer.selFontSize.value) {
            case '1': iCount = ForCalc_Val7; sFontSize = "12"; break;
            case '2': iCount = ForCalc_Val8; sFontSize = "14"; break;
            case '3': iCount = ForCalc_Val9; sFontSize = "18"; break;
        }break;
    }
    return iCount;
}


function CalculateText(command) {
    var PagesCntObj = document.getElementById('pagescnt');
    var PagesFontObj = document.getElementById('pagesfont');
    var ResultCaptionObj = document.getElementById('pagescntlbl');

    var wrdsCount = 0;
    var pagesCount = 0;
    var iKoef = 1;
    var timeNeed = 0
    var iType = 0

    if (command == 1) {
        if ((hmrHistory[hmrHistoryIndex - 1] != document.getElementById('tText').value) && (document.getElementById('tText').value != "")) {
            hmrHistory[hmrHistoryIndex] = document.getElementById('tText').value;
            var HmrBackObj = document.getElementById('hmrback');
            HmrBackObj.onclick = function () { setHistoryStep(hmrHistoryIndex - 1); }
            if (hmrHistoryIndex > 0) {
                HmrBackObj.disables = false;
            }
            else {
                HmrBackObj.disables = true;
            }
            hmrHistoryIndex++;
        }
    }

    wrdsCount = precalculate();
    ResultCaptionObj.style.visibility = 'visible';

    if (document.forms.frmStranicemer.iFunctionType[0].checked) { iType = 2; } else { iType = 1; }


    if (iType == 2) {
        var iMinutes = 0;
        iMinutes = parseInt(document.forms.frmStranicemer.iKoefH.value * 60) + parseInt(document.forms.frmStranicemer.iKoefM.value) + (Math.ceil((parseInt(document.forms.frmStranicemer.iKoefS.value) / 60) * 100)) / 100;
        pagesCount = Math.ceil((iMinutes * ForCalc_Koef) / GetFormalWordsCountOnPage() * 10) / 10;
    }
    else {
        pagesCount = Math.ceil(wrdsCount / GetFormalWordsCountOnPage() * 10) / 10;
    }
    PagesCntObj.innerHTML = ' ' + pagesCount + ' ' + GetWordsEnd(pagesCount);
    PagesFontObj.innerHTML = ' (A4, шрифт ' + sFontName + ', ' + sFontSize + ' размер)';

    return true;
}