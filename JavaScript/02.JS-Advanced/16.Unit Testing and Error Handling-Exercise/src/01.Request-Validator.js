function validate(request) {
    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const uriRegex = /^([\w\d\.]+|\*)$/g;
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messageRegex = /^([^<>\\&'"]*)$/g;

    let method = request['method'];
    if (validateMethod(method) === false) {
        throw new Error('Invalid request header: Invalid Method');
    }

    let uri = request['uri'];
    if (validateUri(uri) === false) {
        throw new Error('Invalid request header: Invalid URI');
    }

    let version = request['version'];
    if (validateVersion(version) == false) {
        throw new Error('Invalid request header: Invalid Version');
    }

    let message = request['message'];
    if (validateMessage(message) === false) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return request;

    function validateMethod(method) {
        if (methods.includes(method)) {
            return true;
        }

        return false;
    }

    function validateUri(uri) {
        if (uri != undefined && uriRegex.test(uri)) {
            return true;
        }

        return false;
    }

    function validateVersion(version) {
        if (versions.includes(version)) {
            return true;
        }

        return false;
    }

    function validateMessage(message) {
        if (message != undefined && messageRegex.test(message)) {
            return true;
        }

        return false;
    }
}

console.log(validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));

console.log(validate({
    method: 'POST',
    uri: 'home.bash',
    version: 'HTTP/2.0'
}));

console.log(validate({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
}
));

console.log(validate({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
}
));