//Программный код написал Тодераш Сергей /  The code is written by Toderash Sergey (www.ufairock.ru)

$(document).ready(function () {
    Start();
    calc_min();

});

var unit = ' сек.';
var text_data = new Array();
var nextprev_text = 1;
var data_string = '';

function strip_tags(str, allowed_tags) {
    var key = '', allowed = false;
    var matches = [];
    var allowed_array = [];
    var allowed_tag = '';
    var i = 0;
    var k = '';
    var html = '';

    var replacer = function (search, replace, str) {
        return str.split(search).join(replace);
    };

    // Build allowes tags associative array
    if (allowed_tags) {
        allowed_array = allowed_tags.match(/([a-zA-Z0-9]+)/gi);
    }

    str += '';

    // Match tags
    matches = str.match(/(<\/?[\S][^>]*>)/gi);

    // Go through all HTML tags
    for (key in matches) {
        if (isNaN(key)) {
            // IE7 Hack
            continue;
        }

        // Save HTML tag
        html = matches[key].toString();

        // Is tag not in allowed list? Remove from str!
        allowed = false;

        // Go through all allowed tags
        for (k in allowed_array) {
            // Init
            allowed_tag = allowed_array[k];
            i = -1;

            if (i != 0) { i = html.toLowerCase().indexOf('<' + allowed_tag + '>'); }
            if (i != 0) { i = html.toLowerCase().indexOf('<' + allowed_tag + ' '); }
            if (i != 0) { i = html.toLowerCase().indexOf('</' + allowed_tag); }

            // Determine
            if (i == 0) {
                allowed = true;
                break;
            }
        }

        if (!allowed) {
            str = replacer(html, "", str); // Custom replace. No regexing
        }
    }

    return str;
}


function calc() {
    //str = document.getElementById('edit').contentWindow.document.body.innerHTML;

    //alert($('#hidenFild').val());
    //var data_str = strip_tags (str, '<br>')
    calc_proces(strip_tags($('#edit').val()));

}

function max_value(value, id) {
    //alert(document.getElementById(id).value);
    if (document.getElementById(id).value > 60) {
        alert('Заначение не должно превышать ' + value);
        document.getElementById(id).value = value;
    }
}

function calc_sec() {
    var value = '';
    if (isNaN(parseInt(document.getElementById('menu_time_min').value))) { value = parseInt(document.getElementById('menu_time_sec').value); }
    else if (isNaN(parseInt(document.getElementById('menu_time_sec').value))) { value = parseInt(document.getElementById('menu_time_min').value * 60); }
    else { value = parseInt(document.getElementById('menu_time_sec').value) + parseInt(document.getElementById('menu_time_min').value * 60); }
    if (!isNaN(value)) { document.getElementById('time_limit').value = value; }

}

function calc_min() {
    if (document.getElementById('time_limit').disabled) { document.getElementById('wanted_time').checked = false; }
    else { document.getElementById('wanted_time').checked = true; }

    if (document.getElementById('wanted_time').checked) {
        document.getElementById('menu_time_min').disabled = false;
        document.getElementById('menu_time_sec').disabled = false;
        var min_val = Math.floor(document.getElementById('time_limit').value / 60);
        var sec_val = parseInt(document.getElementById('time_limit').value) - parseInt(min_val * 60);
        if (!isNaN(min_val)) { document.getElementById('menu_time_min').value = min_val; }
        else { document.getElementById('menu_time_min').value = 0; }
        if (!isNaN(sec_val)) { document.getElementById('menu_time_sec').value = sec_val; }
        else { document.getElementById('menu_time_sec').value = 0; }
    }
    else {
        document.getElementById('menu_time_min').value = '';
        document.getElementById('menu_time_sec').value = '';
        document.getElementById('menu_time_min').disabled = true;
        document.getElementById('menu_time_sec').disabled = true;
    }
}

function disable_time() {
    if (!document.getElementById('wanted_time').checked) {
        document.getElementById('menu_time_min').value = '';
        document.getElementById('menu_time_sec').value = '';
        document.getElementById('menu_time_min').disabled = true;
        document.getElementById('menu_time_sec').disabled = true;
        document.getElementById('time_limit').value = '';
    }
    else {
        document.getElementById('menu_time_min').disabled = false;
        document.getElementById('menu_time_sec').disabled = false;
    }
}


function calcDigit(number) {
    //alert(duration);
    //alert(number);
    number = number.split('');
    var i = 0;
    var count = 0;
    var z = 0;
    var zero = 0;
    var duration = number.length / 2;
    var subst = new Array();
    z = number.length - (Math.floor(number.length / 3) * 3);
    for (s = 0; s <= Math.ceil(number.length / 3); s++) {
        subst[s] = '';
    }
    for (ele = 0; ele < number.length; ele++) {
        if (i == z) { count++; i = 0; z = 3; }
        if (number[ele] == '0') { duration -= 0.5; }
        subst[count] += number[ele].split('');
        i++;
    }
    subst[count] = subst[count].split('');
    if (number.length <= 3) { subst.splice(1, 1); }
    for (con = 0; con < subst.length; con++) {

        var zero_point = 0;
        for (cons = 0; cons <= subst[con].length; cons++) {
            if (subst[con][cons] == '0') { zero_point++ }
        }

        if (zero_point == 3) { zero++; }
        if (subst[con].length == 3 && subst.length > 1) { duration += 0.5; }
        if (subst[con].length == 3 && subst[con][1] == '1') { duration -= 0.5; }
        if (subst[con].length == 2 && subst[con][0] == '1') { duration -= 0.5; }
    }
    if (zero > 1) { duration -= 0.5 * (zero - 1); }


    return duration;
}
/* Функция подсчета хроно для чисел */
function countDigit(pf) {
    pf = pf.split('');
    var duration = 0;
    var i = 0;
    var tere = 0;
    string = new Array();
    string[0] = '';

    for (ip = 0; ip < pf.length; ip++) {

        if (pf[ip] == '-') { duration += calcDigit(string[0]); duration -= 0.5; string[0] = ''; }

        else {
            if (pf[ip] == ',' || pf[ip] == '.') { i++; string[1] = ''; }
            else if (pf[ip] == '%') { duration += 0.5; }
            else { string[i] += pf[ip]; }
        }

    }

    if (!isNaN(string[1])) {

        duration += calcDigit(string[0]) + calcDigit(string[1]) + 1;

    }
    else {
        duration += calcDigit(string[0]);

    }

    return duration;

    //	if (pf%10 == 0 && pf <= 1000) duration += 0.5;
    //	else if (pf <= 20) duration += 0.5;
    //	else if (pf%10 != 0 && pf > 20 && pf < 121) duration = 1;
    //    else duration += pf.length/2;

    // return duration.toFixed(0);
}
/* End */

function isNumber(val) {
    return /^-?((\d+\.?\d?)|(\.\d+))$/.test(val);
}


function calc_proces(string) {
    updateStats();
    disable_time();

    var text1 = string;
    var total = document.getElementById('total');
    var total2 = document.getElementById('total2');
    var line = document.getElementById('line');
    var line_red = document.getElementById('line_red');
    var tl = document.getElementById('time_limit');
    var spare = document.getElementById('spare');
    var free = document.getElementById('free');
    var tempo = 1;
    var exceeded = 0;
    //if (text1 != '') document.getElementById('div_temp').style.display = 'block';
    //var tempo_r = document.myform.tempo;

    //tempo = getCheckedValue(tempo_r);
    //if (tempo == 0) tempo = 1;

    //tl.disabled = 'false';



    var pattern = /\&nbsp;/gi;
    var pattern2 = /<br>|\n/gi;
    var pattern3 = / <br> <br> /gi;

    text1 = text1.replace(pattern, ' ');
    text1 = text1.replace(pattern2, ' <br> ');
    text1 = text1.replace(pattern3, ' <br> ');
    text1 = text1.replace('<font color="red">', '');
    text1 = text1.replace('<FONT color=red>', '');
    text1 = text1.replace('</font>', '');
    text1 = text1.replace('</FONT>', '');
    text1 = text1.replace('(', '');
    text1 = text1.replace(')', '');

    //alert (text1);

    var array = text1.split(' ');
    var duration = 0;
    var index;
    var prep = 0;
    var rec_duration = 0;
    var all_els = '';
    var pf;
    var exc = 0;
    var spare_words = 0


    for (el = 0; el < array.length; el++) {

        if (array[el] == '<br>') {
            if (all_els == '') all_els += array[el];
            else all_els += ' ' + array[el];
            continue;
        }

        if (array[el].indexOf("$") != -1 || array[el].indexOf("&") != -1 || array[el] == '%' || array[el].indexOf("№") != -1) { duration += 0.5; }
        if (array[el].indexOf("...") != -1 && array[el].length > 3) duration += 1;
        if (array[el].indexOf("...") != -1 && array[el].length == 3) duration += 0.5;
        //if (array[el].indexOf("...") != -1 && array[el].length == 3) duration += 5;

        if (all_els == '') all_els += array[el];
        else all_els += ' ' + array[el];


        array[el] = array[el].replace(/\ /g, '');
        var pf = array[el].split('');

        var phone = true;
        for (c = 0; c < array[el].length; c++) {
            if (array[el].lastIndexOf('-') != -1) {
                if (isNumber(pf[c])) { duration += 0.5; phone = false; }

            }
            else { phone = true; }
            if (pf[c] == '-' && pf.length > 2 && c != 0 && phone == true) { duration += 0.5; }
            if (pf[c] == ' ' && pf.length > 2) { subst.splice(c, 1); }
        }



        if (isNumber(array[el])) {
            duration += countDigit(array[el].toString());
            //alert("number");
        }
        else if (array[el].length > 2 && array[el].length <= 14 && phone == true) { duration += 0.5; }
        else if (array[el].length > 14 && phone == true) duration += 1;

        else if (array[el].length == 2 && phone == true) prep += 2;
        //if (array[el].length == 1 && array[el] != '-') prep++;
        else if (prep > 5 && phone == true) {
            duration += 0.5;
            prep = 0;
        }

    }
    if ((duration * tempo) > tl.value && tl.value > 0) {
        // all_els += '<font color="red"> ';
        //alert(duration.toFixed(0));
        //alert(tl.value);
        spare_words = (duration - tl.value) * 2;
        exceeded = 1;
    }

    //console.log(duration*2);



    //alert(spare_words);


    //duration *= parseFloat(tempo);
    document.getElementById('count_words').value = duration * 2;
    duration = duration.toFixed(0);


    if (duration < 0) duration = 0;
    if (text1 == '') duration = '0';


    //total.value = duration+unit;
    //alert (all_els); alert(document.getElementById('edit').contentWindow.document.body.innerHTML);
    duration2 = Math.round((parseFloat(duration) / 10) + parseFloat(duration));
    //if (document.getElementById('edit').contentWindow.document.body.innerHTML != all_els)


    text_data[text_data.length] = all_els;

    //document.getElementById('edit').contentWindow.document.body.innerHTML = all_els;
    var frame = document.getElementById('edit');
    //frame.focus();
    //total2.value = duration2+unit;
    tot1 = (Math.round((parseFloat(duration) - parseFloat(duration) / 10)));
    tot2 = (parseFloat(duration) + 1);
    total.value = Math.round(tot1 + (tot1 * 0.10)) + unit;
    total2.value = Math.round(tot2 + (tot1 * 0.10)) + unit;



    if (tl.value && tl.value != 0) {
        //document.getElementById('line_div').style.display = 'block';
        document.getElementById('user_time').style.display = 'block';
        document.getElementById('min_hro').style.display = 'none';
        document.getElementById('total').style.display = 'none';
        document.getElementById('comf').innerHTML = 'Хронометраж:';
        var time_limit = tl.value;
        if (parseInt(duration) > parseInt(time_limit)) {
            document.getElementById('hrono_normal').style.color = 'red';
            document.getElementById('hrono_normal').innerHTML = 'Хронометраж превышен';
        }
        if (parseInt(duration) == parseInt(time_limit)) {
            document.getElementById('hrono_normal').style.color = 'green';
            document.getElementById('hrono_normal').innerHTML = 'Хронометраж оптимален';
        }
        if (parseInt(duration) < parseInt(time_limit)) {
            document.getElementById('hrono_normal').style.color = 'red';
            document.getElementById('hrono_normal').innerHTML = 'Хронометраж занижен';
        }

        document.getElementById('user_time').innerHTML = +time_limit + ' сек.';

        //if (duration == time_limit) {
        //    document.getElementById('line_activ').style.width = '512px';
        //    document.getElementById('line_pasiv').style.width = '183px';
        //}
        //else {
        //    if (695 > Math.floor((512 / time_limit) * duration)) {
        //        document.getElementById('line_activ').style.width = Math.floor((512 / time_limit) * duration) + 'px';
        //        document.getElementById('line_pasiv').style.width = 695 - Math.floor((512 / time_limit) * duration) + 'px';
        //    }

        //    else {
        //        document.getElementById('line_pasiv').style.width = '0px';
        //        document.getElementById('line_activ').style.width = '695px'
        //    }

        //}

    }
    else {
        //document.getElementById('line_div').style.display = 'none';
        document.getElementById('hrono_normal').style.color = 'green';
        document.getElementById('hrono_normal').innerHTML = ' ';
        document.getElementById('min_hro').style.display = 'block';
        document.getElementById('comf').style.display = 'block';
        document.getElementById('comf').innerHTML = 'Оптимальный хронометраж:';
        document.getElementById('total').style.display = 'inline';
        document.getElementById('user_time').style.display = 'none';
        document.getElementById('free_words_div').style.display = 'none';
        document.getElementById('sp_words_div').style.display = 'none';

    }





    if (spare_words > 0) {
        var word = ' лишних слов';
        if (spare_words == 1 || spare_words == 21) word = ' лишнее слово';
        if (spare_words > 1 && spare_words < 5) word = ' лишних слова';
        spare.innerHTML = spare_words + word;
        if (spare_words > 0) {
            document.getElementById('sp_words_div').style.display = 'block';
            document.getElementById('free_words_div').style.display = 'none';
        }
        else document.getElementById('sp_words_div').style.display = 'none';

    }


    else {
        var free_words = (parseFloat(time_limit) - parseFloat(duration)) * 2;
        var word = ' слов';
        if (free_words == 1 || free_words == 21) word = ' слово';
        if (free_words > 1 && free_words < 5) word = ' слова';

        free.innerHTML = free_words + word;
        if (free_words > 0) {
            document.getElementById('free_words_div').style.display = 'block';
            document.getElementById('sp_words_div').style.display = 'none';
        }
        else {
            document.getElementById('free_words_div').style.display = 'none';
            document.getElementById('sp_words_div').style.display = 'none';
        }

    }
}




var iF;

function Start() {
    //iF=document.getElementById('edit').contentWindow.document;
    //iF.designMode = "on";
}
/*  
function preview() {
	if(text_data.length > nextprev_text) nextprev_text++;
	document.getElementById('edit').contentWindow.document.body.innerHTML = text_data[text_data.length - Math.abs(nextprev_text)];
	}
	
function next() {
	if(nextprev_text > 1)nextprev_text--;
	document.getElementById('edit').contentWindow.document.body.innerHTML = text_data[text_data.length - Math.abs(nextprev_text)];
	}	  
*/

function preview() {
    if (text_data.length > nextprev_text) nextprev_text++;
    $('#edit').val(text_data[text_data.length - Math.abs(nextprev_text)]);
}

function next() {
    if (nextprev_text > 1) nextprev_text--;
    $('#edit').val(text_data[text_data.length - Math.abs(nextprev_text)]);
}

function updateStats() {

    //$.getJSON('hr_statistic.php?'+Math.random()+'"', function (data) {								
    //	document.getElementById('today').innerHTML = data.today;
    //	document.getElementById('alltime').innerHTML = data.alltime;
    //});
}