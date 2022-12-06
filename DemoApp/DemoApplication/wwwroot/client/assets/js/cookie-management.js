
function add_cookie(name, value) {
    var cookie = [name, '=', JSON.stringify(value)].join('');
    document.cookie = cookie;
}

function read_cookie(name) {
    var result = document.cookie.match(new RegExp(name + '=([^;]+)'));
    result && (result = JSON.parse(result[1]));
    return result;
}

function is_cookie_exists(name) {
    return document.cookie.indexOf(`${name}=`) == 0;
}

function reset_cookie(name) {
    document.cookie = `${name}=[]`
}