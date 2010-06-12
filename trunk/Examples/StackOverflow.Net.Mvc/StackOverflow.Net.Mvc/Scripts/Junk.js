if (top != self) {
    top.location.replace(document.location);
    alert("For security reasons, framing is not allowed; click OK to remove the frames.")
}
$(function () {
    $.ajaxSetup({
        cache: false
    })
});
$.fn.extend({
    fadeOutAndRemove: function (a) {
        return this.each(function () {
            var c = $(this);
            c.fadeOut("fast", function () {
                c.remove()
            })
        })
    },
    charCounter: function (a) {
        return this.each(function () {
            $(this).bind("blur focus keyup", function () {
                var f = a.min;
                var d = a.max;
                var g = a.setIsValid ||
                function () { };
                var h = this.value ? this.value.length : 0;
                var e = h > d * 0.8 ? "supernova" : h > d * 0.6 ? "hot" : h > d * 0.4 ? "warm" : "cool";
                var c = "";
                if (h == 0) {
                    c = "enter at least " + f + " characters";
                    g(false)
                } else {
                    if (h < f) {
                        c = (f - h) + " more to go..";
                        g(false)
                    } else {
                        c = (d - h) + " character" + (d - h != 1 ? "s" : "") + " left";
                        g(h <= d)
                    }
                }
                $(this).parents("form").find("span.text-counter").text(c).removeClass().addClass("text-counter").addClass(e)
            })
        })
    }
});

function moveScroller() {
    var a = function () {
        var c = $(window).scrollTop();
        var e = $("#scroller-anchor").offset({
            scroll: false
        }).top;
        var d = $("#scroller");
        if (c > e) {
            d.css({
                position: "fixed",
                top: "0px"
            })
        } else {
            if (c <= e) {
                d.css({
                    position: "relative",
                    top: ""
                })
            }
        }
    };
    $(window).scroll(a);
    a()
}
function enableSubmitButton(a) {
    setSubmitButtonDisabled(a, false)
}
function disableSubmitButton(a) {
    setSubmitButtonDisabled(a, true)
}
function setSubmitButtonDisabled(c, a) {
    $(c).find("input[type='submit']").attr("disabled", a ? "disabled" : "")
}
function setConfirmUnload(a, c) {
    window.onbeforeunload = a ?
    function () {
        if (c && $.trim(c.val())) {
            return a
        }
    } : null
}
function showAjaxError(a, d) {
    var e = $('<div class="error-notification supernovabg"><h2>' + d + "</h2>(click on this box to dismiss)</div>");
    var c = function () {
        $(".error-notification").fadeOut("fast", function () {
            $(this).remove()
        })
    };
    e.click(function (f) {
        c()
    });
    $(a).append(e);
    e.fadeIn("fast");
    setTimeout(c, 1000 * 30)
}
function styleCode() {
    if (typeof disableStyleCode != "undefined") {
        return
    }
    var a = false;
    $("pre code").parent().each(function () {
        if (!$(this).hasClass("prettyprint")) {
            $(this).addClass("prettyprint");
            a = true
        }
    });
    if (a) {
        prettyPrint()
    }
}
function appendLoader(a) {
    $(a).append('<img class="ajax-loader" src="' + imagePath + 'ajax-loader.gif" title="loading..." alt="loading..." />')
}
function removeLoader() {
    $("img.ajax-loader").remove()
}
function savePreference(c, d, e) {
    var a = "";
    if (typeof forUserId != "undefined") {
        a = forUserId
    }
    $.post("/users/save-preference", {
        fkey: preffkey,
        key: c,
        value: d,
        forUserId: a
    }, e)
}
var notify = function () {
    var f = 0;
    var e = -1;
    var h = "m";
    var c = function (j) {
        var i = "<div" + (j.messageTypeId ? ' id="notify-' + j.messageTypeId + '"' : "") + ' style="display:none"><span class="notify-close"<a title="dismiss this notification" onclick="notify.close(' + (j.messageTypeId ? j.messageTypeId : "") + ')">&times;</a></span>' + j.text;
        if (j.showProfile) {
            var k = escape("/users/" + j.userId);
            i += ' See your <a href="/messages/mark-as-read?messagetypeid=' + j.messageTypeId + "&returnurl=" + escape(k) + '">profile</a>.'
        }
        i += "</div>";
        $("#notify-container").append(i)
    };
    var d = function (i) {
        $.cookie(h, (i ? i : "0"), {
            expires: 90,
            path: "/"
        })
    };
    var g = function () {
        var i = parseInt($.cookie(h));
        if (isNaN(i)) {
            i = 0
        }
        if (i < 5) {
            $(".module.newuser").show();
            d(++i)
        }
    };
    var a = function () {
        $("#notify-container div").fadeIn("slow")
    };
    return {
        showFirstTime: function () {
            if ($.cookie(h)) {
                g()
            } else {
                $(".module.newuser").show();
                $("body").css("margin-top", "2.5em");
                c({
                    messageTypeId: e,
                    text: 'First time here? Check out the <a onclick="notify.closeFirstTime()">FAQ</a>!'
                });
                a()
            }
        },
        showMessages: function (j) {
            for (var k = 0; k < j.length; k++) {
                c(j[k])
            }
            f = j.length;
            a()
        },
        show: function (i) {
            $("body").css("margin-top", "2.5em");
            c({
                text: i
            });
            a()
        },
        close: function (i) {
            var k;
            var j = 0;
            f--;
            if (i && i != e) {
                $.post("/messages/mark-as-read", {
                    messagetypeid: i
                });
                k = $("#notify-" + i);
                if (f > 0) {
                    j = parseInt($("body").css("margin-top").match(/\d+/));
                    j = j - (j / (f + 1))
                }
            } else {
                if (i && i == e) {
                    d()
                }
                k = $("#notify-container")
            }
            k.fadeOut("fast", function () {
                $("body").css("margin-top", j + "px");
                k.remove()
            })
        },
        closeFirstTime: function () {
            d();
            document.location = "/faq"
        }
    }
} ();

function applyPrefs(d) {
    var c = $("#ignoredTags > a");
    var f = $("#interestingTags > a");
    if (d && c.length == 0 && f.length == 0) {
        return
    }
    $("div.question-summary").removeClass("tagged-ignored tagged-ignored-hidden tagged-interesting");
    var g = getTagsSelector(c);
    var e = getTagsSelector(f);
    if (g.length > 0) {
        var a = $("#hideIgnored").is(":checked") ? "tagged-ignored-hidden" : "tagged-ignored";
        $(g).parents("div.question-summary").addClass(a)
    }
    if (e.length > 0) {
        $(e).parents("div.question-summary").addClass("tagged-interesting")
    }
}
function getTagsSelector(d) {
    var c = "";
    var a = "";
    d.each(function () {
        var e = false;
        a = $(this).text();
        if (a.indexOf("#") > -1) {
            a = a.replace(/#/g, "ñ")
        }
        if (a.indexOf("+") > -1) {
            a = a.replace(/\+/g, "ç")
        }
        if (a.indexOf(".") > -1) {
            a = a.replace(/\./g, "û")
        }
        if (a.indexOf("*") > -1) {
            e = true
        }
        if (e) {
            c += "div.tags:regex(class, t-" + a.replace(/\*/g, ".*") + "),"
        } else {
            c += "div.t-" + a + ","
        }
    });
    if (c.length > 0) {
        c = c.substring(0, c.length - 1)
    }
    return c
}
function saveTags(a, j, d, e) {
    var k = $.trim($(a).val());
    var g = k.split(" ");
    var h = false;
    for (var f = 0; f < g.length; f++) {
        if ($.trim(g[f]).length != 0) {
            $(j).children().each(function () {
                if ($(this).text() == g[f]) {
                    $(this).fadeTo(500, 0.1).fadeTo(500, 1);
                    h = true;
                    return
                }
            });
            if (!h) {
                var c = $.URLEncode(g[f]);
                $(j).append('<a id="' + g[f] + '" href="/questions/tagged/' + c + '" class="' + e + '" title="show questions tagged \'' + g[f] + "'\">" + g[f] + "</a> ");
                initDeleteBindings(d)
            }
            h = false
        }
    }
    $(a).val("").focus();
    savePreference(d, $(j).text());
    applyPrefs()
}
function initTagPrefs() {
    initDeleteBindings(0);
    $("#ignoredAdd").click(function () {
        saveTags("#ignoredTag", "#ignoredTags", 25, "post-tag")
    });
    $("#interestingAdd").click(function () {
        saveTags("#interestingTag", "#interestingTags", 20, "post-tag")
    });
    $("#hideIgnored").click(function () {
        savePreference(30, $(this).is(":checked"));
        applyPrefs()
    });
    bindTagFilterAutoComplete("#ignoredTag");
    bindTagFilterAutoComplete("#interestingTag")
}
function initDeleteBindings(c) {
    var a = "<span class='delete-tag' onmouseover=\"$(this).attr('class', 'delete-tag-hover')\" onmouseout=\"$(this).attr('class', 'delete-tag')\" title=\"remove this tag\"></span>";
    if (c == 0) {
        $("#ignoredTags > .post-tag").after(a)
    }
    if (c == 25) {
        $("#ignoredTags > .post-tag:last").after(a)
    }
    $("#ignoredTags > .delete-tag").click(function () {
        $(this).prev().remove();
        $(this).remove();
        savePreference(25, $("#ignoredTags").text());
        applyPrefs()
    });
    if (c == 0) {
        $("#interestingTags > .post-tag").after(a)
    }
    if (c == 20) {
        $("#interestingTags > .post-tag:last").after(a)
    }
    $("#interestingTags > .delete-tag").click(function () {
        $(this).prev().remove();
        $(this).remove();
        savePreference(20, $("#interestingTags").text());
        applyPrefs()
    })
}
function initBindingsAddSuggestedTag() {
    var c = imagePath + "add-small.png";
    var a = imagePath + "add-small-hover.png";
    var d = "<img class='add' src=\"" + c + "\" onmouseover=\"$(this).attr('src', '" + a + "')\" onmouseout=\"$(this).attr('src', '" + c;
    d += '\')" title="add this tag to interesting tags" />';
    $("#suggestedTags > .post-tag").after(d);
    $("#suggestedTags > .add").click(function () {
        $("#interestingTag").val($("#interestingTag").val() + $(this).prev().text() + " ")
    })
}
jQuery.cookie = function (c, k, o) {
    if (typeof k != "undefined") {
        o = o || {};
        if (k === null) {
            k = "";
            o.expires = -1
        }
        var f = "";
        if (o.expires && (typeof o.expires == "number" || o.expires.toUTCString)) {
            var g;
            if (typeof o.expires == "number") {
                g = new Date();
                g.setTime(g.getTime() + (o.expires * 24 * 60 * 60 * 1000))
            } else {
                g = o.expires
            }
            f = "; expires=" + g.toUTCString()
        }
        var n = o.path ? "; path=" + (o.path) : "";
        var h = o.domain ? "; domain=" + (o.domain) : "";
        var a = o.secure ? "; secure" : "";
        document.cookie = [c, "=", encodeURIComponent(k), f, n, h, a].join("")
    } else {
        var e = null;
        if (document.cookie && document.cookie != "") {
            var l = document.cookie.split(";");
            for (var j = 0; j < l.length; j++) {
                var d = jQuery.trim(l[j]);
                if (d.substring(0, c.length + 1) == (c + "=")) {
                    e = decodeURIComponent(d.substring(c.length + 1));
                    break
                }
            }
        }
        return e
    }
};
window.PR_SHOULD_USE_CONTINUATION = true;
window.PR_TAB_WIDTH = 8;
window.PR_normalizedHtml = window.PR = window.prettyPrintOne = window.prettyPrint = void 0;
window._pr_isIE6 = function () {
    var a = navigator && navigator.userAgent && navigator.userAgent.match(/\bMSIE ([678])\./);
    a = a ? +a[1] : false;
    window._pr_isIE6 = function () {
        return a
    };
    return a
};
(function () {
    var n = "break continue do else for if return while ";
    var F = n + "auto case char const default double enum extern float goto int long register short signed sizeof static struct switch typedef union unsigned void volatile ";
    var x = F + "catch class delete false import new operator private protected public this throw true try typeof ";
    var q = x + "alignof align_union asm axiom bool concept concept_map const_cast constexpr decltype dynamic_cast explicit export friend inline late_check mutable namespace nullptr reinterpret_cast static_assert static_cast template typeid typename using virtual wchar_t where ";
    var I = x + "abstract boolean byte extends final finally implements import instanceof null native package strictfp super synchronized throws transient ";
    var an = I + "as base by checked decimal delegate descending event fixed foreach from group implicit in interface internal into is lock object out override orderby params partial readonly ref sbyte sealed stackalloc string select uint ulong unchecked unsafe ushort var ";
    var H = x + "debugger eval export function get null set undefined var with Infinity NaN ";
    var A = "caller delete die do dump elsif eval exit foreach for goto if import last local my next no our print package redo require sub undef unless until use wantarray while BEGIN END ";
    var ab = n + "and as assert class def del elif except exec finally from global import in is lambda nonlocal not or pass print raise try with yield False True None ";
    var k = n + "alias and begin case class def defined elsif end ensure false in module next nil not or redo rescue retry self super then true undef unless until when yield BEGIN END ";
    var Z = n + "case done elif esac eval fi function in local set then until ";
    var N = (q + an + H + A + ab + k + Z);
    var P = "str";
    var M = "kwd";
    var o = "com";
    var aj = "typ";
    var X = "lit";
    var ag = "pun";
    var W = "pln";
    var r = "tag";
    var V = "dec";
    var ad = "src";
    var am = "atn";
    var t = "atv";
    var ai = "nocode";
    var ah = function () {
        var aq = ["!", "!=", "!==", "#", "%", "%=", "&", "&&", "&&=", "&=", "(", "*", "*=", "+=", ",", "-=", "->", "/", "/=", ":", "::", ";", "<", "<<", "<<=", "<=", "=", "==", "===", ">", ">=", ">>", ">>=", ">>>", ">>>=", "?", "@", "[", "^", "^=", "^^", "^^=", "{", "|", "|=", "||", "||=", "~", "break", "case", "continue", "delete", "do", "else", "finally", "instanceof", "return", "throw", "try", "typeof"];
        var ar = "(?:^^|[+-]";
        for (var ap = 0; ap < aq.length; ++ap) {
            ar += "|" + aq[ap].replace(/([^=<>:&a-z])/g, "\\$1")
        }
        ar += ")\\s*";
        return ar
    } ();
    var T = /&/g;
    var Y = /</g;
    var z = />/g;
    var L = /\"/g;

    function G(ap) {
        return ap.replace(T, "&amp;").replace(Y, "&lt;").replace(z, "&gt;").replace(L, "&quot;")
    }
    function s(ap) {
        return ap.replace(T, "&amp;").replace(Y, "&lt;").replace(z, "&gt;")
    }
    var d = /&lt;/g;
    var E = /&gt;/g;
    var c = /&apos;/g;
    var i = /&quot;/g;
    var ao = /&amp;/g;
    var K = /&nbsp;/g;

    function u(at) {
        var av = at.indexOf("&");
        if (av < 0) {
            return at
        }
        for (--av;
        (av = at.indexOf("&#", av + 1)) >= 0; ) {
            var ap = at.indexOf(";", av);
            if (ap >= 0) {
                var ar = at.substring(av + 3, ap);
                var au = 10;
                if (ar && ar.charAt(0) === "x") {
                    ar = ar.substring(1);
                    au = 16
                }
                var aq = parseInt(ar, au);
                if (!isNaN(aq)) {
                    at = (at.substring(0, av) + String.fromCharCode(aq) + at.substring(ap + 1))
                }
            }
        }
        return at.replace(d, "<").replace(E, ">").replace(c, "'").replace(i, '"').replace(K, " ").replace(ao, "&")
    }
    function S(ap) {
        return "XMP" === ap.tagName
    }
    var aa = /[\r\n]/g;

    function B(ar, aq) {
        if ("PRE" === ar.tagName) {
            return true
        }
        if (!aa.test(aq)) {
            return true
        }
        var ap = "";
        if (ar.currentStyle) {
            ap = ar.currentStyle.whiteSpace
        } else {
            if (window.getComputedStyle) {
                ap = window.getComputedStyle(ar, null).whiteSpace
            }
        }
        return !ap || ap === "pre"
    }
    function al(au, ar) {
        switch (au.nodeType) {
            case 1:
                var aq = au.tagName.toLowerCase();
                ar.push("<", aq);
                for (var at = 0; at < au.attributes.length; ++at) {
                    var ap = au.attributes[at];
                    if (!ap.specified) {
                        continue
                    }
                    ar.push(" ");
                    al(ap, ar)
                }
                ar.push(">");
                for (var av = au.firstChild; av; av = av.nextSibling) {
                    al(av, ar)
                }
                if (au.firstChild || !/^(?:br|link|img)$/.test(aq)) {
                    ar.push("</", aq, ">")
                }
                break;
            case 2:
                ar.push(au.name.toLowerCase(), '="', G(au.value), '"');
                break;
            case 3:
            case 4:
                ar.push(s(au.nodeValue));
                break
        }
    }
    function p(aw) {
        var aA = 0;
        var ap = false;
        var az = false;
        for (var at = 0, ar = aw.length; at < ar; ++at) {
            var aB = aw[at];
            if (aB.ignoreCase) {
                az = true
            } else {
                if (/[a-z]/i.test(aB.source.replace(/\\u[0-9a-f]{4}|\\x[0-9a-f]{2}|\\[^ux]/gi, ""))) {
                    ap = true;
                    az = false;
                    break
                }
            }
        }
        function ay(aC) {
            if (aC.charAt(0) !== "\\") {
                return aC.charCodeAt(0)
            }
            switch (aC.charAt(1)) {
                case "b":
                    return 8;
                case "t":
                    return 9;
                case "n":
                    return 10;
                case "v":
                    return 11;
                case "f":
                    return 12;
                case "r":
                    return 13;
                case "u":
                case "x":
                    return parseInt(aC.substring(2), 16) || aC.charCodeAt(1);
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                    return parseInt(aC.substring(1), 8);
                default:
                    return aC.charCodeAt(1)
            }
        }
        function aq(aC) {
            if (aC < 32) {
                return (aC < 16 ? "\\x0" : "\\x") + aC.toString(16)
            }
            var aD = String.fromCharCode(aC);
            if (aD === "\\" || aD === "-" || aD === "[" || aD === "]") {
                aD = "\\" + aD
            }
            return aD
        }
        function av(aJ) {
            var aN = aJ.substring(1, aJ.length - 1).match(new RegExp("\\\\u[0-9A-Fa-f]{4}|\\\\x[0-9A-Fa-f]{2}|\\\\[0-3][0-7]{0,2}|\\\\[0-7]{1,2}|\\\\[\\s\\S]|-|[^-\\\\]", "g"));
            var aH = [];
            var aC = [];
            var aL = aN[0] === "^";
            for (var aO = aL ? 1 : 0, aG = aN.length; aO < aG; ++aO) {
                var aE = aN[aO];
                switch (aE) {
                    case "\\B":
                    case "\\b":
                    case "\\D":
                    case "\\d":
                    case "\\S":
                    case "\\s":
                    case "\\W":
                    case "\\w":
                        aH.push(aE);
                        continue
                }
                var aD = ay(aE);
                var aI;
                if (aO + 2 < aG && "-" === aN[aO + 1]) {
                    aI = ay(aN[aO + 2]);
                    aO += 2
                } else {
                    aI = aD
                }
                aC.push([aD, aI]);
                if (!(aI < 65 || aD > 122)) {
                    if (!(aI < 65 || aD > 90)) {
                        aC.push([Math.max(65, aD) | 32, Math.min(aI, 90) | 32])
                    }
                    if (!(aI < 97 || aD > 122)) {
                        aC.push([Math.max(97, aD) & ~32, Math.min(aI, 122) & ~32])
                    }
                }
            }
            aC.sort(function (aR, aQ) {
                return (aR[0] - aQ[0]) || (aQ[1] - aR[1])
            });
            var aF = [];
            var aM = [NaN, NaN];
            for (var aO = 0; aO < aC.length; ++aO) {
                var aP = aC[aO];
                if (aP[0] <= aM[1] + 1) {
                    aM[1] = Math.max(aM[1], aP[1])
                } else {
                    aF.push(aM = aP)
                }
            }
            var aK = ["["];
            if (aL) {
                aK.push("^")
            }
            aK.push.apply(aK, aH);
            for (var aO = 0; aO < aF.length; ++aO) {
                var aP = aF[aO];
                aK.push(aq(aP[0]));
                if (aP[1] > aP[0]) {
                    if (aP[1] + 1 > aP[0]) {
                        aK.push("-")
                    }
                    aK.push(aq(aP[1]))
                }
            }
            aK.push("]");
            return aK.join("")
        }
        function au(aI) {
            var aG = aI.source.match(new RegExp("(?:\\[(?:[^\\x5C\\x5D]|\\\\[\\s\\S])*\\]|\\\\u[A-Fa-f0-9]{4}|\\\\x[A-Fa-f0-9]{2}|\\\\[0-9]+|\\\\[^ux0-9]|\\(\\?[:!=]|[\\(\\)\\^]|[^\\x5B\\x5C\\(\\)\\^]+)", "g"));
            var aE = aG.length;
            var aK = [];
            for (var aH = 0, aJ = 0; aH < aE; ++aH) {
                var aD = aG[aH];
                if (aD === "(") {
                    ++aJ
                } else {
                    if ("\\" === aD.charAt(0)) {
                        var aC = +aD.substring(1);
                        if (aC && aC <= aJ) {
                            aK[aC] = -1
                        }
                    }
                }
            }
            for (var aH = 1; aH < aK.length; ++aH) {
                if (-1 === aK[aH]) {
                    aK[aH] = ++aA
                }
            }
            for (var aH = 0, aJ = 0; aH < aE; ++aH) {
                var aD = aG[aH];
                if (aD === "(") {
                    ++aJ;
                    if (aK[aJ] === undefined) {
                        aG[aH] = "(?:"
                    }
                } else {
                    if ("\\" === aD.charAt(0)) {
                        var aC = +aD.substring(1);
                        if (aC && aC <= aJ) {
                            aG[aH] = "\\" + aK[aJ]
                        }
                    }
                }
            }
            for (var aH = 0, aJ = 0; aH < aE; ++aH) {
                if ("^" === aG[aH] && "^" !== aG[aH + 1]) {
                    aG[aH] = ""
                }
            }
            if (aI.ignoreCase && ap) {
                for (var aH = 0; aH < aE; ++aH) {
                    var aD = aG[aH];
                    var aF = aD.charAt(0);
                    if (aD.length >= 2 && aF === "[") {
                        aG[aH] = av(aD)
                    } else {
                        if (aF !== "\\") {
                            aG[aH] = aD.replace(/[a-zA-Z]/g, function (aL) {
                                var aM = aL.charCodeAt(0);
                                return "[" + String.fromCharCode(aM & ~32, aM | 32) + "]"
                            })
                        }
                    }
                }
            }
            return aG.join("")
        }
        var ax = [];
        for (var at = 0, ar = aw.length; at < ar; ++at) {
            var aB = aw[at];
            if (aB.global || aB.multiline) {
                throw new Error("" + aB)
            }
            ax.push("(?:" + au(aB) + ")")
        }
        return new RegExp(ax.join("|"), az ? "gi" : "g")
    }
    var ak = null;

    function a(at) {
        if (null === ak) {
            var aq = document.createElement("PRE");
            aq.appendChild(document.createTextNode('<!DOCTYPE foo PUBLIC "foo bar">\n<foo />'));
            ak = !/</.test(aq.innerHTML)
        }
        if (ak) {
            var ar = at.innerHTML;
            if (S(at)) {
                ar = s(ar)
            } else {
                if (!B(at, ar)) {
                    ar = ar.replace(/(<br\s*\/?>)[\r\n]+/g, "$1").replace(/(?:[\r\n]+[ \t]*)+/g, " ")
                }
            }
            return ar
        }
        var ap = [];
        for (var au = at.firstChild; au; au = au.nextSibling) {
            al(au, ap)
        }
        return ap.join("")
    }
    function af(ar) {
        var ap = " ";
        var aq = 0;
        return function (aw) {
            var au = null;
            var az = 0;
            for (var av = 0, ay = aw.length; av < ay; ++av) {
                var ax = aw.charAt(av);
                switch (ax) {
                    case "\t":
                        if (!au) {
                            au = []
                        }
                        au.push(aw.substring(az, av));
                        var at = ar - (aq % ar);
                        aq += at;
                        for (; at >= 0; at -= ap.length) {
                            au.push(ap.substring(0, at))
                        }
                        az = av + 1;
                        break;
                    case "\n":
                        aq = 0;
                        break;
                    default:
                        ++aq
                }
            }
            if (!au) {
                return aw
            }
            au.push(aw.substring(az));
            return au.join("")
        }
    }
    var R = new RegExp("[^<]+|<!--[\\s\\S]*?-->|<!\\[CDATA\\[[\\s\\S]*?\\]\\]>|</?[a-zA-Z](?:[^>\"']|'[^']*'|\"[^\"]*\")*>|<", "g");
    var w = /^<\!--/;
    var U = /^<!\[CDATA\[/;
    var v = /^<br\b/i;
    var g = /^<(\/?)([a-zA-Z][a-zA-Z0-9]*)/;

    function D(aC) {
        var ay = aC.match(R);
        var aB = [];
        var at = 0;
        var ap = [];
        if (ay) {
            for (var ax = 0, ar = ay.length; ax < ar; ++ax) {
                var az = ay[ax];
                if (az.length > 1 && az.charAt(0) === "<") {
                    if (w.test(az)) {
                        continue
                    }
                    if (U.test(az)) {
                        aB.push(az.substring(9, az.length - 3));
                        at += az.length - 12
                    } else {
                        if (v.test(az)) {
                            aB.push("\n");
                            ++at
                        } else {
                            if (az.indexOf(ai) >= 0 && ac(az)) {
                                var aq = az.match(g)[2];
                                var aw = 1;
                                var av;
                                end_tag_loop: for (av = ax + 1; av < ar; ++av) {
                                    var aA = ay[av].match(g);
                                    if (aA && aA[2] === aq) {
                                        if (aA[1] === "/") {
                                            if (--aw === 0) {
                                                break end_tag_loop
                                            }
                                        } else {
                                            ++aw
                                        }
                                    }
                                }
                                if (av < ar) {
                                    ap.push(at, ay.slice(ax, av + 1).join(""));
                                    ax = av
                                } else {
                                    ap.push(at, az)
                                }
                            } else {
                                ap.push(at, az)
                            }
                        }
                    }
                } else {
                    var au = u(az);
                    aB.push(au);
                    at += au.length
                }
            }
        }
        return {
            source: aB.join(""),
            tags: ap
        }
    }
    function ac(ap) {
        return !!ap.replace(/\s(\w+)\s*=\s*(?:\"([^\"]*)\"|'([^\']*)'|(\S+))/g, ' $1="$2$3$4"').match(/[cC][lL][aA][sS][sS]=\"[^\"]*\bnocode\b/)
    }
    function O(ap, ar, au, aq) {
        if (!ar) {
            return
        }
        var at = {
            source: ar,
            basePos: ap
        };
        au(at);
        aq.push.apply(aq, at.decorations)
    }
    function j(ar, aq) {
        var ap = {};
        var at;
        (function () {
            var aC = ar.concat(aq);
            var aG = [];
            var aF = {};
            for (var aA = 0, ay = aC.length; aA < ay; ++aA) {
                var ax = aC[aA];
                var aB = ax[3];
                if (aB) {
                    for (var aD = aB.length; --aD >= 0; ) {
                        ap[aB.charAt(aD)] = ax
                    }
                }
                var aE = ax[1];
                var az = "" + aE;
                if (!aF.hasOwnProperty(az)) {
                    aG.push(aE);
                    aF[az] = null
                }
            }
            aG.push(/[\0-\uffff]/);
            at = p(aG)
        })();
        var aw = aq.length;
        var av = /\S/;
        var au = function (aG) {
            var ay = aG.source,
                ax = aG.basePos;
            var aC = [ax, W];
            var aE = 0;
            var aM = ay.match(at) || [];
            var aI = {};
            for (var aD = 0, aP = aM.length; aD < aP; ++aD) {
                var aF = aM[aD];
                var aO = aI[aF];
                var aH = void 0;
                var aL;
                if (typeof aO === "string") {
                    aL = false
                } else {
                    var az = ap[aF.charAt(0)];
                    if (az) {
                        aH = aF.match(az[1]);
                        aO = az[0]
                    } else {
                        for (var aN = 0; aN < aw; ++aN) {
                            az = aq[aN];
                            aH = aF.match(az[1]);
                            if (aH) {
                                aO = az[0];
                                break
                            }
                        }
                        if (!aH) {
                            aO = W
                        }
                    }
                    aL = aO.length >= 5 && "lang-" === aO.substring(0, 5);
                    if (aL && !(aH && typeof aH[1] === "string")) {
                        aL = false;
                        aO = ad
                    }
                    if (!aL) {
                        aI[aF] = aO
                    }
                }
                var aA = aE;
                aE += aF.length;
                if (!aL) {
                    aC.push(ax + aA, aO)
                } else {
                    var aK = aH[1];
                    var aJ = aF.indexOf(aK);
                    var aB = aJ + aK.length;
                    if (aH[2]) {
                        aB = aF.length - aH[2].length;
                        aJ = aB - aK.length
                    }
                    var aQ = aO.substring(5);
                    O(ax + aA, aF.substring(0, aJ), au, aC);
                    O(ax + aA + aJ, aK, y(aQ, aK), aC);
                    O(ax + aA + aB, aF.substring(aB), au, aC)
                }
            }
            aG.decorations = aC
        };
        return au
    }
    function l(aq) {
        var at = [],
            ap = [];
        if (aq.tripleQuotedStrings) {
            at.push([P, /^(?:\'\'\'(?:[^\'\\]|\\[\s\S]|\'{1,2}(?=[^\']))*(?:\'\'\'|$)|\"\"\"(?:[^\"\\]|\\[\s\S]|\"{1,2}(?=[^\"]))*(?:\"\"\"|$)|\'(?:[^\\\']|\\[\s\S])*(?:\'|$)|\"(?:[^\\\"]|\\[\s\S])*(?:\"|$))/, null, "'\""])
        } else {
            if (aq.multiLineStrings) {
                at.push([P, /^(?:\'(?:[^\\\']|\\[\s\S])*(?:\'|$)|\"(?:[^\\\"]|\\[\s\S])*(?:\"|$)|\`(?:[^\\\`]|\\[\s\S])*(?:\`|$))/, null, "'\"`"])
            } else {
                at.push([P, /^(?:\'(?:[^\\\'\r\n]|\\.)*(?:\'|$)|\"(?:[^\\\"\r\n]|\\.)*(?:\"|$))/, null, "\"'"])
            }
        }
        if (aq.verbatimStrings) {
            ap.push([P, /^@\"(?:[^\"]|\"\")*(?:\"|$)/, null])
        }
        if (aq.hashComments) {
            if (aq.cStyleComments) {
                at.push([o, /^#(?:(?:define|elif|else|endif|error|ifdef|include|ifndef|line|pragma|undef|warning)\b|[^\r\n]*)/, null, "#"]);
                ap.push([P, /^<(?:(?:(?:\.\.\/)*|\/?)(?:[\w-]+(?:\/[\w-]+)+)?[\w-]+\.h|[a-z]\w*)>/, null])
            } else {
                at.push([o, /^#[^\r\n]*/, null, "#"])
            }
        }
        if (aq.cStyleComments) {
            ap.push([o, /^\/\/[^\r\n]*/, null]);
            ap.push([o, /^\/\*[\s\S]*?(?:\*\/|$)/, null])
        }
        if (aq.regexLiterals) {
            var au = ("/(?=[^/*])(?:[^/\\x5B\\x5C]|\\x5C[\\s\\S]|\\x5B(?:[^\\x5C\\x5D]|\\x5C[\\s\\S])*(?:\\x5D|$))+/");
            ap.push(["lang-regex", new RegExp("^" + ah + "(" + au + ")")])
        }
        var ar = aq.keywords.replace(/^\s+|\s+$/g, "");
        if (ar.length) {
            ap.push([M, new RegExp("^(?:" + ar.replace(/\s+/g, "|") + ")\\b"), null])
        }
        at.push([W, /^\s+/, null, " \r\n\t\xA0"]);
        ap.push([X, /^@[a-z_$][a-z_$@0-9]*/i, null], [aj, /^@?[A-Z]+[a-z][A-Za-z_$@0-9]*/, null], [W, /^[a-z_$][a-z_$@0-9]*/i, null], [X, new RegExp("^(?:0x[a-f0-9]+|(?:\\d(?:_\\d+)*\\d*(?:\\.\\d*)?|\\.\\d\\+)(?:e[+\\-]?\\d+)?)[a-z]*", "i"), null, "0123456789"], [ag, /^.[^\s\w\.$@\'\"\`\/\#]*/, null]);
        return j(at, ap)
    }
    var ae = l({
        keywords: N,
        hashComments: true,
        cStyleComments: true,
        multiLineStrings: true,
        regexLiterals: true
    });

    function Q(au) {
        var aB = au.source;
        var at = au.extractedTags;
        var ar = au.decorations;
        var ay = [];
        var aw = 0;
        var aG = null;
        var az = null;
        var aq = 0;
        var aF = 0;
        var aH = af(window.PR_TAB_WIDTH);
        var aD = /([\r\n ]) /g;
        var av = /(^| ) /gm;
        var aC = /\r\n?|\n/g;
        var ax = /[ \r\n]$/;
        var ap = true;

        function aA(aI) {
            if (aI > aw) {
                if (aG && aG !== az) {
                    ay.push("</span>");
                    aG = null
                }
                if (!aG && az) {
                    aG = az;
                    ay.push('<span class="', aG, '">')
                }
                var aJ = s(aH(aB.substring(aw, aI))).replace(ap ? av : aD, "$1&nbsp;");
                ap = ax.test(aJ);
                var aK = window._pr_isIE6() ? "&nbsp;<br />" : "<br />";
                ay.push(aJ.replace(aC, aK));
                aw = aI
            }
        }
        while (true) {
            var aE;
            if (aq < at.length) {
                if (aF < ar.length) {
                    aE = at[aq] <= ar[aF]
                } else {
                    aE = true
                }
            } else {
                aE = false
            }
            if (aE) {
                aA(at[aq]);
                if (aG) {
                    ay.push("</span>");
                    aG = null
                }
                ay.push(at[aq + 1]);
                aq += 2
            } else {
                if (aF < ar.length) {
                    aA(ar[aF]);
                    az = ar[aF + 1];
                    aF += 2
                } else {
                    break
                }
            }
        }
        aA(aB.length);
        if (aG) {
            ay.push("</span>")
        }
        au.prettyPrintedHtml = ay.join("")
    }
    var C = {};

    function f(ar, at) {
        for (var ap = at.length; --ap >= 0; ) {
            var aq = at[ap];
            if (!C.hasOwnProperty(aq)) {
                C[aq] = ar
            } else {
                if ("console" in window) {
                    console.warn("cannot override language handler %s", aq)
                }
            }
        }
    }
    function y(aq, ap) {
        if (!(aq && C.hasOwnProperty(aq))) {
            aq = /^\s*</.test(ap) ? "default-markup" : "default-code"
        }
        return C[aq]
    }
    f(ae, ["default-code"]);
    f(j([], [
        [W, /^[^<?]+/],
        [V, /^<!\w[^>]*(?:>|$)/],
        [o, /^<\!--[\s\S]*?(?:-\->|$)/],
        ["lang-", /^<\?([\s\S]+?)(?:\?>|$)/],
        ["lang-", /^<%([\s\S]+?)(?:%>|$)/],
        [ag, /^(?:<[%?]|[%?]>)/],
        ["lang-", /^<xmp\b[^>]*>([\s\S]+?)<\/xmp\b[^>]*>/i],
        ["lang-js", /^<script\b[^>]*>([\s\S]*?)(<\/script\b[^>]*>)/i],
        ["lang-css", /^<style\b[^>]*>([\s\S]*?)(<\/style\b[^>]*>)/i],
        ["lang-in.tag", /^(<\/?[a-z][^<>]*>)/i]
    ]), ["default-markup", "htm", "html", "mxml", "xhtml", "xml", "xsl"]);
    f(j([
        [W, /^[\s]+/, null, " \t\r\n"],
        [t, /^(?:\"[^\"]*\"?|\'[^\']*\'?)/, null, "\"'"]
    ], [
        [r, /^^<\/?[a-z](?:[\w.:-]*\w)?|\/?>$/i],
        [am, /^(?!style[\s=]|on)[a-z](?:[\w:-]*\w)?/i],
        ["lang-uq.val", /^=\s*([^>\'\"\s]*(?:[^>\'\"\s\/]|\/(?=\s)))/],
        [ag, /^[=<>\/]+/],
        ["lang-js", /^on\w+\s*=\s*\"([^\"]+)\"/i],
        ["lang-js", /^on\w+\s*=\s*\'([^\']+)\'/i],
        ["lang-js", /^on\w+\s*=\s*([^\"\'>\s]+)/i],
        ["lang-css", /^style\s*=\s*\"([^\"]+)\"/i],
        ["lang-css", /^style\s*=\s*\'([^\']+)\'/i],
        ["lang-css", /^style\s*=\s*([^\"\'>\s]+)/i]
    ]), ["in.tag"]);
    f(j([], [
        [t, /^[\s\S]+/]
    ]), ["uq.val"]);
    f(l({
        keywords: q,
        hashComments: true,
        cStyleComments: true
    }), ["c", "cc", "cpp", "cxx", "cyc", "m"]);
    f(l({
        keywords: "null true false"
    }), ["json"]);
    f(l({
        keywords: an,
        hashComments: true,
        cStyleComments: true,
        verbatimStrings: true
    }), ["cs"]);
    f(l({
        keywords: I,
        cStyleComments: true
    }), ["java"]);
    f(l({
        keywords: Z,
        hashComments: true,
        multiLineStrings: true
    }), ["bsh", "csh", "sh"]);
    f(l({
        keywords: ab,
        hashComments: true,
        multiLineStrings: true,
        tripleQuotedStrings: true
    }), ["cv", "py"]);
    f(l({
        keywords: A,
        hashComments: true,
        multiLineStrings: true,
        regexLiterals: true
    }), ["perl", "pl", "pm"]);
    f(l({
        keywords: k,
        hashComments: true,
        multiLineStrings: true,
        regexLiterals: true
    }), ["rb"]);
    f(l({
        keywords: H,
        cStyleComments: true,
        regexLiterals: true
    }), ["js"]);
    f(j([], [
        [P, /^[\s\S]+/]
    ]), ["regex"]);

    function h(ar) {
        var au = ar.sourceCodeHtml;
        var aq = ar.langExtension;
        ar.prettyPrintedHtml = au;
        try {
            var av = D(au);
            var ap = av.source;
            ar.source = ap;
            ar.basePos = 0;
            ar.extractedTags = av.tags;
            y(aq, ap)(ar);
            Q(ar)
        } catch (at) {
            if ("console" in window) {
                console.log(at);
                console.trace()
            }
        }
    }
    function J(ar, aq) {
        var ap = {
            sourceCodeHtml: ar,
            langExtension: aq
        };
        h(ap);
        return ap.prettyPrintedHtml
    }
    function e(aC) {
        var aB = window._pr_isIE6();
        var av = aB === 6 ? "\r\n" : "\r";
        var az = [document.getElementsByTagName("pre"), document.getElementsByTagName("code"), document.getElementsByTagName("xmp")];
        var aq = [];
        for (var ay = 0; ay < az.length; ++ay) {
            for (var ax = 0, at = az[ay].length; ax < at; ++ax) {
                aq.push(az[ay][ax])
            }
        }
        az = null;
        var au = Date;
        if (!au.now) {
            au = {
                now: function () {
                    return (new Date).getTime()
                }
            }
        }
        var aw = 0;
        var ap;

        function ar() {
            var aD = (window.PR_SHOULD_USE_CONTINUATION ? au.now() + 250 : Infinity);
            for (; aw < aq.length && au.now() < aD; aw++) {
                var aF = aq[aw];
                if (aF.className && aF.className.indexOf("prettyprint") >= 0) {
                    var aE = aF.className.match(/\blang-(\w+)\b/);
                    if (aE) {
                        aE = aE[1]
                    }
                    var aI = false;
                    for (var aH = aF.parentNode; aH; aH = aH.parentNode) {
                        if ((aH.tagName === "pre" || aH.tagName === "code" || aH.tagName === "xmp") && aH.className && aH.className.indexOf("prettyprint") >= 0) {
                            aI = true;
                            break
                        }
                    }
                    if (!aI) {
                        var aG = a(aF);
                        aG = aG.replace(/(?:\r\n?|\n)$/, "");
                        ap = {
                            sourceCodeHtml: aG,
                            langExtension: aE,
                            sourceNode: aF
                        };
                        h(ap);
                        aA()
                    }
                }
            }
            if (aw < aq.length) {
                setTimeout(ar, 250)
            } else {
                if (aC) {
                    aC()
                }
            }
        }
        function aA() {
            var aK = ap.prettyPrintedHtml;
            if (!aK) {
                return
            }
            var aG = ap.sourceNode;
            if (!S(aG)) {
                aG.innerHTML = aK
            } else {
                var aD = document.createElement("PRE");
                for (var aF = 0; aF < aG.attributes.length; ++aF) {
                    var aL = aG.attributes[aF];
                    if (aL.specified) {
                        var aI = aL.name.toLowerCase();
                        if (aI === "class") {
                            aD.className = aL.value
                        } else {
                            aD.setAttribute(aL.name, aL.value)
                        }
                    }
                }
                aD.innerHTML = aK;
                aG.parentNode.replaceChild(aD, aG);
                aG = aD
            }
            if (aB && aG.tagName === "PRE") {
                var aH = aG.getElementsByTagName("br");
                for (var aE = aH.length; --aE >= 0; ) {
                    var aJ = aH[aE];
                    aJ.parentNode.replaceChild(document.createTextNode(av), aJ)
                }
            }
        }
        ar()
    }
    window.PR_normalizedHtml = al;
    window.prettyPrintOne = J;
    window.prettyPrint = e;
    window.PR = {
        combinePrefixPatterns: p,
        createSimpleLexer: j,
        registerLangHandler: f,
        sourceDecorator: l,
        PR_ATTRIB_NAME: am,
        PR_ATTRIB_VALUE: t,
        PR_COMMENT: o,
        PR_DECLARATION: V,
        PR_KEYWORD: M,
        PR_LITERAL: X,
        PR_NOCODE: ai,
        PR_PLAIN: W,
        PR_PUNCTUATION: ag,
        PR_SOURCE: ad,
        PR_STRING: P,
        PR_TAG: r,
        PR_TYPE: aj
    }
})();
jQuery.expr[":"].regex = function (h, e, d) {
    var i = d[3].split(","),
        c = /^(data|css):/,
        a = {
            method: i[0].match(c) ? i[0].split(":")[0] : "attr",
            property: i.shift().replace(c, "")
        },
        g = "ig",
        f = new RegExp(i.join("").replace(/^\s+|\s+$/g, ""), g);
    return f.test(jQuery(h)[a.method](a.property))
};
$.extend({
    URLEncode: function (k) {
        var j = "";
        var e = 0;
        k = k.toString();
        var g = /(^[a-zA-Z0-9_.]*)/;
        while (e < k.length) {
            var a = g.exec(k.substr(e));
            if (a != null && a.length > 1 && a[1] != "") {
                j += a[1];
                e += a[1].length
            } else {
                if (k[e] == " ") {
                    j += "+"
                } else {
                    var i = k.charCodeAt(e);
                    var f = i.toString(16);
                    j += "%" + (f.length < 2 ? "0" : "") + f.toUpperCase()
                }
                e++
            }
        }
        return j
    },
    URLDecode: function (d) {
        var f = d;
        var a, c;
        var e = /(%[^%]{2})/;
        while ((m = e.exec(f)) != null && m.length > 1 && m[1] != "") {
            b = parseInt(m[1].substr(1), 16);
            c = String.fromCharCode(b);
            f = f.replace(m[1], c)
        }
        return f
    }
});