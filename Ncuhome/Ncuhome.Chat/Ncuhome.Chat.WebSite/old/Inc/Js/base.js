// Initializes a new instance of the StringBuilder class
// and appends the given value if supplied
function StringBuilder(value) {
    this.strings = new Array("");
    this.append(value);
}

// Appends the given value to the end of this instance.

StringBuilder.prototype.append = function(value) {
    if (value) {
        this.strings.push(value);
    }
}

// Clears the string buffer

StringBuilder.prototype.clear = function() {
    this.strings.length = 1;
}

// Converts this instance to a String.

StringBuilder.prototype.toString = function() {
    return this.strings.join("");
}
function replaceHtml(el, html) {
    var oldEl = typeof el === "string" ? document.getElementById(el) : el;
    /*@cc_on // Pure innerHTML is slightly faster in IE
    oldEl.innerHTML = html;
    return oldEl;
    @*/
    var newEl = oldEl.cloneNode(false);
    newEl.innerHTML = html;
    oldEl.parentNode.replaceChild(newEl, oldEl);
    /* Since we just removed the old element from the DOM, return a reference
    to the new element, which can be used to restore variable references. */
    return newEl;
};
