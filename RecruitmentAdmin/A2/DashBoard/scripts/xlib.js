/* Main Jquery */
/*! jQuery v1.9.1 | (c) 2005, 2012 jQuery Foundation, Inc. | jquery.org/license
//@ sourceMappingURL=jquery.min.map
*/(function(e,t){var n,r,i=typeof t,o=e.document,a=e.location,s=e.jQuery,u=e.$,l={},c=[],p="1.9.1",f=c.concat,d=c.push,h=c.slice,g=c.indexOf,m=l.toString,y=l.hasOwnProperty,v=p.trim,b=function(e,t){return new b.fn.init(e,t,r)},x=/[+-]?(?:\d*\.|)\d+(?:[eE][+-]?\d+|)/.source,w=/\S+/g,T=/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g,N=/^(?:(<[\w\W]+>)[^>]*|#([\w-]*))$/,C=/^<(\w+)\s*\/?>(?:<\/\1>|)$/,k=/^[\],:{}\s]*$/,E=/(?:^|:|,)(?:\s*\[)+/g,S=/\\(?:["\\\/bfnrt]|u[\da-fA-F]{4})/g,A=/"[^"\\\r\n]*"|true|false|null|-?(?:\d+\.|)\d+(?:[eE][+-]?\d+|)/g,j=/^-ms-/,D=/-([\da-z])/gi,L=function(e,t){return t.toUpperCase()},H=function(e){(o.addEventListener||"load"===e.type||"complete"===o.readyState)&&(q(),b.ready())},q=function(){o.addEventListener?(o.removeEventListener("DOMContentLoaded",H,!1),e.removeEventListener("load",H,!1)):(o.detachEvent("onreadystatechange",H),e.detachEvent("onload",H))};b.fn=b.prototype={jquery:p,constructor:b,init:function(e,n,r){var i,a;if(!e)return this;if("string"==typeof e){if(i="<"===e.charAt(0)&&">"===e.charAt(e.length-1)&&e.length>=3?[null,e,null]:N.exec(e),!i||!i[1]&&n)return!n||n.jquery?(n||r).find(e):this.constructor(n).find(e);if(i[1]){if(n=n instanceof b?n[0]:n,b.merge(this,b.parseHTML(i[1],n&&n.nodeType?n.ownerDocument||n:o,!0)),C.test(i[1])&&b.isPlainObject(n))for(i in n)b.isFunction(this[i])?this[i](n[i]):this.attr(i,n[i]);return this}if(a=o.getElementById(i[2]),a&&a.parentNode){if(a.id!==i[2])return r.find(e);this.length=1,this[0]=a}return this.context=o,this.selector=e,this}return e.nodeType?(this.context=this[0]=e,this.length=1,this):b.isFunction(e)?r.ready(e):(e.selector!==t&&(this.selector=e.selector,this.context=e.context),b.makeArray(e,this))},selector:"",length:0,size:function(){return this.length},toArray:function(){return h.call(this)},get:function(e){return null==e?this.toArray():0>e?this[this.length+e]:this[e]},pushStack:function(e){var t=b.merge(this.constructor(),e);return t.prevObject=this,t.context=this.context,t},each:function(e,t){return b.each(this,e,t)},ready:function(e){return b.ready.promise().done(e),this},slice:function(){return this.pushStack(h.apply(this,arguments))},first:function(){return this.eq(0)},last:function(){return this.eq(-1)},eq:function(e){var t=this.length,n=+e+(0>e?t:0);return this.pushStack(n>=0&&t>n?[this[n]]:[])},map:function(e){return this.pushStack(b.map(this,function(t,n){return e.call(t,n,t)}))},end:function(){return this.prevObject||this.constructor(null)},push:d,sort:[].sort,splice:[].splice},b.fn.init.prototype=b.fn,b.extend=b.fn.extend=function(){var e,n,r,i,o,a,s=arguments[0]||{},u=1,l=arguments.length,c=!1;for("boolean"==typeof s&&(c=s,s=arguments[1]||{},u=2),"object"==typeof s||b.isFunction(s)||(s={}),l===u&&(s=this,--u);l>u;u++)if(null!=(o=arguments[u]))for(i in o)e=s[i],r=o[i],s!==r&&(c&&r&&(b.isPlainObject(r)||(n=b.isArray(r)))?(n?(n=!1,a=e&&b.isArray(e)?e:[]):a=e&&b.isPlainObject(e)?e:{},s[i]=b.extend(c,a,r)):r!==t&&(s[i]=r));return s},b.extend({noConflict:function(t){return e.$===b&&(e.$=u),t&&e.jQuery===b&&(e.jQuery=s),b},isReady:!1,readyWait:1,holdReady:function(e){e?b.readyWait++:b.ready(!0)},ready:function(e){if(e===!0?!--b.readyWait:!b.isReady){if(!o.body)return setTimeout(b.ready);b.isReady=!0,e!==!0&&--b.readyWait>0||(n.resolveWith(o,[b]),b.fn.trigger&&b(o).trigger("ready").off("ready"))}},isFunction:function(e){return"function"===b.type(e)},isArray:Array.isArray||function(e){return"array"===b.type(e)},isWindow:function(e){return null!=e&&e==e.window},isNumeric:function(e){return!isNaN(parseFloat(e))&&isFinite(e)},type:function(e){return null==e?e+"":"object"==typeof e||"function"==typeof e?l[m.call(e)]||"object":typeof e},isPlainObject:function(e){if(!e||"object"!==b.type(e)||e.nodeType||b.isWindow(e))return!1;try{if(e.constructor&&!y.call(e,"constructor")&&!y.call(e.constructor.prototype,"isPrototypeOf"))return!1}catch(n){return!1}var r;for(r in e);return r===t||y.call(e,r)},isEmptyObject:function(e){var t;for(t in e)return!1;return!0},error:function(e){throw Error(e)},parseHTML:function(e,t,n){if(!e||"string"!=typeof e)return null;"boolean"==typeof t&&(n=t,t=!1),t=t||o;var r=C.exec(e),i=!n&&[];return r?[t.createElement(r[1])]:(r=b.buildFragment([e],t,i),i&&b(i).remove(),b.merge([],r.childNodes))},parseJSON:function(n){return e.JSON&&e.JSON.parse?e.JSON.parse(n):null===n?n:"string"==typeof n&&(n=b.trim(n),n&&k.test(n.replace(S,"@").replace(A,"]").replace(E,"")))?Function("return "+n)():(b.error("Invalid JSON: "+n),t)},parseXML:function(n){var r,i;if(!n||"string"!=typeof n)return null;try{e.DOMParser?(i=new DOMParser,r=i.parseFromString(n,"text/xml")):(r=new ActiveXObject("Microsoft.XMLDOM"),r.async="false",r.loadXML(n))}catch(o){r=t}return r&&r.documentElement&&!r.getElementsByTagName("parsererror").length||b.error("Invalid XML: "+n),r},noop:function(){},globalEval:function(t){t&&b.trim(t)&&(e.execScript||function(t){e.eval.call(e,t)})(t)},camelCase:function(e){return e.replace(j,"ms-").replace(D,L)},nodeName:function(e,t){return e.nodeName&&e.nodeName.toLowerCase()===t.toLowerCase()},each:function(e,t,n){var r,i=0,o=e.length,a=M(e);if(n){if(a){for(;o>i;i++)if(r=t.apply(e[i],n),r===!1)break}else for(i in e)if(r=t.apply(e[i],n),r===!1)break}else if(a){for(;o>i;i++)if(r=t.call(e[i],i,e[i]),r===!1)break}else for(i in e)if(r=t.call(e[i],i,e[i]),r===!1)break;return e},trim:v&&!v.call("\ufeff\u00a0")?function(e){return null==e?"":v.call(e)}:function(e){return null==e?"":(e+"").replace(T,"")},makeArray:function(e,t){var n=t||[];return null!=e&&(M(Object(e))?b.merge(n,"string"==typeof e?[e]:e):d.call(n,e)),n},inArray:function(e,t,n){var r;if(t){if(g)return g.call(t,e,n);for(r=t.length,n=n?0>n?Math.max(0,r+n):n:0;r>n;n++)if(n in t&&t[n]===e)return n}return-1},merge:function(e,n){var r=n.length,i=e.length,o=0;if("number"==typeof r)for(;r>o;o++)e[i++]=n[o];else while(n[o]!==t)e[i++]=n[o++];return e.length=i,e},grep:function(e,t,n){var r,i=[],o=0,a=e.length;for(n=!!n;a>o;o++)r=!!t(e[o],o),n!==r&&i.push(e[o]);return i},map:function(e,t,n){var r,i=0,o=e.length,a=M(e),s=[];if(a)for(;o>i;i++)r=t(e[i],i,n),null!=r&&(s[s.length]=r);else for(i in e)r=t(e[i],i,n),null!=r&&(s[s.length]=r);return f.apply([],s)},guid:1,proxy:function(e,n){var r,i,o;return"string"==typeof n&&(o=e[n],n=e,e=o),b.isFunction(e)?(r=h.call(arguments,2),i=function(){return e.apply(n||this,r.concat(h.call(arguments)))},i.guid=e.guid=e.guid||b.guid++,i):t},access:function(e,n,r,i,o,a,s){var u=0,l=e.length,c=null==r;if("object"===b.type(r)){o=!0;for(u in r)b.access(e,n,u,r[u],!0,a,s)}else if(i!==t&&(o=!0,b.isFunction(i)||(s=!0),c&&(s?(n.call(e,i),n=null):(c=n,n=function(e,t,n){return c.call(b(e),n)})),n))for(;l>u;u++)n(e[u],r,s?i:i.call(e[u],u,n(e[u],r)));return o?e:c?n.call(e):l?n(e[0],r):a},now:function(){return(new Date).getTime()}}),b.ready.promise=function(t){if(!n)if(n=b.Deferred(),"complete"===o.readyState)setTimeout(b.ready);else if(o.addEventListener)o.addEventListener("DOMContentLoaded",H,!1),e.addEventListener("load",H,!1);else{o.attachEvent("onreadystatechange",H),e.attachEvent("onload",H);var r=!1;try{r=null==e.frameElement&&o.documentElement}catch(i){}r&&r.doScroll&&function a(){if(!b.isReady){try{r.doScroll("left")}catch(e){return setTimeout(a,50)}q(),b.ready()}}()}return n.promise(t)},b.each("Boolean Number String Function Array Date RegExp Object Error".split(" "),function(e,t){l["[object "+t+"]"]=t.toLowerCase()});function M(e){var t=e.length,n=b.type(e);return b.isWindow(e)?!1:1===e.nodeType&&t?!0:"array"===n||"function"!==n&&(0===t||"number"==typeof t&&t>0&&t-1 in e)}r=b(o);var _={};function F(e){var t=_[e]={};return b.each(e.match(w)||[],function(e,n){t[n]=!0}),t}b.Callbacks=function(e){e="string"==typeof e?_[e]||F(e):b.extend({},e);var n,r,i,o,a,s,u=[],l=!e.once&&[],c=function(t){for(r=e.memory&&t,i=!0,a=s||0,s=0,o=u.length,n=!0;u&&o>a;a++)if(u[a].apply(t[0],t[1])===!1&&e.stopOnFalse){r=!1;break}n=!1,u&&(l?l.length&&c(l.shift()):r?u=[]:p.disable())},p={add:function(){if(u){var t=u.length;(function i(t){b.each(t,function(t,n){var r=b.type(n);"function"===r?e.unique&&p.has(n)||u.push(n):n&&n.length&&"string"!==r&&i(n)})})(arguments),n?o=u.length:r&&(s=t,c(r))}return this},remove:function(){return u&&b.each(arguments,function(e,t){var r;while((r=b.inArray(t,u,r))>-1)u.splice(r,1),n&&(o>=r&&o--,a>=r&&a--)}),this},has:function(e){return e?b.inArray(e,u)>-1:!(!u||!u.length)},empty:function(){return u=[],this},disable:function(){return u=l=r=t,this},disabled:function(){return!u},lock:function(){return l=t,r||p.disable(),this},locked:function(){return!l},fireWith:function(e,t){return t=t||[],t=[e,t.slice?t.slice():t],!u||i&&!l||(n?l.push(t):c(t)),this},fire:function(){return p.fireWith(this,arguments),this},fired:function(){return!!i}};return p},b.extend({Deferred:function(e){var t=[["resolve","done",b.Callbacks("once memory"),"resolved"],["reject","fail",b.Callbacks("once memory"),"rejected"],["notify","progress",b.Callbacks("memory")]],n="pending",r={state:function(){return n},always:function(){return i.done(arguments).fail(arguments),this},then:function(){var e=arguments;return b.Deferred(function(n){b.each(t,function(t,o){var a=o[0],s=b.isFunction(e[t])&&e[t];i[o[1]](function(){var e=s&&s.apply(this,arguments);e&&b.isFunction(e.promise)?e.promise().done(n.resolve).fail(n.reject).progress(n.notify):n[a+"With"](this===r?n.promise():this,s?[e]:arguments)})}),e=null}).promise()},promise:function(e){return null!=e?b.extend(e,r):r}},i={};return r.pipe=r.then,b.each(t,function(e,o){var a=o[2],s=o[3];r[o[1]]=a.add,s&&a.add(function(){n=s},t[1^e][2].disable,t[2][2].lock),i[o[0]]=function(){return i[o[0]+"With"](this===i?r:this,arguments),this},i[o[0]+"With"]=a.fireWith}),r.promise(i),e&&e.call(i,i),i},when:function(e){var t=0,n=h.call(arguments),r=n.length,i=1!==r||e&&b.isFunction(e.promise)?r:0,o=1===i?e:b.Deferred(),a=function(e,t,n){return function(r){t[e]=this,n[e]=arguments.length>1?h.call(arguments):r,n===s?o.notifyWith(t,n):--i||o.resolveWith(t,n)}},s,u,l;if(r>1)for(s=Array(r),u=Array(r),l=Array(r);r>t;t++)n[t]&&b.isFunction(n[t].promise)?n[t].promise().done(a(t,l,n)).fail(o.reject).progress(a(t,u,s)):--i;return i||o.resolveWith(l,n),o.promise()}}),b.support=function(){var t,n,r,a,s,u,l,c,p,f,d=o.createElement("div");if(d.setAttribute("className","t"),d.innerHTML="  <link/><table></table><a href='/a'>a</a><input type='checkbox'/>",n=d.getElementsByTagName("*"),r=d.getElementsByTagName("a")[0],!n||!r||!n.length)return{};s=o.createElement("select"),l=s.appendChild(o.createElement("option")),a=d.getElementsByTagName("input")[0],r.style.cssText="top:1px;float:left;opacity:.5",t={getSetAttribute:"t"!==d.className,leadingWhitespace:3===d.firstChild.nodeType,tbody:!d.getElementsByTagName("tbody").length,htmlSerialize:!!d.getElementsByTagName("link").length,style:/top/.test(r.getAttribute("style")),hrefNormalized:"/a"===r.getAttribute("href"),opacity:/^0.5/.test(r.style.opacity),cssFloat:!!r.style.cssFloat,checkOn:!!a.value,optSelected:l.selected,enctype:!!o.createElement("form").enctype,html5Clone:"<:nav></:nav>"!==o.createElement("nav").cloneNode(!0).outerHTML,boxModel:"CSS1Compat"===o.compatMode,deleteExpando:!0,noCloneEvent:!0,inlineBlockNeedsLayout:!1,shrinkWrapBlocks:!1,reliableMarginRight:!0,boxSizingReliable:!0,pixelPosition:!1},a.checked=!0,t.noCloneChecked=a.cloneNode(!0).checked,s.disabled=!0,t.optDisabled=!l.disabled;try{delete d.test}catch(h){t.deleteExpando=!1}a=o.createElement("input"),a.setAttribute("value",""),t.input=""===a.getAttribute("value"),a.value="t",a.setAttribute("type","radio"),t.radioValue="t"===a.value,a.setAttribute("checked","t"),a.setAttribute("name","t"),u=o.createDocumentFragment(),u.appendChild(a),t.appendChecked=a.checked,t.checkClone=u.cloneNode(!0).cloneNode(!0).lastChild.checked,d.attachEvent&&(d.attachEvent("onclick",function(){t.noCloneEvent=!1}),d.cloneNode(!0).click());for(f in{submit:!0,change:!0,focusin:!0})d.setAttribute(c="on"+f,"t"),t[f+"Bubbles"]=c in e||d.attributes[c].expando===!1;return d.style.backgroundClip="content-box",d.cloneNode(!0).style.backgroundClip="",t.clearCloneStyle="content-box"===d.style.backgroundClip,b(function(){var n,r,a,s="padding:0;margin:0;border:0;display:block;box-sizing:content-box;-moz-box-sizing:content-box;-webkit-box-sizing:content-box;",u=o.getElementsByTagName("body")[0];u&&(n=o.createElement("div"),n.style.cssText="border:0;width:0;height:0;position:absolute;top:0;left:-9999px;margin-top:1px",u.appendChild(n).appendChild(d),d.innerHTML="<table><tr><td></td><td>t</td></tr></table>",a=d.getElementsByTagName("td"),a[0].style.cssText="padding:0;margin:0;border:0;display:none",p=0===a[0].offsetHeight,a[0].style.display="",a[1].style.display="none",t.reliableHiddenOffsets=p&&0===a[0].offsetHeight,d.innerHTML="",d.style.cssText="box-sizing:border-box;-moz-box-sizing:border-box;-webkit-box-sizing:border-box;padding:1px;border:1px;display:block;width:4px;margin-top:1%;position:absolute;top:1%;",t.boxSizing=4===d.offsetWidth,t.doesNotIncludeMarginInBodyOffset=1!==u.offsetTop,e.getComputedStyle&&(t.pixelPosition="1%"!==(e.getComputedStyle(d,null)||{}).top,t.boxSizingReliable="4px"===(e.getComputedStyle(d,null)||{width:"4px"}).width,r=d.appendChild(o.createElement("div")),r.style.cssText=d.style.cssText=s,r.style.marginRight=r.style.width="0",d.style.width="1px",t.reliableMarginRight=!parseFloat((e.getComputedStyle(r,null)||{}).marginRight)),typeof d.style.zoom!==i&&(d.innerHTML="",d.style.cssText=s+"width:1px;padding:1px;display:inline;zoom:1",t.inlineBlockNeedsLayout=3===d.offsetWidth,d.style.display="block",d.innerHTML="<div></div>",d.firstChild.style.width="5px",t.shrinkWrapBlocks=3!==d.offsetWidth,t.inlineBlockNeedsLayout&&(u.style.zoom=1)),u.removeChild(n),n=d=a=r=null)}),n=s=u=l=r=a=null,t}();var O=/(?:\{[\s\S]*\}|\[[\s\S]*\])$/,B=/([A-Z])/g;function P(e,n,r,i){if(b.acceptData(e)){var o,a,s=b.expando,u="string"==typeof n,l=e.nodeType,p=l?b.cache:e,f=l?e[s]:e[s]&&s;if(f&&p[f]&&(i||p[f].data)||!u||r!==t)return f||(l?e[s]=f=c.pop()||b.guid++:f=s),p[f]||(p[f]={},l||(p[f].toJSON=b.noop)),("object"==typeof n||"function"==typeof n)&&(i?p[f]=b.extend(p[f],n):p[f].data=b.extend(p[f].data,n)),o=p[f],i||(o.data||(o.data={}),o=o.data),r!==t&&(o[b.camelCase(n)]=r),u?(a=o[n],null==a&&(a=o[b.camelCase(n)])):a=o,a}}function R(e,t,n){if(b.acceptData(e)){var r,i,o,a=e.nodeType,s=a?b.cache:e,u=a?e[b.expando]:b.expando;if(s[u]){if(t&&(o=n?s[u]:s[u].data)){b.isArray(t)?t=t.concat(b.map(t,b.camelCase)):t in o?t=[t]:(t=b.camelCase(t),t=t in o?[t]:t.split(" "));for(r=0,i=t.length;i>r;r++)delete o[t[r]];if(!(n?$:b.isEmptyObject)(o))return}(n||(delete s[u].data,$(s[u])))&&(a?b.cleanData([e],!0):b.support.deleteExpando||s!=s.window?delete s[u]:s[u]=null)}}}b.extend({cache:{},expando:"jQuery"+(p+Math.random()).replace(/\D/g,""),noData:{embed:!0,object:"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000",applet:!0},hasData:function(e){return e=e.nodeType?b.cache[e[b.expando]]:e[b.expando],!!e&&!$(e)},data:function(e,t,n){return P(e,t,n)},removeData:function(e,t){return R(e,t)},_data:function(e,t,n){return P(e,t,n,!0)},_removeData:function(e,t){return R(e,t,!0)},acceptData:function(e){if(e.nodeType&&1!==e.nodeType&&9!==e.nodeType)return!1;var t=e.nodeName&&b.noData[e.nodeName.toLowerCase()];return!t||t!==!0&&e.getAttribute("classid")===t}}),b.fn.extend({data:function(e,n){var r,i,o=this[0],a=0,s=null;if(e===t){if(this.length&&(s=b.data(o),1===o.nodeType&&!b._data(o,"parsedAttrs"))){for(r=o.attributes;r.length>a;a++)i=r[a].name,i.indexOf("data-")||(i=b.camelCase(i.slice(5)),W(o,i,s[i]));b._data(o,"parsedAttrs",!0)}return s}return"object"==typeof e?this.each(function(){b.data(this,e)}):b.access(this,function(n){return n===t?o?W(o,e,b.data(o,e)):null:(this.each(function(){b.data(this,e,n)}),t)},null,n,arguments.length>1,null,!0)},removeData:function(e){return this.each(function(){b.removeData(this,e)})}});function W(e,n,r){if(r===t&&1===e.nodeType){var i="data-"+n.replace(B,"-$1").toLowerCase();if(r=e.getAttribute(i),"string"==typeof r){try{r="true"===r?!0:"false"===r?!1:"null"===r?null:+r+""===r?+r:O.test(r)?b.parseJSON(r):r}catch(o){}b.data(e,n,r)}else r=t}return r}function $(e){var t;for(t in e)if(("data"!==t||!b.isEmptyObject(e[t]))&&"toJSON"!==t)return!1;return!0}b.extend({queue:function(e,n,r){var i;return e?(n=(n||"fx")+"queue",i=b._data(e,n),r&&(!i||b.isArray(r)?i=b._data(e,n,b.makeArray(r)):i.push(r)),i||[]):t},dequeue:function(e,t){t=t||"fx";var n=b.queue(e,t),r=n.length,i=n.shift(),o=b._queueHooks(e,t),a=function(){b.dequeue(e,t)};"inprogress"===i&&(i=n.shift(),r--),o.cur=i,i&&("fx"===t&&n.unshift("inprogress"),delete o.stop,i.call(e,a,o)),!r&&o&&o.empty.fire()},_queueHooks:function(e,t){var n=t+"queueHooks";return b._data(e,n)||b._data(e,n,{empty:b.Callbacks("once memory").add(function(){b._removeData(e,t+"queue"),b._removeData(e,n)})})}}),b.fn.extend({queue:function(e,n){var r=2;return"string"!=typeof e&&(n=e,e="fx",r--),r>arguments.length?b.queue(this[0],e):n===t?this:this.each(function(){var t=b.queue(this,e,n);b._queueHooks(this,e),"fx"===e&&"inprogress"!==t[0]&&b.dequeue(this,e)})},dequeue:function(e){return this.each(function(){b.dequeue(this,e)})},delay:function(e,t){return e=b.fx?b.fx.speeds[e]||e:e,t=t||"fx",this.queue(t,function(t,n){var r=setTimeout(t,e);n.stop=function(){clearTimeout(r)}})},clearQueue:function(e){return this.queue(e||"fx",[])},promise:function(e,n){var r,i=1,o=b.Deferred(),a=this,s=this.length,u=function(){--i||o.resolveWith(a,[a])};"string"!=typeof e&&(n=e,e=t),e=e||"fx";while(s--)r=b._data(a[s],e+"queueHooks"),r&&r.empty&&(i++,r.empty.add(u));return u(),o.promise(n)}});var I,z,X=/[\t\r\n]/g,U=/\r/g,V=/^(?:input|select|textarea|button|object)$/i,Y=/^(?:a|area)$/i,J=/^(?:checked|selected|autofocus|autoplay|async|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped)$/i,G=/^(?:checked|selected)$/i,Q=b.support.getSetAttribute,K=b.support.input;b.fn.extend({attr:function(e,t){return b.access(this,b.attr,e,t,arguments.length>1)},removeAttr:function(e){return this.each(function(){b.removeAttr(this,e)})},prop:function(e,t){return b.access(this,b.prop,e,t,arguments.length>1)},removeProp:function(e){return e=b.propFix[e]||e,this.each(function(){try{this[e]=t,delete this[e]}catch(n){}})},addClass:function(e){var t,n,r,i,o,a=0,s=this.length,u="string"==typeof e&&e;if(b.isFunction(e))return this.each(function(t){b(this).addClass(e.call(this,t,this.className))});if(u)for(t=(e||"").match(w)||[];s>a;a++)if(n=this[a],r=1===n.nodeType&&(n.className?(" "+n.className+" ").replace(X," "):" ")){o=0;while(i=t[o++])0>r.indexOf(" "+i+" ")&&(r+=i+" ");n.className=b.trim(r)}return this},removeClass:function(e){var t,n,r,i,o,a=0,s=this.length,u=0===arguments.length||"string"==typeof e&&e;if(b.isFunction(e))return this.each(function(t){b(this).removeClass(e.call(this,t,this.className))});if(u)for(t=(e||"").match(w)||[];s>a;a++)if(n=this[a],r=1===n.nodeType&&(n.className?(" "+n.className+" ").replace(X," "):"")){o=0;while(i=t[o++])while(r.indexOf(" "+i+" ")>=0)r=r.replace(" "+i+" "," ");n.className=e?b.trim(r):""}return this},toggleClass:function(e,t){var n=typeof e,r="boolean"==typeof t;return b.isFunction(e)?this.each(function(n){b(this).toggleClass(e.call(this,n,this.className,t),t)}):this.each(function(){if("string"===n){var o,a=0,s=b(this),u=t,l=e.match(w)||[];while(o=l[a++])u=r?u:!s.hasClass(o),s[u?"addClass":"removeClass"](o)}else(n===i||"boolean"===n)&&(this.className&&b._data(this,"__className__",this.className),this.className=this.className||e===!1?"":b._data(this,"__className__")||"")})},hasClass:function(e){var t=" "+e+" ",n=0,r=this.length;for(;r>n;n++)if(1===this[n].nodeType&&(" "+this[n].className+" ").replace(X," ").indexOf(t)>=0)return!0;return!1},val:function(e){var n,r,i,o=this[0];{if(arguments.length)return i=b.isFunction(e),this.each(function(n){var o,a=b(this);1===this.nodeType&&(o=i?e.call(this,n,a.val()):e,null==o?o="":"number"==typeof o?o+="":b.isArray(o)&&(o=b.map(o,function(e){return null==e?"":e+""})),r=b.valHooks[this.type]||b.valHooks[this.nodeName.toLowerCase()],r&&"set"in r&&r.set(this,o,"value")!==t||(this.value=o))});if(o)return r=b.valHooks[o.type]||b.valHooks[o.nodeName.toLowerCase()],r&&"get"in r&&(n=r.get(o,"value"))!==t?n:(n=o.value,"string"==typeof n?n.replace(U,""):null==n?"":n)}}}),b.extend({valHooks:{option:{get:function(e){var t=e.attributes.value;return!t||t.specified?e.value:e.text}},select:{get:function(e){var t,n,r=e.options,i=e.selectedIndex,o="select-one"===e.type||0>i,a=o?null:[],s=o?i+1:r.length,u=0>i?s:o?i:0;for(;s>u;u++)if(n=r[u],!(!n.selected&&u!==i||(b.support.optDisabled?n.disabled:null!==n.getAttribute("disabled"))||n.parentNode.disabled&&b.nodeName(n.parentNode,"optgroup"))){if(t=b(n).val(),o)return t;a.push(t)}return a},set:function(e,t){var n=b.makeArray(t);return b(e).find("option").each(function(){this.selected=b.inArray(b(this).val(),n)>=0}),n.length||(e.selectedIndex=-1),n}}},attr:function(e,n,r){var o,a,s,u=e.nodeType;if(e&&3!==u&&8!==u&&2!==u)return typeof e.getAttribute===i?b.prop(e,n,r):(a=1!==u||!b.isXMLDoc(e),a&&(n=n.toLowerCase(),o=b.attrHooks[n]||(J.test(n)?z:I)),r===t?o&&a&&"get"in o&&null!==(s=o.get(e,n))?s:(typeof e.getAttribute!==i&&(s=e.getAttribute(n)),null==s?t:s):null!==r?o&&a&&"set"in o&&(s=o.set(e,r,n))!==t?s:(e.setAttribute(n,r+""),r):(b.removeAttr(e,n),t))},removeAttr:function(e,t){var n,r,i=0,o=t&&t.match(w);if(o&&1===e.nodeType)while(n=o[i++])r=b.propFix[n]||n,J.test(n)?!Q&&G.test(n)?e[b.camelCase("default-"+n)]=e[r]=!1:e[r]=!1:b.attr(e,n,""),e.removeAttribute(Q?n:r)},attrHooks:{type:{set:function(e,t){if(!b.support.radioValue&&"radio"===t&&b.nodeName(e,"input")){var n=e.value;return e.setAttribute("type",t),n&&(e.value=n),t}}}},propFix:{tabindex:"tabIndex",readonly:"readOnly","for":"htmlFor","class":"className",maxlength:"maxLength",cellspacing:"cellSpacing",cellpadding:"cellPadding",rowspan:"rowSpan",colspan:"colSpan",usemap:"useMap",frameborder:"frameBorder",contenteditable:"contentEditable"},prop:function(e,n,r){var i,o,a,s=e.nodeType;if(e&&3!==s&&8!==s&&2!==s)return a=1!==s||!b.isXMLDoc(e),a&&(n=b.propFix[n]||n,o=b.propHooks[n]),r!==t?o&&"set"in o&&(i=o.set(e,r,n))!==t?i:e[n]=r:o&&"get"in o&&null!==(i=o.get(e,n))?i:e[n]},propHooks:{tabIndex:{get:function(e){var n=e.getAttributeNode("tabindex");return n&&n.specified?parseInt(n.value,10):V.test(e.nodeName)||Y.test(e.nodeName)&&e.href?0:t}}}}),z={get:function(e,n){var r=b.prop(e,n),i="boolean"==typeof r&&e.getAttribute(n),o="boolean"==typeof r?K&&Q?null!=i:G.test(n)?e[b.camelCase("default-"+n)]:!!i:e.getAttributeNode(n);return o&&o.value!==!1?n.toLowerCase():t},set:function(e,t,n){return t===!1?b.removeAttr(e,n):K&&Q||!G.test(n)?e.setAttribute(!Q&&b.propFix[n]||n,n):e[b.camelCase("default-"+n)]=e[n]=!0,n}},K&&Q||(b.attrHooks.value={get:function(e,n){var r=e.getAttributeNode(n);return b.nodeName(e,"input")?e.defaultValue:r&&r.specified?r.value:t},set:function(e,n,r){return b.nodeName(e,"input")?(e.defaultValue=n,t):I&&I.set(e,n,r)}}),Q||(I=b.valHooks.button={get:function(e,n){var r=e.getAttributeNode(n);return r&&("id"===n||"name"===n||"coords"===n?""!==r.value:r.specified)?r.value:t},set:function(e,n,r){var i=e.getAttributeNode(r);return i||e.setAttributeNode(i=e.ownerDocument.createAttribute(r)),i.value=n+="","value"===r||n===e.getAttribute(r)?n:t}},b.attrHooks.contenteditable={get:I.get,set:function(e,t,n){I.set(e,""===t?!1:t,n)}},b.each(["width","height"],function(e,n){b.attrHooks[n]=b.extend(b.attrHooks[n],{set:function(e,r){return""===r?(e.setAttribute(n,"auto"),r):t}})})),b.support.hrefNormalized||(b.each(["href","src","width","height"],function(e,n){b.attrHooks[n]=b.extend(b.attrHooks[n],{get:function(e){var r=e.getAttribute(n,2);return null==r?t:r}})}),b.each(["href","src"],function(e,t){b.propHooks[t]={get:function(e){return e.getAttribute(t,4)}}})),b.support.style||(b.attrHooks.style={get:function(e){return e.style.cssText||t},set:function(e,t){return e.style.cssText=t+""}}),b.support.optSelected||(b.propHooks.selected=b.extend(b.propHooks.selected,{get:function(e){var t=e.parentNode;return t&&(t.selectedIndex,t.parentNode&&t.parentNode.selectedIndex),null}})),b.support.enctype||(b.propFix.enctype="encoding"),b.support.checkOn||b.each(["radio","checkbox"],function(){b.valHooks[this]={get:function(e){return null===e.getAttribute("value")?"on":e.value}}}),b.each(["radio","checkbox"],function(){b.valHooks[this]=b.extend(b.valHooks[this],{set:function(e,n){return b.isArray(n)?e.checked=b.inArray(b(e).val(),n)>=0:t}})});var Z=/^(?:input|select|textarea)$/i,et=/^key/,tt=/^(?:mouse|contextmenu)|click/,nt=/^(?:focusinfocus|focusoutblur)$/,rt=/^([^.]*)(?:\.(.+)|)$/;function it(){return!0}function ot(){return!1}b.event={global:{},add:function(e,n,r,o,a){var s,u,l,c,p,f,d,h,g,m,y,v=b._data(e);if(v){r.handler&&(c=r,r=c.handler,a=c.selector),r.guid||(r.guid=b.guid++),(u=v.events)||(u=v.events={}),(f=v.handle)||(f=v.handle=function(e){return typeof b===i||e&&b.event.triggered===e.type?t:b.event.dispatch.apply(f.elem,arguments)},f.elem=e),n=(n||"").match(w)||[""],l=n.length;while(l--)s=rt.exec(n[l])||[],g=y=s[1],m=(s[2]||"").split(".").sort(),p=b.event.special[g]||{},g=(a?p.delegateType:p.bindType)||g,p=b.event.special[g]||{},d=b.extend({type:g,origType:y,data:o,handler:r,guid:r.guid,selector:a,needsContext:a&&b.expr.match.needsContext.test(a),namespace:m.join(".")},c),(h=u[g])||(h=u[g]=[],h.delegateCount=0,p.setup&&p.setup.call(e,o,m,f)!==!1||(e.addEventListener?e.addEventListener(g,f,!1):e.attachEvent&&e.attachEvent("on"+g,f))),p.add&&(p.add.call(e,d),d.handler.guid||(d.handler.guid=r.guid)),a?h.splice(h.delegateCount++,0,d):h.push(d),b.event.global[g]=!0;e=null}},remove:function(e,t,n,r,i){var o,a,s,u,l,c,p,f,d,h,g,m=b.hasData(e)&&b._data(e);if(m&&(c=m.events)){t=(t||"").match(w)||[""],l=t.length;while(l--)if(s=rt.exec(t[l])||[],d=g=s[1],h=(s[2]||"").split(".").sort(),d){p=b.event.special[d]||{},d=(r?p.delegateType:p.bindType)||d,f=c[d]||[],s=s[2]&&RegExp("(^|\\.)"+h.join("\\.(?:.*\\.|)")+"(\\.|$)"),u=o=f.length;while(o--)a=f[o],!i&&g!==a.origType||n&&n.guid!==a.guid||s&&!s.test(a.namespace)||r&&r!==a.selector&&("**"!==r||!a.selector)||(f.splice(o,1),a.selector&&f.delegateCount--,p.remove&&p.remove.call(e,a));u&&!f.length&&(p.teardown&&p.teardown.call(e,h,m.handle)!==!1||b.removeEvent(e,d,m.handle),delete c[d])}else for(d in c)b.event.remove(e,d+t[l],n,r,!0);b.isEmptyObject(c)&&(delete m.handle,b._removeData(e,"events"))}},trigger:function(n,r,i,a){var s,u,l,c,p,f,d,h=[i||o],g=y.call(n,"type")?n.type:n,m=y.call(n,"namespace")?n.namespace.split("."):[];if(l=f=i=i||o,3!==i.nodeType&&8!==i.nodeType&&!nt.test(g+b.event.triggered)&&(g.indexOf(".")>=0&&(m=g.split("."),g=m.shift(),m.sort()),u=0>g.indexOf(":")&&"on"+g,n=n[b.expando]?n:new b.Event(g,"object"==typeof n&&n),n.isTrigger=!0,n.namespace=m.join("."),n.namespace_re=n.namespace?RegExp("(^|\\.)"+m.join("\\.(?:.*\\.|)")+"(\\.|$)"):null,n.result=t,n.target||(n.target=i),r=null==r?[n]:b.makeArray(r,[n]),p=b.event.special[g]||{},a||!p.trigger||p.trigger.apply(i,r)!==!1)){if(!a&&!p.noBubble&&!b.isWindow(i)){for(c=p.delegateType||g,nt.test(c+g)||(l=l.parentNode);l;l=l.parentNode)h.push(l),f=l;f===(i.ownerDocument||o)&&h.push(f.defaultView||f.parentWindow||e)}d=0;while((l=h[d++])&&!n.isPropagationStopped())n.type=d>1?c:p.bindType||g,s=(b._data(l,"events")||{})[n.type]&&b._data(l,"handle"),s&&s.apply(l,r),s=u&&l[u],s&&b.acceptData(l)&&s.apply&&s.apply(l,r)===!1&&n.preventDefault();if(n.type=g,!(a||n.isDefaultPrevented()||p._default&&p._default.apply(i.ownerDocument,r)!==!1||"click"===g&&b.nodeName(i,"a")||!b.acceptData(i)||!u||!i[g]||b.isWindow(i))){f=i[u],f&&(i[u]=null),b.event.triggered=g;try{i[g]()}catch(v){}b.event.triggered=t,f&&(i[u]=f)}return n.result}},dispatch:function(e){e=b.event.fix(e);var n,r,i,o,a,s=[],u=h.call(arguments),l=(b._data(this,"events")||{})[e.type]||[],c=b.event.special[e.type]||{};if(u[0]=e,e.delegateTarget=this,!c.preDispatch||c.preDispatch.call(this,e)!==!1){s=b.event.handlers.call(this,e,l),n=0;while((o=s[n++])&&!e.isPropagationStopped()){e.currentTarget=o.elem,a=0;while((i=o.handlers[a++])&&!e.isImmediatePropagationStopped())(!e.namespace_re||e.namespace_re.test(i.namespace))&&(e.handleObj=i,e.data=i.data,r=((b.event.special[i.origType]||{}).handle||i.handler).apply(o.elem,u),r!==t&&(e.result=r)===!1&&(e.preventDefault(),e.stopPropagation()))}return c.postDispatch&&c.postDispatch.call(this,e),e.result}},handlers:function(e,n){var r,i,o,a,s=[],u=n.delegateCount,l=e.target;if(u&&l.nodeType&&(!e.button||"click"!==e.type))for(;l!=this;l=l.parentNode||this)if(1===l.nodeType&&(l.disabled!==!0||"click"!==e.type)){for(o=[],a=0;u>a;a++)i=n[a],r=i.selector+" ",o[r]===t&&(o[r]=i.needsContext?b(r,this).index(l)>=0:b.find(r,this,null,[l]).length),o[r]&&o.push(i);o.length&&s.push({elem:l,handlers:o})}return n.length>u&&s.push({elem:this,handlers:n.slice(u)}),s},fix:function(e){if(e[b.expando])return e;var t,n,r,i=e.type,a=e,s=this.fixHooks[i];s||(this.fixHooks[i]=s=tt.test(i)?this.mouseHooks:et.test(i)?this.keyHooks:{}),r=s.props?this.props.concat(s.props):this.props,e=new b.Event(a),t=r.length;while(t--)n=r[t],e[n]=a[n];return e.target||(e.target=a.srcElement||o),3===e.target.nodeType&&(e.target=e.target.parentNode),e.metaKey=!!e.metaKey,s.filter?s.filter(e,a):e},props:"altKey bubbles cancelable ctrlKey currentTarget eventPhase metaKey relatedTarget shiftKey target timeStamp view which".split(" "),fixHooks:{},keyHooks:{props:"char charCode key keyCode".split(" "),filter:function(e,t){return null==e.which&&(e.which=null!=t.charCode?t.charCode:t.keyCode),e}},mouseHooks:{props:"button buttons clientX clientY fromElement offsetX offsetY pageX pageY screenX screenY toElement".split(" "),filter:function(e,n){var r,i,a,s=n.button,u=n.fromElement;return null==e.pageX&&null!=n.clientX&&(i=e.target.ownerDocument||o,a=i.documentElement,r=i.body,e.pageX=n.clientX+(a&&a.scrollLeft||r&&r.scrollLeft||0)-(a&&a.clientLeft||r&&r.clientLeft||0),e.pageY=n.clientY+(a&&a.scrollTop||r&&r.scrollTop||0)-(a&&a.clientTop||r&&r.clientTop||0)),!e.relatedTarget&&u&&(e.relatedTarget=u===e.target?n.toElement:u),e.which||s===t||(e.which=1&s?1:2&s?3:4&s?2:0),e}},special:{load:{noBubble:!0},click:{trigger:function(){return b.nodeName(this,"input")&&"checkbox"===this.type&&this.click?(this.click(),!1):t}},focus:{trigger:function(){if(this!==o.activeElement&&this.focus)try{return this.focus(),!1}catch(e){}},delegateType:"focusin"},blur:{trigger:function(){return this===o.activeElement&&this.blur?(this.blur(),!1):t},delegateType:"focusout"},beforeunload:{postDispatch:function(e){e.result!==t&&(e.originalEvent.returnValue=e.result)}}},simulate:function(e,t,n,r){var i=b.extend(new b.Event,n,{type:e,isSimulated:!0,originalEvent:{}});r?b.event.trigger(i,null,t):b.event.dispatch.call(t,i),i.isDefaultPrevented()&&n.preventDefault()}},b.removeEvent=o.removeEventListener?function(e,t,n){e.removeEventListener&&e.removeEventListener(t,n,!1)}:function(e,t,n){var r="on"+t;e.detachEvent&&(typeof e[r]===i&&(e[r]=null),e.detachEvent(r,n))},b.Event=function(e,n){return this instanceof b.Event?(e&&e.type?(this.originalEvent=e,this.type=e.type,this.isDefaultPrevented=e.defaultPrevented||e.returnValue===!1||e.getPreventDefault&&e.getPreventDefault()?it:ot):this.type=e,n&&b.extend(this,n),this.timeStamp=e&&e.timeStamp||b.now(),this[b.expando]=!0,t):new b.Event(e,n)},b.Event.prototype={isDefaultPrevented:ot,isPropagationStopped:ot,isImmediatePropagationStopped:ot,preventDefault:function(){var e=this.originalEvent;this.isDefaultPrevented=it,e&&(e.preventDefault?e.preventDefault():e.returnValue=!1)},stopPropagation:function(){var e=this.originalEvent;this.isPropagationStopped=it,e&&(e.stopPropagation&&e.stopPropagation(),e.cancelBubble=!0)},stopImmediatePropagation:function(){this.isImmediatePropagationStopped=it,this.stopPropagation()}},b.each({mouseenter:"mouseover",mouseleave:"mouseout"},function(e,t){b.event.special[e]={delegateType:t,bindType:t,handle:function(e){var n,r=this,i=e.relatedTarget,o=e.handleObj;
return(!i||i!==r&&!b.contains(r,i))&&(e.type=o.origType,n=o.handler.apply(this,arguments),e.type=t),n}}}),b.support.submitBubbles||(b.event.special.submit={setup:function(){return b.nodeName(this,"form")?!1:(b.event.add(this,"click._submit keypress._submit",function(e){var n=e.target,r=b.nodeName(n,"input")||b.nodeName(n,"button")?n.form:t;r&&!b._data(r,"submitBubbles")&&(b.event.add(r,"submit._submit",function(e){e._submit_bubble=!0}),b._data(r,"submitBubbles",!0))}),t)},postDispatch:function(e){e._submit_bubble&&(delete e._submit_bubble,this.parentNode&&!e.isTrigger&&b.event.simulate("submit",this.parentNode,e,!0))},teardown:function(){return b.nodeName(this,"form")?!1:(b.event.remove(this,"._submit"),t)}}),b.support.changeBubbles||(b.event.special.change={setup:function(){return Z.test(this.nodeName)?(("checkbox"===this.type||"radio"===this.type)&&(b.event.add(this,"propertychange._change",function(e){"checked"===e.originalEvent.propertyName&&(this._just_changed=!0)}),b.event.add(this,"click._change",function(e){this._just_changed&&!e.isTrigger&&(this._just_changed=!1),b.event.simulate("change",this,e,!0)})),!1):(b.event.add(this,"beforeactivate._change",function(e){var t=e.target;Z.test(t.nodeName)&&!b._data(t,"changeBubbles")&&(b.event.add(t,"change._change",function(e){!this.parentNode||e.isSimulated||e.isTrigger||b.event.simulate("change",this.parentNode,e,!0)}),b._data(t,"changeBubbles",!0))}),t)},handle:function(e){var n=e.target;return this!==n||e.isSimulated||e.isTrigger||"radio"!==n.type&&"checkbox"!==n.type?e.handleObj.handler.apply(this,arguments):t},teardown:function(){return b.event.remove(this,"._change"),!Z.test(this.nodeName)}}),b.support.focusinBubbles||b.each({focus:"focusin",blur:"focusout"},function(e,t){var n=0,r=function(e){b.event.simulate(t,e.target,b.event.fix(e),!0)};b.event.special[t]={setup:function(){0===n++&&o.addEventListener(e,r,!0)},teardown:function(){0===--n&&o.removeEventListener(e,r,!0)}}}),b.fn.extend({on:function(e,n,r,i,o){var a,s;if("object"==typeof e){"string"!=typeof n&&(r=r||n,n=t);for(a in e)this.on(a,n,r,e[a],o);return this}if(null==r&&null==i?(i=n,r=n=t):null==i&&("string"==typeof n?(i=r,r=t):(i=r,r=n,n=t)),i===!1)i=ot;else if(!i)return this;return 1===o&&(s=i,i=function(e){return b().off(e),s.apply(this,arguments)},i.guid=s.guid||(s.guid=b.guid++)),this.each(function(){b.event.add(this,e,i,r,n)})},one:function(e,t,n,r){return this.on(e,t,n,r,1)},off:function(e,n,r){var i,o;if(e&&e.preventDefault&&e.handleObj)return i=e.handleObj,b(e.delegateTarget).off(i.namespace?i.origType+"."+i.namespace:i.origType,i.selector,i.handler),this;if("object"==typeof e){for(o in e)this.off(o,n,e[o]);return this}return(n===!1||"function"==typeof n)&&(r=n,n=t),r===!1&&(r=ot),this.each(function(){b.event.remove(this,e,r,n)})},bind:function(e,t,n){return this.on(e,null,t,n)},unbind:function(e,t){return this.off(e,null,t)},delegate:function(e,t,n,r){return this.on(t,e,n,r)},undelegate:function(e,t,n){return 1===arguments.length?this.off(e,"**"):this.off(t,e||"**",n)},trigger:function(e,t){return this.each(function(){b.event.trigger(e,t,this)})},triggerHandler:function(e,n){var r=this[0];return r?b.event.trigger(e,n,r,!0):t}}),function(e,t){var n,r,i,o,a,s,u,l,c,p,f,d,h,g,m,y,v,x="sizzle"+-new Date,w=e.document,T={},N=0,C=0,k=it(),E=it(),S=it(),A=typeof t,j=1<<31,D=[],L=D.pop,H=D.push,q=D.slice,M=D.indexOf||function(e){var t=0,n=this.length;for(;n>t;t++)if(this[t]===e)return t;return-1},_="[\\x20\\t\\r\\n\\f]",F="(?:\\\\.|[\\w-]|[^\\x00-\\xa0])+",O=F.replace("w","w#"),B="([*^$|!~]?=)",P="\\["+_+"*("+F+")"+_+"*(?:"+B+_+"*(?:(['\"])((?:\\\\.|[^\\\\])*?)\\3|("+O+")|)|)"+_+"*\\]",R=":("+F+")(?:\\(((['\"])((?:\\\\.|[^\\\\])*?)\\3|((?:\\\\.|[^\\\\()[\\]]|"+P.replace(3,8)+")*)|.*)\\)|)",W=RegExp("^"+_+"+|((?:^|[^\\\\])(?:\\\\.)*)"+_+"+$","g"),$=RegExp("^"+_+"*,"+_+"*"),I=RegExp("^"+_+"*([\\x20\\t\\r\\n\\f>+~])"+_+"*"),z=RegExp(R),X=RegExp("^"+O+"$"),U={ID:RegExp("^#("+F+")"),CLASS:RegExp("^\\.("+F+")"),NAME:RegExp("^\\[name=['\"]?("+F+")['\"]?\\]"),TAG:RegExp("^("+F.replace("w","w*")+")"),ATTR:RegExp("^"+P),PSEUDO:RegExp("^"+R),CHILD:RegExp("^:(only|first|last|nth|nth-last)-(child|of-type)(?:\\("+_+"*(even|odd|(([+-]|)(\\d*)n|)"+_+"*(?:([+-]|)"+_+"*(\\d+)|))"+_+"*\\)|)","i"),needsContext:RegExp("^"+_+"*[>+~]|:(even|odd|eq|gt|lt|nth|first|last)(?:\\("+_+"*((?:-\\d)?\\d*)"+_+"*\\)|)(?=[^-]|$)","i")},V=/[\x20\t\r\n\f]*[+~]/,Y=/^[^{]+\{\s*\[native code/,J=/^(?:#([\w-]+)|(\w+)|\.([\w-]+))$/,G=/^(?:input|select|textarea|button)$/i,Q=/^h\d$/i,K=/'|\\/g,Z=/\=[\x20\t\r\n\f]*([^'"\]]*)[\x20\t\r\n\f]*\]/g,et=/\\([\da-fA-F]{1,6}[\x20\t\r\n\f]?|.)/g,tt=function(e,t){var n="0x"+t-65536;return n!==n?t:0>n?String.fromCharCode(n+65536):String.fromCharCode(55296|n>>10,56320|1023&n)};try{q.call(w.documentElement.childNodes,0)[0].nodeType}catch(nt){q=function(e){var t,n=[];while(t=this[e++])n.push(t);return n}}function rt(e){return Y.test(e+"")}function it(){var e,t=[];return e=function(n,r){return t.push(n+=" ")>i.cacheLength&&delete e[t.shift()],e[n]=r}}function ot(e){return e[x]=!0,e}function at(e){var t=p.createElement("div");try{return e(t)}catch(n){return!1}finally{t=null}}function st(e,t,n,r){var i,o,a,s,u,l,f,g,m,v;if((t?t.ownerDocument||t:w)!==p&&c(t),t=t||p,n=n||[],!e||"string"!=typeof e)return n;if(1!==(s=t.nodeType)&&9!==s)return[];if(!d&&!r){if(i=J.exec(e))if(a=i[1]){if(9===s){if(o=t.getElementById(a),!o||!o.parentNode)return n;if(o.id===a)return n.push(o),n}else if(t.ownerDocument&&(o=t.ownerDocument.getElementById(a))&&y(t,o)&&o.id===a)return n.push(o),n}else{if(i[2])return H.apply(n,q.call(t.getElementsByTagName(e),0)),n;if((a=i[3])&&T.getByClassName&&t.getElementsByClassName)return H.apply(n,q.call(t.getElementsByClassName(a),0)),n}if(T.qsa&&!h.test(e)){if(f=!0,g=x,m=t,v=9===s&&e,1===s&&"object"!==t.nodeName.toLowerCase()){l=ft(e),(f=t.getAttribute("id"))?g=f.replace(K,"\\$&"):t.setAttribute("id",g),g="[id='"+g+"'] ",u=l.length;while(u--)l[u]=g+dt(l[u]);m=V.test(e)&&t.parentNode||t,v=l.join(",")}if(v)try{return H.apply(n,q.call(m.querySelectorAll(v),0)),n}catch(b){}finally{f||t.removeAttribute("id")}}}return wt(e.replace(W,"$1"),t,n,r)}a=st.isXML=function(e){var t=e&&(e.ownerDocument||e).documentElement;return t?"HTML"!==t.nodeName:!1},c=st.setDocument=function(e){var n=e?e.ownerDocument||e:w;return n!==p&&9===n.nodeType&&n.documentElement?(p=n,f=n.documentElement,d=a(n),T.tagNameNoComments=at(function(e){return e.appendChild(n.createComment("")),!e.getElementsByTagName("*").length}),T.attributes=at(function(e){e.innerHTML="<select></select>";var t=typeof e.lastChild.getAttribute("multiple");return"boolean"!==t&&"string"!==t}),T.getByClassName=at(function(e){return e.innerHTML="<div class='hidden e'></div><div class='hidden'></div>",e.getElementsByClassName&&e.getElementsByClassName("e").length?(e.lastChild.className="e",2===e.getElementsByClassName("e").length):!1}),T.getByName=at(function(e){e.id=x+0,e.innerHTML="<a name='"+x+"'></a><div name='"+x+"'></div>",f.insertBefore(e,f.firstChild);var t=n.getElementsByName&&n.getElementsByName(x).length===2+n.getElementsByName(x+0).length;return T.getIdNotName=!n.getElementById(x),f.removeChild(e),t}),i.attrHandle=at(function(e){return e.innerHTML="<a href='#'></a>",e.firstChild&&typeof e.firstChild.getAttribute!==A&&"#"===e.firstChild.getAttribute("href")})?{}:{href:function(e){return e.getAttribute("href",2)},type:function(e){return e.getAttribute("type")}},T.getIdNotName?(i.find.ID=function(e,t){if(typeof t.getElementById!==A&&!d){var n=t.getElementById(e);return n&&n.parentNode?[n]:[]}},i.filter.ID=function(e){var t=e.replace(et,tt);return function(e){return e.getAttribute("id")===t}}):(i.find.ID=function(e,n){if(typeof n.getElementById!==A&&!d){var r=n.getElementById(e);return r?r.id===e||typeof r.getAttributeNode!==A&&r.getAttributeNode("id").value===e?[r]:t:[]}},i.filter.ID=function(e){var t=e.replace(et,tt);return function(e){var n=typeof e.getAttributeNode!==A&&e.getAttributeNode("id");return n&&n.value===t}}),i.find.TAG=T.tagNameNoComments?function(e,n){return typeof n.getElementsByTagName!==A?n.getElementsByTagName(e):t}:function(e,t){var n,r=[],i=0,o=t.getElementsByTagName(e);if("*"===e){while(n=o[i++])1===n.nodeType&&r.push(n);return r}return o},i.find.NAME=T.getByName&&function(e,n){return typeof n.getElementsByName!==A?n.getElementsByName(name):t},i.find.CLASS=T.getByClassName&&function(e,n){return typeof n.getElementsByClassName===A||d?t:n.getElementsByClassName(e)},g=[],h=[":focus"],(T.qsa=rt(n.querySelectorAll))&&(at(function(e){e.innerHTML="<select><option selected=''></option></select>",e.querySelectorAll("[selected]").length||h.push("\\["+_+"*(?:checked|disabled|ismap|multiple|readonly|selected|value)"),e.querySelectorAll(":checked").length||h.push(":checked")}),at(function(e){e.innerHTML="<input type='hidden' i=''/>",e.querySelectorAll("[i^='']").length&&h.push("[*^$]="+_+"*(?:\"\"|'')"),e.querySelectorAll(":enabled").length||h.push(":enabled",":disabled"),e.querySelectorAll("*,:x"),h.push(",.*:")})),(T.matchesSelector=rt(m=f.matchesSelector||f.mozMatchesSelector||f.webkitMatchesSelector||f.oMatchesSelector||f.msMatchesSelector))&&at(function(e){T.disconnectedMatch=m.call(e,"div"),m.call(e,"[s!='']:x"),g.push("!=",R)}),h=RegExp(h.join("|")),g=RegExp(g.join("|")),y=rt(f.contains)||f.compareDocumentPosition?function(e,t){var n=9===e.nodeType?e.documentElement:e,r=t&&t.parentNode;return e===r||!(!r||1!==r.nodeType||!(n.contains?n.contains(r):e.compareDocumentPosition&&16&e.compareDocumentPosition(r)))}:function(e,t){if(t)while(t=t.parentNode)if(t===e)return!0;return!1},v=f.compareDocumentPosition?function(e,t){var r;return e===t?(u=!0,0):(r=t.compareDocumentPosition&&e.compareDocumentPosition&&e.compareDocumentPosition(t))?1&r||e.parentNode&&11===e.parentNode.nodeType?e===n||y(w,e)?-1:t===n||y(w,t)?1:0:4&r?-1:1:e.compareDocumentPosition?-1:1}:function(e,t){var r,i=0,o=e.parentNode,a=t.parentNode,s=[e],l=[t];if(e===t)return u=!0,0;if(!o||!a)return e===n?-1:t===n?1:o?-1:a?1:0;if(o===a)return ut(e,t);r=e;while(r=r.parentNode)s.unshift(r);r=t;while(r=r.parentNode)l.unshift(r);while(s[i]===l[i])i++;return i?ut(s[i],l[i]):s[i]===w?-1:l[i]===w?1:0},u=!1,[0,0].sort(v),T.detectDuplicates=u,p):p},st.matches=function(e,t){return st(e,null,null,t)},st.matchesSelector=function(e,t){if((e.ownerDocument||e)!==p&&c(e),t=t.replace(Z,"='$1']"),!(!T.matchesSelector||d||g&&g.test(t)||h.test(t)))try{var n=m.call(e,t);if(n||T.disconnectedMatch||e.document&&11!==e.document.nodeType)return n}catch(r){}return st(t,p,null,[e]).length>0},st.contains=function(e,t){return(e.ownerDocument||e)!==p&&c(e),y(e,t)},st.attr=function(e,t){var n;return(e.ownerDocument||e)!==p&&c(e),d||(t=t.toLowerCase()),(n=i.attrHandle[t])?n(e):d||T.attributes?e.getAttribute(t):((n=e.getAttributeNode(t))||e.getAttribute(t))&&e[t]===!0?t:n&&n.specified?n.value:null},st.error=function(e){throw Error("Syntax error, unrecognized expression: "+e)},st.uniqueSort=function(e){var t,n=[],r=1,i=0;if(u=!T.detectDuplicates,e.sort(v),u){for(;t=e[r];r++)t===e[r-1]&&(i=n.push(r));while(i--)e.splice(n[i],1)}return e};function ut(e,t){var n=t&&e,r=n&&(~t.sourceIndex||j)-(~e.sourceIndex||j);if(r)return r;if(n)while(n=n.nextSibling)if(n===t)return-1;return e?1:-1}function lt(e){return function(t){var n=t.nodeName.toLowerCase();return"input"===n&&t.type===e}}function ct(e){return function(t){var n=t.nodeName.toLowerCase();return("input"===n||"button"===n)&&t.type===e}}function pt(e){return ot(function(t){return t=+t,ot(function(n,r){var i,o=e([],n.length,t),a=o.length;while(a--)n[i=o[a]]&&(n[i]=!(r[i]=n[i]))})})}o=st.getText=function(e){var t,n="",r=0,i=e.nodeType;if(i){if(1===i||9===i||11===i){if("string"==typeof e.textContent)return e.textContent;for(e=e.firstChild;e;e=e.nextSibling)n+=o(e)}else if(3===i||4===i)return e.nodeValue}else for(;t=e[r];r++)n+=o(t);return n},i=st.selectors={cacheLength:50,createPseudo:ot,match:U,find:{},relative:{">":{dir:"parentNode",first:!0}," ":{dir:"parentNode"},"+":{dir:"previousSibling",first:!0},"~":{dir:"previousSibling"}},preFilter:{ATTR:function(e){return e[1]=e[1].replace(et,tt),e[3]=(e[4]||e[5]||"").replace(et,tt),"~="===e[2]&&(e[3]=" "+e[3]+" "),e.slice(0,4)},CHILD:function(e){return e[1]=e[1].toLowerCase(),"nth"===e[1].slice(0,3)?(e[3]||st.error(e[0]),e[4]=+(e[4]?e[5]+(e[6]||1):2*("even"===e[3]||"odd"===e[3])),e[5]=+(e[7]+e[8]||"odd"===e[3])):e[3]&&st.error(e[0]),e},PSEUDO:function(e){var t,n=!e[5]&&e[2];return U.CHILD.test(e[0])?null:(e[4]?e[2]=e[4]:n&&z.test(n)&&(t=ft(n,!0))&&(t=n.indexOf(")",n.length-t)-n.length)&&(e[0]=e[0].slice(0,t),e[2]=n.slice(0,t)),e.slice(0,3))}},filter:{TAG:function(e){return"*"===e?function(){return!0}:(e=e.replace(et,tt).toLowerCase(),function(t){return t.nodeName&&t.nodeName.toLowerCase()===e})},CLASS:function(e){var t=k[e+" "];return t||(t=RegExp("(^|"+_+")"+e+"("+_+"|$)"))&&k(e,function(e){return t.test(e.className||typeof e.getAttribute!==A&&e.getAttribute("class")||"")})},ATTR:function(e,t,n){return function(r){var i=st.attr(r,e);return null==i?"!="===t:t?(i+="","="===t?i===n:"!="===t?i!==n:"^="===t?n&&0===i.indexOf(n):"*="===t?n&&i.indexOf(n)>-1:"$="===t?n&&i.slice(-n.length)===n:"~="===t?(" "+i+" ").indexOf(n)>-1:"|="===t?i===n||i.slice(0,n.length+1)===n+"-":!1):!0}},CHILD:function(e,t,n,r,i){var o="nth"!==e.slice(0,3),a="last"!==e.slice(-4),s="of-type"===t;return 1===r&&0===i?function(e){return!!e.parentNode}:function(t,n,u){var l,c,p,f,d,h,g=o!==a?"nextSibling":"previousSibling",m=t.parentNode,y=s&&t.nodeName.toLowerCase(),v=!u&&!s;if(m){if(o){while(g){p=t;while(p=p[g])if(s?p.nodeName.toLowerCase()===y:1===p.nodeType)return!1;h=g="only"===e&&!h&&"nextSibling"}return!0}if(h=[a?m.firstChild:m.lastChild],a&&v){c=m[x]||(m[x]={}),l=c[e]||[],d=l[0]===N&&l[1],f=l[0]===N&&l[2],p=d&&m.childNodes[d];while(p=++d&&p&&p[g]||(f=d=0)||h.pop())if(1===p.nodeType&&++f&&p===t){c[e]=[N,d,f];break}}else if(v&&(l=(t[x]||(t[x]={}))[e])&&l[0]===N)f=l[1];else while(p=++d&&p&&p[g]||(f=d=0)||h.pop())if((s?p.nodeName.toLowerCase()===y:1===p.nodeType)&&++f&&(v&&((p[x]||(p[x]={}))[e]=[N,f]),p===t))break;return f-=i,f===r||0===f%r&&f/r>=0}}},PSEUDO:function(e,t){var n,r=i.pseudos[e]||i.setFilters[e.toLowerCase()]||st.error("unsupported pseudo: "+e);return r[x]?r(t):r.length>1?(n=[e,e,"",t],i.setFilters.hasOwnProperty(e.toLowerCase())?ot(function(e,n){var i,o=r(e,t),a=o.length;while(a--)i=M.call(e,o[a]),e[i]=!(n[i]=o[a])}):function(e){return r(e,0,n)}):r}},pseudos:{not:ot(function(e){var t=[],n=[],r=s(e.replace(W,"$1"));return r[x]?ot(function(e,t,n,i){var o,a=r(e,null,i,[]),s=e.length;while(s--)(o=a[s])&&(e[s]=!(t[s]=o))}):function(e,i,o){return t[0]=e,r(t,null,o,n),!n.pop()}}),has:ot(function(e){return function(t){return st(e,t).length>0}}),contains:ot(function(e){return function(t){return(t.textContent||t.innerText||o(t)).indexOf(e)>-1}}),lang:ot(function(e){return X.test(e||"")||st.error("unsupported lang: "+e),e=e.replace(et,tt).toLowerCase(),function(t){var n;do if(n=d?t.getAttribute("xml:lang")||t.getAttribute("lang"):t.lang)return n=n.toLowerCase(),n===e||0===n.indexOf(e+"-");while((t=t.parentNode)&&1===t.nodeType);return!1}}),target:function(t){var n=e.location&&e.location.hash;return n&&n.slice(1)===t.id},root:function(e){return e===f},focus:function(e){return e===p.activeElement&&(!p.hasFocus||p.hasFocus())&&!!(e.type||e.href||~e.tabIndex)},enabled:function(e){return e.disabled===!1},disabled:function(e){return e.disabled===!0},checked:function(e){var t=e.nodeName.toLowerCase();return"input"===t&&!!e.checked||"option"===t&&!!e.selected},selected:function(e){return e.parentNode&&e.parentNode.selectedIndex,e.selected===!0},empty:function(e){for(e=e.firstChild;e;e=e.nextSibling)if(e.nodeName>"@"||3===e.nodeType||4===e.nodeType)return!1;return!0},parent:function(e){return!i.pseudos.empty(e)},header:function(e){return Q.test(e.nodeName)},input:function(e){return G.test(e.nodeName)},button:function(e){var t=e.nodeName.toLowerCase();return"input"===t&&"button"===e.type||"button"===t},text:function(e){var t;return"input"===e.nodeName.toLowerCase()&&"text"===e.type&&(null==(t=e.getAttribute("type"))||t.toLowerCase()===e.type)},first:pt(function(){return[0]}),last:pt(function(e,t){return[t-1]}),eq:pt(function(e,t,n){return[0>n?n+t:n]}),even:pt(function(e,t){var n=0;for(;t>n;n+=2)e.push(n);return e}),odd:pt(function(e,t){var n=1;for(;t>n;n+=2)e.push(n);return e}),lt:pt(function(e,t,n){var r=0>n?n+t:n;for(;--r>=0;)e.push(r);return e}),gt:pt(function(e,t,n){var r=0>n?n+t:n;for(;t>++r;)e.push(r);return e})}};for(n in{radio:!0,checkbox:!0,file:!0,password:!0,image:!0})i.pseudos[n]=lt(n);for(n in{submit:!0,reset:!0})i.pseudos[n]=ct(n);function ft(e,t){var n,r,o,a,s,u,l,c=E[e+" "];if(c)return t?0:c.slice(0);s=e,u=[],l=i.preFilter;while(s){(!n||(r=$.exec(s)))&&(r&&(s=s.slice(r[0].length)||s),u.push(o=[])),n=!1,(r=I.exec(s))&&(n=r.shift(),o.push({value:n,type:r[0].replace(W," ")}),s=s.slice(n.length));for(a in i.filter)!(r=U[a].exec(s))||l[a]&&!(r=l[a](r))||(n=r.shift(),o.push({value:n,type:a,matches:r}),s=s.slice(n.length));if(!n)break}return t?s.length:s?st.error(e):E(e,u).slice(0)}function dt(e){var t=0,n=e.length,r="";for(;n>t;t++)r+=e[t].value;return r}function ht(e,t,n){var i=t.dir,o=n&&"parentNode"===i,a=C++;return t.first?function(t,n,r){while(t=t[i])if(1===t.nodeType||o)return e(t,n,r)}:function(t,n,s){var u,l,c,p=N+" "+a;if(s){while(t=t[i])if((1===t.nodeType||o)&&e(t,n,s))return!0}else while(t=t[i])if(1===t.nodeType||o)if(c=t[x]||(t[x]={}),(l=c[i])&&l[0]===p){if((u=l[1])===!0||u===r)return u===!0}else if(l=c[i]=[p],l[1]=e(t,n,s)||r,l[1]===!0)return!0}}function gt(e){return e.length>1?function(t,n,r){var i=e.length;while(i--)if(!e[i](t,n,r))return!1;return!0}:e[0]}function mt(e,t,n,r,i){var o,a=[],s=0,u=e.length,l=null!=t;for(;u>s;s++)(o=e[s])&&(!n||n(o,r,i))&&(a.push(o),l&&t.push(s));return a}function yt(e,t,n,r,i,o){return r&&!r[x]&&(r=yt(r)),i&&!i[x]&&(i=yt(i,o)),ot(function(o,a,s,u){var l,c,p,f=[],d=[],h=a.length,g=o||xt(t||"*",s.nodeType?[s]:s,[]),m=!e||!o&&t?g:mt(g,f,e,s,u),y=n?i||(o?e:h||r)?[]:a:m;if(n&&n(m,y,s,u),r){l=mt(y,d),r(l,[],s,u),c=l.length;while(c--)(p=l[c])&&(y[d[c]]=!(m[d[c]]=p))}if(o){if(i||e){if(i){l=[],c=y.length;while(c--)(p=y[c])&&l.push(m[c]=p);i(null,y=[],l,u)}c=y.length;while(c--)(p=y[c])&&(l=i?M.call(o,p):f[c])>-1&&(o[l]=!(a[l]=p))}}else y=mt(y===a?y.splice(h,y.length):y),i?i(null,a,y,u):H.apply(a,y)})}function vt(e){var t,n,r,o=e.length,a=i.relative[e[0].type],s=a||i.relative[" "],u=a?1:0,c=ht(function(e){return e===t},s,!0),p=ht(function(e){return M.call(t,e)>-1},s,!0),f=[function(e,n,r){return!a&&(r||n!==l)||((t=n).nodeType?c(e,n,r):p(e,n,r))}];for(;o>u;u++)if(n=i.relative[e[u].type])f=[ht(gt(f),n)];else{if(n=i.filter[e[u].type].apply(null,e[u].matches),n[x]){for(r=++u;o>r;r++)if(i.relative[e[r].type])break;return yt(u>1&&gt(f),u>1&&dt(e.slice(0,u-1)).replace(W,"$1"),n,r>u&&vt(e.slice(u,r)),o>r&&vt(e=e.slice(r)),o>r&&dt(e))}f.push(n)}return gt(f)}function bt(e,t){var n=0,o=t.length>0,a=e.length>0,s=function(s,u,c,f,d){var h,g,m,y=[],v=0,b="0",x=s&&[],w=null!=d,T=l,C=s||a&&i.find.TAG("*",d&&u.parentNode||u),k=N+=null==T?1:Math.random()||.1;for(w&&(l=u!==p&&u,r=n);null!=(h=C[b]);b++){if(a&&h){g=0;while(m=e[g++])if(m(h,u,c)){f.push(h);break}w&&(N=k,r=++n)}o&&((h=!m&&h)&&v--,s&&x.push(h))}if(v+=b,o&&b!==v){g=0;while(m=t[g++])m(x,y,u,c);if(s){if(v>0)while(b--)x[b]||y[b]||(y[b]=L.call(f));y=mt(y)}H.apply(f,y),w&&!s&&y.length>0&&v+t.length>1&&st.uniqueSort(f)}return w&&(N=k,l=T),x};return o?ot(s):s}s=st.compile=function(e,t){var n,r=[],i=[],o=S[e+" "];if(!o){t||(t=ft(e)),n=t.length;while(n--)o=vt(t[n]),o[x]?r.push(o):i.push(o);o=S(e,bt(i,r))}return o};function xt(e,t,n){var r=0,i=t.length;for(;i>r;r++)st(e,t[r],n);return n}function wt(e,t,n,r){var o,a,u,l,c,p=ft(e);if(!r&&1===p.length){if(a=p[0]=p[0].slice(0),a.length>2&&"ID"===(u=a[0]).type&&9===t.nodeType&&!d&&i.relative[a[1].type]){if(t=i.find.ID(u.matches[0].replace(et,tt),t)[0],!t)return n;e=e.slice(a.shift().value.length)}o=U.needsContext.test(e)?0:a.length;while(o--){if(u=a[o],i.relative[l=u.type])break;if((c=i.find[l])&&(r=c(u.matches[0].replace(et,tt),V.test(a[0].type)&&t.parentNode||t))){if(a.splice(o,1),e=r.length&&dt(a),!e)return H.apply(n,q.call(r,0)),n;break}}}return s(e,p)(r,t,d,n,V.test(e)),n}i.pseudos.nth=i.pseudos.eq;function Tt(){}i.filters=Tt.prototype=i.pseudos,i.setFilters=new Tt,c(),st.attr=b.attr,b.find=st,b.expr=st.selectors,b.expr[":"]=b.expr.pseudos,b.unique=st.uniqueSort,b.text=st.getText,b.isXMLDoc=st.isXML,b.contains=st.contains}(e);var at=/Until$/,st=/^(?:parents|prev(?:Until|All))/,ut=/^.[^:#\[\.,]*$/,lt=b.expr.match.needsContext,ct={children:!0,contents:!0,next:!0,prev:!0};b.fn.extend({find:function(e){var t,n,r,i=this.length;if("string"!=typeof e)return r=this,this.pushStack(b(e).filter(function(){for(t=0;i>t;t++)if(b.contains(r[t],this))return!0}));for(n=[],t=0;i>t;t++)b.find(e,this[t],n);return n=this.pushStack(i>1?b.unique(n):n),n.selector=(this.selector?this.selector+" ":"")+e,n},has:function(e){var t,n=b(e,this),r=n.length;return this.filter(function(){for(t=0;r>t;t++)if(b.contains(this,n[t]))return!0})},not:function(e){return this.pushStack(ft(this,e,!1))},filter:function(e){return this.pushStack(ft(this,e,!0))},is:function(e){return!!e&&("string"==typeof e?lt.test(e)?b(e,this.context).index(this[0])>=0:b.filter(e,this).length>0:this.filter(e).length>0)},closest:function(e,t){var n,r=0,i=this.length,o=[],a=lt.test(e)||"string"!=typeof e?b(e,t||this.context):0;for(;i>r;r++){n=this[r];while(n&&n.ownerDocument&&n!==t&&11!==n.nodeType){if(a?a.index(n)>-1:b.find.matchesSelector(n,e)){o.push(n);break}n=n.parentNode}}return this.pushStack(o.length>1?b.unique(o):o)},index:function(e){return e?"string"==typeof e?b.inArray(this[0],b(e)):b.inArray(e.jquery?e[0]:e,this):this[0]&&this[0].parentNode?this.first().prevAll().length:-1},add:function(e,t){var n="string"==typeof e?b(e,t):b.makeArray(e&&e.nodeType?[e]:e),r=b.merge(this.get(),n);return this.pushStack(b.unique(r))},addBack:function(e){return this.add(null==e?this.prevObject:this.prevObject.filter(e))}}),b.fn.andSelf=b.fn.addBack;function pt(e,t){do e=e[t];while(e&&1!==e.nodeType);return e}b.each({parent:function(e){var t=e.parentNode;return t&&11!==t.nodeType?t:null},parents:function(e){return b.dir(e,"parentNode")},parentsUntil:function(e,t,n){return b.dir(e,"parentNode",n)},next:function(e){return pt(e,"nextSibling")},prev:function(e){return pt(e,"previousSibling")},nextAll:function(e){return b.dir(e,"nextSibling")},prevAll:function(e){return b.dir(e,"previousSibling")},nextUntil:function(e,t,n){return b.dir(e,"nextSibling",n)},prevUntil:function(e,t,n){return b.dir(e,"previousSibling",n)},siblings:function(e){return b.sibling((e.parentNode||{}).firstChild,e)},children:function(e){return b.sibling(e.firstChild)},contents:function(e){return b.nodeName(e,"iframe")?e.contentDocument||e.contentWindow.document:b.merge([],e.childNodes)}},function(e,t){b.fn[e]=function(n,r){var i=b.map(this,t,n);return at.test(e)||(r=n),r&&"string"==typeof r&&(i=b.filter(r,i)),i=this.length>1&&!ct[e]?b.unique(i):i,this.length>1&&st.test(e)&&(i=i.reverse()),this.pushStack(i)}}),b.extend({filter:function(e,t,n){return n&&(e=":not("+e+")"),1===t.length?b.find.matchesSelector(t[0],e)?[t[0]]:[]:b.find.matches(e,t)},dir:function(e,n,r){var i=[],o=e[n];while(o&&9!==o.nodeType&&(r===t||1!==o.nodeType||!b(o).is(r)))1===o.nodeType&&i.push(o),o=o[n];return i},sibling:function(e,t){var n=[];for(;e;e=e.nextSibling)1===e.nodeType&&e!==t&&n.push(e);return n}});function ft(e,t,n){if(t=t||0,b.isFunction(t))return b.grep(e,function(e,r){var i=!!t.call(e,r,e);return i===n});if(t.nodeType)return b.grep(e,function(e){return e===t===n});if("string"==typeof t){var r=b.grep(e,function(e){return 1===e.nodeType});if(ut.test(t))return b.filter(t,r,!n);t=b.filter(t,r)}return b.grep(e,function(e){return b.inArray(e,t)>=0===n})}function dt(e){var t=ht.split("|"),n=e.createDocumentFragment();if(n.createElement)while(t.length)n.createElement(t.pop());return n}var ht="abbr|article|aside|audio|bdi|canvas|data|datalist|details|figcaption|figure|footer|header|hgroup|mark|meter|nav|output|progress|section|summary|time|video",gt=/ jQuery\d+="(?:null|\d+)"/g,mt=RegExp("<(?:"+ht+")[\\s/>]","i"),yt=/^\s+/,vt=/<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/gi,bt=/<([\w:]+)/,xt=/<tbody/i,wt=/<|&#?\w+;/,Tt=/<(?:script|style|link)/i,Nt=/^(?:checkbox|radio)$/i,Ct=/checked\s*(?:[^=]|=\s*.checked.)/i,kt=/^$|\/(?:java|ecma)script/i,Et=/^true\/(.*)/,St=/^\s*<!(?:\[CDATA\[|--)|(?:\]\]|--)>\s*$/g,At={option:[1,"<select multiple='multiple'>","</select>"],legend:[1,"<fieldset>","</fieldset>"],area:[1,"<map>","</map>"],param:[1,"<object>","</object>"],thead:[1,"<table>","</table>"],tr:[2,"<table><tbody>","</tbody></table>"],col:[2,"<table><tbody></tbody><colgroup>","</colgroup></table>"],td:[3,"<table><tbody><tr>","</tr></tbody></table>"],_default:b.support.htmlSerialize?[0,"",""]:[1,"X<div>","</div>"]},jt=dt(o),Dt=jt.appendChild(o.createElement("div"));At.optgroup=At.option,At.tbody=At.tfoot=At.colgroup=At.caption=At.thead,At.th=At.td,b.fn.extend({text:function(e){return b.access(this,function(e){return e===t?b.text(this):this.empty().append((this[0]&&this[0].ownerDocument||o).createTextNode(e))},null,e,arguments.length)},wrapAll:function(e){if(b.isFunction(e))return this.each(function(t){b(this).wrapAll(e.call(this,t))});if(this[0]){var t=b(e,this[0].ownerDocument).eq(0).clone(!0);this[0].parentNode&&t.insertBefore(this[0]),t.map(function(){var e=this;while(e.firstChild&&1===e.firstChild.nodeType)e=e.firstChild;return e}).append(this)}return this},wrapInner:function(e){return b.isFunction(e)?this.each(function(t){b(this).wrapInner(e.call(this,t))}):this.each(function(){var t=b(this),n=t.contents();n.length?n.wrapAll(e):t.append(e)})},wrap:function(e){var t=b.isFunction(e);return this.each(function(n){b(this).wrapAll(t?e.call(this,n):e)})},unwrap:function(){return this.parent().each(function(){b.nodeName(this,"body")||b(this).replaceWith(this.childNodes)}).end()},append:function(){return this.domManip(arguments,!0,function(e){(1===this.nodeType||11===this.nodeType||9===this.nodeType)&&this.appendChild(e)})},prepend:function(){return this.domManip(arguments,!0,function(e){(1===this.nodeType||11===this.nodeType||9===this.nodeType)&&this.insertBefore(e,this.firstChild)})},before:function(){return this.domManip(arguments,!1,function(e){this.parentNode&&this.parentNode.insertBefore(e,this)})},after:function(){return this.domManip(arguments,!1,function(e){this.parentNode&&this.parentNode.insertBefore(e,this.nextSibling)})},remove:function(e,t){var n,r=0;for(;null!=(n=this[r]);r++)(!e||b.filter(e,[n]).length>0)&&(t||1!==n.nodeType||b.cleanData(Ot(n)),n.parentNode&&(t&&b.contains(n.ownerDocument,n)&&Mt(Ot(n,"script")),n.parentNode.removeChild(n)));return this},empty:function(){var e,t=0;for(;null!=(e=this[t]);t++){1===e.nodeType&&b.cleanData(Ot(e,!1));while(e.firstChild)e.removeChild(e.firstChild);e.options&&b.nodeName(e,"select")&&(e.options.length=0)}return this},clone:function(e,t){return e=null==e?!1:e,t=null==t?e:t,this.map(function(){return b.clone(this,e,t)})},html:function(e){return b.access(this,function(e){var n=this[0]||{},r=0,i=this.length;if(e===t)return 1===n.nodeType?n.innerHTML.replace(gt,""):t;if(!("string"!=typeof e||Tt.test(e)||!b.support.htmlSerialize&&mt.test(e)||!b.support.leadingWhitespace&&yt.test(e)||At[(bt.exec(e)||["",""])[1].toLowerCase()])){e=e.replace(vt,"<$1></$2>");try{for(;i>r;r++)n=this[r]||{},1===n.nodeType&&(b.cleanData(Ot(n,!1)),n.innerHTML=e);n=0}catch(o){}}n&&this.empty().append(e)},null,e,arguments.length)},replaceWith:function(e){var t=b.isFunction(e);return t||"string"==typeof e||(e=b(e).not(this).detach()),this.domManip([e],!0,function(e){var t=this.nextSibling,n=this.parentNode;n&&(b(this).remove(),n.insertBefore(e,t))})},detach:function(e){return this.remove(e,!0)},domManip:function(e,n,r){e=f.apply([],e);var i,o,a,s,u,l,c=0,p=this.length,d=this,h=p-1,g=e[0],m=b.isFunction(g);if(m||!(1>=p||"string"!=typeof g||b.support.checkClone)&&Ct.test(g))return this.each(function(i){var o=d.eq(i);m&&(e[0]=g.call(this,i,n?o.html():t)),o.domManip(e,n,r)});if(p&&(l=b.buildFragment(e,this[0].ownerDocument,!1,this),i=l.firstChild,1===l.childNodes.length&&(l=i),i)){for(n=n&&b.nodeName(i,"tr"),s=b.map(Ot(l,"script"),Ht),a=s.length;p>c;c++)o=l,c!==h&&(o=b.clone(o,!0,!0),a&&b.merge(s,Ot(o,"script"))),r.call(n&&b.nodeName(this[c],"table")?Lt(this[c],"tbody"):this[c],o,c);if(a)for(u=s[s.length-1].ownerDocument,b.map(s,qt),c=0;a>c;c++)o=s[c],kt.test(o.type||"")&&!b._data(o,"globalEval")&&b.contains(u,o)&&(o.src?b.ajax({url:o.src,type:"GET",dataType:"script",async:!1,global:!1,"throws":!0}):b.globalEval((o.text||o.textContent||o.innerHTML||"").replace(St,"")));l=i=null}return this}});function Lt(e,t){return e.getElementsByTagName(t)[0]||e.appendChild(e.ownerDocument.createElement(t))}function Ht(e){var t=e.getAttributeNode("type");return e.type=(t&&t.specified)+"/"+e.type,e}function qt(e){var t=Et.exec(e.type);return t?e.type=t[1]:e.removeAttribute("type"),e}function Mt(e,t){var n,r=0;for(;null!=(n=e[r]);r++)b._data(n,"globalEval",!t||b._data(t[r],"globalEval"))}function _t(e,t){if(1===t.nodeType&&b.hasData(e)){var n,r,i,o=b._data(e),a=b._data(t,o),s=o.events;if(s){delete a.handle,a.events={};for(n in s)for(r=0,i=s[n].length;i>r;r++)b.event.add(t,n,s[n][r])}a.data&&(a.data=b.extend({},a.data))}}function Ft(e,t){var n,r,i;if(1===t.nodeType){if(n=t.nodeName.toLowerCase(),!b.support.noCloneEvent&&t[b.expando]){i=b._data(t);for(r in i.events)b.removeEvent(t,r,i.handle);t.removeAttribute(b.expando)}"script"===n&&t.text!==e.text?(Ht(t).text=e.text,qt(t)):"object"===n?(t.parentNode&&(t.outerHTML=e.outerHTML),b.support.html5Clone&&e.innerHTML&&!b.trim(t.innerHTML)&&(t.innerHTML=e.innerHTML)):"input"===n&&Nt.test(e.type)?(t.defaultChecked=t.checked=e.checked,t.value!==e.value&&(t.value=e.value)):"option"===n?t.defaultSelected=t.selected=e.defaultSelected:("input"===n||"textarea"===n)&&(t.defaultValue=e.defaultValue)}}b.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(e,t){b.fn[e]=function(e){var n,r=0,i=[],o=b(e),a=o.length-1;for(;a>=r;r++)n=r===a?this:this.clone(!0),b(o[r])[t](n),d.apply(i,n.get());return this.pushStack(i)}});function Ot(e,n){var r,o,a=0,s=typeof e.getElementsByTagName!==i?e.getElementsByTagName(n||"*"):typeof e.querySelectorAll!==i?e.querySelectorAll(n||"*"):t;if(!s)for(s=[],r=e.childNodes||e;null!=(o=r[a]);a++)!n||b.nodeName(o,n)?s.push(o):b.merge(s,Ot(o,n));return n===t||n&&b.nodeName(e,n)?b.merge([e],s):s}function Bt(e){Nt.test(e.type)&&(e.defaultChecked=e.checked)}b.extend({clone:function(e,t,n){var r,i,o,a,s,u=b.contains(e.ownerDocument,e);if(b.support.html5Clone||b.isXMLDoc(e)||!mt.test("<"+e.nodeName+">")?o=e.cloneNode(!0):(Dt.innerHTML=e.outerHTML,Dt.removeChild(o=Dt.firstChild)),!(b.support.noCloneEvent&&b.support.noCloneChecked||1!==e.nodeType&&11!==e.nodeType||b.isXMLDoc(e)))for(r=Ot(o),s=Ot(e),a=0;null!=(i=s[a]);++a)r[a]&&Ft(i,r[a]);if(t)if(n)for(s=s||Ot(e),r=r||Ot(o),a=0;null!=(i=s[a]);a++)_t(i,r[a]);else _t(e,o);return r=Ot(o,"script"),r.length>0&&Mt(r,!u&&Ot(e,"script")),r=s=i=null,o},buildFragment:function(e,t,n,r){var i,o,a,s,u,l,c,p=e.length,f=dt(t),d=[],h=0;for(;p>h;h++)if(o=e[h],o||0===o)if("object"===b.type(o))b.merge(d,o.nodeType?[o]:o);else if(wt.test(o)){s=s||f.appendChild(t.createElement("div")),u=(bt.exec(o)||["",""])[1].toLowerCase(),c=At[u]||At._default,s.innerHTML=c[1]+o.replace(vt,"<$1></$2>")+c[2],i=c[0];while(i--)s=s.lastChild;if(!b.support.leadingWhitespace&&yt.test(o)&&d.push(t.createTextNode(yt.exec(o)[0])),!b.support.tbody){o="table"!==u||xt.test(o)?"<table>"!==c[1]||xt.test(o)?0:s:s.firstChild,i=o&&o.childNodes.length;while(i--)b.nodeName(l=o.childNodes[i],"tbody")&&!l.childNodes.length&&o.removeChild(l)
}b.merge(d,s.childNodes),s.textContent="";while(s.firstChild)s.removeChild(s.firstChild);s=f.lastChild}else d.push(t.createTextNode(o));s&&f.removeChild(s),b.support.appendChecked||b.grep(Ot(d,"input"),Bt),h=0;while(o=d[h++])if((!r||-1===b.inArray(o,r))&&(a=b.contains(o.ownerDocument,o),s=Ot(f.appendChild(o),"script"),a&&Mt(s),n)){i=0;while(o=s[i++])kt.test(o.type||"")&&n.push(o)}return s=null,f},cleanData:function(e,t){var n,r,o,a,s=0,u=b.expando,l=b.cache,p=b.support.deleteExpando,f=b.event.special;for(;null!=(n=e[s]);s++)if((t||b.acceptData(n))&&(o=n[u],a=o&&l[o])){if(a.events)for(r in a.events)f[r]?b.event.remove(n,r):b.removeEvent(n,r,a.handle);l[o]&&(delete l[o],p?delete n[u]:typeof n.removeAttribute!==i?n.removeAttribute(u):n[u]=null,c.push(o))}}});var Pt,Rt,Wt,$t=/alpha\([^)]*\)/i,It=/opacity\s*=\s*([^)]*)/,zt=/^(top|right|bottom|left)$/,Xt=/^(none|table(?!-c[ea]).+)/,Ut=/^margin/,Vt=RegExp("^("+x+")(.*)$","i"),Yt=RegExp("^("+x+")(?!px)[a-z%]+$","i"),Jt=RegExp("^([+-])=("+x+")","i"),Gt={BODY:"block"},Qt={position:"absolute",visibility:"hidden",display:"block"},Kt={letterSpacing:0,fontWeight:400},Zt=["Top","Right","Bottom","Left"],en=["Webkit","O","Moz","ms"];function tn(e,t){if(t in e)return t;var n=t.charAt(0).toUpperCase()+t.slice(1),r=t,i=en.length;while(i--)if(t=en[i]+n,t in e)return t;return r}function nn(e,t){return e=t||e,"none"===b.css(e,"display")||!b.contains(e.ownerDocument,e)}function rn(e,t){var n,r,i,o=[],a=0,s=e.length;for(;s>a;a++)r=e[a],r.style&&(o[a]=b._data(r,"olddisplay"),n=r.style.display,t?(o[a]||"none"!==n||(r.style.display=""),""===r.style.display&&nn(r)&&(o[a]=b._data(r,"olddisplay",un(r.nodeName)))):o[a]||(i=nn(r),(n&&"none"!==n||!i)&&b._data(r,"olddisplay",i?n:b.css(r,"display"))));for(a=0;s>a;a++)r=e[a],r.style&&(t&&"none"!==r.style.display&&""!==r.style.display||(r.style.display=t?o[a]||"":"none"));return e}b.fn.extend({css:function(e,n){return b.access(this,function(e,n,r){var i,o,a={},s=0;if(b.isArray(n)){for(o=Rt(e),i=n.length;i>s;s++)a[n[s]]=b.css(e,n[s],!1,o);return a}return r!==t?b.style(e,n,r):b.css(e,n)},e,n,arguments.length>1)},show:function(){return rn(this,!0)},hide:function(){return rn(this)},toggle:function(e){var t="boolean"==typeof e;return this.each(function(){(t?e:nn(this))?b(this).show():b(this).hide()})}}),b.extend({cssHooks:{opacity:{get:function(e,t){if(t){var n=Wt(e,"opacity");return""===n?"1":n}}}},cssNumber:{columnCount:!0,fillOpacity:!0,fontWeight:!0,lineHeight:!0,opacity:!0,orphans:!0,widows:!0,zIndex:!0,zoom:!0},cssProps:{"float":b.support.cssFloat?"cssFloat":"styleFloat"},style:function(e,n,r,i){if(e&&3!==e.nodeType&&8!==e.nodeType&&e.style){var o,a,s,u=b.camelCase(n),l=e.style;if(n=b.cssProps[u]||(b.cssProps[u]=tn(l,u)),s=b.cssHooks[n]||b.cssHooks[u],r===t)return s&&"get"in s&&(o=s.get(e,!1,i))!==t?o:l[n];if(a=typeof r,"string"===a&&(o=Jt.exec(r))&&(r=(o[1]+1)*o[2]+parseFloat(b.css(e,n)),a="number"),!(null==r||"number"===a&&isNaN(r)||("number"!==a||b.cssNumber[u]||(r+="px"),b.support.clearCloneStyle||""!==r||0!==n.indexOf("background")||(l[n]="inherit"),s&&"set"in s&&(r=s.set(e,r,i))===t)))try{l[n]=r}catch(c){}}},css:function(e,n,r,i){var o,a,s,u=b.camelCase(n);return n=b.cssProps[u]||(b.cssProps[u]=tn(e.style,u)),s=b.cssHooks[n]||b.cssHooks[u],s&&"get"in s&&(a=s.get(e,!0,r)),a===t&&(a=Wt(e,n,i)),"normal"===a&&n in Kt&&(a=Kt[n]),""===r||r?(o=parseFloat(a),r===!0||b.isNumeric(o)?o||0:a):a},swap:function(e,t,n,r){var i,o,a={};for(o in t)a[o]=e.style[o],e.style[o]=t[o];i=n.apply(e,r||[]);for(o in t)e.style[o]=a[o];return i}}),e.getComputedStyle?(Rt=function(t){return e.getComputedStyle(t,null)},Wt=function(e,n,r){var i,o,a,s=r||Rt(e),u=s?s.getPropertyValue(n)||s[n]:t,l=e.style;return s&&(""!==u||b.contains(e.ownerDocument,e)||(u=b.style(e,n)),Yt.test(u)&&Ut.test(n)&&(i=l.width,o=l.minWidth,a=l.maxWidth,l.minWidth=l.maxWidth=l.width=u,u=s.width,l.width=i,l.minWidth=o,l.maxWidth=a)),u}):o.documentElement.currentStyle&&(Rt=function(e){return e.currentStyle},Wt=function(e,n,r){var i,o,a,s=r||Rt(e),u=s?s[n]:t,l=e.style;return null==u&&l&&l[n]&&(u=l[n]),Yt.test(u)&&!zt.test(n)&&(i=l.left,o=e.runtimeStyle,a=o&&o.left,a&&(o.left=e.currentStyle.left),l.left="fontSize"===n?"1em":u,u=l.pixelLeft+"px",l.left=i,a&&(o.left=a)),""===u?"auto":u});function on(e,t,n){var r=Vt.exec(t);return r?Math.max(0,r[1]-(n||0))+(r[2]||"px"):t}function an(e,t,n,r,i){var o=n===(r?"border":"content")?4:"width"===t?1:0,a=0;for(;4>o;o+=2)"margin"===n&&(a+=b.css(e,n+Zt[o],!0,i)),r?("content"===n&&(a-=b.css(e,"padding"+Zt[o],!0,i)),"margin"!==n&&(a-=b.css(e,"border"+Zt[o]+"Width",!0,i))):(a+=b.css(e,"padding"+Zt[o],!0,i),"padding"!==n&&(a+=b.css(e,"border"+Zt[o]+"Width",!0,i)));return a}function sn(e,t,n){var r=!0,i="width"===t?e.offsetWidth:e.offsetHeight,o=Rt(e),a=b.support.boxSizing&&"border-box"===b.css(e,"boxSizing",!1,o);if(0>=i||null==i){if(i=Wt(e,t,o),(0>i||null==i)&&(i=e.style[t]),Yt.test(i))return i;r=a&&(b.support.boxSizingReliable||i===e.style[t]),i=parseFloat(i)||0}return i+an(e,t,n||(a?"border":"content"),r,o)+"px"}function un(e){var t=o,n=Gt[e];return n||(n=ln(e,t),"none"!==n&&n||(Pt=(Pt||b("<iframe frameborder='0' width='0' height='0'/>").css("cssText","display:block !important")).appendTo(t.documentElement),t=(Pt[0].contentWindow||Pt[0].contentDocument).document,t.write("<!doctype html><html><body>"),t.close(),n=ln(e,t),Pt.detach()),Gt[e]=n),n}function ln(e,t){var n=b(t.createElement(e)).appendTo(t.body),r=b.css(n[0],"display");return n.remove(),r}b.each(["height","width"],function(e,n){b.cssHooks[n]={get:function(e,r,i){return r?0===e.offsetWidth&&Xt.test(b.css(e,"display"))?b.swap(e,Qt,function(){return sn(e,n,i)}):sn(e,n,i):t},set:function(e,t,r){var i=r&&Rt(e);return on(e,t,r?an(e,n,r,b.support.boxSizing&&"border-box"===b.css(e,"boxSizing",!1,i),i):0)}}}),b.support.opacity||(b.cssHooks.opacity={get:function(e,t){return It.test((t&&e.currentStyle?e.currentStyle.filter:e.style.filter)||"")?.01*parseFloat(RegExp.$1)+"":t?"1":""},set:function(e,t){var n=e.style,r=e.currentStyle,i=b.isNumeric(t)?"alpha(opacity="+100*t+")":"",o=r&&r.filter||n.filter||"";n.zoom=1,(t>=1||""===t)&&""===b.trim(o.replace($t,""))&&n.removeAttribute&&(n.removeAttribute("filter"),""===t||r&&!r.filter)||(n.filter=$t.test(o)?o.replace($t,i):o+" "+i)}}),b(function(){b.support.reliableMarginRight||(b.cssHooks.marginRight={get:function(e,n){return n?b.swap(e,{display:"inline-block"},Wt,[e,"marginRight"]):t}}),!b.support.pixelPosition&&b.fn.position&&b.each(["top","left"],function(e,n){b.cssHooks[n]={get:function(e,r){return r?(r=Wt(e,n),Yt.test(r)?b(e).position()[n]+"px":r):t}}})}),b.expr&&b.expr.filters&&(b.expr.filters.hidden=function(e){return 0>=e.offsetWidth&&0>=e.offsetHeight||!b.support.reliableHiddenOffsets&&"none"===(e.style&&e.style.display||b.css(e,"display"))},b.expr.filters.visible=function(e){return!b.expr.filters.hidden(e)}),b.each({margin:"",padding:"",border:"Width"},function(e,t){b.cssHooks[e+t]={expand:function(n){var r=0,i={},o="string"==typeof n?n.split(" "):[n];for(;4>r;r++)i[e+Zt[r]+t]=o[r]||o[r-2]||o[0];return i}},Ut.test(e)||(b.cssHooks[e+t].set=on)});var cn=/%20/g,pn=/\[\]$/,fn=/\r?\n/g,dn=/^(?:submit|button|image|reset|file)$/i,hn=/^(?:input|select|textarea|keygen)/i;b.fn.extend({serialize:function(){return b.param(this.serializeArray())},serializeArray:function(){return this.map(function(){var e=b.prop(this,"elements");return e?b.makeArray(e):this}).filter(function(){var e=this.type;return this.name&&!b(this).is(":disabled")&&hn.test(this.nodeName)&&!dn.test(e)&&(this.checked||!Nt.test(e))}).map(function(e,t){var n=b(this).val();return null==n?null:b.isArray(n)?b.map(n,function(e){return{name:t.name,value:e.replace(fn,"\r\n")}}):{name:t.name,value:n.replace(fn,"\r\n")}}).get()}}),b.param=function(e,n){var r,i=[],o=function(e,t){t=b.isFunction(t)?t():null==t?"":t,i[i.length]=encodeURIComponent(e)+"="+encodeURIComponent(t)};if(n===t&&(n=b.ajaxSettings&&b.ajaxSettings.traditional),b.isArray(e)||e.jquery&&!b.isPlainObject(e))b.each(e,function(){o(this.name,this.value)});else for(r in e)gn(r,e[r],n,o);return i.join("&").replace(cn,"+")};function gn(e,t,n,r){var i;if(b.isArray(t))b.each(t,function(t,i){n||pn.test(e)?r(e,i):gn(e+"["+("object"==typeof i?t:"")+"]",i,n,r)});else if(n||"object"!==b.type(t))r(e,t);else for(i in t)gn(e+"["+i+"]",t[i],n,r)}b.each("blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error contextmenu".split(" "),function(e,t){b.fn[t]=function(e,n){return arguments.length>0?this.on(t,null,e,n):this.trigger(t)}}),b.fn.hover=function(e,t){return this.mouseenter(e).mouseleave(t||e)};var mn,yn,vn=b.now(),bn=/\?/,xn=/#.*$/,wn=/([?&])_=[^&]*/,Tn=/^(.*?):[ \t]*([^\r\n]*)\r?$/gm,Nn=/^(?:about|app|app-storage|.+-extension|file|res|widget):$/,Cn=/^(?:GET|HEAD)$/,kn=/^\/\//,En=/^([\w.+-]+:)(?:\/\/([^\/?#:]*)(?::(\d+)|)|)/,Sn=b.fn.load,An={},jn={},Dn="*/".concat("*");try{yn=a.href}catch(Ln){yn=o.createElement("a"),yn.href="",yn=yn.href}mn=En.exec(yn.toLowerCase())||[];function Hn(e){return function(t,n){"string"!=typeof t&&(n=t,t="*");var r,i=0,o=t.toLowerCase().match(w)||[];if(b.isFunction(n))while(r=o[i++])"+"===r[0]?(r=r.slice(1)||"*",(e[r]=e[r]||[]).unshift(n)):(e[r]=e[r]||[]).push(n)}}function qn(e,n,r,i){var o={},a=e===jn;function s(u){var l;return o[u]=!0,b.each(e[u]||[],function(e,u){var c=u(n,r,i);return"string"!=typeof c||a||o[c]?a?!(l=c):t:(n.dataTypes.unshift(c),s(c),!1)}),l}return s(n.dataTypes[0])||!o["*"]&&s("*")}function Mn(e,n){var r,i,o=b.ajaxSettings.flatOptions||{};for(i in n)n[i]!==t&&((o[i]?e:r||(r={}))[i]=n[i]);return r&&b.extend(!0,e,r),e}b.fn.load=function(e,n,r){if("string"!=typeof e&&Sn)return Sn.apply(this,arguments);var i,o,a,s=this,u=e.indexOf(" ");return u>=0&&(i=e.slice(u,e.length),e=e.slice(0,u)),b.isFunction(n)?(r=n,n=t):n&&"object"==typeof n&&(a="POST"),s.length>0&&b.ajax({url:e,type:a,dataType:"html",data:n}).done(function(e){o=arguments,s.html(i?b("<div>").append(b.parseHTML(e)).find(i):e)}).complete(r&&function(e,t){s.each(r,o||[e.responseText,t,e])}),this},b.each(["ajaxStart","ajaxStop","ajaxComplete","ajaxError","ajaxSuccess","ajaxSend"],function(e,t){b.fn[t]=function(e){return this.on(t,e)}}),b.each(["get","post"],function(e,n){b[n]=function(e,r,i,o){return b.isFunction(r)&&(o=o||i,i=r,r=t),b.ajax({url:e,type:n,dataType:o,data:r,success:i})}}),b.extend({active:0,lastModified:{},etag:{},ajaxSettings:{url:yn,type:"GET",isLocal:Nn.test(mn[1]),global:!0,processData:!0,async:!0,contentType:"application/x-www-form-urlencoded; charset=UTF-8",accepts:{"*":Dn,text:"text/plain",html:"text/html",xml:"application/xml, text/xml",json:"application/json, text/javascript"},contents:{xml:/xml/,html:/html/,json:/json/},responseFields:{xml:"responseXML",text:"responseText"},converters:{"* text":e.String,"text html":!0,"text json":b.parseJSON,"text xml":b.parseXML},flatOptions:{url:!0,context:!0}},ajaxSetup:function(e,t){return t?Mn(Mn(e,b.ajaxSettings),t):Mn(b.ajaxSettings,e)},ajaxPrefilter:Hn(An),ajaxTransport:Hn(jn),ajax:function(e,n){"object"==typeof e&&(n=e,e=t),n=n||{};var r,i,o,a,s,u,l,c,p=b.ajaxSetup({},n),f=p.context||p,d=p.context&&(f.nodeType||f.jquery)?b(f):b.event,h=b.Deferred(),g=b.Callbacks("once memory"),m=p.statusCode||{},y={},v={},x=0,T="canceled",N={readyState:0,getResponseHeader:function(e){var t;if(2===x){if(!c){c={};while(t=Tn.exec(a))c[t[1].toLowerCase()]=t[2]}t=c[e.toLowerCase()]}return null==t?null:t},getAllResponseHeaders:function(){return 2===x?a:null},setRequestHeader:function(e,t){var n=e.toLowerCase();return x||(e=v[n]=v[n]||e,y[e]=t),this},overrideMimeType:function(e){return x||(p.mimeType=e),this},statusCode:function(e){var t;if(e)if(2>x)for(t in e)m[t]=[m[t],e[t]];else N.always(e[N.status]);return this},abort:function(e){var t=e||T;return l&&l.abort(t),k(0,t),this}};if(h.promise(N).complete=g.add,N.success=N.done,N.error=N.fail,p.url=((e||p.url||yn)+"").replace(xn,"").replace(kn,mn[1]+"//"),p.type=n.method||n.type||p.method||p.type,p.dataTypes=b.trim(p.dataType||"*").toLowerCase().match(w)||[""],null==p.crossDomain&&(r=En.exec(p.url.toLowerCase()),p.crossDomain=!(!r||r[1]===mn[1]&&r[2]===mn[2]&&(r[3]||("http:"===r[1]?80:443))==(mn[3]||("http:"===mn[1]?80:443)))),p.data&&p.processData&&"string"!=typeof p.data&&(p.data=b.param(p.data,p.traditional)),qn(An,p,n,N),2===x)return N;u=p.global,u&&0===b.active++&&b.event.trigger("ajaxStart"),p.type=p.type.toUpperCase(),p.hasContent=!Cn.test(p.type),o=p.url,p.hasContent||(p.data&&(o=p.url+=(bn.test(o)?"&":"?")+p.data,delete p.data),p.cache===!1&&(p.url=wn.test(o)?o.replace(wn,"$1_="+vn++):o+(bn.test(o)?"&":"?")+"_="+vn++)),p.ifModified&&(b.lastModified[o]&&N.setRequestHeader("If-Modified-Since",b.lastModified[o]),b.etag[o]&&N.setRequestHeader("If-None-Match",b.etag[o])),(p.data&&p.hasContent&&p.contentType!==!1||n.contentType)&&N.setRequestHeader("Content-Type",p.contentType),N.setRequestHeader("Accept",p.dataTypes[0]&&p.accepts[p.dataTypes[0]]?p.accepts[p.dataTypes[0]]+("*"!==p.dataTypes[0]?", "+Dn+"; q=0.01":""):p.accepts["*"]);for(i in p.headers)N.setRequestHeader(i,p.headers[i]);if(p.beforeSend&&(p.beforeSend.call(f,N,p)===!1||2===x))return N.abort();T="abort";for(i in{success:1,error:1,complete:1})N[i](p[i]);if(l=qn(jn,p,n,N)){N.readyState=1,u&&d.trigger("ajaxSend",[N,p]),p.async&&p.timeout>0&&(s=setTimeout(function(){N.abort("timeout")},p.timeout));try{x=1,l.send(y,k)}catch(C){if(!(2>x))throw C;k(-1,C)}}else k(-1,"No Transport");function k(e,n,r,i){var c,y,v,w,T,C=n;2!==x&&(x=2,s&&clearTimeout(s),l=t,a=i||"",N.readyState=e>0?4:0,r&&(w=_n(p,N,r)),e>=200&&300>e||304===e?(p.ifModified&&(T=N.getResponseHeader("Last-Modified"),T&&(b.lastModified[o]=T),T=N.getResponseHeader("etag"),T&&(b.etag[o]=T)),204===e?(c=!0,C="nocontent"):304===e?(c=!0,C="notmodified"):(c=Fn(p,w),C=c.state,y=c.data,v=c.error,c=!v)):(v=C,(e||!C)&&(C="error",0>e&&(e=0))),N.status=e,N.statusText=(n||C)+"",c?h.resolveWith(f,[y,C,N]):h.rejectWith(f,[N,C,v]),N.statusCode(m),m=t,u&&d.trigger(c?"ajaxSuccess":"ajaxError",[N,p,c?y:v]),g.fireWith(f,[N,C]),u&&(d.trigger("ajaxComplete",[N,p]),--b.active||b.event.trigger("ajaxStop")))}return N},getScript:function(e,n){return b.get(e,t,n,"script")},getJSON:function(e,t,n){return b.get(e,t,n,"json")}});function _n(e,n,r){var i,o,a,s,u=e.contents,l=e.dataTypes,c=e.responseFields;for(s in c)s in r&&(n[c[s]]=r[s]);while("*"===l[0])l.shift(),o===t&&(o=e.mimeType||n.getResponseHeader("Content-Type"));if(o)for(s in u)if(u[s]&&u[s].test(o)){l.unshift(s);break}if(l[0]in r)a=l[0];else{for(s in r){if(!l[0]||e.converters[s+" "+l[0]]){a=s;break}i||(i=s)}a=a||i}return a?(a!==l[0]&&l.unshift(a),r[a]):t}function Fn(e,t){var n,r,i,o,a={},s=0,u=e.dataTypes.slice(),l=u[0];if(e.dataFilter&&(t=e.dataFilter(t,e.dataType)),u[1])for(i in e.converters)a[i.toLowerCase()]=e.converters[i];for(;r=u[++s];)if("*"!==r){if("*"!==l&&l!==r){if(i=a[l+" "+r]||a["* "+r],!i)for(n in a)if(o=n.split(" "),o[1]===r&&(i=a[l+" "+o[0]]||a["* "+o[0]])){i===!0?i=a[n]:a[n]!==!0&&(r=o[0],u.splice(s--,0,r));break}if(i!==!0)if(i&&e["throws"])t=i(t);else try{t=i(t)}catch(c){return{state:"parsererror",error:i?c:"No conversion from "+l+" to "+r}}}l=r}return{state:"success",data:t}}b.ajaxSetup({accepts:{script:"text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"},contents:{script:/(?:java|ecma)script/},converters:{"text script":function(e){return b.globalEval(e),e}}}),b.ajaxPrefilter("script",function(e){e.cache===t&&(e.cache=!1),e.crossDomain&&(e.type="GET",e.global=!1)}),b.ajaxTransport("script",function(e){if(e.crossDomain){var n,r=o.head||b("head")[0]||o.documentElement;return{send:function(t,i){n=o.createElement("script"),n.async=!0,e.scriptCharset&&(n.charset=e.scriptCharset),n.src=e.url,n.onload=n.onreadystatechange=function(e,t){(t||!n.readyState||/loaded|complete/.test(n.readyState))&&(n.onload=n.onreadystatechange=null,n.parentNode&&n.parentNode.removeChild(n),n=null,t||i(200,"success"))},r.insertBefore(n,r.firstChild)},abort:function(){n&&n.onload(t,!0)}}}});var On=[],Bn=/(=)\?(?=&|$)|\?\?/;b.ajaxSetup({jsonp:"callback",jsonpCallback:function(){var e=On.pop()||b.expando+"_"+vn++;return this[e]=!0,e}}),b.ajaxPrefilter("json jsonp",function(n,r,i){var o,a,s,u=n.jsonp!==!1&&(Bn.test(n.url)?"url":"string"==typeof n.data&&!(n.contentType||"").indexOf("application/x-www-form-urlencoded")&&Bn.test(n.data)&&"data");return u||"jsonp"===n.dataTypes[0]?(o=n.jsonpCallback=b.isFunction(n.jsonpCallback)?n.jsonpCallback():n.jsonpCallback,u?n[u]=n[u].replace(Bn,"$1"+o):n.jsonp!==!1&&(n.url+=(bn.test(n.url)?"&":"?")+n.jsonp+"="+o),n.converters["script json"]=function(){return s||b.error(o+" was not called"),s[0]},n.dataTypes[0]="json",a=e[o],e[o]=function(){s=arguments},i.always(function(){e[o]=a,n[o]&&(n.jsonpCallback=r.jsonpCallback,On.push(o)),s&&b.isFunction(a)&&a(s[0]),s=a=t}),"script"):t});var Pn,Rn,Wn=0,$n=e.ActiveXObject&&function(){var e;for(e in Pn)Pn[e](t,!0)};function In(){try{return new e.XMLHttpRequest}catch(t){}}function zn(){try{return new e.ActiveXObject("Microsoft.XMLHTTP")}catch(t){}}b.ajaxSettings.xhr=e.ActiveXObject?function(){return!this.isLocal&&In()||zn()}:In,Rn=b.ajaxSettings.xhr(),b.support.cors=!!Rn&&"withCredentials"in Rn,Rn=b.support.ajax=!!Rn,Rn&&b.ajaxTransport(function(n){if(!n.crossDomain||b.support.cors){var r;return{send:function(i,o){var a,s,u=n.xhr();if(n.username?u.open(n.type,n.url,n.async,n.username,n.password):u.open(n.type,n.url,n.async),n.xhrFields)for(s in n.xhrFields)u[s]=n.xhrFields[s];n.mimeType&&u.overrideMimeType&&u.overrideMimeType(n.mimeType),n.crossDomain||i["X-Requested-With"]||(i["X-Requested-With"]="XMLHttpRequest");try{for(s in i)u.setRequestHeader(s,i[s])}catch(l){}u.send(n.hasContent&&n.data||null),r=function(e,i){var s,l,c,p;try{if(r&&(i||4===u.readyState))if(r=t,a&&(u.onreadystatechange=b.noop,$n&&delete Pn[a]),i)4!==u.readyState&&u.abort();else{p={},s=u.status,l=u.getAllResponseHeaders(),"string"==typeof u.responseText&&(p.text=u.responseText);try{c=u.statusText}catch(f){c=""}s||!n.isLocal||n.crossDomain?1223===s&&(s=204):s=p.text?200:404}}catch(d){i||o(-1,d)}p&&o(s,c,p,l)},n.async?4===u.readyState?setTimeout(r):(a=++Wn,$n&&(Pn||(Pn={},b(e).unload($n)),Pn[a]=r),u.onreadystatechange=r):r()},abort:function(){r&&r(t,!0)}}}});var Xn,Un,Vn=/^(?:toggle|show|hide)$/,Yn=RegExp("^(?:([+-])=|)("+x+")([a-z%]*)$","i"),Jn=/queueHooks$/,Gn=[nr],Qn={"*":[function(e,t){var n,r,i=this.createTween(e,t),o=Yn.exec(t),a=i.cur(),s=+a||0,u=1,l=20;if(o){if(n=+o[2],r=o[3]||(b.cssNumber[e]?"":"px"),"px"!==r&&s){s=b.css(i.elem,e,!0)||n||1;do u=u||".5",s/=u,b.style(i.elem,e,s+r);while(u!==(u=i.cur()/a)&&1!==u&&--l)}i.unit=r,i.start=s,i.end=o[1]?s+(o[1]+1)*n:n}return i}]};function Kn(){return setTimeout(function(){Xn=t}),Xn=b.now()}function Zn(e,t){b.each(t,function(t,n){var r=(Qn[t]||[]).concat(Qn["*"]),i=0,o=r.length;for(;o>i;i++)if(r[i].call(e,t,n))return})}function er(e,t,n){var r,i,o=0,a=Gn.length,s=b.Deferred().always(function(){delete u.elem}),u=function(){if(i)return!1;var t=Xn||Kn(),n=Math.max(0,l.startTime+l.duration-t),r=n/l.duration||0,o=1-r,a=0,u=l.tweens.length;for(;u>a;a++)l.tweens[a].run(o);return s.notifyWith(e,[l,o,n]),1>o&&u?n:(s.resolveWith(e,[l]),!1)},l=s.promise({elem:e,props:b.extend({},t),opts:b.extend(!0,{specialEasing:{}},n),originalProperties:t,originalOptions:n,startTime:Xn||Kn(),duration:n.duration,tweens:[],createTween:function(t,n){var r=b.Tween(e,l.opts,t,n,l.opts.specialEasing[t]||l.opts.easing);return l.tweens.push(r),r},stop:function(t){var n=0,r=t?l.tweens.length:0;if(i)return this;for(i=!0;r>n;n++)l.tweens[n].run(1);return t?s.resolveWith(e,[l,t]):s.rejectWith(e,[l,t]),this}}),c=l.props;for(tr(c,l.opts.specialEasing);a>o;o++)if(r=Gn[o].call(l,e,c,l.opts))return r;return Zn(l,c),b.isFunction(l.opts.start)&&l.opts.start.call(e,l),b.fx.timer(b.extend(u,{elem:e,anim:l,queue:l.opts.queue})),l.progress(l.opts.progress).done(l.opts.done,l.opts.complete).fail(l.opts.fail).always(l.opts.always)}function tr(e,t){var n,r,i,o,a;for(i in e)if(r=b.camelCase(i),o=t[r],n=e[i],b.isArray(n)&&(o=n[1],n=e[i]=n[0]),i!==r&&(e[r]=n,delete e[i]),a=b.cssHooks[r],a&&"expand"in a){n=a.expand(n),delete e[r];for(i in n)i in e||(e[i]=n[i],t[i]=o)}else t[r]=o}b.Animation=b.extend(er,{tweener:function(e,t){b.isFunction(e)?(t=e,e=["*"]):e=e.split(" ");var n,r=0,i=e.length;for(;i>r;r++)n=e[r],Qn[n]=Qn[n]||[],Qn[n].unshift(t)},prefilter:function(e,t){t?Gn.unshift(e):Gn.push(e)}});function nr(e,t,n){var r,i,o,a,s,u,l,c,p,f=this,d=e.style,h={},g=[],m=e.nodeType&&nn(e);n.queue||(c=b._queueHooks(e,"fx"),null==c.unqueued&&(c.unqueued=0,p=c.empty.fire,c.empty.fire=function(){c.unqueued||p()}),c.unqueued++,f.always(function(){f.always(function(){c.unqueued--,b.queue(e,"fx").length||c.empty.fire()})})),1===e.nodeType&&("height"in t||"width"in t)&&(n.overflow=[d.overflow,d.overflowX,d.overflowY],"inline"===b.css(e,"display")&&"none"===b.css(e,"float")&&(b.support.inlineBlockNeedsLayout&&"inline"!==un(e.nodeName)?d.zoom=1:d.display="inline-block")),n.overflow&&(d.overflow="hidden",b.support.shrinkWrapBlocks||f.always(function(){d.overflow=n.overflow[0],d.overflowX=n.overflow[1],d.overflowY=n.overflow[2]}));for(i in t)if(a=t[i],Vn.exec(a)){if(delete t[i],u=u||"toggle"===a,a===(m?"hide":"show"))continue;g.push(i)}if(o=g.length){s=b._data(e,"fxshow")||b._data(e,"fxshow",{}),"hidden"in s&&(m=s.hidden),u&&(s.hidden=!m),m?b(e).show():f.done(function(){b(e).hide()}),f.done(function(){var t;b._removeData(e,"fxshow");for(t in h)b.style(e,t,h[t])});for(i=0;o>i;i++)r=g[i],l=f.createTween(r,m?s[r]:0),h[r]=s[r]||b.style(e,r),r in s||(s[r]=l.start,m&&(l.end=l.start,l.start="width"===r||"height"===r?1:0))}}function rr(e,t,n,r,i){return new rr.prototype.init(e,t,n,r,i)}b.Tween=rr,rr.prototype={constructor:rr,init:function(e,t,n,r,i,o){this.elem=e,this.prop=n,this.easing=i||"swing",this.options=t,this.start=this.now=this.cur(),this.end=r,this.unit=o||(b.cssNumber[n]?"":"px")},cur:function(){var e=rr.propHooks[this.prop];return e&&e.get?e.get(this):rr.propHooks._default.get(this)},run:function(e){var t,n=rr.propHooks[this.prop];return this.pos=t=this.options.duration?b.easing[this.easing](e,this.options.duration*e,0,1,this.options.duration):e,this.now=(this.end-this.start)*t+this.start,this.options.step&&this.options.step.call(this.elem,this.now,this),n&&n.set?n.set(this):rr.propHooks._default.set(this),this}},rr.prototype.init.prototype=rr.prototype,rr.propHooks={_default:{get:function(e){var t;return null==e.elem[e.prop]||e.elem.style&&null!=e.elem.style[e.prop]?(t=b.css(e.elem,e.prop,""),t&&"auto"!==t?t:0):e.elem[e.prop]},set:function(e){b.fx.step[e.prop]?b.fx.step[e.prop](e):e.elem.style&&(null!=e.elem.style[b.cssProps[e.prop]]||b.cssHooks[e.prop])?b.style(e.elem,e.prop,e.now+e.unit):e.elem[e.prop]=e.now}}},rr.propHooks.scrollTop=rr.propHooks.scrollLeft={set:function(e){e.elem.nodeType&&e.elem.parentNode&&(e.elem[e.prop]=e.now)}},b.each(["toggle","show","hide"],function(e,t){var n=b.fn[t];b.fn[t]=function(e,r,i){return null==e||"boolean"==typeof e?n.apply(this,arguments):this.animate(ir(t,!0),e,r,i)}}),b.fn.extend({fadeTo:function(e,t,n,r){return this.filter(nn).css("opacity",0).show().end().animate({opacity:t},e,n,r)},animate:function(e,t,n,r){var i=b.isEmptyObject(e),o=b.speed(t,n,r),a=function(){var t=er(this,b.extend({},e),o);a.finish=function(){t.stop(!0)},(i||b._data(this,"finish"))&&t.stop(!0)};return a.finish=a,i||o.queue===!1?this.each(a):this.queue(o.queue,a)},stop:function(e,n,r){var i=function(e){var t=e.stop;delete e.stop,t(r)};return"string"!=typeof e&&(r=n,n=e,e=t),n&&e!==!1&&this.queue(e||"fx",[]),this.each(function(){var t=!0,n=null!=e&&e+"queueHooks",o=b.timers,a=b._data(this);if(n)a[n]&&a[n].stop&&i(a[n]);else for(n in a)a[n]&&a[n].stop&&Jn.test(n)&&i(a[n]);for(n=o.length;n--;)o[n].elem!==this||null!=e&&o[n].queue!==e||(o[n].anim.stop(r),t=!1,o.splice(n,1));(t||!r)&&b.dequeue(this,e)})},finish:function(e){return e!==!1&&(e=e||"fx"),this.each(function(){var t,n=b._data(this),r=n[e+"queue"],i=n[e+"queueHooks"],o=b.timers,a=r?r.length:0;for(n.finish=!0,b.queue(this,e,[]),i&&i.cur&&i.cur.finish&&i.cur.finish.call(this),t=o.length;t--;)o[t].elem===this&&o[t].queue===e&&(o[t].anim.stop(!0),o.splice(t,1));for(t=0;a>t;t++)r[t]&&r[t].finish&&r[t].finish.call(this);delete n.finish})}});function ir(e,t){var n,r={height:e},i=0;for(t=t?1:0;4>i;i+=2-t)n=Zt[i],r["margin"+n]=r["padding"+n]=e;return t&&(r.opacity=r.width=e),r}b.each({slideDown:ir("show"),slideUp:ir("hide"),slideToggle:ir("toggle"),fadeIn:{opacity:"show"},fadeOut:{opacity:"hide"},fadeToggle:{opacity:"toggle"}},function(e,t){b.fn[e]=function(e,n,r){return this.animate(t,e,n,r)}}),b.speed=function(e,t,n){var r=e&&"object"==typeof e?b.extend({},e):{complete:n||!n&&t||b.isFunction(e)&&e,duration:e,easing:n&&t||t&&!b.isFunction(t)&&t};return r.duration=b.fx.off?0:"number"==typeof r.duration?r.duration:r.duration in b.fx.speeds?b.fx.speeds[r.duration]:b.fx.speeds._default,(null==r.queue||r.queue===!0)&&(r.queue="fx"),r.old=r.complete,r.complete=function(){b.isFunction(r.old)&&r.old.call(this),r.queue&&b.dequeue(this,r.queue)},r},b.easing={linear:function(e){return e},swing:function(e){return.5-Math.cos(e*Math.PI)/2}},b.timers=[],b.fx=rr.prototype.init,b.fx.tick=function(){var e,n=b.timers,r=0;for(Xn=b.now();n.length>r;r++)e=n[r],e()||n[r]!==e||n.splice(r--,1);n.length||b.fx.stop(),Xn=t},b.fx.timer=function(e){e()&&b.timers.push(e)&&b.fx.start()},b.fx.interval=13,b.fx.start=function(){Un||(Un=setInterval(b.fx.tick,b.fx.interval))},b.fx.stop=function(){clearInterval(Un),Un=null},b.fx.speeds={slow:600,fast:200,_default:400},b.fx.step={},b.expr&&b.expr.filters&&(b.expr.filters.animated=function(e){return b.grep(b.timers,function(t){return e===t.elem}).length}),b.fn.offset=function(e){if(arguments.length)return e===t?this:this.each(function(t){b.offset.setOffset(this,e,t)});var n,r,o={top:0,left:0},a=this[0],s=a&&a.ownerDocument;if(s)return n=s.documentElement,b.contains(n,a)?(typeof a.getBoundingClientRect!==i&&(o=a.getBoundingClientRect()),r=or(s),{top:o.top+(r.pageYOffset||n.scrollTop)-(n.clientTop||0),left:o.left+(r.pageXOffset||n.scrollLeft)-(n.clientLeft||0)}):o},b.offset={setOffset:function(e,t,n){var r=b.css(e,"position");"static"===r&&(e.style.position="relative");var i=b(e),o=i.offset(),a=b.css(e,"top"),s=b.css(e,"left"),u=("absolute"===r||"fixed"===r)&&b.inArray("auto",[a,s])>-1,l={},c={},p,f;u?(c=i.position(),p=c.top,f=c.left):(p=parseFloat(a)||0,f=parseFloat(s)||0),b.isFunction(t)&&(t=t.call(e,n,o)),null!=t.top&&(l.top=t.top-o.top+p),null!=t.left&&(l.left=t.left-o.left+f),"using"in t?t.using.call(e,l):i.css(l)}},b.fn.extend({position:function(){if(this[0]){var e,t,n={top:0,left:0},r=this[0];return"fixed"===b.css(r,"position")?t=r.getBoundingClientRect():(e=this.offsetParent(),t=this.offset(),b.nodeName(e[0],"html")||(n=e.offset()),n.top+=b.css(e[0],"borderTopWidth",!0),n.left+=b.css(e[0],"borderLeftWidth",!0)),{top:t.top-n.top-b.css(r,"marginTop",!0),left:t.left-n.left-b.css(r,"marginLeft",!0)}}},offsetParent:function(){return this.map(function(){var e=this.offsetParent||o.documentElement;while(e&&!b.nodeName(e,"html")&&"static"===b.css(e,"position"))e=e.offsetParent;return e||o.documentElement})}}),b.each({scrollLeft:"pageXOffset",scrollTop:"pageYOffset"},function(e,n){var r=/Y/.test(n);b.fn[e]=function(i){return b.access(this,function(e,i,o){var a=or(e);return o===t?a?n in a?a[n]:a.document.documentElement[i]:e[i]:(a?a.scrollTo(r?b(a).scrollLeft():o,r?o:b(a).scrollTop()):e[i]=o,t)},e,i,arguments.length,null)}});function or(e){return b.isWindow(e)?e:9===e.nodeType?e.defaultView||e.parentWindow:!1}b.each({Height:"height",Width:"width"},function(e,n){b.each({padding:"inner"+e,content:n,"":"outer"+e},function(r,i){b.fn[i]=function(i,o){var a=arguments.length&&(r||"boolean"!=typeof i),s=r||(i===!0||o===!0?"margin":"border");return b.access(this,function(n,r,i){var o;return b.isWindow(n)?n.document.documentElement["client"+e]:9===n.nodeType?(o=n.documentElement,Math.max(n.body["scroll"+e],o["scroll"+e],n.body["offset"+e],o["offset"+e],o["client"+e])):i===t?b.css(n,r,s):b.style(n,r,i,s)},n,a?i:t,a,null)}})}),e.jQuery=e.$=b,"function"==typeof define&&define.amd&&define.amd.jQuery&&define("jquery",[],function(){return b})})(window);
/* Main Jquery Ends */
/* Jquery UI */
(function(e,t){function i(t,n){var r,i,o,u=t.nodeName.toLowerCase();if("area"===u){r=t.parentNode;i=r.name;if(!t.href||!i||r.nodeName.toLowerCase()!=="map"){return false}o=e("img[usemap=#"+i+"]")[0];return!!o&&s(o)}return(/input|select|textarea|button|object/.test(u)?!t.disabled:"a"===u?t.href||n:n)&&s(t)}function s(t){return e.expr.filters.visible(t)&&!e(t).parents().addBack().filter(function(){return e.css(this,"visibility")==="hidden"}).length}var n=0,r=/^ui-id-\d+$/;e.ui=e.ui||{};e.extend(e.ui,{version:"1.10.3",keyCode:{BACKSPACE:8,COMMA:188,DELETE:46,DOWN:40,END:35,ENTER:13,ESCAPE:27,HOME:36,LEFT:37,NUMPAD_ADD:107,NUMPAD_DECIMAL:110,NUMPAD_DIVIDE:111,NUMPAD_ENTER:108,NUMPAD_MULTIPLY:106,NUMPAD_SUBTRACT:109,PAGE_DOWN:34,PAGE_UP:33,PERIOD:190,RIGHT:39,SPACE:32,TAB:9,UP:38}});e.fn.extend({focus:function(t){return function(n,r){return typeof n==="number"?this.each(function(){var t=this;setTimeout(function(){e(t).focus();if(r){r.call(t)}},n)}):t.apply(this,arguments)}}(e.fn.focus),scrollParent:function(){var t;if(e.ui.ie&&/(static|relative)/.test(this.css("position"))||/absolute/.test(this.css("position"))){t=this.parents().filter(function(){return/(relative|absolute|fixed)/.test(e.css(this,"position"))&&/(auto|scroll)/.test(e.css(this,"overflow")+e.css(this,"overflow-y")+e.css(this,"overflow-x"))}).eq(0)}else{t=this.parents().filter(function(){return/(auto|scroll)/.test(e.css(this,"overflow")+e.css(this,"overflow-y")+e.css(this,"overflow-x"))}).eq(0)}return/fixed/.test(this.css("position"))||!t.length?e(document):t},zIndex:function(n){if(n!==t){return this.css("zIndex",n)}if(this.length){var r=e(this[0]),i,s;while(r.length&&r[0]!==document){i=r.css("position");if(i==="absolute"||i==="relative"||i==="fixed"){s=parseInt(r.css("zIndex"),10);if(!isNaN(s)&&s!==0){return s}}r=r.parent()}}return 0},uniqueId:function(){return this.each(function(){if(!this.id){this.id="ui-id-"+ ++n}})},removeUniqueId:function(){return this.each(function(){if(r.test(this.id)){e(this).removeAttr("id")}})}});e.extend(e.expr[":"],{data:e.expr.createPseudo?e.expr.createPseudo(function(t){return function(n){return!!e.data(n,t)}}):function(t,n,r){return!!e.data(t,r[3])},focusable:function(t){return i(t,!isNaN(e.attr(t,"tabindex")))},tabbable:function(t){var n=e.attr(t,"tabindex"),r=isNaN(n);return(r||n>=0)&&i(t,!r)}});if(!e("<a>").outerWidth(1).jquery){e.each(["Width","Height"],function(n,r){function u(t,n,r,s){e.each(i,function(){n-=parseFloat(e.css(t,"padding"+this))||0;if(r){n-=parseFloat(e.css(t,"border"+this+"Width"))||0}if(s){n-=parseFloat(e.css(t,"margin"+this))||0}});return n}var i=r==="Width"?["Left","Right"]:["Top","Bottom"],s=r.toLowerCase(),o={innerWidth:e.fn.innerWidth,innerHeight:e.fn.innerHeight,outerWidth:e.fn.outerWidth,outerHeight:e.fn.outerHeight};e.fn["inner"+r]=function(n){if(n===t){return o["inner"+r].call(this)}return this.each(function(){e(this).css(s,u(this,n)+"px")})};e.fn["outer"+r]=function(t,n){if(typeof t!=="number"){return o["outer"+r].call(this,t)}return this.each(function(){e(this).css(s,u(this,t,true,n)+"px")})}})}if(!e.fn.addBack){e.fn.addBack=function(e){return this.add(e==null?this.prevObject:this.prevObject.filter(e))}}if(e("<a>").data("a-b","a").removeData("a-b").data("a-b")){e.fn.removeData=function(t){return function(n){if(arguments.length){return t.call(this,e.camelCase(n))}else{return t.call(this)}}}(e.fn.removeData)}e.ui.ie=!!/msie [\w.]+/.exec(navigator.userAgent.toLowerCase());e.support.selectstart="onselectstart"in document.createElement("div");e.fn.extend({disableSelection:function(){return this.bind((e.support.selectstart?"selectstart":"mousedown")+".ui-disableSelection",function(e){e.preventDefault()})},enableSelection:function(){return this.unbind(".ui-disableSelection")}});e.extend(e.ui,{plugin:{add:function(t,n,r){var i,s=e.ui[t].prototype;for(i in r){s.plugins[i]=s.plugins[i]||[];s.plugins[i].push([n,r[i]])}},call:function(e,t,n){var r,i=e.plugins[t];if(!i||!e.element[0].parentNode||e.element[0].parentNode.nodeType===11){return}for(r=0;r<i.length;r++){if(e.options[i[r][0]]){i[r][1].apply(e.element,n)}}}},hasScroll:function(t,n){if(e(t).css("overflow")==="hidden"){return false}var r=n&&n==="left"?"scrollLeft":"scrollTop",i=false;if(t[r]>0){return true}t[r]=1;i=t[r]>0;t[r]=0;return i}})})(jQuery);(function(e,t){var n=0,r=Array.prototype.slice,i=e.cleanData;e.cleanData=function(t){for(var n=0,r;(r=t[n])!=null;n++){try{e(r).triggerHandler("remove")}catch(s){}}i(t)};e.widget=function(t,n,r){var i,s,o,u,a={},f=t.split(".")[0];t=t.split(".")[1];i=f+"-"+t;if(!r){r=n;n=e.Widget}e.expr[":"][i.toLowerCase()]=function(t){return!!e.data(t,i)};e[f]=e[f]||{};s=e[f][t];o=e[f][t]=function(e,t){if(!this._createWidget){return new o(e,t)}if(arguments.length){this._createWidget(e,t)}};e.extend(o,s,{version:r.version,_proto:e.extend({},r),_childConstructors:[]});u=new n;u.options=e.widget.extend({},u.options);e.each(r,function(t,r){if(!e.isFunction(r)){a[t]=r;return}a[t]=function(){var e=function(){return n.prototype[t].apply(this,arguments)},i=function(e){return n.prototype[t].apply(this,e)};return function(){var t=this._super,n=this._superApply,s;this._super=e;this._superApply=i;s=r.apply(this,arguments);this._super=t;this._superApply=n;return s}}()});o.prototype=e.widget.extend(u,{widgetEventPrefix:s?u.widgetEventPrefix:t},a,{constructor:o,namespace:f,widgetName:t,widgetFullName:i});if(s){e.each(s._childConstructors,function(t,n){var r=n.prototype;e.widget(r.namespace+"."+r.widgetName,o,n._proto)});delete s._childConstructors}else{n._childConstructors.push(o)}e.widget.bridge(t,o)};e.widget.extend=function(n){var i=r.call(arguments,1),s=0,o=i.length,u,a;for(;s<o;s++){for(u in i[s]){a=i[s][u];if(i[s].hasOwnProperty(u)&&a!==t){if(e.isPlainObject(a)){n[u]=e.isPlainObject(n[u])?e.widget.extend({},n[u],a):e.widget.extend({},a)}else{n[u]=a}}}}return n};e.widget.bridge=function(n,i){var s=i.prototype.widgetFullName||n;e.fn[n]=function(o){var u=typeof o==="string",a=r.call(arguments,1),f=this;o=!u&&a.length?e.widget.extend.apply(null,[o].concat(a)):o;if(u){this.each(function(){var r,i=e.data(this,s);if(!i){return e.error("cannot call methods on "+n+" prior to initialization; "+"attempted to call method '"+o+"'")}if(!e.isFunction(i[o])||o.charAt(0)==="_"){return e.error("no such method '"+o+"' for "+n+" widget instance")}r=i[o].apply(i,a);if(r!==i&&r!==t){f=r&&r.jquery?f.pushStack(r.get()):r;return false}})}else{this.each(function(){var t=e.data(this,s);if(t){t.option(o||{})._init()}else{e.data(this,s,new i(o,this))}})}return f}};e.Widget=function(){};e.Widget._childConstructors=[];e.Widget.prototype={widgetName:"widget",widgetEventPrefix:"",defaultElement:"<div>",options:{disabled:false,create:null},_createWidget:function(t,r){r=e(r||this.defaultElement||this)[0];this.element=e(r);this.uuid=n++;this.eventNamespace="."+this.widgetName+this.uuid;this.options=e.widget.extend({},this.options,this._getCreateOptions(),t);this.bindings=e();this.hoverable=e();this.focusable=e();if(r!==this){e.data(r,this.widgetFullName,this);this._on(true,this.element,{remove:function(e){if(e.target===r){this.destroy()}}});this.document=e(r.style?r.ownerDocument:r.document||r);this.window=e(this.document[0].defaultView||this.document[0].parentWindow)}this._create();this._trigger("create",null,this._getCreateEventData());this._init()},_getCreateOptions:e.noop,_getCreateEventData:e.noop,_create:e.noop,_init:e.noop,destroy:function(){this._destroy();this.element.unbind(this.eventNamespace).removeData(this.widgetName).removeData(this.widgetFullName).removeData(e.camelCase(this.widgetFullName));this.widget().unbind(this.eventNamespace).removeAttr("aria-disabled").removeClass(this.widgetFullName+"-disabled "+"ui-state-disabled");this.bindings.unbind(this.eventNamespace);this.hoverable.removeClass("ui-state-hover");this.focusable.removeClass("ui-state-focus")},_destroy:e.noop,widget:function(){return this.element},option:function(n,r){var i=n,s,o,u;if(arguments.length===0){return e.widget.extend({},this.options)}if(typeof n==="string"){i={};s=n.split(".");n=s.shift();if(s.length){o=i[n]=e.widget.extend({},this.options[n]);for(u=0;u<s.length-1;u++){o[s[u]]=o[s[u]]||{};o=o[s[u]]}n=s.pop();if(r===t){return o[n]===t?null:o[n]}o[n]=r}else{if(r===t){return this.options[n]===t?null:this.options[n]}i[n]=r}}this._setOptions(i);return this},_setOptions:function(e){var t;for(t in e){this._setOption(t,e[t])}return this},_setOption:function(e,t){this.options[e]=t;if(e==="disabled"){this.widget().toggleClass(this.widgetFullName+"-disabled ui-state-disabled",!!t).attr("aria-disabled",t);this.hoverable.removeClass("ui-state-hover");this.focusable.removeClass("ui-state-focus")}return this},enable:function(){return this._setOption("disabled",false)},disable:function(){return this._setOption("disabled",true)},_on:function(t,n,r){var i,s=this;if(typeof t!=="boolean"){r=n;n=t;t=false}if(!r){r=n;n=this.element;i=this.widget()}else{n=i=e(n);this.bindings=this.bindings.add(n)}e.each(r,function(r,o){function u(){if(!t&&(s.options.disabled===true||e(this).hasClass("ui-state-disabled"))){return}return(typeof o==="string"?s[o]:o).apply(s,arguments)}if(typeof o!=="string"){u.guid=o.guid=o.guid||u.guid||e.guid++}var a=r.match(/^(\w+)\s*(.*)$/),f=a[1]+s.eventNamespace,l=a[2];if(l){i.delegate(l,f,u)}else{n.bind(f,u)}})},_off:function(e,t){t=(t||"").split(" ").join(this.eventNamespace+" ")+this.eventNamespace;e.unbind(t).undelegate(t)},_delay:function(e,t){function n(){return(typeof e==="string"?r[e]:e).apply(r,arguments)}var r=this;return setTimeout(n,t||0)},_hoverable:function(t){this.hoverable=this.hoverable.add(t);this._on(t,{mouseenter:function(t){e(t.currentTarget).addClass("ui-state-hover")},mouseleave:function(t){e(t.currentTarget).removeClass("ui-state-hover")}})},_focusable:function(t){this.focusable=this.focusable.add(t);this._on(t,{focusin:function(t){e(t.currentTarget).addClass("ui-state-focus")},focusout:function(t){e(t.currentTarget).removeClass("ui-state-focus")}})},_trigger:function(t,n,r){var i,s,o=this.options[t];r=r||{};n=e.Event(n);n.type=(t===this.widgetEventPrefix?t:this.widgetEventPrefix+t).toLowerCase();n.target=this.element[0];s=n.originalEvent;if(s){for(i in s){if(!(i in n)){n[i]=s[i]}}}this.element.trigger(n,r);return!(e.isFunction(o)&&o.apply(this.element[0],[n].concat(r))===false||n.isDefaultPrevented())}};e.each({show:"fadeIn",hide:"fadeOut"},function(t,n){e.Widget.prototype["_"+t]=function(r,i,s){if(typeof i==="string"){i={effect:i}}var o,u=!i?t:i===true||typeof i==="number"?n:i.effect||n;i=i||{};if(typeof i==="number"){i={duration:i}}o=!e.isEmptyObject(i);i.complete=s;if(i.delay){r.delay(i.delay)}if(o&&e.effects&&e.effects.effect[u]){r[t](i)}else if(u!==t&&r[u]){r[u](i.duration,i.easing,s)}else{r.queue(function(n){e(this)[t]();if(s){s.call(r[0])}n()})}}})})(jQuery);(function(e,t){var n=false;e(document).mouseup(function(){n=false});e.widget("ui.mouse",{version:"1.10.3",options:{cancel:"input,textarea,button,select,option",distance:1,delay:0},_mouseInit:function(){var t=this;this.element.bind("mousedown."+this.widgetName,function(e){return t._mouseDown(e)}).bind("click."+this.widgetName,function(n){if(true===e.data(n.target,t.widgetName+".preventClickEvent")){e.removeData(n.target,t.widgetName+".preventClickEvent");n.stopImmediatePropagation();return false}});this.started=false},_mouseDestroy:function(){this.element.unbind("."+this.widgetName);if(this._mouseMoveDelegate){e(document).unbind("mousemove."+this.widgetName,this._mouseMoveDelegate).unbind("mouseup."+this.widgetName,this._mouseUpDelegate)}},_mouseDown:function(t){if(n){return}this._mouseStarted&&this._mouseUp(t);this._mouseDownEvent=t;var r=this,i=t.which===1,s=typeof this.options.cancel==="string"&&t.target.nodeName?e(t.target).closest(this.options.cancel).length:false;if(!i||s||!this._mouseCapture(t)){return true}this.mouseDelayMet=!this.options.delay;if(!this.mouseDelayMet){this._mouseDelayTimer=setTimeout(function(){r.mouseDelayMet=true},this.options.delay)}if(this._mouseDistanceMet(t)&&this._mouseDelayMet(t)){this._mouseStarted=this._mouseStart(t)!==false;if(!this._mouseStarted){t.preventDefault();return true}}if(true===e.data(t.target,this.widgetName+".preventClickEvent")){e.removeData(t.target,this.widgetName+".preventClickEvent")}this._mouseMoveDelegate=function(e){return r._mouseMove(e)};this._mouseUpDelegate=function(e){return r._mouseUp(e)};e(document).bind("mousemove."+this.widgetName,this._mouseMoveDelegate).bind("mouseup."+this.widgetName,this._mouseUpDelegate);t.preventDefault();n=true;return true},_mouseMove:function(t){if(e.ui.ie&&(!document.documentMode||document.documentMode<9)&&!t.button){return this._mouseUp(t)}if(this._mouseStarted){this._mouseDrag(t);return t.preventDefault()}if(this._mouseDistanceMet(t)&&this._mouseDelayMet(t)){this._mouseStarted=this._mouseStart(this._mouseDownEvent,t)!==false;this._mouseStarted?this._mouseDrag(t):this._mouseUp(t)}return!this._mouseStarted},_mouseUp:function(t){e(document).unbind("mousemove."+this.widgetName,this._mouseMoveDelegate).unbind("mouseup."+this.widgetName,this._mouseUpDelegate);if(this._mouseStarted){this._mouseStarted=false;if(t.target===this._mouseDownEvent.target){e.data(t.target,this.widgetName+".preventClickEvent",true)}this._mouseStop(t)}return false},_mouseDistanceMet:function(e){return Math.max(Math.abs(this._mouseDownEvent.pageX-e.pageX),Math.abs(this._mouseDownEvent.pageY-e.pageY))>=this.options.distance},_mouseDelayMet:function(){return this.mouseDelayMet},_mouseStart:function(){},_mouseDrag:function(){},_mouseStop:function(){},_mouseCapture:function(){return true}})})(jQuery);(function(e,t){e.widget("ui.draggable",e.ui.mouse,{version:"1.10.3",widgetEventPrefix:"drag",options:{addClasses:true,appendTo:"parent",axis:false,connectToSortable:false,containment:false,cursor:"auto",cursorAt:false,grid:false,handle:false,helper:"original",iframeFix:false,opacity:false,refreshPositions:false,revert:false,revertDuration:500,scope:"default",scroll:true,scrollSensitivity:20,scrollSpeed:20,snap:false,snapMode:"both",snapTolerance:20,stack:false,zIndex:false,drag:null,start:null,stop:null},_create:function(){if(this.options.helper==="original"&&!/^(?:r|a|f)/.test(this.element.css("position"))){this.element[0].style.position="relative"}if(this.options.addClasses){this.element.addClass("ui-draggable")}if(this.options.disabled){this.element.addClass("ui-draggable-disabled")}this._mouseInit()},_destroy:function(){this.element.removeClass("ui-draggable ui-draggable-dragging ui-draggable-disabled");this._mouseDestroy()},_mouseCapture:function(t){var n=this.options;if(this.helper||n.disabled||e(t.target).closest(".ui-resizable-handle").length>0){return false}this.handle=this._getHandle(t);if(!this.handle){return false}e(n.iframeFix===true?"iframe":n.iframeFix).each(function(){e("<div class='ui-draggable-iframeFix' style='background: #fff;'></div>").css({width:this.offsetWidth+"px",height:this.offsetHeight+"px",position:"absolute",opacity:"0.001",zIndex:1e3}).css(e(this).offset()).appendTo("body")});return true},_mouseStart:function(t){var n=this.options;this.helper=this._createHelper(t);this.helper.addClass("ui-draggable-dragging");this._cacheHelperProportions();if(e.ui.ddmanager){e.ui.ddmanager.current=this}this._cacheMargins();this.cssPosition=this.helper.css("position");this.scrollParent=this.helper.scrollParent();this.offsetParent=this.helper.offsetParent();this.offsetParentCssPosition=this.offsetParent.css("position");this.offset=this.positionAbs=this.element.offset();this.offset={top:this.offset.top-this.margins.top,left:this.offset.left-this.margins.left};this.offset.scroll=false;e.extend(this.offset,{click:{left:t.pageX-this.offset.left,top:t.pageY-this.offset.top},parent:this._getParentOffset(),relative:this._getRelativeOffset()});this.originalPosition=this.position=this._generatePosition(t);this.originalPageX=t.pageX;this.originalPageY=t.pageY;n.cursorAt&&this._adjustOffsetFromHelper(n.cursorAt);this._setContainment();if(this._trigger("start",t)===false){this._clear();return false}this._cacheHelperProportions();if(e.ui.ddmanager&&!n.dropBehaviour){e.ui.ddmanager.prepareOffsets(this,t)}this._mouseDrag(t,true);if(e.ui.ddmanager){e.ui.ddmanager.dragStart(this,t)}return true},_mouseDrag:function(t,n){if(this.offsetParentCssPosition==="fixed"){this.offset.parent=this._getParentOffset()}this.position=this._generatePosition(t);this.positionAbs=this._convertPositionTo("absolute");if(!n){var r=this._uiHash();if(this._trigger("drag",t,r)===false){this._mouseUp({});return false}this.position=r.position}if(!this.options.axis||this.options.axis!=="y"){this.helper[0].style.left=this.position.left+"px"}if(!this.options.axis||this.options.axis!=="x"){this.helper[0].style.top=this.position.top+"px"}if(e.ui.ddmanager){e.ui.ddmanager.drag(this,t)}return false},_mouseStop:function(t){var n=this,r=false;if(e.ui.ddmanager&&!this.options.dropBehaviour){r=e.ui.ddmanager.drop(this,t)}if(this.dropped){r=this.dropped;this.dropped=false}if(this.options.helper==="original"&&!e.contains(this.element[0].ownerDocument,this.element[0])){return false}if(this.options.revert==="invalid"&&!r||this.options.revert==="valid"&&r||this.options.revert===true||e.isFunction(this.options.revert)&&this.options.revert.call(this.element,r)){e(this.helper).animate(this.originalPosition,parseInt(this.options.revertDuration,10),function(){if(n._trigger("stop",t)!==false){n._clear()}})}else{if(this._trigger("stop",t)!==false){this._clear()}}return false},_mouseUp:function(t){e("div.ui-draggable-iframeFix").each(function(){this.parentNode.removeChild(this)});if(e.ui.ddmanager){e.ui.ddmanager.dragStop(this,t)}return e.ui.mouse.prototype._mouseUp.call(this,t)},cancel:function(){if(this.helper.is(".ui-draggable-dragging")){this._mouseUp({})}else{this._clear()}return this},_getHandle:function(t){return this.options.handle?!!e(t.target).closest(this.element.find(this.options.handle)).length:true},_createHelper:function(t){var n=this.options,r=e.isFunction(n.helper)?e(n.helper.apply(this.element[0],[t])):n.helper==="clone"?this.element.clone().removeAttr("id"):this.element;if(!r.parents("body").length){r.appendTo(n.appendTo==="parent"?this.element[0].parentNode:n.appendTo)}if(r[0]!==this.element[0]&&!/(fixed|absolute)/.test(r.css("position"))){r.css("position","absolute")}return r},_adjustOffsetFromHelper:function(t){if(typeof t==="string"){t=t.split(" ")}if(e.isArray(t)){t={left:+t[0],top:+t[1]||0}}if("left"in t){this.offset.click.left=t.left+this.margins.left}if("right"in t){this.offset.click.left=this.helperProportions.width-t.right+this.margins.left}if("top"in t){this.offset.click.top=t.top+this.margins.top}if("bottom"in t){this.offset.click.top=this.helperProportions.height-t.bottom+this.margins.top}},_getParentOffset:function(){var t=this.offsetParent.offset();if(this.cssPosition==="absolute"&&this.scrollParent[0]!==document&&e.contains(this.scrollParent[0],this.offsetParent[0])){t.left+=this.scrollParent.scrollLeft();t.top+=this.scrollParent.scrollTop()}if(this.offsetParent[0]===document.body||this.offsetParent[0].tagName&&this.offsetParent[0].tagName.toLowerCase()==="html"&&e.ui.ie){t={top:0,left:0}}return{top:t.top+(parseInt(this.offsetParent.css("borderTopWidth"),10)||0),left:t.left+(parseInt(this.offsetParent.css("borderLeftWidth"),10)||0)}},_getRelativeOffset:function(){if(this.cssPosition==="relative"){var e=this.element.position();return{top:e.top-(parseInt(this.helper.css("top"),10)||0)+this.scrollParent.scrollTop(),left:e.left-(parseInt(this.helper.css("left"),10)||0)+this.scrollParent.scrollLeft()}}else{return{top:0,left:0}}},_cacheMargins:function(){this.margins={left:parseInt(this.element.css("marginLeft"),10)||0,top:parseInt(this.element.css("marginTop"),10)||0,right:parseInt(this.element.css("marginRight"),10)||0,bottom:parseInt(this.element.css("marginBottom"),10)||0}},_cacheHelperProportions:function(){this.helperProportions={width:this.helper.outerWidth(),height:this.helper.outerHeight()}},_setContainment:function(){var t,n,r,i=this.options;if(!i.containment){this.containment=null;return}if(i.containment==="window"){this.containment=[e(window).scrollLeft()-this.offset.relative.left-this.offset.parent.left,e(window).scrollTop()-this.offset.relative.top-this.offset.parent.top,e(window).scrollLeft()+e(window).width()-this.helperProportions.width-this.margins.left,e(window).scrollTop()+(e(window).height()||document.body.parentNode.scrollHeight)-this.helperProportions.height-this.margins.top];return}if(i.containment==="document"){this.containment=[0,0,e(document).width()-this.helperProportions.width-this.margins.left,(e(document).height()||document.body.parentNode.scrollHeight)-this.helperProportions.height-this.margins.top];return}if(i.containment.constructor===Array){this.containment=i.containment;return}if(i.containment==="parent"){i.containment=this.helper[0].parentNode}n=e(i.containment);r=n[0];if(!r){return}t=n.css("overflow")!=="hidden";this.containment=[(parseInt(n.css("borderLeftWidth"),10)||0)+(parseInt(n.css("paddingLeft"),10)||0),(parseInt(n.css("borderTopWidth"),10)||0)+(parseInt(n.css("paddingTop"),10)||0),(t?Math.max(r.scrollWidth,r.offsetWidth):r.offsetWidth)-(parseInt(n.css("borderRightWidth"),10)||0)-(parseInt(n.css("paddingRight"),10)||0)-this.helperProportions.width-this.margins.left-this.margins.right,(t?Math.max(r.scrollHeight,r.offsetHeight):r.offsetHeight)-(parseInt(n.css("borderBottomWidth"),10)||0)-(parseInt(n.css("paddingBottom"),10)||0)-this.helperProportions.height-this.margins.top-this.margins.bottom];this.relative_container=n},_convertPositionTo:function(t,n){if(!n){n=this.position}var r=t==="absolute"?1:-1,i=this.cssPosition==="absolute"&&!(this.scrollParent[0]!==document&&e.contains(this.scrollParent[0],this.offsetParent[0]))?this.offsetParent:this.scrollParent;if(!this.offset.scroll){this.offset.scroll={top:i.scrollTop(),left:i.scrollLeft()}}return{top:n.top+this.offset.relative.top*r+this.offset.parent.top*r-(this.cssPosition==="fixed"?-this.scrollParent.scrollTop():this.offset.scroll.top)*r,left:n.left+this.offset.relative.left*r+this.offset.parent.left*r-(this.cssPosition==="fixed"?-this.scrollParent.scrollLeft():this.offset.scroll.left)*r}},_generatePosition:function(t){var n,r,i,s,o=this.options,u=this.cssPosition==="absolute"&&!(this.scrollParent[0]!==document&&e.contains(this.scrollParent[0],this.offsetParent[0]))?this.offsetParent:this.scrollParent,a=t.pageX,f=t.pageY;if(!this.offset.scroll){this.offset.scroll={top:u.scrollTop(),left:u.scrollLeft()}}if(this.originalPosition){if(this.containment){if(this.relative_container){r=this.relative_container.offset();n=[this.containment[0]+r.left,this.containment[1]+r.top,this.containment[2]+r.left,this.containment[3]+r.top]}else{n=this.containment}if(t.pageX-this.offset.click.left<n[0]){a=n[0]+this.offset.click.left}if(t.pageY-this.offset.click.top<n[1]){f=n[1]+this.offset.click.top}if(t.pageX-this.offset.click.left>n[2]){a=n[2]+this.offset.click.left}if(t.pageY-this.offset.click.top>n[3]){f=n[3]+this.offset.click.top}}if(o.grid){i=o.grid[1]?this.originalPageY+Math.round((f-this.originalPageY)/o.grid[1])*o.grid[1]:this.originalPageY;f=n?i-this.offset.click.top>=n[1]||i-this.offset.click.top>n[3]?i:i-this.offset.click.top>=n[1]?i-o.grid[1]:i+o.grid[1]:i;s=o.grid[0]?this.originalPageX+Math.round((a-this.originalPageX)/o.grid[0])*o.grid[0]:this.originalPageX;a=n?s-this.offset.click.left>=n[0]||s-this.offset.click.left>n[2]?s:s-this.offset.click.left>=n[0]?s-o.grid[0]:s+o.grid[0]:s}}return{top:f-this.offset.click.top-this.offset.relative.top-this.offset.parent.top+(this.cssPosition==="fixed"?-this.scrollParent.scrollTop():this.offset.scroll.top),left:a-this.offset.click.left-this.offset.relative.left-this.offset.parent.left+(this.cssPosition==="fixed"?-this.scrollParent.scrollLeft():this.offset.scroll.left)}},_clear:function(){this.helper.removeClass("ui-draggable-dragging");if(this.helper[0]!==this.element[0]&&!this.cancelHelperRemoval){this.helper.remove()}this.helper=null;this.cancelHelperRemoval=false},_trigger:function(t,n,r){r=r||this._uiHash();e.ui.plugin.call(this,t,[n,r]);if(t==="drag"){this.positionAbs=this._convertPositionTo("absolute")}return e.Widget.prototype._trigger.call(this,t,n,r)},plugins:{},_uiHash:function(){return{helper:this.helper,position:this.position,originalPosition:this.originalPosition,offset:this.positionAbs}}});e.ui.plugin.add("draggable","connectToSortable",{start:function(t,n){var r=e(this).data("ui-draggable"),i=r.options,s=e.extend({},n,{item:r.element});r.sortables=[];e(i.connectToSortable).each(function(){var n=e.data(this,"ui-sortable");if(n&&!n.options.disabled){r.sortables.push({instance:n,shouldRevert:n.options.revert});n.refreshPositions();n._trigger("activate",t,s)}})},stop:function(t,n){var r=e(this).data("ui-draggable"),i=e.extend({},n,{item:r.element});e.each(r.sortables,function(){if(this.instance.isOver){this.instance.isOver=0;r.cancelHelperRemoval=true;this.instance.cancelHelperRemoval=false;if(this.shouldRevert){this.instance.options.revert=this.shouldRevert}this.instance._mouseStop(t);this.instance.options.helper=this.instance.options._helper;if(r.options.helper==="original"){this.instance.currentItem.css({top:"auto",left:"auto"})}}else{this.instance.cancelHelperRemoval=false;this.instance._trigger("deactivate",t,i)}})},drag:function(t,n){var r=e(this).data("ui-draggable"),i=this;e.each(r.sortables,function(){var s=false,o=this;this.instance.positionAbs=r.positionAbs;this.instance.helperProportions=r.helperProportions;this.instance.offset.click=r.offset.click;if(this.instance._intersectsWith(this.instance.containerCache)){s=true;e.each(r.sortables,function(){this.instance.positionAbs=r.positionAbs;this.instance.helperProportions=r.helperProportions;this.instance.offset.click=r.offset.click;if(this!==o&&this.instance._intersectsWith(this.instance.containerCache)&&e.contains(o.instance.element[0],this.instance.element[0])){s=false}return s})}if(s){if(!this.instance.isOver){this.instance.isOver=1;this.instance.currentItem=e(i).clone().removeAttr("id").appendTo(this.instance.element).data("ui-sortable-item",true);this.instance.options._helper=this.instance.options.helper;this.instance.options.helper=function(){return n.helper[0]};t.target=this.instance.currentItem[0];this.instance._mouseCapture(t,true);this.instance._mouseStart(t,true,true);this.instance.offset.click.top=r.offset.click.top;this.instance.offset.click.left=r.offset.click.left;this.instance.offset.parent.left-=r.offset.parent.left-this.instance.offset.parent.left;this.instance.offset.parent.top-=r.offset.parent.top-this.instance.offset.parent.top;r._trigger("toSortable",t);r.dropped=this.instance.element;r.currentItem=r.element;this.instance.fromOutside=r}if(this.instance.currentItem){this.instance._mouseDrag(t)}}else{if(this.instance.isOver){this.instance.isOver=0;this.instance.cancelHelperRemoval=true;this.instance.options.revert=false;this.instance._trigger("out",t,this.instance._uiHash(this.instance));this.instance._mouseStop(t,true);this.instance.options.helper=this.instance.options._helper;this.instance.currentItem.remove();if(this.instance.placeholder){this.instance.placeholder.remove()}r._trigger("fromSortable",t);r.dropped=false}}})}});e.ui.plugin.add("draggable","cursor",{start:function(){var t=e("body"),n=e(this).data("ui-draggable").options;if(t.css("cursor")){n._cursor=t.css("cursor")}t.css("cursor",n.cursor)},stop:function(){var t=e(this).data("ui-draggable").options;if(t._cursor){e("body").css("cursor",t._cursor)}}});e.ui.plugin.add("draggable","opacity",{start:function(t,n){var r=e(n.helper),i=e(this).data("ui-draggable").options;if(r.css("opacity")){i._opacity=r.css("opacity")}r.css("opacity",i.opacity)},stop:function(t,n){var r=e(this).data("ui-draggable").options;if(r._opacity){e(n.helper).css("opacity",r._opacity)}}});e.ui.plugin.add("draggable","scroll",{start:function(){var t=e(this).data("ui-draggable");if(t.scrollParent[0]!==document&&t.scrollParent[0].tagName!=="HTML"){t.overflowOffset=t.scrollParent.offset()}},drag:function(t){var n=e(this).data("ui-draggable"),r=n.options,i=false;if(n.scrollParent[0]!==document&&n.scrollParent[0].tagName!=="HTML"){if(!r.axis||r.axis!=="x"){if(n.overflowOffset.top+n.scrollParent[0].offsetHeight-t.pageY<r.scrollSensitivity){n.scrollParent[0].scrollTop=i=n.scrollParent[0].scrollTop+r.scrollSpeed}else if(t.pageY-n.overflowOffset.top<r.scrollSensitivity){n.scrollParent[0].scrollTop=i=n.scrollParent[0].scrollTop-r.scrollSpeed}}if(!r.axis||r.axis!=="y"){if(n.overflowOffset.left+n.scrollParent[0].offsetWidth-t.pageX<r.scrollSensitivity){n.scrollParent[0].scrollLeft=i=n.scrollParent[0].scrollLeft+r.scrollSpeed}else if(t.pageX-n.overflowOffset.left<r.scrollSensitivity){n.scrollParent[0].scrollLeft=i=n.scrollParent[0].scrollLeft-r.scrollSpeed}}}else{if(!r.axis||r.axis!=="x"){if(t.pageY-e(document).scrollTop()<r.scrollSensitivity){i=e(document).scrollTop(e(document).scrollTop()-r.scrollSpeed)}else if(e(window).height()-(t.pageY-e(document).scrollTop())<r.scrollSensitivity){i=e(document).scrollTop(e(document).scrollTop()+r.scrollSpeed)}}if(!r.axis||r.axis!=="y"){if(t.pageX-e(document).scrollLeft()<r.scrollSensitivity){i=e(document).scrollLeft(e(document).scrollLeft()-r.scrollSpeed)}else if(e(window).width()-(t.pageX-e(document).scrollLeft())<r.scrollSensitivity){i=e(document).scrollLeft(e(document).scrollLeft()+r.scrollSpeed)}}}if(i!==false&&e.ui.ddmanager&&!r.dropBehaviour){e.ui.ddmanager.prepareOffsets(n,t)}}});e.ui.plugin.add("draggable","snap",{start:function(){var t=e(this).data("ui-draggable"),n=t.options;t.snapElements=[];e(n.snap.constructor!==String?n.snap.items||":data(ui-draggable)":n.snap).each(function(){var n=e(this),r=n.offset();if(this!==t.element[0]){t.snapElements.push({item:this,width:n.outerWidth(),height:n.outerHeight(),top:r.top,left:r.left})}})},drag:function(t,n){var r,i,s,o,u,a,f,l,c,h,p=e(this).data("ui-draggable"),d=p.options,v=d.snapTolerance,m=n.offset.left,g=m+p.helperProportions.width,y=n.offset.top,b=y+p.helperProportions.height;for(c=p.snapElements.length-1;c>=0;c--){u=p.snapElements[c].left;a=u+p.snapElements[c].width;f=p.snapElements[c].top;l=f+p.snapElements[c].height;if(g<u-v||m>a+v||b<f-v||y>l+v||!e.contains(p.snapElements[c].item.ownerDocument,p.snapElements[c].item)){if(p.snapElements[c].snapping){p.options.snap.release&&p.options.snap.release.call(p.element,t,e.extend(p._uiHash(),{snapItem:p.snapElements[c].item}))}p.snapElements[c].snapping=false;continue}if(d.snapMode!=="inner"){r=Math.abs(f-b)<=v;i=Math.abs(l-y)<=v;s=Math.abs(u-g)<=v;o=Math.abs(a-m)<=v;if(r){n.position.top=p._convertPositionTo("relative",{top:f-p.helperProportions.height,left:0}).top-p.margins.top}if(i){n.position.top=p._convertPositionTo("relative",{top:l,left:0}).top-p.margins.top}if(s){n.position.left=p._convertPositionTo("relative",{top:0,left:u-p.helperProportions.width}).left-p.margins.left}if(o){n.position.left=p._convertPositionTo("relative",{top:0,left:a}).left-p.margins.left}}h=r||i||s||o;if(d.snapMode!=="outer"){r=Math.abs(f-y)<=v;i=Math.abs(l-b)<=v;s=Math.abs(u-m)<=v;o=Math.abs(a-g)<=v;if(r){n.position.top=p._convertPositionTo("relative",{top:f,left:0}).top-p.margins.top}if(i){n.position.top=p._convertPositionTo("relative",{top:l-p.helperProportions.height,left:0}).top-p.margins.top}if(s){n.position.left=p._convertPositionTo("relative",{top:0,left:u}).left-p.margins.left}if(o){n.position.left=p._convertPositionTo("relative",{top:0,left:a-p.helperProportions.width}).left-p.margins.left}}if(!p.snapElements[c].snapping&&(r||i||s||o||h)){p.options.snap.snap&&p.options.snap.snap.call(p.element,t,e.extend(p._uiHash(),{snapItem:p.snapElements[c].item}))}p.snapElements[c].snapping=r||i||s||o||h}}});e.ui.plugin.add("draggable","stack",{start:function(){var t,n=this.data("ui-draggable").options,r=e.makeArray(e(n.stack)).sort(function(t,n){return(parseInt(e(t).css("zIndex"),10)||0)-(parseInt(e(n).css("zIndex"),10)||0)});if(!r.length){return}t=parseInt(e(r[0]).css("zIndex"),10)||0;e(r).each(function(n){e(this).css("zIndex",t+n)});this.css("zIndex",t+r.length)}});e.ui.plugin.add("draggable","zIndex",{start:function(t,n){var r=e(n.helper),i=e(this).data("ui-draggable").options;if(r.css("zIndex")){i._zIndex=r.css("zIndex")}r.css("zIndex",i.zIndex)},stop:function(t,n){var r=e(this).data("ui-draggable").options;if(r._zIndex){e(n.helper).css("zIndex",r._zIndex)}}})})(jQuery);(function(e,t){function n(e,t,n){return e>t&&e<t+n}e.widget("ui.droppable",{version:"1.10.3",widgetEventPrefix:"drop",options:{accept:"*",activeClass:false,addClasses:true,greedy:false,hoverClass:false,scope:"default",tolerance:"intersect",activate:null,deactivate:null,drop:null,out:null,over:null},_create:function(){var t=this.options,n=t.accept;this.isover=false;this.isout=true;this.accept=e.isFunction(n)?n:function(e){return e.is(n)};this.proportions={width:this.element[0].offsetWidth,height:this.element[0].offsetHeight};e.ui.ddmanager.droppables[t.scope]=e.ui.ddmanager.droppables[t.scope]||[];e.ui.ddmanager.droppables[t.scope].push(this);t.addClasses&&this.element.addClass("ui-droppable")},_destroy:function(){var t=0,n=e.ui.ddmanager.droppables[this.options.scope];for(;t<n.length;t++){if(n[t]===this){n.splice(t,1)}}this.element.removeClass("ui-droppable ui-droppable-disabled")},_setOption:function(t,n){if(t==="accept"){this.accept=e.isFunction(n)?n:function(e){return e.is(n)}}e.Widget.prototype._setOption.apply(this,arguments)},_activate:function(t){var n=e.ui.ddmanager.current;if(this.options.activeClass){this.element.addClass(this.options.activeClass)}if(n){this._trigger("activate",t,this.ui(n))}},_deactivate:function(t){var n=e.ui.ddmanager.current;if(this.options.activeClass){this.element.removeClass(this.options.activeClass)}if(n){this._trigger("deactivate",t,this.ui(n))}},_over:function(t){var n=e.ui.ddmanager.current;if(!n||(n.currentItem||n.element)[0]===this.element[0]){return}if(this.accept.call(this.element[0],n.currentItem||n.element)){if(this.options.hoverClass){this.element.addClass(this.options.hoverClass)}this._trigger("over",t,this.ui(n))}},_out:function(t){var n=e.ui.ddmanager.current;if(!n||(n.currentItem||n.element)[0]===this.element[0]){return}if(this.accept.call(this.element[0],n.currentItem||n.element)){if(this.options.hoverClass){this.element.removeClass(this.options.hoverClass)}this._trigger("out",t,this.ui(n))}},_drop:function(t,n){var r=n||e.ui.ddmanager.current,i=false;if(!r||(r.currentItem||r.element)[0]===this.element[0]){return false}this.element.find(":data(ui-droppable)").not(".ui-draggable-dragging").each(function(){var t=e.data(this,"ui-droppable");if(t.options.greedy&&!t.options.disabled&&t.options.scope===r.options.scope&&t.accept.call(t.element[0],r.currentItem||r.element)&&e.ui.intersect(r,e.extend(t,{offset:t.element.offset()}),t.options.tolerance)){i=true;return false}});if(i){return false}if(this.accept.call(this.element[0],r.currentItem||r.element)){if(this.options.activeClass){this.element.removeClass(this.options.activeClass)}if(this.options.hoverClass){this.element.removeClass(this.options.hoverClass)}this._trigger("drop",t,this.ui(r));return this.element}return false},ui:function(e){return{draggable:e.currentItem||e.element,helper:e.helper,position:e.position,offset:e.positionAbs}}});e.ui.intersect=function(e,t,r){if(!t.offset){return false}var i,s,o=(e.positionAbs||e.position.absolute).left,u=o+e.helperProportions.width,a=(e.positionAbs||e.position.absolute).top,f=a+e.helperProportions.height,l=t.offset.left,c=l+t.proportions.width,h=t.offset.top,p=h+t.proportions.height;switch(r){case"fit":return l<=o&&u<=c&&h<=a&&f<=p;case"intersect":return l<o+e.helperProportions.width/2&&u-e.helperProportions.width/2<c&&h<a+e.helperProportions.height/2&&f-e.helperProportions.height/2<p;case"pointer":i=(e.positionAbs||e.position.absolute).left+(e.clickOffset||e.offset.click).left;s=(e.positionAbs||e.position.absolute).top+(e.clickOffset||e.offset.click).top;return n(s,h,t.proportions.height)&&n(i,l,t.proportions.width);case"touch":return(a>=h&&a<=p||f>=h&&f<=p||a<h&&f>p)&&(o>=l&&o<=c||u>=l&&u<=c||o<l&&u>c);default:return false}};e.ui.ddmanager={current:null,droppables:{"default":[]},prepareOffsets:function(t,n){var r,i,s=e.ui.ddmanager.droppables[t.options.scope]||[],o=n?n.type:null,u=(t.currentItem||t.element).find(":data(ui-droppable)").addBack();e:for(r=0;r<s.length;r++){if(s[r].options.disabled||t&&!s[r].accept.call(s[r].element[0],t.currentItem||t.element)){continue}for(i=0;i<u.length;i++){if(u[i]===s[r].element[0]){s[r].proportions.height=0;continue e}}s[r].visible=s[r].element.css("display")!=="none";if(!s[r].visible){continue}if(o==="mousedown"){s[r]._activate.call(s[r],n)}s[r].offset=s[r].element.offset();s[r].proportions={width:s[r].element[0].offsetWidth,height:s[r].element[0].offsetHeight}}},drop:function(t,n){var r=false;e.each((e.ui.ddmanager.droppables[t.options.scope]||[]).slice(),function(){if(!this.options){return}if(!this.options.disabled&&this.visible&&e.ui.intersect(t,this,this.options.tolerance)){r=this._drop.call(this,n)||r}if(!this.options.disabled&&this.visible&&this.accept.call(this.element[0],t.currentItem||t.element)){this.isout=true;this.isover=false;this._deactivate.call(this,n)}});return r},dragStart:function(t,n){t.element.parentsUntil("body").bind("scroll.droppable",function(){if(!t.options.refreshPositions){e.ui.ddmanager.prepareOffsets(t,n)}})},drag:function(t,n){if(t.options.refreshPositions){e.ui.ddmanager.prepareOffsets(t,n)}e.each(e.ui.ddmanager.droppables[t.options.scope]||[],function(){if(this.options.disabled||this.greedyChild||!this.visible){return}var r,i,s,o=e.ui.intersect(t,this,this.options.tolerance),u=!o&&this.isover?"isout":o&&!this.isover?"isover":null;if(!u){return}if(this.options.greedy){i=this.options.scope;s=this.element.parents(":data(ui-droppable)").filter(function(){return e.data(this,"ui-droppable").options.scope===i});if(s.length){r=e.data(s[0],"ui-droppable");r.greedyChild=u==="isover"}}if(r&&u==="isover"){r.isover=false;r.isout=true;r._out.call(r,n)}this[u]=true;this[u==="isout"?"isover":"isout"]=false;this[u==="isover"?"_over":"_out"].call(this,n);if(r&&u==="isout"){r.isout=false;r.isover=true;r._over.call(r,n)}})},dragStop:function(t,n){t.element.parentsUntil("body").unbind("scroll.droppable");if(!t.options.refreshPositions){e.ui.ddmanager.prepareOffsets(t,n)}}}})(jQuery);(function(e,t){function n(e){return parseInt(e,10)||0}function r(e){return!isNaN(parseInt(e,10))}e.widget("ui.resizable",e.ui.mouse,{version:"1.10.3",widgetEventPrefix:"resize",options:{alsoResize:false,animate:false,animateDuration:"slow",animateEasing:"swing",aspectRatio:false,autoHide:false,containment:false,ghost:false,grid:false,handles:"e,s,se",helper:false,maxHeight:null,maxWidth:null,minHeight:10,minWidth:10,zIndex:90,resize:null,start:null,stop:null},_create:function(){var t,n,r,i,s,o=this,u=this.options;this.element.addClass("ui-resizable");e.extend(this,{_aspectRatio:!!u.aspectRatio,aspectRatio:u.aspectRatio,originalElement:this.element,_proportionallyResizeElements:[],_helper:u.helper||u.ghost||u.animate?u.helper||"ui-resizable-helper":null});if(this.element[0].nodeName.match(/canvas|textarea|input|select|button|img/i)){this.element.wrap(e("<div class='ui-wrapper' style='overflow: hidden;'></div>").css({position:this.element.css("position"),width:this.element.outerWidth(),height:this.element.outerHeight(),top:this.element.css("top"),left:this.element.css("left")}));this.element=this.element.parent().data("ui-resizable",this.element.data("ui-resizable"));this.elementIsWrapper=true;this.element.css({marginLeft:this.originalElement.css("marginLeft"),marginTop:this.originalElement.css("marginTop"),marginRight:this.originalElement.css("marginRight"),marginBottom:this.originalElement.css("marginBottom")});this.originalElement.css({marginLeft:0,marginTop:0,marginRight:0,marginBottom:0});this.originalResizeStyle=this.originalElement.css("resize");this.originalElement.css("resize","none");this._proportionallyResizeElements.push(this.originalElement.css({position:"static",zoom:1,display:"block"}));this.originalElement.css({margin:this.originalElement.css("margin")});this._proportionallyResize()}this.handles=u.handles||(!e(".ui-resizable-handle",this.element).length?"e,s,se":{n:".ui-resizable-n",e:".ui-resizable-e",s:".ui-resizable-s",w:".ui-resizable-w",se:".ui-resizable-se",sw:".ui-resizable-sw",ne:".ui-resizable-ne",nw:".ui-resizable-nw"});if(this.handles.constructor===String){if(this.handles==="all"){this.handles="n,e,s,w,se,sw,ne,nw"}t=this.handles.split(",");this.handles={};for(n=0;n<t.length;n++){r=e.trim(t[n]);s="ui-resizable-"+r;i=e("<div class='ui-resizable-handle "+s+"'></div>");i.css({zIndex:u.zIndex});if("se"===r){i.addClass("ui-icon ui-icon-gripsmall-diagonal-se")}this.handles[r]=".ui-resizable-"+r;this.element.append(i)}}this._renderAxis=function(t){var n,r,i,s;t=t||this.element;for(n in this.handles){if(this.handles[n].constructor===String){this.handles[n]=e(this.handles[n],this.element).show()}if(this.elementIsWrapper&&this.originalElement[0].nodeName.match(/textarea|input|select|button/i)){r=e(this.handles[n],this.element);s=/sw|ne|nw|se|n|s/.test(n)?r.outerHeight():r.outerWidth();i=["padding",/ne|nw|n/.test(n)?"Top":/se|sw|s/.test(n)?"Bottom":/^e$/.test(n)?"Right":"Left"].join("");t.css(i,s);this._proportionallyResize()}if(!e(this.handles[n]).length){continue}}};this._renderAxis(this.element);this._handles=e(".ui-resizable-handle",this.element).disableSelection();this._handles.mouseover(function(){if(!o.resizing){if(this.className){i=this.className.match(/ui-resizable-(se|sw|ne|nw|n|e|s|w)/i)}o.axis=i&&i[1]?i[1]:"se"}});if(u.autoHide){this._handles.hide();e(this.element).addClass("ui-resizable-autohide").mouseenter(function(){if(u.disabled){return}e(this).removeClass("ui-resizable-autohide");o._handles.show()}).mouseleave(function(){if(u.disabled){return}if(!o.resizing){e(this).addClass("ui-resizable-autohide");o._handles.hide()}})}this._mouseInit()},_destroy:function(){this._mouseDestroy();var t,n=function(t){e(t).removeClass("ui-resizable ui-resizable-disabled ui-resizable-resizing").removeData("resizable").removeData("ui-resizable").unbind(".resizable").find(".ui-resizable-handle").remove()};if(this.elementIsWrapper){n(this.element);t=this.element;this.originalElement.css({position:t.css("position"),width:t.outerWidth(),height:t.outerHeight(),top:t.css("top"),left:t.css("left")}).insertAfter(t);t.remove()}this.originalElement.css("resize",this.originalResizeStyle);n(this.originalElement);return this},_mouseCapture:function(t){var n,r,i=false;for(n in this.handles){r=e(this.handles[n])[0];if(r===t.target||e.contains(r,t.target)){i=true}}return!this.options.disabled&&i},_mouseStart:function(t){var r,i,s,o=this.options,u=this.element.position(),a=this.element;this.resizing=true;if(/absolute/.test(a.css("position"))){a.css({position:"absolute",top:a.css("top"),left:a.css("left")})}else if(a.is(".ui-draggable")){a.css({position:"absolute",top:u.top,left:u.left})}this._renderProxy();r=n(this.helper.css("left"));i=n(this.helper.css("top"));if(o.containment){r+=e(o.containment).scrollLeft()||0;i+=e(o.containment).scrollTop()||0}this.offset=this.helper.offset();this.position={left:r,top:i};this.size=this._helper?{width:a.outerWidth(),height:a.outerHeight()}:{width:a.width(),height:a.height()};this.originalSize=this._helper?{width:a.outerWidth(),height:a.outerHeight()}:{width:a.width(),height:a.height()};this.originalPosition={left:r,top:i};this.sizeDiff={width:a.outerWidth()-a.width(),height:a.outerHeight()-a.height()};this.originalMousePosition={left:t.pageX,top:t.pageY};this.aspectRatio=typeof o.aspectRatio==="number"?o.aspectRatio:this.originalSize.width/this.originalSize.height||1;s=e(".ui-resizable-"+this.axis).css("cursor");e("body").css("cursor",s==="auto"?this.axis+"-resize":s);a.addClass("ui-resizable-resizing");this._propagate("start",t);return true},_mouseDrag:function(t){var n,r=this.helper,i={},s=this.originalMousePosition,o=this.axis,u=this.position.top,a=this.position.left,f=this.size.width,l=this.size.height,c=t.pageX-s.left||0,h=t.pageY-s.top||0,p=this._change[o];if(!p){return false}n=p.apply(this,[t,c,h]);this._updateVirtualBoundaries(t.shiftKey);if(this._aspectRatio||t.shiftKey){n=this._updateRatio(n,t)}n=this._respectSize(n,t);this._updateCache(n);this._propagate("resize",t);if(this.position.top!==u){i.top=this.position.top+"px"}if(this.position.left!==a){i.left=this.position.left+"px"}if(this.size.width!==f){i.width=this.size.width+"px"}if(this.size.height!==l){i.height=this.size.height+"px"}r.css(i);if(!this._helper&&this._proportionallyResizeElements.length){this._proportionallyResize()}if(!e.isEmptyObject(i)){this._trigger("resize",t,this.ui())}return false},_mouseStop:function(t){this.resizing=false;var n,r,i,s,o,u,a,f=this.options,l=this;if(this._helper){n=this._proportionallyResizeElements;r=n.length&&/textarea/i.test(n[0].nodeName);i=r&&e.ui.hasScroll(n[0],"left")?0:l.sizeDiff.height;s=r?0:l.sizeDiff.width;o={width:l.helper.width()-s,height:l.helper.height()-i};u=parseInt(l.element.css("left"),10)+(l.position.left-l.originalPosition.left)||null;a=parseInt(l.element.css("top"),10)+(l.position.top-l.originalPosition.top)||null;if(!f.animate){this.element.css(e.extend(o,{top:a,left:u}))}l.helper.height(l.size.height);l.helper.width(l.size.width);if(this._helper&&!f.animate){this._proportionallyResize()}}e("body").css("cursor","auto");this.element.removeClass("ui-resizable-resizing");this._propagate("stop",t);if(this._helper){this.helper.remove()}return false},_updateVirtualBoundaries:function(e){var t,n,i,s,o,u=this.options;o={minWidth:r(u.minWidth)?u.minWidth:0,maxWidth:r(u.maxWidth)?u.maxWidth:Infinity,minHeight:r(u.minHeight)?u.minHeight:0,maxHeight:r(u.maxHeight)?u.maxHeight:Infinity};if(this._aspectRatio||e){t=o.minHeight*this.aspectRatio;i=o.minWidth/this.aspectRatio;n=o.maxHeight*this.aspectRatio;s=o.maxWidth/this.aspectRatio;if(t>o.minWidth){o.minWidth=t}if(i>o.minHeight){o.minHeight=i}if(n<o.maxWidth){o.maxWidth=n}if(s<o.maxHeight){o.maxHeight=s}}this._vBoundaries=o},_updateCache:function(e){this.offset=this.helper.offset();if(r(e.left)){this.position.left=e.left}if(r(e.top)){this.position.top=e.top}if(r(e.height)){this.size.height=e.height}if(r(e.width)){this.size.width=e.width}},_updateRatio:function(e){var t=this.position,n=this.size,i=this.axis;if(r(e.height)){e.width=e.height*this.aspectRatio}else if(r(e.width)){e.height=e.width/this.aspectRatio}if(i==="sw"){e.left=t.left+(n.width-e.width);e.top=null}if(i==="nw"){e.top=t.top+(n.height-e.height);e.left=t.left+(n.width-e.width)}return e},_respectSize:function(e){var t=this._vBoundaries,n=this.axis,i=r(e.width)&&t.maxWidth&&t.maxWidth<e.width,s=r(e.height)&&t.maxHeight&&t.maxHeight<e.height,o=r(e.width)&&t.minWidth&&t.minWidth>e.width,u=r(e.height)&&t.minHeight&&t.minHeight>e.height,a=this.originalPosition.left+this.originalSize.width,f=this.position.top+this.size.height,l=/sw|nw|w/.test(n),c=/nw|ne|n/.test(n);if(o){e.width=t.minWidth}if(u){e.height=t.minHeight}if(i){e.width=t.maxWidth}if(s){e.height=t.maxHeight}if(o&&l){e.left=a-t.minWidth}if(i&&l){e.left=a-t.maxWidth}if(u&&c){e.top=f-t.minHeight}if(s&&c){e.top=f-t.maxHeight}if(!e.width&&!e.height&&!e.left&&e.top){e.top=null}else if(!e.width&&!e.height&&!e.top&&e.left){e.left=null}return e},_proportionallyResize:function(){if(!this._proportionallyResizeElements.length){return}var e,t,n,r,i,s=this.helper||this.element;for(e=0;e<this._proportionallyResizeElements.length;e++){i=this._proportionallyResizeElements[e];if(!this.borderDif){this.borderDif=[];n=[i.css("borderTopWidth"),i.css("borderRightWidth"),i.css("borderBottomWidth"),i.css("borderLeftWidth")];r=[i.css("paddingTop"),i.css("paddingRight"),i.css("paddingBottom"),i.css("paddingLeft")];for(t=0;t<n.length;t++){this.borderDif[t]=(parseInt(n[t],10)||0)+(parseInt(r[t],10)||0)}}i.css({height:s.height()-this.borderDif[0]-this.borderDif[2]||0,width:s.width()-this.borderDif[1]-this.borderDif[3]||0})}},_renderProxy:function(){var t=this.element,n=this.options;this.elementOffset=t.offset();if(this._helper){this.helper=this.helper||e("<div style='overflow:hidden;'></div>");this.helper.addClass(this._helper).css({width:this.element.outerWidth()-1,height:this.element.outerHeight()-1,position:"absolute",left:this.elementOffset.left+"px",top:this.elementOffset.top+"px",zIndex:++n.zIndex});this.helper.appendTo("body").disableSelection()}else{this.helper=this.element}},_change:{e:function(e,t){return{width:this.originalSize.width+t}},w:function(e,t){var n=this.originalSize,r=this.originalPosition;return{left:r.left+t,width:n.width-t}},n:function(e,t,n){var r=this.originalSize,i=this.originalPosition;return{top:i.top+n,height:r.height-n}},s:function(e,t,n){return{height:this.originalSize.height+n}},se:function(t,n,r){return e.extend(this._change.s.apply(this,arguments),this._change.e.apply(this,[t,n,r]))},sw:function(t,n,r){return e.extend(this._change.s.apply(this,arguments),this._change.w.apply(this,[t,n,r]))},ne:function(t,n,r){return e.extend(this._change.n.apply(this,arguments),this._change.e.apply(this,[t,n,r]))},nw:function(t,n,r){return e.extend(this._change.n.apply(this,arguments),this._change.w.apply(this,[t,n,r]))}},_propagate:function(t,n){e.ui.plugin.call(this,t,[n,this.ui()]);t!=="resize"&&this._trigger(t,n,this.ui())},plugins:{},ui:function(){return{originalElement:this.originalElement,element:this.element,helper:this.helper,position:this.position,size:this.size,originalSize:this.originalSize,originalPosition:this.originalPosition}}});e.ui.plugin.add("resizable","animate",{stop:function(t){var n=e(this).data("ui-resizable"),r=n.options,i=n._proportionallyResizeElements,s=i.length&&/textarea/i.test(i[0].nodeName),o=s&&e.ui.hasScroll(i[0],"left")?0:n.sizeDiff.height,u=s?0:n.sizeDiff.width,a={width:n.size.width-u,height:n.size.height-o},f=parseInt(n.element.css("left"),10)+(n.position.left-n.originalPosition.left)||null,l=parseInt(n.element.css("top"),10)+(n.position.top-n.originalPosition.top)||null;n.element.animate(e.extend(a,l&&f?{top:l,left:f}:{}),{duration:r.animateDuration,easing:r.animateEasing,step:function(){var r={width:parseInt(n.element.css("width"),10),height:parseInt(n.element.css("height"),10),top:parseInt(n.element.css("top"),10),left:parseInt(n.element.css("left"),10)};if(i&&i.length){e(i[0]).css({width:r.width,height:r.height})}n._updateCache(r);n._propagate("resize",t)}})}});e.ui.plugin.add("resizable","containment",{start:function(){var t,r,i,s,o,u,a,f=e(this).data("ui-resizable"),l=f.options,c=f.element,h=l.containment,p=h instanceof e?h.get(0):/parent/.test(h)?c.parent().get(0):h;if(!p){return}f.containerElement=e(p);if(/document/.test(h)||h===document){f.containerOffset={left:0,top:0};f.containerPosition={left:0,top:0};f.parentData={element:e(document),left:0,top:0,width:e(document).width(),height:e(document).height()||document.body.parentNode.scrollHeight}}else{t=e(p);r=[];e(["Top","Right","Left","Bottom"]).each(function(e,i){r[e]=n(t.css("padding"+i))});f.containerOffset=t.offset();f.containerPosition=t.position();f.containerSize={height:t.innerHeight()-r[3],width:t.innerWidth()-r[1]};i=f.containerOffset;s=f.containerSize.height;o=f.containerSize.width;u=e.ui.hasScroll(p,"left")?p.scrollWidth:o;a=e.ui.hasScroll(p)?p.scrollHeight:s;f.parentData={element:p,left:i.left,top:i.top,width:u,height:a}}},resize:function(t){var n,r,i,s,o=e(this).data("ui-resizable"),u=o.options,a=o.containerOffset,f=o.position,l=o._aspectRatio||t.shiftKey,c={top:0,left:0},h=o.containerElement;if(h[0]!==document&&/static/.test(h.css("position"))){c=a}if(f.left<(o._helper?a.left:0)){o.size.width=o.size.width+(o._helper?o.position.left-a.left:o.position.left-c.left);if(l){o.size.height=o.size.width/o.aspectRatio}o.position.left=u.helper?a.left:0}if(f.top<(o._helper?a.top:0)){o.size.height=o.size.height+(o._helper?o.position.top-a.top:o.position.top);if(l){o.size.width=o.size.height*o.aspectRatio}o.position.top=o._helper?a.top:0}o.offset.left=o.parentData.left+o.position.left;o.offset.top=o.parentData.top+o.position.top;n=Math.abs((o._helper?o.offset.left-c.left:o.offset.left-c.left)+o.sizeDiff.width);r=Math.abs((o._helper?o.offset.top-c.top:o.offset.top-a.top)+o.sizeDiff.height);i=o.containerElement.get(0)===o.element.parent().get(0);s=/relative|absolute/.test(o.containerElement.css("position"));if(i&&s){n-=o.parentData.left}if(n+o.size.width>=o.parentData.width){o.size.width=o.parentData.width-n;if(l){o.size.height=o.size.width/o.aspectRatio}}if(r+o.size.height>=o.parentData.height){o.size.height=o.parentData.height-r;if(l){o.size.width=o.size.height*o.aspectRatio}}},stop:function(){var t=e(this).data("ui-resizable"),n=t.options,r=t.containerOffset,i=t.containerPosition,s=t.containerElement,o=e(t.helper),u=o.offset(),a=o.outerWidth()-t.sizeDiff.width,f=o.outerHeight()-t.sizeDiff.height;if(t._helper&&!n.animate&&/relative/.test(s.css("position"))){e(this).css({left:u.left-i.left-r.left,width:a,height:f})}if(t._helper&&!n.animate&&/static/.test(s.css("position"))){e(this).css({left:u.left-i.left-r.left,width:a,height:f})}}});e.ui.plugin.add("resizable","alsoResize",{start:function(){var t=e(this).data("ui-resizable"),n=t.options,r=function(t){e(t).each(function(){var t=e(this);t.data("ui-resizable-alsoresize",{width:parseInt(t.width(),10),height:parseInt(t.height(),10),left:parseInt(t.css("left"),10),top:parseInt(t.css("top"),10)})})};if(typeof n.alsoResize==="object"&&!n.alsoResize.parentNode){if(n.alsoResize.length){n.alsoResize=n.alsoResize[0];r(n.alsoResize)}else{e.each(n.alsoResize,function(e){r(e)})}}else{r(n.alsoResize)}},resize:function(t,n){var r=e(this).data("ui-resizable"),i=r.options,s=r.originalSize,o=r.originalPosition,u={height:r.size.height-s.height||0,width:r.size.width-s.width||0,top:r.position.top-o.top||0,left:r.position.left-o.left||0},a=function(t,r){e(t).each(function(){var t=e(this),i=e(this).data("ui-resizable-alsoresize"),s={},o=r&&r.length?r:t.parents(n.originalElement[0]).length?["width","height"]:["width","height","top","left"];e.each(o,function(e,t){var n=(i[t]||0)+(u[t]||0);if(n&&n>=0){s[t]=n||null}});t.css(s)})};if(typeof i.alsoResize==="object"&&!i.alsoResize.nodeType){e.each(i.alsoResize,function(e,t){a(e,t)})}else{a(i.alsoResize)}},stop:function(){e(this).removeData("resizable-alsoresize")}});e.ui.plugin.add("resizable","ghost",{start:function(){var t=e(this).data("ui-resizable"),n=t.options,r=t.size;t.ghost=t.originalElement.clone();t.ghost.css({opacity:.25,display:"block",position:"relative",height:r.height,width:r.width,margin:0,left:0,top:0}).addClass("ui-resizable-ghost").addClass(typeof n.ghost==="string"?n.ghost:"");t.ghost.appendTo(t.helper)},resize:function(){var t=e(this).data("ui-resizable");if(t.ghost){t.ghost.css({position:"relative",height:t.size.height,width:t.size.width})}},stop:function(){var t=e(this).data("ui-resizable");if(t.ghost&&t.helper){t.helper.get(0).removeChild(t.ghost.get(0))}}});e.ui.plugin.add("resizable","grid",{resize:function(){var t=e(this).data("ui-resizable"),n=t.options,r=t.size,i=t.originalSize,s=t.originalPosition,o=t.axis,u=typeof n.grid==="number"?[n.grid,n.grid]:n.grid,a=u[0]||1,f=u[1]||1,l=Math.round((r.width-i.width)/a)*a,c=Math.round((r.height-i.height)/f)*f,h=i.width+l,p=i.height+c,d=n.maxWidth&&n.maxWidth<h,v=n.maxHeight&&n.maxHeight<p,m=n.minWidth&&n.minWidth>h,g=n.minHeight&&n.minHeight>p;n.grid=u;if(m){h=h+a}if(g){p=p+f}if(d){h=h-a}if(v){p=p-f}if(/^(se|s|e)$/.test(o)){t.size.width=h;t.size.height=p}else if(/^(ne)$/.test(o)){t.size.width=h;t.size.height=p;t.position.top=s.top-c}else if(/^(sw)$/.test(o)){t.size.width=h;t.size.height=p;t.position.left=s.left-l}else{t.size.width=h;t.size.height=p;t.position.top=s.top-c;t.position.left=s.left-l}}})})(jQuery);(function(e,t){e.widget("ui.selectable",e.ui.mouse,{version:"1.10.3",options:{appendTo:"body",autoRefresh:true,distance:0,filter:"*",tolerance:"touch",selected:null,selecting:null,start:null,stop:null,unselected:null,unselecting:null},_create:function(){var t,n=this;this.element.addClass("ui-selectable");this.dragged=false;this.refresh=function(){t=e(n.options.filter,n.element[0]);t.addClass("ui-selectee");t.each(function(){var t=e(this),n=t.offset();e.data(this,"selectable-item",{element:this,$element:t,left:n.left,top:n.top,right:n.left+t.outerWidth(),bottom:n.top+t.outerHeight(),startselected:false,selected:t.hasClass("ui-selected"),selecting:t.hasClass("ui-selecting"),unselecting:t.hasClass("ui-unselecting")})})};this.refresh();this.selectees=t.addClass("ui-selectee");this._mouseInit();this.helper=e("<div class='ui-selectable-helper'></div>")},_destroy:function(){this.selectees.removeClass("ui-selectee").removeData("selectable-item");this.element.removeClass("ui-selectable ui-selectable-disabled");this._mouseDestroy()},_mouseStart:function(t){var n=this,r=this.options;this.opos=[t.pageX,t.pageY];if(this.options.disabled){return}this.selectees=e(r.filter,this.element[0]);this._trigger("start",t);e(r.appendTo).append(this.helper);this.helper.css({left:t.pageX,top:t.pageY,width:0,height:0});if(r.autoRefresh){this.refresh()}this.selectees.filter(".ui-selected").each(function(){var r=e.data(this,"selectable-item");r.startselected=true;if(!t.metaKey&&!t.ctrlKey){r.$element.removeClass("ui-selected");r.selected=false;r.$element.addClass("ui-unselecting");r.unselecting=true;n._trigger("unselecting",t,{unselecting:r.element})}});e(t.target).parents().addBack().each(function(){var r,i=e.data(this,"selectable-item");if(i){r=!t.metaKey&&!t.ctrlKey||!i.$element.hasClass("ui-selected");i.$element.removeClass(r?"ui-unselecting":"ui-selected").addClass(r?"ui-selecting":"ui-unselecting");i.unselecting=!r;i.selecting=r;i.selected=r;if(r){n._trigger("selecting",t,{selecting:i.element})}else{n._trigger("unselecting",t,{unselecting:i.element})}return false}})},_mouseDrag:function(t){this.dragged=true;if(this.options.disabled){return}var n,r=this,i=this.options,s=this.opos[0],o=this.opos[1],u=t.pageX,a=t.pageY;if(s>u){n=u;u=s;s=n}if(o>a){n=a;a=o;o=n}this.helper.css({left:s,top:o,width:u-s,height:a-o});this.selectees.each(function(){var n=e.data(this,"selectable-item"),f=false;if(!n||n.element===r.element[0]){return}if(i.tolerance==="touch"){f=!(n.left>u||n.right<s||n.top>a||n.bottom<o)}else if(i.tolerance==="fit"){f=n.left>s&&n.right<u&&n.top>o&&n.bottom<a}if(f){if(n.selected){n.$element.removeClass("ui-selected");n.selected=false}if(n.unselecting){n.$element.removeClass("ui-unselecting");n.unselecting=false}if(!n.selecting){n.$element.addClass("ui-selecting");n.selecting=true;r._trigger("selecting",t,{selecting:n.element})}}else{if(n.selecting){if((t.metaKey||t.ctrlKey)&&n.startselected){n.$element.removeClass("ui-selecting");n.selecting=false;n.$element.addClass("ui-selected");n.selected=true}else{n.$element.removeClass("ui-selecting");n.selecting=false;if(n.startselected){n.$element.addClass("ui-unselecting");n.unselecting=true}r._trigger("unselecting",t,{unselecting:n.element})}}if(n.selected){if(!t.metaKey&&!t.ctrlKey&&!n.startselected){n.$element.removeClass("ui-selected");n.selected=false;n.$element.addClass("ui-unselecting");n.unselecting=true;r._trigger("unselecting",t,{unselecting:n.element})}}}});return false},_mouseStop:function(t){var n=this;this.dragged=false;e(".ui-unselecting",this.element[0]).each(function(){var r=e.data(this,"selectable-item");r.$element.removeClass("ui-unselecting");r.unselecting=false;r.startselected=false;n._trigger("unselected",t,{unselected:r.element})});e(".ui-selecting",this.element[0]).each(function(){var r=e.data(this,"selectable-item");r.$element.removeClass("ui-selecting").addClass("ui-selected");r.selecting=false;r.selected=true;r.startselected=true;n._trigger("selected",t,{selected:r.element})});this._trigger("stop",t);this.helper.remove();return false}})})(jQuery);(function(e,t){function n(e,t,n){return e>t&&e<t+n}function r(e){return/left|right/.test(e.css("float"))||/inline|table-cell/.test(e.css("display"))}e.widget("ui.sortable",e.ui.mouse,{version:"1.10.3",widgetEventPrefix:"sort",ready:false,options:{appendTo:"parent",axis:false,connectWith:false,containment:false,cursor:"auto",cursorAt:false,dropOnEmpty:true,forcePlaceholderSize:false,forceHelperSize:false,grid:false,handle:false,helper:"original",items:"> *",opacity:false,placeholder:false,revert:false,scroll:true,scrollSensitivity:20,scrollSpeed:20,scope:"default",tolerance:"intersect",zIndex:1e3,activate:null,beforeStop:null,change:null,deactivate:null,out:null,over:null,receive:null,remove:null,sort:null,start:null,stop:null,update:null},_create:function(){var e=this.options;this.containerCache={};this.element.addClass("ui-sortable");this.refresh();this.floating=this.items.length?e.axis==="x"||r(this.items[0].item):false;this.offset=this.element.offset();this._mouseInit();this.ready=true},_destroy:function(){this.element.removeClass("ui-sortable ui-sortable-disabled");this._mouseDestroy();for(var e=this.items.length-1;e>=0;e--){this.items[e].item.removeData(this.widgetName+"-item")}return this},_setOption:function(t,n){if(t==="disabled"){this.options[t]=n;this.widget().toggleClass("ui-sortable-disabled",!!n)}else{e.Widget.prototype._setOption.apply(this,arguments)}},_mouseCapture:function(t,n){var r=null,i=false,s=this;if(this.reverting){return false}if(this.options.disabled||this.options.type==="static"){return false}this._refreshItems(t);e(t.target).parents().each(function(){if(e.data(this,s.widgetName+"-item")===s){r=e(this);return false}});if(e.data(t.target,s.widgetName+"-item")===s){r=e(t.target)}if(!r){return false}if(this.options.handle&&!n){e(this.options.handle,r).find("*").addBack().each(function(){if(this===t.target){i=true}});if(!i){return false}}this.currentItem=r;this._removeCurrentsFromItems();return true},_mouseStart:function(t,n,r){var i,s,o=this.options;this.currentContainer=this;this.refreshPositions();this.helper=this._createHelper(t);this._cacheHelperProportions();this._cacheMargins();this.scrollParent=this.helper.scrollParent();this.offset=this.currentItem.offset();this.offset={top:this.offset.top-this.margins.top,left:this.offset.left-this.margins.left};e.extend(this.offset,{click:{left:t.pageX-this.offset.left,top:t.pageY-this.offset.top},parent:this._getParentOffset(),relative:this._getRelativeOffset()});this.helper.css("position","absolute");this.cssPosition=this.helper.css("position");this.originalPosition=this._generatePosition(t);this.originalPageX=t.pageX;this.originalPageY=t.pageY;o.cursorAt&&this._adjustOffsetFromHelper(o.cursorAt);this.domPosition={prev:this.currentItem.prev()[0],parent:this.currentItem.parent()[0]};if(this.helper[0]!==this.currentItem[0]){this.currentItem.hide()}this._createPlaceholder();if(o.containment){this._setContainment()}if(o.cursor&&o.cursor!=="auto"){s=this.document.find("body");this.storedCursor=s.css("cursor");s.css("cursor",o.cursor);this.storedStylesheet=e("<style>*{ cursor: "+o.cursor+" !important; }</style>").appendTo(s)}if(o.opacity){if(this.helper.css("opacity")){this._storedOpacity=this.helper.css("opacity")}this.helper.css("opacity",o.opacity)}if(o.zIndex){if(this.helper.css("zIndex")){this._storedZIndex=this.helper.css("zIndex")}this.helper.css("zIndex",o.zIndex)}if(this.scrollParent[0]!==document&&this.scrollParent[0].tagName!=="HTML"){this.overflowOffset=this.scrollParent.offset()}this._trigger("start",t,this._uiHash());if(!this._preserveHelperProportions){this._cacheHelperProportions()}if(!r){for(i=this.containers.length-1;i>=0;i--){this.containers[i]._trigger("activate",t,this._uiHash(this))}}if(e.ui.ddmanager){e.ui.ddmanager.current=this}if(e.ui.ddmanager&&!o.dropBehaviour){e.ui.ddmanager.prepareOffsets(this,t)}this.dragging=true;this.helper.addClass("ui-sortable-helper");this._mouseDrag(t);return true},_mouseDrag:function(t){var n,r,i,s,o=this.options,u=false;this.position=this._generatePosition(t);this.positionAbs=this._convertPositionTo("absolute");if(!this.lastPositionAbs){this.lastPositionAbs=this.positionAbs}if(this.options.scroll){if(this.scrollParent[0]!==document&&this.scrollParent[0].tagName!=="HTML"){if(this.overflowOffset.top+this.scrollParent[0].offsetHeight-t.pageY<o.scrollSensitivity){this.scrollParent[0].scrollTop=u=this.scrollParent[0].scrollTop+o.scrollSpeed}else if(t.pageY-this.overflowOffset.top<o.scrollSensitivity){this.scrollParent[0].scrollTop=u=this.scrollParent[0].scrollTop-o.scrollSpeed}if(this.overflowOffset.left+this.scrollParent[0].offsetWidth-t.pageX<o.scrollSensitivity){this.scrollParent[0].scrollLeft=u=this.scrollParent[0].scrollLeft+o.scrollSpeed}else if(t.pageX-this.overflowOffset.left<o.scrollSensitivity){this.scrollParent[0].scrollLeft=u=this.scrollParent[0].scrollLeft-o.scrollSpeed}}else{if(t.pageY-e(document).scrollTop()<o.scrollSensitivity){u=e(document).scrollTop(e(document).scrollTop()-o.scrollSpeed)}else if(e(window).height()-(t.pageY-e(document).scrollTop())<o.scrollSensitivity){u=e(document).scrollTop(e(document).scrollTop()+o.scrollSpeed)}if(t.pageX-e(document).scrollLeft()<o.scrollSensitivity){u=e(document).scrollLeft(e(document).scrollLeft()-o.scrollSpeed)}else if(e(window).width()-(t.pageX-e(document).scrollLeft())<o.scrollSensitivity){u=e(document).scrollLeft(e(document).scrollLeft()+o.scrollSpeed)}}if(u!==false&&e.ui.ddmanager&&!o.dropBehaviour){e.ui.ddmanager.prepareOffsets(this,t)}}this.positionAbs=this._convertPositionTo("absolute");if(!this.options.axis||this.options.axis!=="y"){this.helper[0].style.left=this.position.left+"px"}if(!this.options.axis||this.options.axis!=="x"){this.helper[0].style.top=this.position.top+"px"}for(n=this.items.length-1;n>=0;n--){r=this.items[n];i=r.item[0];s=this._intersectsWithPointer(r);if(!s){continue}if(r.instance!==this.currentContainer){continue}if(i!==this.currentItem[0]&&this.placeholder[s===1?"next":"prev"]()[0]!==i&&!e.contains(this.placeholder[0],i)&&(this.options.type==="semi-dynamic"?!e.contains(this.element[0],i):true)){this.direction=s===1?"down":"up";if(this.options.tolerance==="pointer"||this._intersectsWithSides(r)){this._rearrange(t,r)}else{break}this._trigger("change",t,this._uiHash());break}}this._contactContainers(t);if(e.ui.ddmanager){e.ui.ddmanager.drag(this,t)}this._trigger("sort",t,this._uiHash());this.lastPositionAbs=this.positionAbs;return false},_mouseStop:function(t,n){if(!t){return}if(e.ui.ddmanager&&!this.options.dropBehaviour){e.ui.ddmanager.drop(this,t)}if(this.options.revert){var r=this,i=this.placeholder.offset(),s=this.options.axis,o={};if(!s||s==="x"){o.left=i.left-this.offset.parent.left-this.margins.left+(this.offsetParent[0]===document.body?0:this.offsetParent[0].scrollLeft)}if(!s||s==="y"){o.top=i.top-this.offset.parent.top-this.margins.top+(this.offsetParent[0]===document.body?0:this.offsetParent[0].scrollTop)}this.reverting=true;e(this.helper).animate(o,parseInt(this.options.revert,10)||500,function(){r._clear(t)})}else{this._clear(t,n)}return false},cancel:function(){if(this.dragging){this._mouseUp({target:null});if(this.options.helper==="original"){this.currentItem.css(this._storedCSS).removeClass("ui-sortable-helper")}else{this.currentItem.show()}for(var t=this.containers.length-1;t>=0;t--){this.containers[t]._trigger("deactivate",null,this._uiHash(this));if(this.containers[t].containerCache.over){this.containers[t]._trigger("out",null,this._uiHash(this));this.containers[t].containerCache.over=0}}}if(this.placeholder){if(this.placeholder[0].parentNode){this.placeholder[0].parentNode.removeChild(this.placeholder[0])}if(this.options.helper!=="original"&&this.helper&&this.helper[0].parentNode){this.helper.remove()}e.extend(this,{helper:null,dragging:false,reverting:false,_noFinalSort:null});if(this.domPosition.prev){e(this.domPosition.prev).after(this.currentItem)}else{e(this.domPosition.parent).prepend(this.currentItem)}}return this},serialize:function(t){var n=this._getItemsAsjQuery(t&&t.connected),r=[];t=t||{};e(n).each(function(){var n=(e(t.item||this).attr(t.attribute||"id")||"").match(t.expression||/(.+)[\-=_](.+)/);if(n){r.push((t.key||n[1]+"[]")+"="+(t.key&&t.expression?n[1]:n[2]))}});if(!r.length&&t.key){r.push(t.key+"=")}return r.join("&")},toArray:function(t){var n=this._getItemsAsjQuery(t&&t.connected),r=[];t=t||{};n.each(function(){r.push(e(t.item||this).attr(t.attribute||"id")||"")});return r},_intersectsWith:function(e){var t=this.positionAbs.left,n=t+this.helperProportions.width,r=this.positionAbs.top,i=r+this.helperProportions.height,s=e.left,o=s+e.width,u=e.top,a=u+e.height,f=this.offset.click.top,l=this.offset.click.left,c=this.options.axis==="x"||r+f>u&&r+f<a,h=this.options.axis==="y"||t+l>s&&t+l<o,p=c&&h;if(this.options.tolerance==="pointer"||this.options.forcePointerForContainers||this.options.tolerance!=="pointer"&&this.helperProportions[this.floating?"width":"height"]>e[this.floating?"width":"height"]){return p}else{return s<t+this.helperProportions.width/2&&n-this.helperProportions.width/2<o&&u<r+this.helperProportions.height/2&&i-this.helperProportions.height/2<a}},_intersectsWithPointer:function(e){var t=this.options.axis==="x"||n(this.positionAbs.top+this.offset.click.top,e.top,e.height),r=this.options.axis==="y"||n(this.positionAbs.left+this.offset.click.left,e.left,e.width),i=t&&r,s=this._getDragVerticalDirection(),o=this._getDragHorizontalDirection();if(!i){return false}return this.floating?o&&o==="right"||s==="down"?2:1:s&&(s==="down"?2:1)},_intersectsWithSides:function(e){var t=n(this.positionAbs.top+this.offset.click.top,e.top+e.height/2,e.height),r=n(this.positionAbs.left+this.offset.click.left,e.left+e.width/2,e.width),i=this._getDragVerticalDirection(),s=this._getDragHorizontalDirection();if(this.floating&&s){return s==="right"&&r||s==="left"&&!r}else{return i&&(i==="down"&&t||i==="up"&&!t)}},_getDragVerticalDirection:function(){var e=this.positionAbs.top-this.lastPositionAbs.top;return e!==0&&(e>0?"down":"up")},_getDragHorizontalDirection:function(){var e=this.positionAbs.left-this.lastPositionAbs.left;return e!==0&&(e>0?"right":"left")},refresh:function(e){this._refreshItems(e);this.refreshPositions();return this},_connectWith:function(){var e=this.options;return e.connectWith.constructor===String?[e.connectWith]:e.connectWith},_getItemsAsjQuery:function(t){var n,r,i,s,o=[],u=[],a=this._connectWith();if(a&&t){for(n=a.length-1;n>=0;n--){i=e(a[n]);for(r=i.length-1;r>=0;r--){s=e.data(i[r],this.widgetFullName);if(s&&s!==this&&!s.options.disabled){u.push([e.isFunction(s.options.items)?s.options.items.call(s.element):e(s.options.items,s.element).not(".ui-sortable-helper").not(".ui-sortable-placeholder"),s])}}}}u.push([e.isFunction(this.options.items)?this.options.items.call(this.element,null,{options:this.options,item:this.currentItem}):e(this.options.items,this.element).not(".ui-sortable-helper").not(".ui-sortable-placeholder"),this]);for(n=u.length-1;n>=0;n--){u[n][0].each(function(){o.push(this)})}return e(o)},_removeCurrentsFromItems:function(){var t=this.currentItem.find(":data("+this.widgetName+"-item)");this.items=e.grep(this.items,function(e){for(var n=0;n<t.length;n++){if(t[n]===e.item[0]){return false}}return true})},_refreshItems:function(t){this.items=[];this.containers=[this];var n,r,i,s,o,u,a,f,l=this.items,c=[[e.isFunction(this.options.items)?this.options.items.call(this.element[0],t,{item:this.currentItem}):e(this.options.items,this.element),this]],h=this._connectWith();if(h&&this.ready){for(n=h.length-1;n>=0;n--){i=e(h[n]);for(r=i.length-1;r>=0;r--){s=e.data(i[r],this.widgetFullName);if(s&&s!==this&&!s.options.disabled){c.push([e.isFunction(s.options.items)?s.options.items.call(s.element[0],t,{item:this.currentItem}):e(s.options.items,s.element),s]);this.containers.push(s)}}}}for(n=c.length-1;n>=0;n--){o=c[n][1];u=c[n][0];for(r=0,f=u.length;r<f;r++){a=e(u[r]);a.data(this.widgetName+"-item",o);l.push({item:a,instance:o,width:0,height:0,left:0,top:0})}}},refreshPositions:function(t){if(this.offsetParent&&this.helper){this.offset.parent=this._getParentOffset()}var n,r,i,s;for(n=this.items.length-1;n>=0;n--){r=this.items[n];if(r.instance!==this.currentContainer&&this.currentContainer&&r.item[0]!==this.currentItem[0]){continue}i=this.options.toleranceElement?e(this.options.toleranceElement,r.item):r.item;if(!t){r.width=i.outerWidth();r.height=i.outerHeight()}s=i.offset();r.left=s.left;r.top=s.top}if(this.options.custom&&this.options.custom.refreshContainers){this.options.custom.refreshContainers.call(this)}else{for(n=this.containers.length-1;n>=0;n--){s=this.containers[n].element.offset();this.containers[n].containerCache.left=s.left;this.containers[n].containerCache.top=s.top;this.containers[n].containerCache.width=this.containers[n].element.outerWidth();this.containers[n].containerCache.height=this.containers[n].element.outerHeight()}}return this},_createPlaceholder:function(t){t=t||this;var n,r=t.options;if(!r.placeholder||r.placeholder.constructor===String){n=r.placeholder;r.placeholder={element:function(){var r=t.currentItem[0].nodeName.toLowerCase(),i=e("<"+r+">",t.document[0]).addClass(n||t.currentItem[0].className+" ui-sortable-placeholder").removeClass("ui-sortable-helper");if(r==="tr"){t.currentItem.children().each(function(){e("<td>&#160;</td>",t.document[0]).attr("colspan",e(this).attr("colspan")||1).appendTo(i)})}else if(r==="img"){i.attr("src",t.currentItem.attr("src"))}if(!n){i.css("visibility","hidden")}return i},update:function(e,i){if(n&&!r.forcePlaceholderSize){return}if(!i.height()){i.height(t.currentItem.innerHeight()-parseInt(t.currentItem.css("paddingTop")||0,10)-parseInt(t.currentItem.css("paddingBottom")||0,10))}if(!i.width()){i.width(t.currentItem.innerWidth()-parseInt(t.currentItem.css("paddingLeft")||0,10)-parseInt(t.currentItem.css("paddingRight")||0,10))}}}}t.placeholder=e(r.placeholder.element.call(t.element,t.currentItem));t.currentItem.after(t.placeholder);r.placeholder.update(t,t.placeholder)},_contactContainers:function(t){var i,s,o,u,a,f,l,c,h,p,d=null,v=null;for(i=this.containers.length-1;i>=0;i--){if(e.contains(this.currentItem[0],this.containers[i].element[0])){continue}if(this._intersectsWith(this.containers[i].containerCache)){if(d&&e.contains(this.containers[i].element[0],d.element[0])){continue}d=this.containers[i];v=i}else{if(this.containers[i].containerCache.over){this.containers[i]._trigger("out",t,this._uiHash(this));this.containers[i].containerCache.over=0}}}if(!d){return}if(this.containers.length===1){if(!this.containers[v].containerCache.over){this.containers[v]._trigger("over",t,this._uiHash(this));this.containers[v].containerCache.over=1}}else{o=1e4;u=null;p=d.floating||r(this.currentItem);a=p?"left":"top";f=p?"width":"height";l=this.positionAbs[a]+this.offset.click[a];for(s=this.items.length-1;s>=0;s--){if(!e.contains(this.containers[v].element[0],this.items[s].item[0])){continue}if(this.items[s].item[0]===this.currentItem[0]){continue}if(p&&!n(this.positionAbs.top+this.offset.click.top,this.items[s].top,this.items[s].height)){continue}c=this.items[s].item.offset()[a];h=false;if(Math.abs(c-l)>Math.abs(c+this.items[s][f]-l)){h=true;c+=this.items[s][f]}if(Math.abs(c-l)<o){o=Math.abs(c-l);u=this.items[s];this.direction=h?"up":"down"}}if(!u&&!this.options.dropOnEmpty){return}if(this.currentContainer===this.containers[v]){return}u?this._rearrange(t,u,null,true):this._rearrange(t,null,this.containers[v].element,true);this._trigger("change",t,this._uiHash());this.containers[v]._trigger("change",t,this._uiHash(this));this.currentContainer=this.containers[v];this.options.placeholder.update(this.currentContainer,this.placeholder);this.containers[v]._trigger("over",t,this._uiHash(this));this.containers[v].containerCache.over=1}},_createHelper:function(t){var n=this.options,r=e.isFunction(n.helper)?e(n.helper.apply(this.element[0],[t,this.currentItem])):n.helper==="clone"?this.currentItem.clone():this.currentItem;if(!r.parents("body").length){e(n.appendTo!=="parent"?n.appendTo:this.currentItem[0].parentNode)[0].appendChild(r[0])}if(r[0]===this.currentItem[0]){this._storedCSS={width:this.currentItem[0].style.width,height:this.currentItem[0].style.height,position:this.currentItem.css("position"),top:this.currentItem.css("top"),left:this.currentItem.css("left")}}if(!r[0].style.width||n.forceHelperSize){r.width(this.currentItem.width())}if(!r[0].style.height||n.forceHelperSize){r.height(this.currentItem.height())}return r},_adjustOffsetFromHelper:function(t){if(typeof t==="string"){t=t.split(" ")}if(e.isArray(t)){t={left:+t[0],top:+t[1]||0}}if("left"in t){this.offset.click.left=t.left+this.margins.left}if("right"in t){this.offset.click.left=this.helperProportions.width-t.right+this.margins.left}if("top"in t){this.offset.click.top=t.top+this.margins.top}if("bottom"in t){this.offset.click.top=this.helperProportions.height-t.bottom+this.margins.top}},_getParentOffset:function(){this.offsetParent=this.helper.offsetParent();var t=this.offsetParent.offset();if(this.cssPosition==="absolute"&&this.scrollParent[0]!==document&&e.contains(this.scrollParent[0],this.offsetParent[0])){t.left+=this.scrollParent.scrollLeft();t.top+=this.scrollParent.scrollTop()}if(this.offsetParent[0]===document.body||this.offsetParent[0].tagName&&this.offsetParent[0].tagName.toLowerCase()==="html"&&e.ui.ie){t={top:0,left:0}}return{top:t.top+(parseInt(this.offsetParent.css("borderTopWidth"),10)||0),left:t.left+(parseInt(this.offsetParent.css("borderLeftWidth"),10)||0)}},_getRelativeOffset:function(){if(this.cssPosition==="relative"){var e=this.currentItem.position();return{top:e.top-(parseInt(this.helper.css("top"),10)||0)+this.scrollParent.scrollTop(),left:e.left-(parseInt(this.helper.css("left"),10)||0)+this.scrollParent.scrollLeft()}}else{return{top:0,left:0}}},_cacheMargins:function(){this.margins={left:parseInt(this.currentItem.css("marginLeft"),10)||0,top:parseInt(this.currentItem.css("marginTop"),10)||0}},_cacheHelperProportions:function(){this.helperProportions={width:this.helper.outerWidth(),height:this.helper.outerHeight()}},_setContainment:function(){var t,n,r,i=this.options;if(i.containment==="parent"){i.containment=this.helper[0].parentNode}if(i.containment==="document"||i.containment==="window"){this.containment=[0-this.offset.relative.left-this.offset.parent.left,0-this.offset.relative.top-this.offset.parent.top,e(i.containment==="document"?document:window).width()-this.helperProportions.width-this.margins.left,(e(i.containment==="document"?document:window).height()||document.body.parentNode.scrollHeight)-this.helperProportions.height-this.margins.top]}if(!/^(document|window|parent)$/.test(i.containment)){t=e(i.containment)[0];n=e(i.containment).offset();r=e(t).css("overflow")!=="hidden";this.containment=[n.left+(parseInt(e(t).css("borderLeftWidth"),10)||0)+(parseInt(e(t).css("paddingLeft"),10)||0)-this.margins.left,n.top+(parseInt(e(t).css("borderTopWidth"),10)||0)+(parseInt(e(t).css("paddingTop"),10)||0)-this.margins.top,n.left+(r?Math.max(t.scrollWidth,t.offsetWidth):t.offsetWidth)-(parseInt(e(t).css("borderLeftWidth"),10)||0)-(parseInt(e(t).css("paddingRight"),10)||0)-this.helperProportions.width-this.margins.left,n.top+(r?Math.max(t.scrollHeight,t.offsetHeight):t.offsetHeight)-(parseInt(e(t).css("borderTopWidth"),10)||0)-(parseInt(e(t).css("paddingBottom"),10)||0)-this.helperProportions.height-this.margins.top]}},_convertPositionTo:function(t,n){if(!n){n=this.position}var r=t==="absolute"?1:-1,i=this.cssPosition==="absolute"&&!(this.scrollParent[0]!==document&&e.contains(this.scrollParent[0],this.offsetParent[0]))?this.offsetParent:this.scrollParent,s=/(html|body)/i.test(i[0].tagName);return{top:n.top+this.offset.relative.top*r+this.offset.parent.top*r-(this.cssPosition==="fixed"?-this.scrollParent.scrollTop():s?0:i.scrollTop())*r,left:n.left+this.offset.relative.left*r+this.offset.parent.left*r-(this.cssPosition==="fixed"?-this.scrollParent.scrollLeft():s?0:i.scrollLeft())*r}},_generatePosition:function(t){var n,r,i=this.options,s=t.pageX,o=t.pageY,u=this.cssPosition==="absolute"&&!(this.scrollParent[0]!==document&&e.contains(this.scrollParent[0],this.offsetParent[0]))?this.offsetParent:this.scrollParent,a=/(html|body)/i.test(u[0].tagName);if(this.cssPosition==="relative"&&!(this.scrollParent[0]!==document&&this.scrollParent[0]!==this.offsetParent[0])){this.offset.relative=this._getRelativeOffset()}if(this.originalPosition){if(this.containment){if(t.pageX-this.offset.click.left<this.containment[0]){s=this.containment[0]+this.offset.click.left}if(t.pageY-this.offset.click.top<this.containment[1]){o=this.containment[1]+this.offset.click.top}if(t.pageX-this.offset.click.left>this.containment[2]){s=this.containment[2]+this.offset.click.left}if(t.pageY-this.offset.click.top>this.containment[3]){o=this.containment[3]+this.offset.click.top}}if(i.grid){n=this.originalPageY+Math.round((o-this.originalPageY)/i.grid[1])*i.grid[1];o=this.containment?n-this.offset.click.top>=this.containment[1]&&n-this.offset.click.top<=this.containment[3]?n:n-this.offset.click.top>=this.containment[1]?n-i.grid[1]:n+i.grid[1]:n;r=this.originalPageX+Math.round((s-this.originalPageX)/i.grid[0])*i.grid[0];s=this.containment?r-this.offset.click.left>=this.containment[0]&&r-this.offset.click.left<=this.containment[2]?r:r-this.offset.click.left>=this.containment[0]?r-i.grid[0]:r+i.grid[0]:r}}return{top:o-this.offset.click.top-this.offset.relative.top-this.offset.parent.top+(this.cssPosition==="fixed"?-this.scrollParent.scrollTop():a?0:u.scrollTop()),left:s-this.offset.click.left-this.offset.relative.left-this.offset.parent.left+(this.cssPosition==="fixed"?-this.scrollParent.scrollLeft():a?0:u.scrollLeft())}},_rearrange:function(e,t,n,r){n?n[0].appendChild(this.placeholder[0]):t.item[0].parentNode.insertBefore(this.placeholder[0],this.direction==="down"?t.item[0]:t.item[0].nextSibling);this.counter=this.counter?++this.counter:1;var i=this.counter;this._delay(function(){if(i===this.counter){this.refreshPositions(!r)}})},_clear:function(e,t){this.reverting=false;var n,r=[];if(!this._noFinalSort&&this.currentItem.parent().length){this.placeholder.before(this.currentItem)}this._noFinalSort=null;if(this.helper[0]===this.currentItem[0]){for(n in this._storedCSS){if(this._storedCSS[n]==="auto"||this._storedCSS[n]==="static"){this._storedCSS[n]=""}}this.currentItem.css(this._storedCSS).removeClass("ui-sortable-helper")}else{this.currentItem.show()}if(this.fromOutside&&!t){r.push(function(e){this._trigger("receive",e,this._uiHash(this.fromOutside))})}if((this.fromOutside||this.domPosition.prev!==this.currentItem.prev().not(".ui-sortable-helper")[0]||this.domPosition.parent!==this.currentItem.parent()[0])&&!t){r.push(function(e){this._trigger("update",e,this._uiHash())})}if(this!==this.currentContainer){if(!t){r.push(function(e){this._trigger("remove",e,this._uiHash())});r.push(function(e){return function(t){e._trigger("receive",t,this._uiHash(this))}}.call(this,this.currentContainer));r.push(function(e){return function(t){e._trigger("update",t,this._uiHash(this))}}.call(this,this.currentContainer))}}for(n=this.containers.length-1;n>=0;n--){if(!t){r.push(function(e){return function(t){e._trigger("deactivate",t,this._uiHash(this))}}.call(this,this.containers[n]))}if(this.containers[n].containerCache.over){r.push(function(e){return function(t){e._trigger("out",t,this._uiHash(this))}}.call(this,this.containers[n]));this.containers[n].containerCache.over=0}}if(this.storedCursor){this.document.find("body").css("cursor",this.storedCursor);this.storedStylesheet.remove()}if(this._storedOpacity){this.helper.css("opacity",this._storedOpacity)}if(this._storedZIndex){this.helper.css("zIndex",this._storedZIndex==="auto"?"":this._storedZIndex)}this.dragging=false;if(this.cancelHelperRemoval){if(!t){this._trigger("beforeStop",e,this._uiHash());for(n=0;n<r.length;n++){r[n].call(this,e)}this._trigger("stop",e,this._uiHash())}this.fromOutside=false;return false}if(!t){this._trigger("beforeStop",e,this._uiHash())}this.placeholder[0].parentNode.removeChild(this.placeholder[0]);if(this.helper[0]!==this.currentItem[0]){this.helper.remove()}this.helper=null;if(!t){for(n=0;n<r.length;n++){r[n].call(this,e)}this._trigger("stop",e,this._uiHash())}this.fromOutside=false;return true},_trigger:function(){if(e.Widget.prototype._trigger.apply(this,arguments)===false){this.cancel()}},_uiHash:function(t){var n=t||this;return{helper:n.helper,placeholder:n.placeholder||e([]),position:n.position,originalPosition:n.originalPosition,offset:n.positionAbs,item:n.currentItem,sender:t?t.element:null}}})})(jQuery);(function(e,t){var n="ui-effects-";e.effects={effect:{}};(function(e,t){function h(e,t,n){var r=u[t.type]||{};if(e==null){return n||!t.def?null:t.def}e=r.floor?~~e:parseFloat(e);if(isNaN(e)){return t.def}if(r.mod){return(e+r.mod)%r.mod}return 0>e?0:r.max<e?r.max:e}function p(t){var n=s(),r=n._rgba=[];t=t.toLowerCase();c(i,function(e,i){var s,u=i.re.exec(t),a=u&&i.parse(u),f=i.space||"rgba";if(a){s=n[f](a);n[o[f].cache]=s[o[f].cache];r=n._rgba=s._rgba;return false}});if(r.length){if(r.join()==="0,0,0,0"){e.extend(r,l.transparent)}return n}return l[t]}function d(e,t,n){n=(n+1)%1;if(n*6<1){return e+(t-e)*n*6}if(n*2<1){return t}if(n*3<2){return e+(t-e)*(2/3-n)*6}return e}var n="backgroundColor borderBottomColor borderLeftColor borderRightColor borderTopColor color columnRuleColor outlineColor textDecorationColor textEmphasisColor",r=/^([\-+])=\s*(\d+\.?\d*)/,i=[{re:/rgba?\(\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*(?:,\s*(\d?(?:\.\d+)?)\s*)?\)/,parse:function(e){return[e[1],e[2],e[3],e[4]]}},{re:/rgba?\(\s*(\d+(?:\.\d+)?)\%\s*,\s*(\d+(?:\.\d+)?)\%\s*,\s*(\d+(?:\.\d+)?)\%\s*(?:,\s*(\d?(?:\.\d+)?)\s*)?\)/,parse:function(e){return[e[1]*2.55,e[2]*2.55,e[3]*2.55,e[4]]}},{re:/#([a-f0-9]{2})([a-f0-9]{2})([a-f0-9]{2})/,parse:function(e){return[parseInt(e[1],16),parseInt(e[2],16),parseInt(e[3],16)]}},{re:/#([a-f0-9])([a-f0-9])([a-f0-9])/,parse:function(e){return[parseInt(e[1]+e[1],16),parseInt(e[2]+e[2],16),parseInt(e[3]+e[3],16)]}},{re:/hsla?\(\s*(\d+(?:\.\d+)?)\s*,\s*(\d+(?:\.\d+)?)\%\s*,\s*(\d+(?:\.\d+)?)\%\s*(?:,\s*(\d?(?:\.\d+)?)\s*)?\)/,space:"hsla",parse:function(e){return[e[1],e[2]/100,e[3]/100,e[4]]}}],s=e.Color=function(t,n,r,i){return new e.Color.fn.parse(t,n,r,i)},o={rgba:{props:{red:{idx:0,type:"byte"},green:{idx:1,type:"byte"},blue:{idx:2,type:"byte"}}},hsla:{props:{hue:{idx:0,type:"degrees"},saturation:{idx:1,type:"percent"},lightness:{idx:2,type:"percent"}}}},u={"byte":{floor:true,max:255},percent:{max:1},degrees:{mod:360,floor:true}},a=s.support={},f=e("<p>")[0],l,c=e.each;f.style.cssText="background-color:rgba(1,1,1,.5)";a.rgba=f.style.backgroundColor.indexOf("rgba")>-1;c(o,function(e,t){t.cache="_"+e;t.props.alpha={idx:3,type:"percent",def:1}});s.fn=e.extend(s.prototype,{parse:function(n,r,i,u){if(n===t){this._rgba=[null,null,null,null];return this}if(n.jquery||n.nodeType){n=e(n).css(r);r=t}var a=this,f=e.type(n),d=this._rgba=[];if(r!==t){n=[n,r,i,u];f="array"}if(f==="string"){return this.parse(p(n)||l._default)}if(f==="array"){c(o.rgba.props,function(e,t){d[t.idx]=h(n[t.idx],t)});return this}if(f==="object"){if(n instanceof s){c(o,function(e,t){if(n[t.cache]){a[t.cache]=n[t.cache].slice()}})}else{c(o,function(t,r){var i=r.cache;c(r.props,function(e,t){if(!a[i]&&r.to){if(e==="alpha"||n[e]==null){return}a[i]=r.to(a._rgba)}a[i][t.idx]=h(n[e],t,true)});if(a[i]&&e.inArray(null,a[i].slice(0,3))<0){a[i][3]=1;if(r.from){a._rgba=r.from(a[i])}}})}return this}},is:function(e){var t=s(e),n=true,r=this;c(o,function(e,i){var s,o=t[i.cache];if(o){s=r[i.cache]||i.to&&i.to(r._rgba)||[];c(i.props,function(e,t){if(o[t.idx]!=null){n=o[t.idx]===s[t.idx];return n}})}return n});return n},_space:function(){var e=[],t=this;c(o,function(n,r){if(t[r.cache]){e.push(n)}});return e.pop()},transition:function(e,t){var n=s(e),r=n._space(),i=o[r],a=this.alpha()===0?s("transparent"):this,f=a[i.cache]||i.to(a._rgba),l=f.slice();n=n[i.cache];c(i.props,function(e,r){var i=r.idx,s=f[i],o=n[i],a=u[r.type]||{};if(o===null){return}if(s===null){l[i]=o}else{if(a.mod){if(o-s>a.mod/2){s+=a.mod}else if(s-o>a.mod/2){s-=a.mod}}l[i]=h((o-s)*t+s,r)}});return this[r](l)},blend:function(t){if(this._rgba[3]===1){return this}var n=this._rgba.slice(),r=n.pop(),i=s(t)._rgba;return s(e.map(n,function(e,t){return(1-r)*i[t]+r*e}))},toRgbaString:function(){var t="rgba(",n=e.map(this._rgba,function(e,t){return e==null?t>2?1:0:e});if(n[3]===1){n.pop();t="rgb("}return t+n.join()+")"},toHslaString:function(){var t="hsla(",n=e.map(this.hsla(),function(e,t){if(e==null){e=t>2?1:0}if(t&&t<3){e=Math.round(e*100)+"%"}return e});if(n[3]===1){n.pop();t="hsl("}return t+n.join()+")"},toHexString:function(t){var n=this._rgba.slice(),r=n.pop();if(t){n.push(~~(r*255))}return"#"+e.map(n,function(e){e=(e||0).toString(16);return e.length===1?"0"+e:e}).join("")},toString:function(){return this._rgba[3]===0?"transparent":this.toRgbaString()}});s.fn.parse.prototype=s.fn;o.hsla.to=function(e){if(e[0]==null||e[1]==null||e[2]==null){return[null,null,null,e[3]]}var t=e[0]/255,n=e[1]/255,r=e[2]/255,i=e[3],s=Math.max(t,n,r),o=Math.min(t,n,r),u=s-o,a=s+o,f=a*.5,l,c;if(o===s){l=0}else if(t===s){l=60*(n-r)/u+360}else if(n===s){l=60*(r-t)/u+120}else{l=60*(t-n)/u+240}if(u===0){c=0}else if(f<=.5){c=u/a}else{c=u/(2-a)}return[Math.round(l)%360,c,f,i==null?1:i]};o.hsla.from=function(e){if(e[0]==null||e[1]==null||e[2]==null){return[null,null,null,e[3]]}var t=e[0]/360,n=e[1],r=e[2],i=e[3],s=r<=.5?r*(1+n):r+n-r*n,o=2*r-s;return[Math.round(d(o,s,t+1/3)*255),Math.round(d(o,s,t)*255),Math.round(d(o,s,t-1/3)*255),i]};c(o,function(n,i){var o=i.props,u=i.cache,a=i.to,f=i.from;s.fn[n]=function(n){if(a&&!this[u]){this[u]=a(this._rgba)}if(n===t){return this[u].slice()}var r,i=e.type(n),l=i==="array"||i==="object"?n:arguments,p=this[u].slice();c(o,function(e,t){var n=l[i==="object"?e:t.idx];if(n==null){n=p[t.idx]}p[t.idx]=h(n,t)});if(f){r=s(f(p));r[u]=p;return r}else{return s(p)}};c(o,function(t,i){if(s.fn[t]){return}s.fn[t]=function(s){var o=e.type(s),u=t==="alpha"?this._hsla?"hsla":"rgba":n,a=this[u](),f=a[i.idx],l;if(o==="undefined"){return f}if(o==="function"){s=s.call(this,f);o=e.type(s)}if(s==null&&i.empty){return this}if(o==="string"){l=r.exec(s);if(l){s=f+parseFloat(l[2])*(l[1]==="+"?1:-1)}}a[i.idx]=s;return this[u](a)}})});s.hook=function(t){var n=t.split(" ");c(n,function(t,n){e.cssHooks[n]={set:function(t,r){var i,o,u="";if(r!=="transparent"&&(e.type(r)!=="string"||(i=p(r)))){r=s(i||r);if(!a.rgba&&r._rgba[3]!==1){o=n==="backgroundColor"?t.parentNode:t;while((u===""||u==="transparent")&&o&&o.style){try{u=e.css(o,"backgroundColor");o=o.parentNode}catch(f){}}r=r.blend(u&&u!=="transparent"?u:"_default")}r=r.toRgbaString()}try{t.style[n]=r}catch(f){}}};e.fx.step[n]=function(t){if(!t.colorInit){t.start=s(t.elem,n);t.end=s(t.end);t.colorInit=true}e.cssHooks[n].set(t.elem,t.start.transition(t.end,t.pos))}})};s.hook(n);e.cssHooks.borderColor={expand:function(e){var t={};c(["Top","Right","Bottom","Left"],function(n,r){t["border"+r+"Color"]=e});return t}};l=e.Color.names={aqua:"#00ffff",black:"#000000",blue:"#0000ff",fuchsia:"#ff00ff",gray:"#808080",green:"#008000",lime:"#00ff00",maroon:"#800000",navy:"#000080",olive:"#808000",purple:"#800080",red:"#ff0000",silver:"#c0c0c0",teal:"#008080",white:"#ffffff",yellow:"#ffff00",transparent:[null,null,null,0],_default:"#ffffff"}})(jQuery);(function(){function i(t){var n,r,i=t.ownerDocument.defaultView?t.ownerDocument.defaultView.getComputedStyle(t,null):t.currentStyle,s={};if(i&&i.length&&i[0]&&i[i[0]]){r=i.length;while(r--){n=i[r];if(typeof i[n]==="string"){s[e.camelCase(n)]=i[n]}}}else{for(n in i){if(typeof i[n]==="string"){s[n]=i[n]}}}return s}function s(t,n){var i={},s,o;for(s in n){o=n[s];if(t[s]!==o){if(!r[s]){if(e.fx.step[s]||!isNaN(parseFloat(o))){i[s]=o}}}}return i}var n=["add","remove","toggle"],r={border:1,borderBottom:1,borderColor:1,borderLeft:1,borderRight:1,borderTop:1,borderWidth:1,margin:1,padding:1};e.each(["borderLeftStyle","borderRightStyle","borderBottomStyle","borderTopStyle"],function(t,n){e.fx.step[n]=function(e){if(e.end!=="none"&&!e.setAttr||e.pos===1&&!e.setAttr){jQuery.style(e.elem,n,e.end);e.setAttr=true}}});if(!e.fn.addBack){e.fn.addBack=function(e){return this.add(e==null?this.prevObject:this.prevObject.filter(e))}}e.effects.animateClass=function(t,r,o,u){var a=e.speed(r,o,u);return this.queue(function(){var r=e(this),o=r.attr("class")||"",u,f=a.children?r.find("*").addBack():r;f=f.map(function(){var t=e(this);return{el:t,start:i(this)}});u=function(){e.each(n,function(e,n){if(t[n]){r[n+"Class"](t[n])}})};u();f=f.map(function(){this.end=i(this.el[0]);this.diff=s(this.start,this.end);return this});r.attr("class",o);f=f.map(function(){var t=this,n=e.Deferred(),r=e.extend({},a,{queue:false,complete:function(){n.resolve(t)}});this.el.animate(this.diff,r);return n.promise()});e.when.apply(e,f.get()).done(function(){u();e.each(arguments,function(){var t=this.el;e.each(this.diff,function(e){t.css(e,"")})});a.complete.call(r[0])})})};e.fn.extend({addClass:function(t){return function(n,r,i,s){return r?e.effects.animateClass.call(this,{add:n},r,i,s):t.apply(this,arguments)}}(e.fn.addClass),removeClass:function(t){return function(n,r,i,s){return arguments.length>1?e.effects.animateClass.call(this,{remove:n},r,i,s):t.apply(this,arguments)}}(e.fn.removeClass),toggleClass:function(n){return function(r,i,s,o,u){if(typeof i==="boolean"||i===t){if(!s){return n.apply(this,arguments)}else{return e.effects.animateClass.call(this,i?{add:r}:{remove:r},s,o,u)}}else{return e.effects.animateClass.call(this,{toggle:r},i,s,o)}}}(e.fn.toggleClass),switchClass:function(t,n,r,i,s){return e.effects.animateClass.call(this,{add:n,remove:t},r,i,s)}})})();(function(){function r(t,n,r,i){if(e.isPlainObject(t)){n=t;t=t.effect}t={effect:t};if(n==null){n={}}if(e.isFunction(n)){i=n;r=null;n={}}if(typeof n==="number"||e.fx.speeds[n]){i=r;r=n;n={}}if(e.isFunction(r)){i=r;r=null}if(n){e.extend(t,n)}r=r||n.duration;t.duration=e.fx.off?0:typeof r==="number"?r:r in e.fx.speeds?e.fx.speeds[r]:e.fx.speeds._default;t.complete=i||n.complete;return t}function i(t){if(!t||typeof t==="number"||e.fx.speeds[t]){return true}if(typeof t==="string"&&!e.effects.effect[t]){return true}if(e.isFunction(t)){return true}if(typeof t==="object"&&!t.effect){return true}return false}e.extend(e.effects,{version:"1.10.3",save:function(e,t){for(var r=0;r<t.length;r++){if(t[r]!==null){e.data(n+t[r],e[0].style[t[r]])}}},restore:function(e,r){var i,s;for(s=0;s<r.length;s++){if(r[s]!==null){i=e.data(n+r[s]);if(i===t){i=""}e.css(r[s],i)}}},setMode:function(e,t){if(t==="toggle"){t=e.is(":hidden")?"show":"hide"}return t},getBaseline:function(e,t){var n,r;switch(e[0]){case"top":n=0;break;case"middle":n=.5;break;case"bottom":n=1;break;default:n=e[0]/t.height}switch(e[1]){case"left":r=0;break;case"center":r=.5;break;case"right":r=1;break;default:r=e[1]/t.width}return{x:r,y:n}},createWrapper:function(t){if(t.parent().is(".ui-effects-wrapper")){return t.parent()}var n={width:t.outerWidth(true),height:t.outerHeight(true),"float":t.css("float")},r=e("<div></div>").addClass("ui-effects-wrapper").css({fontSize:"100%",background:"transparent",border:"none",margin:0,padding:0}),i={width:t.width(),height:t.height()},s=document.activeElement;try{s.id}catch(o){s=document.body}t.wrap(r);if(t[0]===s||e.contains(t[0],s)){e(s).focus()}r=t.parent();if(t.css("position")==="static"){r.css({position:"relative"});t.css({position:"relative"})}else{e.extend(n,{position:t.css("position"),zIndex:t.css("z-index")});e.each(["top","left","bottom","right"],function(e,r){n[r]=t.css(r);if(isNaN(parseInt(n[r],10))){n[r]="auto"}});t.css({position:"relative",top:0,left:0,right:"auto",bottom:"auto"})}t.css(i);return r.css(n).show()},removeWrapper:function(t){var n=document.activeElement;if(t.parent().is(".ui-effects-wrapper")){t.parent().replaceWith(t);if(t[0]===n||e.contains(t[0],n)){e(n).focus()}}return t},setTransition:function(t,n,r,i){i=i||{};e.each(n,function(e,n){var s=t.cssUnit(n);if(s[0]>0){i[n]=s[0]*r+s[1]}});return i}});e.fn.extend({effect:function(){function o(n){function u(){if(e.isFunction(i)){i.call(r[0])}if(e.isFunction(n)){n()}}var r=e(this),i=t.complete,o=t.mode;if(r.is(":hidden")?o==="hide":o==="show"){r[o]();u()}else{s.call(r[0],t,u)}}var t=r.apply(this,arguments),n=t.mode,i=t.queue,s=e.effects.effect[t.effect];if(e.fx.off||!s){if(n){return this[n](t.duration,t.complete)}else{return this.each(function(){if(t.complete){t.complete.call(this)}})}}return i===false?this.each(o):this.queue(i||"fx",o)},show:function(e){return function(t){if(i(t)){return e.apply(this,arguments)}else{var n=r.apply(this,arguments);n.mode="show";return this.effect.call(this,n)}}}(e.fn.show),hide:function(e){return function(t){if(i(t)){return e.apply(this,arguments)}else{var n=r.apply(this,arguments);n.mode="hide";return this.effect.call(this,n)}}}(e.fn.hide),toggle:function(e){return function(t){if(i(t)||typeof t==="boolean"){return e.apply(this,arguments)}else{var n=r.apply(this,arguments);n.mode="toggle";return this.effect.call(this,n)}}}(e.fn.toggle),cssUnit:function(t){var n=this.css(t),r=[];e.each(["em","px","%","pt"],function(e,t){if(n.indexOf(t)>0){r=[parseFloat(n),t]}});return r}})})();(function(){var t={};e.each(["Quad","Cubic","Quart","Quint","Expo"],function(e,n){t[n]=function(t){return Math.pow(t,e+2)}});e.extend(t,{Sine:function(e){return 1-Math.cos(e*Math.PI/2)},Circ:function(e){return 1-Math.sqrt(1-e*e)},Elastic:function(e){return e===0||e===1?e:-Math.pow(2,8*(e-1))*Math.sin(((e-1)*80-7.5)*Math.PI/15)},Back:function(e){return e*e*(3*e-2)},Bounce:function(e){var t,n=4;while(e<((t=Math.pow(2,--n))-1)/11){}return 1/Math.pow(4,3-n)-7.5625*Math.pow((t*3-2)/22-e,2)}});e.each(t,function(t,n){e.easing["easeIn"+t]=n;e.easing["easeOut"+t]=function(e){return 1-n(1-e)};e.easing["easeInOut"+t]=function(e){return e<.5?n(e*2)/2:1-n(e*-2+2)/2}})})()})(jQuery);(function(e,t){var n=0,r={},i={};r.height=r.paddingTop=r.paddingBottom=r.borderTopWidth=r.borderBottomWidth="hide";i.height=i.paddingTop=i.paddingBottom=i.borderTopWidth=i.borderBottomWidth="show";e.widget("ui.accordion",{version:"1.10.3",options:{active:0,animate:{},collapsible:false,event:"click",header:"> li > :first-child,> :not(li):even",heightStyle:"auto",icons:{activeHeader:"ui-icon-triangle-1-s",header:"ui-icon-triangle-1-e"},activate:null,beforeActivate:null},_create:function(){var t=this.options;this.prevShow=this.prevHide=e();this.element.addClass("ui-accordion ui-widget ui-helper-reset").attr("role","tablist");if(!t.collapsible&&(t.active===false||t.active==null)){t.active=0}this._processPanels();if(t.active<0){t.active+=this.headers.length}this._refresh()},_getCreateEventData:function(){return{header:this.active,panel:!this.active.length?e():this.active.next(),content:!this.active.length?e():this.active.next()}},_createIcons:function(){var t=this.options.icons;if(t){e("<span>").addClass("ui-accordion-header-icon ui-icon "+t.header).prependTo(this.headers);this.active.children(".ui-accordion-header-icon").removeClass(t.header).addClass(t.activeHeader);this.headers.addClass("ui-accordion-icons")}},_destroyIcons:function(){this.headers.removeClass("ui-accordion-icons").children(".ui-accordion-header-icon").remove()},_destroy:function(){var e;this.element.removeClass("ui-accordion ui-widget ui-helper-reset").removeAttr("role");this.headers.removeClass("ui-accordion-header ui-accordion-header-active ui-helper-reset ui-state-default ui-corner-all ui-state-active ui-state-disabled ui-corner-top").removeAttr("role").removeAttr("aria-selected").removeAttr("aria-controls").removeAttr("tabIndex").each(function(){if(/^ui-accordion/.test(this.id)){this.removeAttribute("id")}});this._destroyIcons();e=this.headers.next().css("display","").removeAttr("role").removeAttr("aria-expanded").removeAttr("aria-hidden").removeAttr("aria-labelledby").removeClass("ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content ui-accordion-content-active ui-state-disabled").each(function(){if(/^ui-accordion/.test(this.id)){this.removeAttribute("id")}});if(this.options.heightStyle!=="content"){e.css("height","")}},_setOption:function(e,t){if(e==="active"){this._activate(t);return}if(e==="event"){if(this.options.event){this._off(this.headers,this.options.event)}this._setupEvents(t)}this._super(e,t);if(e==="collapsible"&&!t&&this.options.active===false){this._activate(0)}if(e==="icons"){this._destroyIcons();if(t){this._createIcons()}}if(e==="disabled"){this.headers.add(this.headers.next()).toggleClass("ui-state-disabled",!!t)}},_keydown:function(t){if(t.altKey||t.ctrlKey){return}var n=e.ui.keyCode,r=this.headers.length,i=this.headers.index(t.target),s=false;switch(t.keyCode){case n.RIGHT:case n.DOWN:s=this.headers[(i+1)%r];break;case n.LEFT:case n.UP:s=this.headers[(i-1+r)%r];break;case n.SPACE:case n.ENTER:this._eventHandler(t);break;case n.HOME:s=this.headers[0];break;case n.END:s=this.headers[r-1];break}if(s){e(t.target).attr("tabIndex",-1);e(s).attr("tabIndex",0);s.focus();t.preventDefault()}},_panelKeyDown:function(t){if(t.keyCode===e.ui.keyCode.UP&&t.ctrlKey){e(t.currentTarget).prev().focus()}},refresh:function(){var t=this.options;this._processPanels();if(t.active===false&&t.collapsible===true||!this.headers.length){t.active=false;this.active=e()}else if(t.active===false){this._activate(0)}else if(this.active.length&&!e.contains(this.element[0],this.active[0])){if(this.headers.length===this.headers.find(".ui-state-disabled").length){t.active=false;this.active=e()}else{this._activate(Math.max(0,t.active-1))}}else{t.active=this.headers.index(this.active)}this._destroyIcons();this._refresh()},_processPanels:function(){this.headers=this.element.find(this.options.header).addClass("ui-accordion-header ui-helper-reset ui-state-default ui-corner-all");this.headers.next().addClass("ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom").filter(":not(.ui-accordion-content-active)").hide()},_refresh:function(){var t,r=this.options,i=r.heightStyle,s=this.element.parent(),o=this.accordionId="ui-accordion-"+(this.element.attr("id")||++n);this.active=this._findActive(r.active).addClass("ui-accordion-header-active ui-state-active ui-corner-top").removeClass("ui-corner-all");this.active.next().addClass("ui-accordion-content-active").show();this.headers.attr("role","tab").each(function(t){var n=e(this),r=n.attr("id"),i=n.next(),s=i.attr("id");if(!r){r=o+"-header-"+t;n.attr("id",r)}if(!s){s=o+"-panel-"+t;i.attr("id",s)}n.attr("aria-controls",s);i.attr("aria-labelledby",r)}).next().attr("role","tabpanel");this.headers.not(this.active).attr({"aria-selected":"false",tabIndex:-1}).next().attr({"aria-expanded":"false","aria-hidden":"true"}).hide();if(!this.active.length){this.headers.eq(0).attr("tabIndex",0)}else{this.active.attr({"aria-selected":"true",tabIndex:0}).next().attr({"aria-expanded":"true","aria-hidden":"false"})}this._createIcons();this._setupEvents(r.event);if(i==="fill"){t=s.height();this.element.siblings(":visible").each(function(){var n=e(this),r=n.css("position");if(r==="absolute"||r==="fixed"){return}t-=n.outerHeight(true)});this.headers.each(function(){t-=e(this).outerHeight(true)});this.headers.next().each(function(){e(this).height(Math.max(0,t-e(this).innerHeight()+e(this).height()))}).css("overflow","auto")}else if(i==="auto"){t=0;this.headers.next().each(function(){t=Math.max(t,e(this).css("height","").height())}).height(t)}},_activate:function(t){var n=this._findActive(t)[0];if(n===this.active[0]){return}n=n||this.active[0];this._eventHandler({target:n,currentTarget:n,preventDefault:e.noop})},_findActive:function(t){return typeof t==="number"?this.headers.eq(t):e()},_setupEvents:function(t){var n={keydown:"_keydown"};if(t){e.each(t.split(" "),function(e,t){n[t]="_eventHandler"})}this._off(this.headers.add(this.headers.next()));this._on(this.headers,n);this._on(this.headers.next(),{keydown:"_panelKeyDown"});this._hoverable(this.headers);this._focusable(this.headers)},_eventHandler:function(t){var n=this.options,r=this.active,i=e(t.currentTarget),s=i[0]===r[0],o=s&&n.collapsible,u=o?e():i.next(),a=r.next(),f={oldHeader:r,oldPanel:a,newHeader:o?e():i,newPanel:u};t.preventDefault();if(s&&!n.collapsible||this._trigger("beforeActivate",t,f)===false){return}n.active=o?false:this.headers.index(i);this.active=s?e():i;this._toggle(f);r.removeClass("ui-accordion-header-active ui-state-active");if(n.icons){r.children(".ui-accordion-header-icon").removeClass(n.icons.activeHeader).addClass(n.icons.header)}if(!s){i.removeClass("ui-corner-all").addClass("ui-accordion-header-active ui-state-active ui-corner-top");if(n.icons){i.children(".ui-accordion-header-icon").removeClass(n.icons.header).addClass(n.icons.activeHeader)}i.next().addClass("ui-accordion-content-active")}},_toggle:function(t){var n=t.newPanel,r=this.prevShow.length?this.prevShow:t.oldPanel;this.prevShow.add(this.prevHide).stop(true,true);this.prevShow=n;this.prevHide=r;if(this.options.animate){this._animate(n,r,t)}else{r.hide();n.show();this._toggleComplete(t)}r.attr({"aria-expanded":"false","aria-hidden":"true"});r.prev().attr("aria-selected","false");if(n.length&&r.length){r.prev().attr("tabIndex",-1)}else if(n.length){this.headers.filter(function(){return e(this).attr("tabIndex")===0}).attr("tabIndex",-1)}n.attr({"aria-expanded":"true","aria-hidden":"false"}).prev().attr({"aria-selected":"true",tabIndex:0})},_animate:function(e,t,n){var s,o,u,a=this,f=0,l=e.length&&(!t.length||e.index()<t.index()),c=this.options.animate||{},h=l&&c.down||c,p=function(){a._toggleComplete(n)};if(typeof h==="number"){u=h}if(typeof h==="string"){o=h}o=o||h.easing||c.easing;u=u||h.duration||c.duration;if(!t.length){return e.animate(i,u,o,p)}if(!e.length){return t.animate(r,u,o,p)}s=e.show().outerHeight();t.animate(r,{duration:u,easing:o,step:function(e,t){t.now=Math.round(e)}});e.hide().animate(i,{duration:u,easing:o,complete:p,step:function(e,n){n.now=Math.round(e);if(n.prop!=="height"){f+=n.now}else if(a.options.heightStyle!=="content"){n.now=Math.round(s-t.outerHeight()-f);f=0}}})},_toggleComplete:function(e){var t=e.oldPanel;t.removeClass("ui-accordion-content-active").prev().removeClass("ui-corner-top").addClass("ui-corner-all");if(t.length){t.parent()[0].className=t.parent()[0].className}this._trigger("activate",null,e)}})})(jQuery);(function(e,t){var n=0;e.widget("ui.autocomplete",{version:"1.10.3",defaultElement:"<input>",options:{appendTo:null,autoFocus:false,delay:300,minLength:1,position:{my:"left top",at:"left bottom",collision:"none"},source:null,change:null,close:null,focus:null,open:null,response:null,search:null,select:null},pending:0,_create:function(){var t,n,r,i=this.element[0].nodeName.toLowerCase(),s=i==="textarea",o=i==="input";this.isMultiLine=s?true:o?false:this.element.prop("isContentEditable");this.valueMethod=this.element[s||o?"val":"text"];this.isNewMenu=true;this.element.addClass("ui-autocomplete-input").attr("autocomplete","off");this._on(this.element,{keydown:function(i){if(this.element.prop("readOnly")){t=true;r=true;n=true;return}t=false;r=false;n=false;var s=e.ui.keyCode;switch(i.keyCode){case s.PAGE_UP:t=true;this._move("previousPage",i);break;case s.PAGE_DOWN:t=true;this._move("nextPage",i);break;case s.UP:t=true;this._keyEvent("previous",i);break;case s.DOWN:t=true;this._keyEvent("next",i);break;case s.ENTER:case s.NUMPAD_ENTER:if(this.menu.active){t=true;i.preventDefault();this.menu.select(i)}break;case s.TAB:if(this.menu.active){this.menu.select(i)}break;case s.ESCAPE:if(this.menu.element.is(":visible")){this._value(this.term);this.close(i);i.preventDefault()}break;default:n=true;this._searchTimeout(i);break}},keypress:function(r){if(t){t=false;if(!this.isMultiLine||this.menu.element.is(":visible")){r.preventDefault()}return}if(n){return}var i=e.ui.keyCode;switch(r.keyCode){case i.PAGE_UP:this._move("previousPage",r);break;case i.PAGE_DOWN:this._move("nextPage",r);break;case i.UP:this._keyEvent("previous",r);break;case i.DOWN:this._keyEvent("next",r);break}},input:function(e){if(r){r=false;e.preventDefault();return}this._searchTimeout(e)},focus:function(){this.selectedItem=null;this.previous=this._value()},blur:function(e){if(this.cancelBlur){delete this.cancelBlur;return}clearTimeout(this.searching);this.close(e);this._change(e)}});this._initSource();this.menu=e("<ul>").addClass("ui-autocomplete ui-front").appendTo(this._appendTo()).menu({role:null}).hide().data("ui-menu");this._on(this.menu.element,{mousedown:function(t){t.preventDefault();this.cancelBlur=true;this._delay(function(){delete this.cancelBlur});var n=this.menu.element[0];if(!e(t.target).closest(".ui-menu-item").length){this._delay(function(){var t=this;this.document.one("mousedown",function(r){if(r.target!==t.element[0]&&r.target!==n&&!e.contains(n,r.target)){t.close()}})})}},menufocus:function(t,n){if(this.isNewMenu){this.isNewMenu=false;if(t.originalEvent&&/^mouse/.test(t.originalEvent.type)){this.menu.blur();this.document.one("mousemove",function(){e(t.target).trigger(t.originalEvent)});return}}var r=n.item.data("ui-autocomplete-item");if(false!==this._trigger("focus",t,{item:r})){if(t.originalEvent&&/^key/.test(t.originalEvent.type)){this._value(r.value)}}else{this.liveRegion.text(r.value)}},menuselect:function(e,t){var n=t.item.data("ui-autocomplete-item"),r=this.previous;if(this.element[0]!==this.document[0].activeElement){this.element.focus();this.previous=r;this._delay(function(){this.previous=r;this.selectedItem=n})}if(false!==this._trigger("select",e,{item:n})){this._value(n.value)}this.term=this._value();this.close(e);this.selectedItem=n}});this.liveRegion=e("<span>",{role:"status","aria-live":"polite"}).addClass("ui-helper-hidden-accessible").insertBefore(this.element);this._on(this.window,{beforeunload:function(){this.element.removeAttr("autocomplete")}})},_destroy:function(){clearTimeout(this.searching);this.element.removeClass("ui-autocomplete-input").removeAttr("autocomplete");this.menu.element.remove();this.liveRegion.remove()},_setOption:function(e,t){this._super(e,t);if(e==="source"){this._initSource()}if(e==="appendTo"){this.menu.element.appendTo(this._appendTo())}if(e==="disabled"&&t&&this.xhr){this.xhr.abort()}},_appendTo:function(){var t=this.options.appendTo;if(t){t=t.jquery||t.nodeType?e(t):this.document.find(t).eq(0)}if(!t){t=this.element.closest(".ui-front")}if(!t.length){t=this.document[0].body}return t},_initSource:function(){var t,n,r=this;if(e.isArray(this.options.source)){t=this.options.source;this.source=function(n,r){r(e.ui.autocomplete.filter(t,n.term))}}else if(typeof this.options.source==="string"){n=this.options.source;this.source=function(t,i){if(r.xhr){r.xhr.abort()}r.xhr=e.ajax({url:n,data:t,dataType:"json",success:function(e){i(e)},error:function(){i([])}})}}else{this.source=this.options.source}},_searchTimeout:function(e){clearTimeout(this.searching);this.searching=this._delay(function(){if(this.term!==this._value()){this.selectedItem=null;this.search(null,e)}},this.options.delay)},search:function(e,t){e=e!=null?e:this._value();this.term=this._value();if(e.length<this.options.minLength){return this.close(t)}if(this._trigger("search",t)===false){return}return this._search(e)},_search:function(e){this.pending++;this.element.addClass("ui-autocomplete-loading");this.cancelSearch=false;this.source({term:e},this._response())},_response:function(){var e=this,t=++n;return function(r){if(t===n){e.__response(r)}e.pending--;if(!e.pending){e.element.removeClass("ui-autocomplete-loading")}}},__response:function(e){if(e){e=this._normalize(e)}this._trigger("response",null,{content:e});if(!this.options.disabled&&e&&e.length&&!this.cancelSearch){this._suggest(e);this._trigger("open")}else{this._close()}},close:function(e){this.cancelSearch=true;this._close(e)},_close:function(e){if(this.menu.element.is(":visible")){this.menu.element.hide();this.menu.blur();this.isNewMenu=true;this._trigger("close",e)}},_change:function(e){if(this.previous!==this._value()){this._trigger("change",e,{item:this.selectedItem})}},_normalize:function(t){if(t.length&&t[0].label&&t[0].value){return t}return e.map(t,function(t){if(typeof t==="string"){return{label:t,value:t}}return e.extend({label:t.label||t.value,value:t.value||t.label},t)})},_suggest:function(t){var n=this.menu.element.empty();this._renderMenu(n,t);this.isNewMenu=true;this.menu.refresh();n.show();this._resizeMenu();n.position(e.extend({of:this.element},this.options.position));if(this.options.autoFocus){this.menu.next()}},_resizeMenu:function(){var e=this.menu.element;e.outerWidth(Math.max(e.width("").outerWidth()+1,this.element.outerWidth()))},_renderMenu:function(t,n){var r=this;e.each(n,function(e,n){r._renderItemData(t,n)})},_renderItemData:function(e,t){return this._renderItem(e,t).data("ui-autocomplete-item",t)},_renderItem:function(t,n){return e("<li>").append(e("<a>").text(n.label)).appendTo(t)},_move:function(e,t){if(!this.menu.element.is(":visible")){this.search(null,t);return}if(this.menu.isFirstItem()&&/^previous/.test(e)||this.menu.isLastItem()&&/^next/.test(e)){this._value(this.term);this.menu.blur();return}this.menu[e](t)},widget:function(){return this.menu.element},_value:function(){return this.valueMethod.apply(this.element,arguments)},_keyEvent:function(e,t){if(!this.isMultiLine||this.menu.element.is(":visible")){this._move(e,t);t.preventDefault()}}});e.extend(e.ui.autocomplete,{escapeRegex:function(e){return e.replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g,"\\$&")},filter:function(t,n){var r=new RegExp(e.ui.autocomplete.escapeRegex(n),"i");return e.grep(t,function(e){return r.test(e.label||e.value||e)})}});e.widget("ui.autocomplete",e.ui.autocomplete,{options:{messages:{noResults:"No search results.",results:function(e){return e+(e>1?" results are":" result is")+" available, use up and down arrow keys to navigate."}}},__response:function(e){var t;this._superApply(arguments);if(this.options.disabled||this.cancelSearch){return}if(e&&e.length){t=this.options.messages.results(e.length)}else{t=this.options.messages.noResults}this.liveRegion.text(t)}})})(jQuery);(function(e,t){var n,r,i,s,o="ui-button ui-widget ui-state-default ui-corner-all",u="ui-state-hover ui-state-active ",a="ui-button-icons-only ui-button-icon-only ui-button-text-icons ui-button-text-icon-primary ui-button-text-icon-secondary ui-button-text-only",f=function(){var t=e(this);setTimeout(function(){t.find(":ui-button").button("refresh")},1)},l=function(t){var n=t.name,r=t.form,i=e([]);if(n){n=n.replace(/'/g,"\\'");if(r){i=e(r).find("[name='"+n+"']")}else{i=e("[name='"+n+"']",t.ownerDocument).filter(function(){return!this.form})}}return i};e.widget("ui.button",{version:"1.10.3",defaultElement:"<button>",options:{disabled:null,text:true,label:null,icons:{primary:null,secondary:null}},_create:function(){this.element.closest("form").unbind("reset"+this.eventNamespace).bind("reset"+this.eventNamespace,f);if(typeof this.options.disabled!=="boolean"){this.options.disabled=!!this.element.prop("disabled")}else{this.element.prop("disabled",this.options.disabled)}this._determineButtonType();this.hasTitle=!!this.buttonElement.attr("title");var t=this,u=this.options,a=this.type==="checkbox"||this.type==="radio",c=!a?"ui-state-active":"",h="ui-state-focus";if(u.label===null){u.label=this.type==="input"?this.buttonElement.val():this.buttonElement.html()}this._hoverable(this.buttonElement);this.buttonElement.addClass(o).attr("role","button").bind("mouseenter"+this.eventNamespace,function(){if(u.disabled){return}if(this===n){e(this).addClass("ui-state-active")}}).bind("mouseleave"+this.eventNamespace,function(){if(u.disabled){return}e(this).removeClass(c)}).bind("click"+this.eventNamespace,function(e){if(u.disabled){e.preventDefault();e.stopImmediatePropagation()}});this.element.bind("focus"+this.eventNamespace,function(){t.buttonElement.addClass(h)}).bind("blur"+this.eventNamespace,function(){t.buttonElement.removeClass(h)});if(a){this.element.bind("change"+this.eventNamespace,function(){if(s){return}t.refresh()});this.buttonElement.bind("mousedown"+this.eventNamespace,function(e){if(u.disabled){return}s=false;r=e.pageX;i=e.pageY}).bind("mouseup"+this.eventNamespace,function(e){if(u.disabled){return}if(r!==e.pageX||i!==e.pageY){s=true}})}if(this.type==="checkbox"){this.buttonElement.bind("click"+this.eventNamespace,function(){if(u.disabled||s){return false}})}else if(this.type==="radio"){this.buttonElement.bind("click"+this.eventNamespace,function(){if(u.disabled||s){return false}e(this).addClass("ui-state-active");t.buttonElement.attr("aria-pressed","true");var n=t.element[0];l(n).not(n).map(function(){return e(this).button("widget")[0]}).removeClass("ui-state-active").attr("aria-pressed","false")})}else{this.buttonElement.bind("mousedown"+this.eventNamespace,function(){if(u.disabled){return false}e(this).addClass("ui-state-active");n=this;t.document.one("mouseup",function(){n=null})}).bind("mouseup"+this.eventNamespace,function(){if(u.disabled){return false}e(this).removeClass("ui-state-active")}).bind("keydown"+this.eventNamespace,function(t){if(u.disabled){return false}if(t.keyCode===e.ui.keyCode.SPACE||t.keyCode===e.ui.keyCode.ENTER){e(this).addClass("ui-state-active")}}).bind("keyup"+this.eventNamespace+" blur"+this.eventNamespace,function(){e(this).removeClass("ui-state-active")});if(this.buttonElement.is("a")){this.buttonElement.keyup(function(t){if(t.keyCode===e.ui.keyCode.SPACE){e(this).click()}})}}this._setOption("disabled",u.disabled);this._resetButton()},_determineButtonType:function(){var e,t,n;if(this.element.is("[type=checkbox]")){this.type="checkbox"}else if(this.element.is("[type=radio]")){this.type="radio"}else if(this.element.is("input")){this.type="input"}else{this.type="button"}if(this.type==="checkbox"||this.type==="radio"){e=this.element.parents().last();t="label[for='"+this.element.attr("id")+"']";this.buttonElement=e.find(t);if(!this.buttonElement.length){e=e.length?e.siblings():this.element.siblings();this.buttonElement=e.filter(t);if(!this.buttonElement.length){this.buttonElement=e.find(t)}}this.element.addClass("ui-helper-hidden-accessible");n=this.element.is(":checked");if(n){this.buttonElement.addClass("ui-state-active")}this.buttonElement.prop("aria-pressed",n)}else{this.buttonElement=this.element}},widget:function(){return this.buttonElement},_destroy:function(){this.element.removeClass("ui-helper-hidden-accessible");this.buttonElement.removeClass(o+" "+u+" "+a).removeAttr("role").removeAttr("aria-pressed").html(this.buttonElement.find(".ui-button-text").html());if(!this.hasTitle){this.buttonElement.removeAttr("title")}},_setOption:function(e,t){this._super(e,t);if(e==="disabled"){if(t){this.element.prop("disabled",true)}else{this.element.prop("disabled",false)}return}this._resetButton()},refresh:function(){var t=this.element.is("input, button")?this.element.is(":disabled"):this.element.hasClass("ui-button-disabled");if(t!==this.options.disabled){this._setOption("disabled",t)}if(this.type==="radio"){l(this.element[0]).each(function(){if(e(this).is(":checked")){e(this).button("widget").addClass("ui-state-active").attr("aria-pressed","true")}else{e(this).button("widget").removeClass("ui-state-active").attr("aria-pressed","false")}})}else if(this.type==="checkbox"){if(this.element.is(":checked")){this.buttonElement.addClass("ui-state-active").attr("aria-pressed","true")}else{this.buttonElement.removeClass("ui-state-active").attr("aria-pressed","false")}}},_resetButton:function(){if(this.type==="input"){if(this.options.label){this.element.val(this.options.label)}return}var t=this.buttonElement.removeClass(a),n=e("<span></span>",this.document[0]).addClass("ui-button-text").html(this.options.label).appendTo(t.empty()).text(),r=this.options.icons,i=r.primary&&r.secondary,s=[];if(r.primary||r.secondary){if(this.options.text){s.push("ui-button-text-icon"+(i?"s":r.primary?"-primary":"-secondary"))}if(r.primary){t.prepend("<span class='ui-button-icon-primary ui-icon "+r.primary+"'></span>")}if(r.secondary){t.append("<span class='ui-button-icon-secondary ui-icon "+r.secondary+"'></span>")}if(!this.options.text){s.push(i?"ui-button-icons-only":"ui-button-icon-only");if(!this.hasTitle){t.attr("title",e.trim(n))}}}else{s.push("ui-button-text-only")}t.addClass(s.join(" "))}});e.widget("ui.buttonset",{version:"1.10.3",options:{items:"button, input[type=button], input[type=submit], input[type=reset], input[type=checkbox], input[type=radio], a, :data(ui-button)"},_create:function(){this.element.addClass("ui-buttonset")},_init:function(){this.refresh()},_setOption:function(e,t){if(e==="disabled"){this.buttons.button("option",e,t)}this._super(e,t)},refresh:function(){var t=this.element.css("direction")==="rtl";this.buttons=this.element.find(this.options.items).filter(":ui-button").button("refresh").end().not(":ui-button").button().end().map(function(){return e(this).button("widget")[0]}).removeClass("ui-corner-all ui-corner-left ui-corner-right").filter(":first").addClass(t?"ui-corner-right":"ui-corner-left").end().filter(":last").addClass(t?"ui-corner-left":"ui-corner-right").end().end()},_destroy:function(){this.element.removeClass("ui-buttonset");this.buttons.map(function(){return e(this).button("widget")[0]}).removeClass("ui-corner-left ui-corner-right").end().button("destroy")}})})(jQuery);(function(e,t){function i(){this._curInst=null;this._keyEvent=false;this._disabledInputs=[];this._datepickerShowing=false;this._inDialog=false;this._mainDivId="ui-datepicker-div";this._inlineClass="ui-datepicker-inline";this._appendClass="ui-datepicker-append";this._triggerClass="ui-datepicker-trigger";this._dialogClass="ui-datepicker-dialog";this._disableClass="ui-datepicker-disabled";this._unselectableClass="ui-datepicker-unselectable";this._currentClass="ui-datepicker-current-day";this._dayOverClass="ui-datepicker-days-cell-over";this.regional=[];this.regional[""]={closeText:"Done",prevText:"Prev",nextText:"Next",currentText:"Today",monthNames:["January","February","March","April","May","June","July","August","September","October","November","December"],monthNamesShort:["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"],dayNames:["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"],dayNamesShort:["Sun","Mon","Tue","Wed","Thu","Fri","Sat"],dayNamesMin:["Su","Mo","Tu","We","Th","Fr","Sa"],weekHeader:"Wk",dateFormat:"mm/dd/yy",firstDay:0,isRTL:false,showMonthAfterYear:false,yearSuffix:""};this._defaults={showOn:"focus",showAnim:"fadeIn",showOptions:{},defaultDate:null,appendText:"",buttonText:"...",buttonImage:"",buttonImageOnly:false,hideIfNoPrevNext:false,navigationAsDateFormat:false,gotoCurrent:false,changeMonth:false,changeYear:false,yearRange:"c-10:c+10",showOtherMonths:false,selectOtherMonths:false,showWeek:false,calculateWeek:this.iso8601Week,shortYearCutoff:"+10",minDate:null,maxDate:null,duration:"fast",beforeShowDay:null,beforeShow:null,onSelect:null,onChangeMonthYear:null,onClose:null,numberOfMonths:1,showCurrentAtPos:0,stepMonths:1,stepBigMonths:12,altField:"",altFormat:"",constrainInput:true,showButtonPanel:false,autoSize:false,disabled:false};e.extend(this._defaults,this.regional[""]);this.dpDiv=s(e("<div id='"+this._mainDivId+"' class='ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all'></div>"))}function s(t){var n="button, .ui-datepicker-prev, .ui-datepicker-next, .ui-datepicker-calendar td a";return t.delegate(n,"mouseout",function(){e(this).removeClass("ui-state-hover");if(this.className.indexOf("ui-datepicker-prev")!==-1){e(this).removeClass("ui-datepicker-prev-hover")}if(this.className.indexOf("ui-datepicker-next")!==-1){e(this).removeClass("ui-datepicker-next-hover")}}).delegate(n,"mouseover",function(){if(!e.datepicker._isDisabledDatepicker(r.inline?t.parent()[0]:r.input[0])){e(this).parents(".ui-datepicker-calendar").find("a").removeClass("ui-state-hover");e(this).addClass("ui-state-hover");if(this.className.indexOf("ui-datepicker-prev")!==-1){e(this).addClass("ui-datepicker-prev-hover")}if(this.className.indexOf("ui-datepicker-next")!==-1){e(this).addClass("ui-datepicker-next-hover")}}})}function o(t,n){e.extend(t,n);for(var r in n){if(n[r]==null){t[r]=n[r]}}return t}e.extend(e.ui,{datepicker:{version:"1.10.3"}});var n="datepicker",r;e.extend(i.prototype,{markerClassName:"hasDatepicker",maxRows:4,_widgetDatepicker:function(){return this.dpDiv},setDefaults:function(e){o(this._defaults,e||{});return this},_attachDatepicker:function(t,n){var r,i,s;r=t.nodeName.toLowerCase();i=r==="div"||r==="span";if(!t.id){this.uuid+=1;t.id="dp"+this.uuid}s=this._newInst(e(t),i);s.settings=e.extend({},n||{});if(r==="input"){this._connectDatepicker(t,s)}else if(i){this._inlineDatepicker(t,s)}},_newInst:function(t,n){var r=t[0].id.replace(/([^A-Za-z0-9_\-])/g,"\\\\$1");return{id:r,input:t,selectedDay:0,selectedMonth:0,selectedYear:0,drawMonth:0,drawYear:0,inline:n,dpDiv:!n?this.dpDiv:s(e("<div class='"+this._inlineClass+" ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all'></div>"))}},_connectDatepicker:function(t,r){var i=e(t);r.append=e([]);r.trigger=e([]);if(i.hasClass(this.markerClassName)){return}this._attachments(i,r);i.addClass(this.markerClassName).keydown(this._doKeyDown).keypress(this._doKeyPress).keyup(this._doKeyUp);this._autoSize(r);e.data(t,n,r);if(r.settings.disabled){this._disableDatepicker(t)}},_attachments:function(t,n){var r,i,s,o=this._get(n,"appendText"),u=this._get(n,"isRTL");if(n.append){n.append.remove()}if(o){n.append=e("<span class='"+this._appendClass+"'>"+o+"</span>");t[u?"before":"after"](n.append)}t.unbind("focus",this._showDatepicker);if(n.trigger){n.trigger.remove()}r=this._get(n,"showOn");if(r==="focus"||r==="both"){t.focus(this._showDatepicker)}if(r==="button"||r==="both"){i=this._get(n,"buttonText");s=this._get(n,"buttonImage");n.trigger=e(this._get(n,"buttonImageOnly")?e("<img/>").addClass(this._triggerClass).attr({src:s,alt:i,title:i}):e("<button type='button'></button>").addClass(this._triggerClass).html(!s?i:e("<img/>").attr({src:s,alt:i,title:i})));t[u?"before":"after"](n.trigger);n.trigger.click(function(){if(e.datepicker._datepickerShowing&&e.datepicker._lastInput===t[0]){e.datepicker._hideDatepicker()}else if(e.datepicker._datepickerShowing&&e.datepicker._lastInput!==t[0]){e.datepicker._hideDatepicker();e.datepicker._showDatepicker(t[0])}else{e.datepicker._showDatepicker(t[0])}return false})}},_autoSize:function(e){if(this._get(e,"autoSize")&&!e.inline){var t,n,r,i,s=new Date(2009,12-1,20),o=this._get(e,"dateFormat");if(o.match(/[DM]/)){t=function(e){n=0;r=0;for(i=0;i<e.length;i++){if(e[i].length>n){n=e[i].length;r=i}}return r};s.setMonth(t(this._get(e,o.match(/MM/)?"monthNames":"monthNamesShort")));s.setDate(t(this._get(e,o.match(/DD/)?"dayNames":"dayNamesShort"))+20-s.getDay())}e.input.attr("size",this._formatDate(e,s).length)}},_inlineDatepicker:function(t,r){var i=e(t);if(i.hasClass(this.markerClassName)){return}i.addClass(this.markerClassName).append(r.dpDiv);e.data(t,n,r);this._setDate(r,this._getDefaultDate(r),true);this._updateDatepicker(r);this._updateAlternate(r);if(r.settings.disabled){this._disableDatepicker(t)}r.dpDiv.css("display","block")},_dialogDatepicker:function(t,r,i,s,u){var a,f,l,c,h,p=this._dialogInst;if(!p){this.uuid+=1;a="dp"+this.uuid;this._dialogInput=e("<input type='text' id='"+a+"' style='position: absolute; top: -100px; width: 0px;'/>");this._dialogInput.keydown(this._doKeyDown);e("body").append(this._dialogInput);p=this._dialogInst=this._newInst(this._dialogInput,false);p.settings={};e.data(this._dialogInput[0],n,p)}o(p.settings,s||{});r=r&&r.constructor===Date?this._formatDate(p,r):r;this._dialogInput.val(r);this._pos=u?u.length?u:[u.pageX,u.pageY]:null;if(!this._pos){f=document.documentElement.clientWidth;l=document.documentElement.clientHeight;c=document.documentElement.scrollLeft||document.body.scrollLeft;h=document.documentElement.scrollTop||document.body.scrollTop;this._pos=[f/2-100+c,l/2-150+h]}this._dialogInput.css("left",this._pos[0]+20+"px").css("top",this._pos[1]+"px");p.settings.onSelect=i;this._inDialog=true;this.dpDiv.addClass(this._dialogClass);this._showDatepicker(this._dialogInput[0]);if(e.blockUI){e.blockUI(this.dpDiv)}e.data(this._dialogInput[0],n,p);return this},_destroyDatepicker:function(t){var r,i=e(t),s=e.data(t,n);if(!i.hasClass(this.markerClassName)){return}r=t.nodeName.toLowerCase();e.removeData(t,n);if(r==="input"){s.append.remove();s.trigger.remove();i.removeClass(this.markerClassName).unbind("focus",this._showDatepicker).unbind("keydown",this._doKeyDown).unbind("keypress",this._doKeyPress).unbind("keyup",this._doKeyUp)}else if(r==="div"||r==="span"){i.removeClass(this.markerClassName).empty()}},_enableDatepicker:function(t){var r,i,s=e(t),o=e.data(t,n);if(!s.hasClass(this.markerClassName)){return}r=t.nodeName.toLowerCase();if(r==="input"){t.disabled=false;o.trigger.filter("button").each(function(){this.disabled=false}).end().filter("img").css({opacity:"1.0",cursor:""})}else if(r==="div"||r==="span"){i=s.children("."+this._inlineClass);i.children().removeClass("ui-state-disabled");i.find("select.ui-datepicker-month, select.ui-datepicker-year").prop("disabled",false)}this._disabledInputs=e.map(this._disabledInputs,function(e){return e===t?null:e})},_disableDatepicker:function(t){var r,i,s=e(t),o=e.data(t,n);if(!s.hasClass(this.markerClassName)){return}r=t.nodeName.toLowerCase();if(r==="input"){t.disabled=true;o.trigger.filter("button").each(function(){this.disabled=true}).end().filter("img").css({opacity:"0.5",cursor:"default"})}else if(r==="div"||r==="span"){i=s.children("."+this._inlineClass);i.children().addClass("ui-state-disabled");i.find("select.ui-datepicker-month, select.ui-datepicker-year").prop("disabled",true)}this._disabledInputs=e.map(this._disabledInputs,function(e){return e===t?null:e});this._disabledInputs[this._disabledInputs.length]=t},_isDisabledDatepicker:function(e){if(!e){return false}for(var t=0;t<this._disabledInputs.length;t++){if(this._disabledInputs[t]===e){return true}}return false},_getInst:function(t){try{return e.data(t,n)}catch(r){throw"Missing instance data for this datepicker"}},_optionDatepicker:function(n,r,i){var s,u,a,f,l=this._getInst(n);if(arguments.length===2&&typeof r==="string"){return r==="defaults"?e.extend({},e.datepicker._defaults):l?r==="all"?e.extend({},l.settings):this._get(l,r):null}s=r||{};if(typeof r==="string"){s={};s[r]=i}if(l){if(this._curInst===l){this._hideDatepicker()}u=this._getDateDatepicker(n,true);a=this._getMinMaxDate(l,"min");f=this._getMinMaxDate(l,"max");o(l.settings,s);if(a!==null&&s.dateFormat!==t&&s.minDate===t){l.settings.minDate=this._formatDate(l,a)}if(f!==null&&s.dateFormat!==t&&s.maxDate===t){l.settings.maxDate=this._formatDate(l,f)}if("disabled"in s){if(s.disabled){this._disableDatepicker(n)}else{this._enableDatepicker(n)}}this._attachments(e(n),l);this._autoSize(l);this._setDate(l,u);this._updateAlternate(l);this._updateDatepicker(l)}},_changeDatepicker:function(e,t,n){this._optionDatepicker(e,t,n)},_refreshDatepicker:function(e){var t=this._getInst(e);if(t){this._updateDatepicker(t)}},_setDateDatepicker:function(e,t){var n=this._getInst(e);if(n){this._setDate(n,t);this._updateDatepicker(n);this._updateAlternate(n)}},_getDateDatepicker:function(e,t){var n=this._getInst(e);if(n&&!n.inline){this._setDateFromField(n,t)}return n?this._getDate(n):null},_doKeyDown:function(t){var n,r,i,s=e.datepicker._getInst(t.target),o=true,u=s.dpDiv.is(".ui-datepicker-rtl");s._keyEvent=true;if(e.datepicker._datepickerShowing){switch(t.keyCode){case 9:e.datepicker._hideDatepicker();o=false;break;case 13:i=e("td."+e.datepicker._dayOverClass+":not(."+e.datepicker._currentClass+")",s.dpDiv);if(i[0]){e.datepicker._selectDay(t.target,s.selectedMonth,s.selectedYear,i[0])}n=e.datepicker._get(s,"onSelect");if(n){r=e.datepicker._formatDate(s);n.apply(s.input?s.input[0]:null,[r,s])}else{e.datepicker._hideDatepicker()}return false;case 27:e.datepicker._hideDatepicker();break;case 33:e.datepicker._adjustDate(t.target,t.ctrlKey?-e.datepicker._get(s,"stepBigMonths"):-e.datepicker._get(s,"stepMonths"),"M");break;case 34:e.datepicker._adjustDate(t.target,t.ctrlKey?+e.datepicker._get(s,"stepBigMonths"):+e.datepicker._get(s,"stepMonths"),"M");break;case 35:if(t.ctrlKey||t.metaKey){e.datepicker._clearDate(t.target)}o=t.ctrlKey||t.metaKey;break;case 36:if(t.ctrlKey||t.metaKey){e.datepicker._gotoToday(t.target)}o=t.ctrlKey||t.metaKey;break;case 37:if(t.ctrlKey||t.metaKey){e.datepicker._adjustDate(t.target,u?+1:-1,"D")}o=t.ctrlKey||t.metaKey;if(t.originalEvent.altKey){e.datepicker._adjustDate(t.target,t.ctrlKey?-e.datepicker._get(s,"stepBigMonths"):-e.datepicker._get(s,"stepMonths"),"M")}break;case 38:if(t.ctrlKey||t.metaKey){e.datepicker._adjustDate(t.target,-7,"D")}o=t.ctrlKey||t.metaKey;break;case 39:if(t.ctrlKey||t.metaKey){e.datepicker._adjustDate(t.target,u?-1:+1,"D")}o=t.ctrlKey||t.metaKey;if(t.originalEvent.altKey){e.datepicker._adjustDate(t.target,t.ctrlKey?+e.datepicker._get(s,"stepBigMonths"):+e.datepicker._get(s,"stepMonths"),"M")}break;case 40:if(t.ctrlKey||t.metaKey){e.datepicker._adjustDate(t.target,+7,"D")}o=t.ctrlKey||t.metaKey;break;default:o=false}}else if(t.keyCode===36&&t.ctrlKey){e.datepicker._showDatepicker(this)}else{o=false}if(o){t.preventDefault();t.stopPropagation()}},_doKeyPress:function(t){var n,r,i=e.datepicker._getInst(t.target);if(e.datepicker._get(i,"constrainInput")){n=e.datepicker._possibleChars(e.datepicker._get(i,"dateFormat"));r=String.fromCharCode(t.charCode==null?t.keyCode:t.charCode);return t.ctrlKey||t.metaKey||r<" "||!n||n.indexOf(r)>-1}},_doKeyUp:function(t){var n,r=e.datepicker._getInst(t.target);if(r.input.val()!==r.lastVal){try{n=e.datepicker.parseDate(e.datepicker._get(r,"dateFormat"),r.input?r.input.val():null,e.datepicker._getFormatConfig(r));if(n){e.datepicker._setDateFromField(r);e.datepicker._updateAlternate(r);e.datepicker._updateDatepicker(r)}}catch(i){}}return true},_showDatepicker:function(t){t=t.target||t;if(t.nodeName.toLowerCase()!=="input"){t=e("input",t.parentNode)[0]}if(e.datepicker._isDisabledDatepicker(t)||e.datepicker._lastInput===t){return}var n,r,i,s,u,a,f;n=e.datepicker._getInst(t);if(e.datepicker._curInst&&e.datepicker._curInst!==n){e.datepicker._curInst.dpDiv.stop(true,true);if(n&&e.datepicker._datepickerShowing){e.datepicker._hideDatepicker(e.datepicker._curInst.input[0])}}r=e.datepicker._get(n,"beforeShow");i=r?r.apply(t,[t,n]):{};if(i===false){return}o(n.settings,i);n.lastVal=null;e.datepicker._lastInput=t;e.datepicker._setDateFromField(n);if(e.datepicker._inDialog){t.value=""}if(!e.datepicker._pos){e.datepicker._pos=e.datepicker._findPos(t);e.datepicker._pos[1]+=t.offsetHeight}s=false;e(t).parents().each(function(){s|=e(this).css("position")==="fixed";return!s});u={left:e.datepicker._pos[0],top:e.datepicker._pos[1]};e.datepicker._pos=null;n.dpDiv.empty();n.dpDiv.css({position:"absolute",display:"block",top:"-1000px"});e.datepicker._updateDatepicker(n);u=e.datepicker._checkOffset(n,u,s);n.dpDiv.css({position:e.datepicker._inDialog&&e.blockUI?"static":s?"fixed":"absolute",display:"none",left:u.left+"px",top:u.top+"px"});if(!n.inline){a=e.datepicker._get(n,"showAnim");f=e.datepicker._get(n,"duration");n.dpDiv.zIndex(e(t).zIndex()+1);e.datepicker._datepickerShowing=true;if(e.effects&&e.effects.effect[a]){n.dpDiv.show(a,e.datepicker._get(n,"showOptions"),f)}else{n.dpDiv[a||"show"](a?f:null)}if(e.datepicker._shouldFocusInput(n)){n.input.focus()}e.datepicker._curInst=n}},_updateDatepicker:function(t){this.maxRows=4;r=t;t.dpDiv.empty().append(this._generateHTML(t));this._attachHandlers(t);t.dpDiv.find("."+this._dayOverClass+" a").mouseover();var n,i=this._getNumberOfMonths(t),s=i[1],o=17;t.dpDiv.removeClass("ui-datepicker-multi-2 ui-datepicker-multi-3 ui-datepicker-multi-4").width("");if(s>1){t.dpDiv.addClass("ui-datepicker-multi-"+s).css("width",o*s+"em")}t.dpDiv[(i[0]!==1||i[1]!==1?"add":"remove")+"Class"]("ui-datepicker-multi");t.dpDiv[(this._get(t,"isRTL")?"add":"remove")+"Class"]("ui-datepicker-rtl");if(t===e.datepicker._curInst&&e.datepicker._datepickerShowing&&e.datepicker._shouldFocusInput(t)){t.input.focus()}if(t.yearshtml){n=t.yearshtml;setTimeout(function(){if(n===t.yearshtml&&t.yearshtml){t.dpDiv.find("select.ui-datepicker-year:first").replaceWith(t.yearshtml)}n=t.yearshtml=null},0)}},_shouldFocusInput:function(e){return e.input&&e.input.is(":visible")&&!e.input.is(":disabled")&&!e.input.is(":focus")},_checkOffset:function(t,n,r){var i=t.dpDiv.outerWidth(),s=t.dpDiv.outerHeight(),o=t.input?t.input.outerWidth():0,u=t.input?t.input.outerHeight():0,a=document.documentElement.clientWidth+(r?0:e(document).scrollLeft()),f=document.documentElement.clientHeight+(r?0:e(document).scrollTop());n.left-=this._get(t,"isRTL")?i-o:0;n.left-=r&&n.left===t.input.offset().left?e(document).scrollLeft():0;n.top-=r&&n.top===t.input.offset().top+u?e(document).scrollTop():0;n.left-=Math.min(n.left,n.left+i>a&&a>i?Math.abs(n.left+i-a):0);n.top-=Math.min(n.top,n.top+s>f&&f>s?Math.abs(s+u):0);return n},_findPos:function(t){var n,r=this._getInst(t),i=this._get(r,"isRTL");while(t&&(t.type==="hidden"||t.nodeType!==1||e.expr.filters.hidden(t))){t=t[i?"previousSibling":"nextSibling"]}n=e(t).offset();return[n.left,n.top]},_hideDatepicker:function(t){var r,i,s,o,u=this._curInst;if(!u||t&&u!==e.data(t,n)){return}if(this._datepickerShowing){r=this._get(u,"showAnim");i=this._get(u,"duration");s=function(){e.datepicker._tidyDialog(u)};if(e.effects&&(e.effects.effect[r]||e.effects[r])){u.dpDiv.hide(r,e.datepicker._get(u,"showOptions"),i,s)}else{u.dpDiv[r==="slideDown"?"slideUp":r==="fadeIn"?"fadeOut":"hide"](r?i:null,s)}if(!r){s()}this._datepickerShowing=false;o=this._get(u,"onClose");if(o){o.apply(u.input?u.input[0]:null,[u.input?u.input.val():"",u])}this._lastInput=null;if(this._inDialog){this._dialogInput.css({position:"absolute",left:"0",top:"-100px"});if(e.blockUI){e.unblockUI();e("body").append(this.dpDiv)}}this._inDialog=false}},_tidyDialog:function(e){e.dpDiv.removeClass(this._dialogClass).unbind(".ui-datepicker-calendar")},_checkExternalClick:function(t){if(!e.datepicker._curInst){return}var n=e(t.target),r=e.datepicker._getInst(n[0]);if(n[0].id!==e.datepicker._mainDivId&&n.parents("#"+e.datepicker._mainDivId).length===0&&!n.hasClass(e.datepicker.markerClassName)&&!n.closest("."+e.datepicker._triggerClass).length&&e.datepicker._datepickerShowing&&!(e.datepicker._inDialog&&e.blockUI)||n.hasClass(e.datepicker.markerClassName)&&e.datepicker._curInst!==r){e.datepicker._hideDatepicker()}},_adjustDate:function(t,n,r){var i=e(t),s=this._getInst(i[0]);if(this._isDisabledDatepicker(i[0])){return}this._adjustInstDate(s,n+(r==="M"?this._get(s,"showCurrentAtPos"):0),r);this._updateDatepicker(s)},_gotoToday:function(t){var n,r=e(t),i=this._getInst(r[0]);if(this._get(i,"gotoCurrent")&&i.currentDay){i.selectedDay=i.currentDay;i.drawMonth=i.selectedMonth=i.currentMonth;i.drawYear=i.selectedYear=i.currentYear}else{n=new Date;i.selectedDay=n.getDate();i.drawMonth=i.selectedMonth=n.getMonth();i.drawYear=i.selectedYear=n.getFullYear()}this._notifyChange(i);this._adjustDate(r)},_selectMonthYear:function(t,n,r){var i=e(t),s=this._getInst(i[0]);s["selected"+(r==="M"?"Month":"Year")]=s["draw"+(r==="M"?"Month":"Year")]=parseInt(n.options[n.selectedIndex].value,10);this._notifyChange(s);this._adjustDate(i)},_selectDay:function(t,n,r,i){var s,o=e(t);if(e(i).hasClass(this._unselectableClass)||this._isDisabledDatepicker(o[0])){return}s=this._getInst(o[0]);s.selectedDay=s.currentDay=e("a",i).html();s.selectedMonth=s.currentMonth=n;s.selectedYear=s.currentYear=r;this._selectDate(t,this._formatDate(s,s.currentDay,s.currentMonth,s.currentYear))},_clearDate:function(t){var n=e(t);this._selectDate(n,"")},_selectDate:function(t,n){var r,i=e(t),s=this._getInst(i[0]);n=n!=null?n:this._formatDate(s);if(s.input){s.input.val(n)}this._updateAlternate(s);r=this._get(s,"onSelect");if(r){r.apply(s.input?s.input[0]:null,[n,s])}else if(s.input){s.input.trigger("change")}if(s.inline){this._updateDatepicker(s)}else{this._hideDatepicker();this._lastInput=s.input[0];if(typeof s.input[0]!=="object"){s.input.focus()}this._lastInput=null}},_updateAlternate:function(t){var n,r,i,s=this._get(t,"altField");if(s){n=this._get(t,"altFormat")||this._get(t,"dateFormat");r=this._getDate(t);i=this.formatDate(n,r,this._getFormatConfig(t));e(s).each(function(){e(this).val(i)})}},noWeekends:function(e){var t=e.getDay();return[t>0&&t<6,""]},iso8601Week:function(e){var t,n=new Date(e.getTime());n.setDate(n.getDate()+4-(n.getDay()||7));t=n.getTime();n.setMonth(0);n.setDate(1);return Math.floor(Math.round((t-n)/864e5)/7)+1},parseDate:function(t,n,r){if(t==null||n==null){throw"Invalid arguments"}n=typeof n==="object"?n.toString():n+"";if(n===""){return null}var i,s,o,u=0,a=(r?r.shortYearCutoff:null)||this._defaults.shortYearCutoff,f=typeof a!=="string"?a:(new Date).getFullYear()%100+parseInt(a,10),l=(r?r.dayNamesShort:null)||this._defaults.dayNamesShort,c=(r?r.dayNames:null)||this._defaults.dayNames,h=(r?r.monthNamesShort:null)||this._defaults.monthNamesShort,p=(r?r.monthNames:null)||this._defaults.monthNames,d=-1,v=-1,m=-1,g=-1,y=false,b,w=function(e){var n=i+1<t.length&&t.charAt(i+1)===e;if(n){i++}return n},E=function(e){var t=w(e),r=e==="@"?14:e==="!"?20:e==="y"&&t?4:e==="o"?3:2,i=new RegExp("^\\d{1,"+r+"}"),s=n.substring(u).match(i);if(!s){throw"Missing number at position "+u}u+=s[0].length;return parseInt(s[0],10)},S=function(t,r,i){var s=-1,o=e.map(w(t)?i:r,function(e,t){return[[t,e]]}).sort(function(e,t){return-(e[1].length-t[1].length)});e.each(o,function(e,t){var r=t[1];if(n.substr(u,r.length).toLowerCase()===r.toLowerCase()){s=t[0];u+=r.length;return false}});if(s!==-1){return s+1}else{throw"Unknown name at position "+u}},x=function(){if(n.charAt(u)!==t.charAt(i)){throw"Unexpected literal at position "+u}u++};for(i=0;i<t.length;i++){if(y){if(t.charAt(i)==="'"&&!w("'")){y=false}else{x()}}else{switch(t.charAt(i)){case"d":m=E("d");break;case"D":S("D",l,c);break;case"o":g=E("o");break;case"m":v=E("m");break;case"M":v=S("M",h,p);break;case"y":d=E("y");break;case"@":b=new Date(E("@"));d=b.getFullYear();v=b.getMonth()+1;m=b.getDate();break;case"!":b=new Date((E("!")-this._ticksTo1970)/1e4);d=b.getFullYear();v=b.getMonth()+1;m=b.getDate();break;case"'":if(w("'")){x()}else{y=true}break;default:x()}}}if(u<n.length){o=n.substr(u);if(!/^\s+/.test(o)){throw"Extra/unparsed characters found in date: "+o}}if(d===-1){d=(new Date).getFullYear()}else if(d<100){d+=(new Date).getFullYear()-(new Date).getFullYear()%100+(d<=f?0:-100)}if(g>-1){v=1;m=g;do{s=this._getDaysInMonth(d,v-1);if(m<=s){break}v++;m-=s}while(true)}b=this._daylightSavingAdjust(new Date(d,v-1,m));if(b.getFullYear()!==d||b.getMonth()+1!==v||b.getDate()!==m){throw"Invalid date"}return b},ATOM:"yy-mm-dd",COOKIE:"D, dd M yy",ISO_8601:"yy-mm-dd",RFC_822:"D, d M y",RFC_850:"DD, dd-M-y",RFC_1036:"D, d M y",RFC_1123:"D, d M yy",RFC_2822:"D, d M yy",RSS:"D, d M y",TICKS:"!",TIMESTAMP:"@",W3C:"yy-mm-dd",_ticksTo1970:((1970-1)*365+Math.floor(1970/4)-Math.floor(1970/100)+Math.floor(1970/400))*24*60*60*1e7,formatDate:function(e,t,n){if(!t){return""}var r,i=(n?n.dayNamesShort:null)||this._defaults.dayNamesShort,s=(n?n.dayNames:null)||this._defaults.dayNames,o=(n?n.monthNamesShort:null)||this._defaults.monthNamesShort,u=(n?n.monthNames:null)||this._defaults.monthNames,a=function(t){var n=r+1<e.length&&e.charAt(r+1)===t;if(n){r++}return n},f=function(e,t,n){var r=""+t;if(a(e)){while(r.length<n){r="0"+r}}return r},l=function(e,t,n,r){return a(e)?r[t]:n[t]},c="",h=false;if(t){for(r=0;r<e.length;r++){if(h){if(e.charAt(r)==="'"&&!a("'")){h=false}else{c+=e.charAt(r)}}else{switch(e.charAt(r)){case"d":c+=f("d",t.getDate(),2);break;case"D":c+=l("D",t.getDay(),i,s);break;case"o":c+=f("o",Math.round(((new Date(t.getFullYear(),t.getMonth(),t.getDate())).getTime()-(new Date(t.getFullYear(),0,0)).getTime())/864e5),3);break;case"m":c+=f("m",t.getMonth()+1,2);break;case"M":c+=l("M",t.getMonth(),o,u);break;case"y":c+=a("y")?t.getFullYear():(t.getYear()%100<10?"0":"")+t.getYear()%100;break;case"@":c+=t.getTime();break;case"!":c+=t.getTime()*1e4+this._ticksTo1970;break;case"'":if(a("'")){c+="'"}else{h=true}break;default:c+=e.charAt(r)}}}}return c},_possibleChars:function(e){var t,n="",r=false,i=function(n){var r=t+1<e.length&&e.charAt(t+1)===n;if(r){t++}return r};for(t=0;t<e.length;t++){if(r){if(e.charAt(t)==="'"&&!i("'")){r=false}else{n+=e.charAt(t)}}else{switch(e.charAt(t)){case"d":case"m":case"y":case"@":n+="0123456789";break;case"D":case"M":return null;case"'":if(i("'")){n+="'"}else{r=true}break;default:n+=e.charAt(t)}}}return n},_get:function(e,n){return e.settings[n]!==t?e.settings[n]:this._defaults[n]},_setDateFromField:function(e,t){if(e.input.val()===e.lastVal){return}var n=this._get(e,"dateFormat"),r=e.lastVal=e.input?e.input.val():null,i=this._getDefaultDate(e),s=i,o=this._getFormatConfig(e);try{s=this.parseDate(n,r,o)||i}catch(u){r=t?"":r}e.selectedDay=s.getDate();e.drawMonth=e.selectedMonth=s.getMonth();e.drawYear=e.selectedYear=s.getFullYear();e.currentDay=r?s.getDate():0;e.currentMonth=r?s.getMonth():0;e.currentYear=r?s.getFullYear():0;this._adjustInstDate(e)},_getDefaultDate:function(e){return this._restrictMinMax(e,this._determineDate(e,this._get(e,"defaultDate"),new Date))},_determineDate:function(t,n,r){var i=function(e){var t=new Date;t.setDate(t.getDate()+e);return t},s=function(n){try{return e.datepicker.parseDate(e.datepicker._get(t,"dateFormat"),n,e.datepicker._getFormatConfig(t))}catch(r){}var i=(n.toLowerCase().match(/^c/)?e.datepicker._getDate(t):null)||new Date,s=i.getFullYear(),o=i.getMonth(),u=i.getDate(),a=/([+\-]?[0-9]+)\s*(d|D|w|W|m|M|y|Y)?/g,f=a.exec(n);while(f){switch(f[2]||"d"){case"d":case"D":u+=parseInt(f[1],10);break;case"w":case"W":u+=parseInt(f[1],10)*7;break;case"m":case"M":o+=parseInt(f[1],10);u=Math.min(u,e.datepicker._getDaysInMonth(s,o));break;case"y":case"Y":s+=parseInt(f[1],10);u=Math.min(u,e.datepicker._getDaysInMonth(s,o));break}f=a.exec(n)}return new Date(s,o,u)},o=n==null||n===""?r:typeof n==="string"?s(n):typeof n==="number"?isNaN(n)?r:i(n):new Date(n.getTime());o=o&&o.toString()==="Invalid Date"?r:o;if(o){o.setHours(0);o.setMinutes(0);o.setSeconds(0);o.setMilliseconds(0)}return this._daylightSavingAdjust(o)},_daylightSavingAdjust:function(e){if(!e){return null}e.setHours(e.getHours()>12?e.getHours()+2:0);return e},_setDate:function(e,t,n){var r=!t,i=e.selectedMonth,s=e.selectedYear,o=this._restrictMinMax(e,this._determineDate(e,t,new Date));e.selectedDay=e.currentDay=o.getDate();e.drawMonth=e.selectedMonth=e.currentMonth=o.getMonth();e.drawYear=e.selectedYear=e.currentYear=o.getFullYear();if((i!==e.selectedMonth||s!==e.selectedYear)&&!n){this._notifyChange(e)}this._adjustInstDate(e);if(e.input){e.input.val(r?"":this._formatDate(e))}},_getDate:function(e){var t=!e.currentYear||e.input&&e.input.val()===""?null:this._daylightSavingAdjust(new Date(e.currentYear,e.currentMonth,e.currentDay));return t},_attachHandlers:function(t){var n=this._get(t,"stepMonths"),r="#"+t.id.replace(/\\\\/g,"\\");t.dpDiv.find("[data-handler]").map(function(){var t={prev:function(){e.datepicker._adjustDate(r,-n,"M")},next:function(){e.datepicker._adjustDate(r,+n,"M")},hide:function(){e.datepicker._hideDatepicker()},today:function(){e.datepicker._gotoToday(r)},selectDay:function(){e.datepicker._selectDay(r,+this.getAttribute("data-month"),+this.getAttribute("data-year"),this);return false},selectMonth:function(){e.datepicker._selectMonthYear(r,this,"M");return false},selectYear:function(){e.datepicker._selectMonthYear(r,this,"Y");return false}};e(this).bind(this.getAttribute("data-event"),t[this.getAttribute("data-handler")])})},_generateHTML:function(e){var t,n,r,i,s,o,u,a,f,l,c,h,p,d,v,m,g,y,b,w,E,S,x,T,N,C,k,L,A,O,M,_,D,P,H,B,j,F,I,q=new Date,R=this._daylightSavingAdjust(new Date(q.getFullYear(),q.getMonth(),q.getDate())),U=this._get(e,"isRTL"),z=this._get(e,"showButtonPanel"),W=this._get(e,"hideIfNoPrevNext"),X=this._get(e,"navigationAsDateFormat"),V=this._getNumberOfMonths(e),$=this._get(e,"showCurrentAtPos"),J=this._get(e,"stepMonths"),K=V[0]!==1||V[1]!==1,Q=this._daylightSavingAdjust(!e.currentDay?new Date(9999,9,9):new Date(e.currentYear,e.currentMonth,e.currentDay)),G=this._getMinMaxDate(e,"min"),Y=this._getMinMaxDate(e,"max"),Z=e.drawMonth-$,et=e.drawYear;if(Z<0){Z+=12;et--}if(Y){t=this._daylightSavingAdjust(new Date(Y.getFullYear(),Y.getMonth()-V[0]*V[1]+1,Y.getDate()));t=G&&t<G?G:t;while(this._daylightSavingAdjust(new Date(et,Z,1))>t){Z--;if(Z<0){Z=11;et--}}}e.drawMonth=Z;e.drawYear=et;n=this._get(e,"prevText");n=!X?n:this.formatDate(n,this._daylightSavingAdjust(new Date(et,Z-J,1)),this._getFormatConfig(e));r=this._canAdjustMonth(e,-1,et,Z)?"<a class='ui-datepicker-prev ui-corner-all' data-handler='prev' data-event='click'"+" title='"+n+"'><span class='ui-icon ui-icon-circle-triangle-"+(U?"e":"w")+"'>"+n+"</span></a>":W?"":"<a class='ui-datepicker-prev ui-corner-all ui-state-disabled' title='"+n+"'><span class='ui-icon ui-icon-circle-triangle-"+(U?"e":"w")+"'>"+n+"</span></a>";i=this._get(e,"nextText");i=!X?i:this.formatDate(i,this._daylightSavingAdjust(new Date(et,Z+J,1)),this._getFormatConfig(e));s=this._canAdjustMonth(e,+1,et,Z)?"<a class='ui-datepicker-next ui-corner-all' data-handler='next' data-event='click'"+" title='"+i+"'><span class='ui-icon ui-icon-circle-triangle-"+(U?"w":"e")+"'>"+i+"</span></a>":W?"":"<a class='ui-datepicker-next ui-corner-all ui-state-disabled' title='"+i+"'><span class='ui-icon ui-icon-circle-triangle-"+(U?"w":"e")+"'>"+i+"</span></a>";o=this._get(e,"currentText");u=this._get(e,"gotoCurrent")&&e.currentDay?Q:R;o=!X?o:this.formatDate(o,u,this._getFormatConfig(e));a=!e.inline?"<button type='button' class='ui-datepicker-close ui-state-default ui-priority-primary ui-corner-all' data-handler='hide' data-event='click'>"+this._get(e,"closeText")+"</button>":"";f=z?"<div class='ui-datepicker-buttonpane ui-widget-content'>"+(U?a:"")+(this._isInRange(e,u)?"<button type='button' class='ui-datepicker-current ui-state-default ui-priority-secondary ui-corner-all' data-handler='today' data-event='click'"+">"+o+"</button>":"")+(U?"":a)+"</div>":"";l=parseInt(this._get(e,"firstDay"),10);l=isNaN(l)?0:l;c=this._get(e,"showWeek");h=this._get(e,"dayNames");p=this._get(e,"dayNamesMin");d=this._get(e,"monthNames");v=this._get(e,"monthNamesShort");m=this._get(e,"beforeShowDay");g=this._get(e,"showOtherMonths");y=this._get(e,"selectOtherMonths");b=this._getDefaultDate(e);w="";E;for(S=0;S<V[0];S++){x="";this.maxRows=4;for(T=0;T<V[1];T++){N=this._daylightSavingAdjust(new Date(et,Z,e.selectedDay));C=" ui-corner-all";k="";if(K){k+="<div class='ui-datepicker-group";if(V[1]>1){switch(T){case 0:k+=" ui-datepicker-group-first";C=" ui-corner-"+(U?"right":"left");break;case V[1]-1:k+=" ui-datepicker-group-last";C=" ui-corner-"+(U?"left":"right");break;default:k+=" ui-datepicker-group-middle";C="";break}}k+="'>"}k+="<div class='ui-datepicker-header ui-widget-header ui-helper-clearfix"+C+"'>"+(/all|left/.test(C)&&S===0?U?s:r:"")+(/all|right/.test(C)&&S===0?U?r:s:"")+this._generateMonthYearHeader(e,Z,et,G,Y,S>0||T>0,d,v)+"</div><table class='ui-datepicker-calendar'><thead>"+"<tr>";L=c?"<th class='ui-datepicker-week-col'>"+this._get(e,"weekHeader")+"</th>":"";for(E=0;E<7;E++){A=(E+l)%7;L+="<th"+((E+l+6)%7>=5?" class='ui-datepicker-week-end'":"")+">"+"<span title='"+h[A]+"'>"+p[A]+"</span></th>"}k+=L+"</tr></thead><tbody>";O=this._getDaysInMonth(et,Z);if(et===e.selectedYear&&Z===e.selectedMonth){e.selectedDay=Math.min(e.selectedDay,O)}M=(this._getFirstDayOfMonth(et,Z)-l+7)%7;_=Math.ceil((M+O)/7);D=K?this.maxRows>_?this.maxRows:_:_;this.maxRows=D;P=this._daylightSavingAdjust(new Date(et,Z,1-M));for(H=0;H<D;H++){k+="<tr>";B=!c?"":"<td class='ui-datepicker-week-col'>"+this._get(e,"calculateWeek")(P)+"</td>";for(E=0;E<7;E++){j=m?m.apply(e.input?e.input[0]:null,[P]):[true,""];F=P.getMonth()!==Z;I=F&&!y||!j[0]||G&&P<G||Y&&P>Y;B+="<td class='"+((E+l+6)%7>=5?" ui-datepicker-week-end":"")+(F?" ui-datepicker-other-month":"")+(P.getTime()===N.getTime()&&Z===e.selectedMonth&&e._keyEvent||b.getTime()===P.getTime()&&b.getTime()===N.getTime()?" "+this._dayOverClass:"")+(I?" "+this._unselectableClass+" ui-state-disabled":"")+(F&&!g?"":" "+j[1]+(P.getTime()===Q.getTime()?" "+this._currentClass:"")+(P.getTime()===R.getTime()?" ui-datepicker-today":""))+"'"+((!F||g)&&j[2]?" title='"+j[2].replace(/'/g,"&#39;")+"'":"")+(I?"":" data-handler='selectDay' data-event='click' data-month='"+P.getMonth()+"' data-year='"+P.getFullYear()+"'")+">"+(F&&!g?"&#xa0;":I?"<span class='ui-state-default'>"+P.getDate()+"</span>":"<a class='ui-state-default"+(P.getTime()===R.getTime()?" ui-state-highlight":"")+(P.getTime()===Q.getTime()?" ui-state-active":"")+(F?" ui-priority-secondary":"")+"' href='#'>"+P.getDate()+"</a>")+"</td>";P.setDate(P.getDate()+1);P=this._daylightSavingAdjust(P)}k+=B+"</tr>"}Z++;if(Z>11){Z=0;et++}k+="</tbody></table>"+(K?"</div>"+(V[0]>0&&T===V[1]-1?"<div class='ui-datepicker-row-break'></div>":""):"");x+=k}w+=x}w+=f;e._keyEvent=false;return w},_generateMonthYearHeader:function(e,t,n,r,i,s,o,u){var a,f,l,c,h,p,d,v,m=this._get(e,"changeMonth"),g=this._get(e,"changeYear"),y=this._get(e,"showMonthAfterYear"),b="<div class='ui-datepicker-title'>",w="";if(s||!m){w+="<span class='ui-datepicker-month'>"+o[t]+"</span>"}else{a=r&&r.getFullYear()===n;f=i&&i.getFullYear()===n;w+="<select class='ui-datepicker-month' data-handler='selectMonth' data-event='change'>";for(l=0;l<12;l++){if((!a||l>=r.getMonth())&&(!f||l<=i.getMonth())){w+="<option value='"+l+"'"+(l===t?" selected='selected'":"")+">"+u[l]+"</option>"}}w+="</select>"}if(!y){b+=w+(s||!(m&&g)?"&#xa0;":"")}if(!e.yearshtml){e.yearshtml="";if(s||!g){b+="<span class='ui-datepicker-year'>"+n+"</span>"}else{c=this._get(e,"yearRange").split(":");h=(new Date).getFullYear();p=function(e){var t=e.match(/c[+\-].*/)?n+parseInt(e.substring(1),10):e.match(/[+\-].*/)?h+parseInt(e,10):parseInt(e,10);return isNaN(t)?h:t};d=p(c[0]);v=Math.max(d,p(c[1]||""));d=r?Math.max(d,r.getFullYear()):d;v=i?Math.min(v,i.getFullYear()):v;e.yearshtml+="<select class='ui-datepicker-year' data-handler='selectYear' data-event='change'>";for(;d<=v;d++){e.yearshtml+="<option value='"+d+"'"+(d===n?" selected='selected'":"")+">"+d+"</option>"}e.yearshtml+="</select>";b+=e.yearshtml;e.yearshtml=null}}b+=this._get(e,"yearSuffix");if(y){b+=(s||!(m&&g)?"&#xa0;":"")+w}b+="</div>";return b},_adjustInstDate:function(e,t,n){var r=e.drawYear+(n==="Y"?t:0),i=e.drawMonth+(n==="M"?t:0),s=Math.min(e.selectedDay,this._getDaysInMonth(r,i))+(n==="D"?t:0),o=this._restrictMinMax(e,this._daylightSavingAdjust(new Date(r,i,s)));e.selectedDay=o.getDate();e.drawMonth=e.selectedMonth=o.getMonth();e.drawYear=e.selectedYear=o.getFullYear();if(n==="M"||n==="Y"){this._notifyChange(e)}},_restrictMinMax:function(e,t){var n=this._getMinMaxDate(e,"min"),r=this._getMinMaxDate(e,"max"),i=n&&t<n?n:t;return r&&i>r?r:i},_notifyChange:function(e){var t=this._get(e,"onChangeMonthYear");if(t){t.apply(e.input?e.input[0]:null,[e.selectedYear,e.selectedMonth+1,e])}},_getNumberOfMonths:function(e){var t=this._get(e,"numberOfMonths");return t==null?[1,1]:typeof t==="number"?[1,t]:t},_getMinMaxDate:function(e,t){return this._determineDate(e,this._get(e,t+"Date"),null)},_getDaysInMonth:function(e,t){return 32-this._daylightSavingAdjust(new Date(e,t,32)).getDate()},_getFirstDayOfMonth:function(e,t){return(new Date(e,t,1)).getDay()},_canAdjustMonth:function(e,t,n,r){var i=this._getNumberOfMonths(e),s=this._daylightSavingAdjust(new Date(n,r+(t<0?t:i[0]*i[1]),1));if(t<0){s.setDate(this._getDaysInMonth(s.getFullYear(),s.getMonth()))}return this._isInRange(e,s)},_isInRange:function(e,t){var n,r,i=this._getMinMaxDate(e,"min"),s=this._getMinMaxDate(e,"max"),o=null,u=null,a=this._get(e,"yearRange");if(a){n=a.split(":");r=(new Date).getFullYear();o=parseInt(n[0],10);u=parseInt(n[1],10);if(n[0].match(/[+\-].*/)){o+=r}if(n[1].match(/[+\-].*/)){u+=r}}return(!i||t.getTime()>=i.getTime())&&(!s||t.getTime()<=s.getTime())&&(!o||t.getFullYear()>=o)&&(!u||t.getFullYear()<=u)},_getFormatConfig:function(e){var t=this._get(e,"shortYearCutoff");t=typeof t!=="string"?t:(new Date).getFullYear()%100+parseInt(t,10);return{shortYearCutoff:t,dayNamesShort:this._get(e,"dayNamesShort"),dayNames:this._get(e,"dayNames"),monthNamesShort:this._get(e,"monthNamesShort"),monthNames:this._get(e,"monthNames")}},_formatDate:function(e,t,n,r){if(!t){e.currentDay=e.selectedDay;e.currentMonth=e.selectedMonth;e.currentYear=e.selectedYear}var i=t?typeof t==="object"?t:this._daylightSavingAdjust(new Date(r,n,t)):this._daylightSavingAdjust(new Date(e.currentYear,e.currentMonth,e.currentDay));return this.formatDate(this._get(e,"dateFormat"),i,this._getFormatConfig(e))}});e.fn.datepicker=function(t){if(!this.length){return this}if(!e.datepicker.initialized){e(document).mousedown(e.datepicker._checkExternalClick);e.datepicker.initialized=true}if(e("#"+e.datepicker._mainDivId).length===0){e("body").append(e.datepicker.dpDiv)}var n=Array.prototype.slice.call(arguments,1);if(typeof t==="string"&&(t==="isDisabled"||t==="getDate"||t==="widget")){return e.datepicker["_"+t+"Datepicker"].apply(e.datepicker,[this[0]].concat(n))}if(t==="option"&&arguments.length===2&&typeof arguments[1]==="string"){return e.datepicker["_"+t+"Datepicker"].apply(e.datepicker,[this[0]].concat(n))}return this.each(function(){typeof t==="string"?e.datepicker["_"+t+"Datepicker"].apply(e.datepicker,[this].concat(n)):e.datepicker._attachDatepicker(this,t)})};e.datepicker=new i;e.datepicker.initialized=false;e.datepicker.uuid=(new Date).getTime();e.datepicker.version="1.10.3"})(jQuery);(function(e,t){var n={buttons:true,height:true,maxHeight:true,maxWidth:true,minHeight:true,minWidth:true,width:true},r={maxHeight:true,maxWidth:true,minHeight:true,minWidth:true};e.widget("ui.dialog",{version:"1.10.3",options:{appendTo:"body",autoOpen:true,buttons:[],closeOnEscape:true,closeText:"close",dialogClass:"",draggable:true,hide:null,height:"auto",maxHeight:null,maxWidth:null,minHeight:150,minWidth:150,modal:false,position:{my:"center",at:"center",of:window,collision:"fit",using:function(t){var n=e(this).css(t).offset().top;if(n<0){e(this).css("top",t.top-n)}}},resizable:true,show:null,title:null,width:300,beforeClose:null,close:null,drag:null,dragStart:null,dragStop:null,focus:null,open:null,resize:null,resizeStart:null,resizeStop:null},_create:function(){this.originalCss={display:this.element[0].style.display,width:this.element[0].style.width,minHeight:this.element[0].style.minHeight,maxHeight:this.element[0].style.maxHeight,height:this.element[0].style.height};this.originalPosition={parent:this.element.parent(),index:this.element.parent().children().index(this.element)};this.originalTitle=this.element.attr("title");this.options.title=this.options.title||this.originalTitle;this._createWrapper();this.element.show().removeAttr("title").addClass("ui-dialog-content ui-widget-content").appendTo(this.uiDialog);this._createTitlebar();this._createButtonPane();if(this.options.draggable&&e.fn.draggable){this._makeDraggable()}if(this.options.resizable&&e.fn.resizable){this._makeResizable()}this._isOpen=false},_init:function(){if(this.options.autoOpen){this.open()}},_appendTo:function(){var t=this.options.appendTo;if(t&&(t.jquery||t.nodeType)){return e(t)}return this.document.find(t||"body").eq(0)},_destroy:function(){var e,t=this.originalPosition;this._destroyOverlay();this.element.removeUniqueId().removeClass("ui-dialog-content ui-widget-content").css(this.originalCss).detach();this.uiDialog.stop(true,true).remove();if(this.originalTitle){this.element.attr("title",this.originalTitle)}e=t.parent.children().eq(t.index);if(e.length&&e[0]!==this.element[0]){e.before(this.element)}else{t.parent.append(this.element)}},widget:function(){return this.uiDialog},disable:e.noop,enable:e.noop,close:function(t){var n=this;if(!this._isOpen||this._trigger("beforeClose",t)===false){return}this._isOpen=false;this._destroyOverlay();if(!this.opener.filter(":focusable").focus().length){e(this.document[0].activeElement).blur()}this._hide(this.uiDialog,this.options.hide,function(){n._trigger("close",t)})},isOpen:function(){return this._isOpen},moveToTop:function(){this._moveToTop()},_moveToTop:function(e,t){var n=!!this.uiDialog.nextAll(":visible").insertBefore(this.uiDialog).length;if(n&&!t){this._trigger("focus",e)}return n},open:function(){var t=this;if(this._isOpen){if(this._moveToTop()){this._focusTabbable()}return}this._isOpen=true;this.opener=e(this.document[0].activeElement);this._size();this._position();this._createOverlay();this._moveToTop(null,true);this._show(this.uiDialog,this.options.show,function(){t._focusTabbable();t._trigger("focus")});this._trigger("open")},_focusTabbable:function(){var e=this.element.find("[autofocus]");if(!e.length){e=this.element.find(":tabbable")}if(!e.length){e=this.uiDialogButtonPane.find(":tabbable")}if(!e.length){e=this.uiDialogTitlebarClose.filter(":tabbable")}if(!e.length){e=this.uiDialog}e.eq(0).focus()},_keepFocus:function(t){function n(){var t=this.document[0].activeElement,n=this.uiDialog[0]===t||e.contains(this.uiDialog[0],t);if(!n){this._focusTabbable()}}t.preventDefault();n.call(this);this._delay(n)},_createWrapper:function(){this.uiDialog=e("<div>").addClass("ui-dialog ui-widget ui-widget-content ui-corner-all ui-front "+this.options.dialogClass).hide().attr({tabIndex:-1,role:"dialog"}).appendTo(this._appendTo());this._on(this.uiDialog,{keydown:function(t){if(this.options.closeOnEscape&&!t.isDefaultPrevented()&&t.keyCode&&t.keyCode===e.ui.keyCode.ESCAPE){t.preventDefault();this.close(t);return}if(t.keyCode!==e.ui.keyCode.TAB){return}var n=this.uiDialog.find(":tabbable"),r=n.filter(":first"),i=n.filter(":last");if((t.target===i[0]||t.target===this.uiDialog[0])&&!t.shiftKey){r.focus(1);t.preventDefault()}else if((t.target===r[0]||t.target===this.uiDialog[0])&&t.shiftKey){i.focus(1);t.preventDefault()}},mousedown:function(e){if(this._moveToTop(e)){this._focusTabbable()}}});if(!this.element.find("[aria-describedby]").length){this.uiDialog.attr({"aria-describedby":this.element.uniqueId().attr("id")})}},_createTitlebar:function(){var t;this.uiDialogTitlebar=e("<div>").addClass("ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix").prependTo(this.uiDialog);this._on(this.uiDialogTitlebar,{mousedown:function(t){if(!e(t.target).closest(".ui-dialog-titlebar-close")){this.uiDialog.focus()}}});this.uiDialogTitlebarClose=e("<button></button>").button({label:this.options.closeText,icons:{primary:"ui-icon-closethick"},text:false}).addClass("ui-dialog-titlebar-close").appendTo(this.uiDialogTitlebar);this._on(this.uiDialogTitlebarClose,{click:function(e){e.preventDefault();this.close(e)}});t=e("<span>").uniqueId().addClass("ui-dialog-title").prependTo(this.uiDialogTitlebar);this._title(t);this.uiDialog.attr({"aria-labelledby":t.attr("id")})},_title:function(e){if(!this.options.title){e.html("&#160;")}e.text(this.options.title)},_createButtonPane:function(){this.uiDialogButtonPane=e("<div>").addClass("ui-dialog-buttonpane ui-widget-content ui-helper-clearfix");this.uiButtonSet=e("<div>").addClass("ui-dialog-buttonset").appendTo(this.uiDialogButtonPane);this._createButtons()},_createButtons:function(){var t=this,n=this.options.buttons;this.uiDialogButtonPane.remove();this.uiButtonSet.empty();if(e.isEmptyObject(n)||e.isArray(n)&&!n.length){this.uiDialog.removeClass("ui-dialog-buttons");return}e.each(n,function(n,r){var i,s;r=e.isFunction(r)?{click:r,text:n}:r;r=e.extend({type:"button"},r);i=r.click;r.click=function(){i.apply(t.element[0],arguments)};s={icons:r.icons,text:r.showText};delete r.icons;delete r.showText;e("<button></button>",r).button(s).appendTo(t.uiButtonSet)});this.uiDialog.addClass("ui-dialog-buttons");this.uiDialogButtonPane.appendTo(this.uiDialog)},_makeDraggable:function(){function r(e){return{position:e.position,offset:e.offset}}var t=this,n=this.options;this.uiDialog.draggable({cancel:".ui-dialog-content, .ui-dialog-titlebar-close",handle:".ui-dialog-titlebar",containment:"document",start:function(n,i){e(this).addClass("ui-dialog-dragging");t._blockFrames();t._trigger("dragStart",n,r(i))},drag:function(e,n){t._trigger("drag",e,r(n))},stop:function(i,s){n.position=[s.position.left-t.document.scrollLeft(),s.position.top-t.document.scrollTop()];e(this).removeClass("ui-dialog-dragging");t._unblockFrames();t._trigger("dragStop",i,r(s))}})},_makeResizable:function(){function o(e){return{originalPosition:e.originalPosition,originalSize:e.originalSize,position:e.position,size:e.size}}var t=this,n=this.options,r=n.resizable,i=this.uiDialog.css("position"),s=typeof r==="string"?r:"n,e,s,w,se,sw,ne,nw";this.uiDialog.resizable({cancel:".ui-dialog-content",containment:"document",alsoResize:this.element,maxWidth:n.maxWidth,maxHeight:n.maxHeight,minWidth:n.minWidth,minHeight:this._minHeight(),handles:s,start:function(n,r){e(this).addClass("ui-dialog-resizing");t._blockFrames();t._trigger("resizeStart",n,o(r))},resize:function(e,n){t._trigger("resize",e,o(n))},stop:function(r,i){n.height=e(this).height();n.width=e(this).width();e(this).removeClass("ui-dialog-resizing");t._unblockFrames();t._trigger("resizeStop",r,o(i))}}).css("position",i)},_minHeight:function(){var e=this.options;return e.height==="auto"?e.minHeight:Math.min(e.minHeight,e.height)},_position:function(){var e=this.uiDialog.is(":visible");if(!e){this.uiDialog.show()}this.uiDialog.position(this.options.position);if(!e){this.uiDialog.hide()}},_setOptions:function(t){var i=this,s=false,o={};e.each(t,function(e,t){i._setOption(e,t);if(e in n){s=true}if(e in r){o[e]=t}});if(s){this._size();this._position()}if(this.uiDialog.is(":data(ui-resizable)")){this.uiDialog.resizable("option",o)}},_setOption:function(e,t){var n,r,i=this.uiDialog;if(e==="dialogClass"){i.removeClass(this.options.dialogClass).addClass(t)}if(e==="disabled"){return}this._super(e,t);if(e==="appendTo"){this.uiDialog.appendTo(this._appendTo())}if(e==="buttons"){this._createButtons()}if(e==="closeText"){this.uiDialogTitlebarClose.button({label:""+t})}if(e==="draggable"){n=i.is(":data(ui-draggable)");if(n&&!t){i.draggable("destroy")}if(!n&&t){this._makeDraggable()}}if(e==="position"){this._position()}if(e==="resizable"){r=i.is(":data(ui-resizable)");if(r&&!t){i.resizable("destroy")}if(r&&typeof t==="string"){i.resizable("option","handles",t)}if(!r&&t!==false){this._makeResizable()}}if(e==="title"){this._title(this.uiDialogTitlebar.find(".ui-dialog-title"))}},_size:function(){var e,t,n,r=this.options;this.element.show().css({width:"auto",minHeight:0,maxHeight:"none",height:0});if(r.minWidth>r.width){r.width=r.minWidth}e=this.uiDialog.css({height:"auto",width:r.width}).outerHeight();t=Math.max(0,r.minHeight-e);n=typeof r.maxHeight==="number"?Math.max(0,r.maxHeight-e):"none";if(r.height==="auto"){this.element.css({minHeight:t,maxHeight:n,height:"auto"})}else{this.element.height(Math.max(0,r.height-e))}if(this.uiDialog.is(":data(ui-resizable)")){this.uiDialog.resizable("option","minHeight",this._minHeight())}},_blockFrames:function(){this.iframeBlocks=this.document.find("iframe").map(function(){var t=e(this);return e("<div>").css({position:"absolute",width:t.outerWidth(),height:t.outerHeight()}).appendTo(t.parent()).offset(t.offset())[0]})},_unblockFrames:function(){if(this.iframeBlocks){this.iframeBlocks.remove();delete this.iframeBlocks}},_allowInteraction:function(t){if(e(t.target).closest(".ui-dialog").length){return true}return!!e(t.target).closest(".ui-datepicker").length},_createOverlay:function(){if(!this.options.modal){return}var t=this,n=this.widgetFullName;if(!e.ui.dialog.overlayInstances){this._delay(function(){if(e.ui.dialog.overlayInstances){this.document.bind("focusin.dialog",function(r){if(!t._allowInteraction(r)){r.preventDefault();e(".ui-dialog:visible:last .ui-dialog-content").data(n)._focusTabbable()}})}})}this.overlay=e("<div>").addClass("ui-widget-overlay ui-front").appendTo(this._appendTo());this._on(this.overlay,{mousedown:"_keepFocus"});e.ui.dialog.overlayInstances++},_destroyOverlay:function(){if(!this.options.modal){return}if(this.overlay){e.ui.dialog.overlayInstances--;if(!e.ui.dialog.overlayInstances){this.document.unbind("focusin.dialog")}this.overlay.remove();this.overlay=null}}});e.ui.dialog.overlayInstances=0;if(e.uiBackCompat!==false){e.widget("ui.dialog",e.ui.dialog,{_position:function(){var t=this.options.position,n=[],r=[0,0],i;if(t){if(typeof t==="string"||typeof t==="object"&&"0"in t){n=t.split?t.split(" "):[t[0],t[1]];if(n.length===1){n[1]=n[0]}e.each(["left","top"],function(e,t){if(+n[e]===n[e]){r[e]=n[e];n[e]=t}});t={my:n[0]+(r[0]<0?r[0]:"+"+r[0])+" "+n[1]+(r[1]<0?r[1]:"+"+r[1]),at:n.join(" ")}}t=e.extend({},e.ui.dialog.prototype.options.position,t)}else{t=e.ui.dialog.prototype.options.position}i=this.uiDialog.is(":visible");if(!i){this.uiDialog.show()}this.uiDialog.position(t);if(!i){this.uiDialog.hide()}}})}})(jQuery);(function(e,t){var n=/up|down|vertical/,r=/up|left|vertical|horizontal/;e.effects.effect.blind=function(t,i){var s=e(this),o=["position","top","bottom","left","right","height","width"],u=e.effects.setMode(s,t.mode||"hide"),a=t.direction||"up",f=n.test(a),l=f?"height":"width",c=f?"top":"left",h=r.test(a),p={},d=u==="show",v,m,g;if(s.parent().is(".ui-effects-wrapper")){e.effects.save(s.parent(),o)}else{e.effects.save(s,o)}s.show();v=e.effects.createWrapper(s).css({overflow:"hidden"});m=v[l]();g=parseFloat(v.css(c))||0;p[l]=d?m:0;if(!h){s.css(f?"bottom":"right",0).css(f?"top":"left","auto").css({position:"absolute"});p[c]=d?g:m+g}if(d){v.css(l,0);if(!h){v.css(c,g+m)}}v.animate(p,{duration:t.duration,easing:t.easing,queue:false,complete:function(){if(u==="hide"){s.hide()}e.effects.restore(s,o);e.effects.removeWrapper(s);i()}})}})(jQuery);(function(e,t){e.effects.effect.bounce=function(t,n){var r=e(this),i=["position","top","bottom","left","right","height","width"],s=e.effects.setMode(r,t.mode||"effect"),o=s==="hide",u=s==="show",a=t.direction||"up",f=t.distance,l=t.times||5,c=l*2+(u||o?1:0),h=t.duration/c,p=t.easing,d=a==="up"||a==="down"?"top":"left",v=a==="up"||a==="left",m,g,y,b=r.queue(),w=b.length;if(u||o){i.push("opacity")}e.effects.save(r,i);r.show();e.effects.createWrapper(r);if(!f){f=r[d==="top"?"outerHeight":"outerWidth"]()/3}if(u){y={opacity:1};y[d]=0;r.css("opacity",0).css(d,v?-f*2:f*2).animate(y,h,p)}if(o){f=f/Math.pow(2,l-1)}y={};y[d]=0;for(m=0;m<l;m++){g={};g[d]=(v?"-=":"+=")+f;r.animate(g,h,p).animate(y,h,p);f=o?f*2:f/2}if(o){g={opacity:0};g[d]=(v?"-=":"+=")+f;r.animate(g,h,p)}r.queue(function(){if(o){r.hide()}e.effects.restore(r,i);e.effects.removeWrapper(r);n()});if(w>1){b.splice.apply(b,[1,0].concat(b.splice(w,c+1)))}r.dequeue()}})(jQuery);(function(e,t){e.effects.effect.clip=function(t,n){var r=e(this),i=["position","top","bottom","left","right","height","width"],s=e.effects.setMode(r,t.mode||"hide"),o=s==="show",u=t.direction||"vertical",a=u==="vertical",f=a?"height":"width",l=a?"top":"left",c={},h,p,d;e.effects.save(r,i);r.show();h=e.effects.createWrapper(r).css({overflow:"hidden"});p=r[0].tagName==="IMG"?h:r;d=p[f]();if(o){p.css(f,0);p.css(l,d/2)}c[f]=o?d:0;c[l]=o?0:d/2;p.animate(c,{queue:false,duration:t.duration,easing:t.easing,complete:function(){if(!o){r.hide()}e.effects.restore(r,i);e.effects.removeWrapper(r);n()}})}})(jQuery);(function(e,t){e.effects.effect.drop=function(t,n){var r=e(this),i=["position","top","bottom","left","right","opacity","height","width"],s=e.effects.setMode(r,t.mode||"hide"),o=s==="show",u=t.direction||"left",a=u==="up"||u==="down"?"top":"left",f=u==="up"||u==="left"?"pos":"neg",l={opacity:o?1:0},c;e.effects.save(r,i);r.show();e.effects.createWrapper(r);c=t.distance||r[a==="top"?"outerHeight":"outerWidth"](true)/2;if(o){r.css("opacity",0).css(a,f==="pos"?-c:c)}l[a]=(o?f==="pos"?"+=":"-=":f==="pos"?"-=":"+=")+c;r.animate(l,{queue:false,duration:t.duration,easing:t.easing,complete:function(){if(s==="hide"){r.hide()}e.effects.restore(r,i);e.effects.removeWrapper(r);n()}})}})(jQuery);(function(e,t){e.effects.effect.explode=function(t,n){function y(){c.push(this);if(c.length===r*i){b()}}function b(){s.css({visibility:"visible"});e(c).remove();if(!u){s.hide()}n()}var r=t.pieces?Math.round(Math.sqrt(t.pieces)):3,i=r,s=e(this),o=e.effects.setMode(s,t.mode||"hide"),u=o==="show",a=s.show().css("visibility","hidden").offset(),f=Math.ceil(s.outerWidth()/i),l=Math.ceil(s.outerHeight()/r),c=[],h,p,d,v,m,g;for(h=0;h<r;h++){v=a.top+h*l;g=h-(r-1)/2;for(p=0;p<i;p++){d=a.left+p*f;m=p-(i-1)/2;s.clone().appendTo("body").wrap("<div></div>").css({position:"absolute",visibility:"visible",left:-p*f,top:-h*l}).parent().addClass("ui-effects-explode").css({position:"absolute",overflow:"hidden",width:f,height:l,left:d+(u?m*f:0),top:v+(u?g*l:0),opacity:u?0:1}).animate({left:d+(u?0:m*f),top:v+(u?0:g*l),opacity:u?1:0},t.duration||500,t.easing,y)}}}})(jQuery);(function(e,t){e.effects.effect.fade=function(t,n){var r=e(this),i=e.effects.setMode(r,t.mode||"toggle");r.animate({opacity:i},{queue:false,duration:t.duration,easing:t.easing,complete:n})}})(jQuery);(function(e,t){e.effects.effect.fold=function(t,n){var r=e(this),i=["position","top","bottom","left","right","height","width"],s=e.effects.setMode(r,t.mode||"hide"),o=s==="show",u=s==="hide",a=t.size||15,f=/([0-9]+)%/.exec(a),l=!!t.horizFirst,c=o!==l,h=c?["width","height"]:["height","width"],p=t.duration/2,d,v,m={},g={};e.effects.save(r,i);r.show();d=e.effects.createWrapper(r).css({overflow:"hidden"});v=c?[d.width(),d.height()]:[d.height(),d.width()];if(f){a=parseInt(f[1],10)/100*v[u?0:1]}if(o){d.css(l?{height:0,width:a}:{height:a,width:0})}m[h[0]]=o?v[0]:a;g[h[1]]=o?v[1]:0;d.animate(m,p,t.easing).animate(g,p,t.easing,function(){if(u){r.hide()}e.effects.restore(r,i);e.effects.removeWrapper(r);n()})}})(jQuery);(function(e,t){e.effects.effect.highlight=function(t,n){var r=e(this),i=["backgroundImage","backgroundColor","opacity"],s=e.effects.setMode(r,t.mode||"show"),o={backgroundColor:r.css("backgroundColor")};if(s==="hide"){o.opacity=0}e.effects.save(r,i);r.show().css({backgroundImage:"none",backgroundColor:t.color||"#ffff99"}).animate(o,{queue:false,duration:t.duration,easing:t.easing,complete:function(){if(s==="hide"){r.hide()}e.effects.restore(r,i);n()}})}})(jQuery);(function(e,t){e.effects.effect.pulsate=function(t,n){var r=e(this),i=e.effects.setMode(r,t.mode||"show"),s=i==="show",o=i==="hide",u=s||i==="hide",a=(t.times||5)*2+(u?1:0),f=t.duration/a,l=0,c=r.queue(),h=c.length,p;if(s||!r.is(":visible")){r.css("opacity",0).show();l=1}for(p=1;p<a;p++){r.animate({opacity:l},f,t.easing);l=1-l}r.animate({opacity:l},f,t.easing);r.queue(function(){if(o){r.hide()}n()});if(h>1){c.splice.apply(c,[1,0].concat(c.splice(h,a+1)))}r.dequeue()}})(jQuery);(function(e,t){e.effects.effect.puff=function(t,n){var r=e(this),i=e.effects.setMode(r,t.mode||"hide"),s=i==="hide",o=parseInt(t.percent,10)||150,u=o/100,a={height:r.height(),width:r.width(),outerHeight:r.outerHeight(),outerWidth:r.outerWidth()};e.extend(t,{effect:"scale",queue:false,fade:true,mode:i,complete:n,percent:s?o:100,from:s?a:{height:a.height*u,width:a.width*u,outerHeight:a.outerHeight*u,outerWidth:a.outerWidth*u}});r.effect(t)};e.effects.effect.scale=function(t,n){var r=e(this),i=e.extend(true,{},t),s=e.effects.setMode(r,t.mode||"effect"),o=parseInt(t.percent,10)||(parseInt(t.percent,10)===0?0:s==="hide"?0:100),u=t.direction||"both",a=t.origin,f={height:r.height(),width:r.width(),outerHeight:r.outerHeight(),outerWidth:r.outerWidth()},l={y:u!=="horizontal"?o/100:1,x:u!=="vertical"?o/100:1};i.effect="size";i.queue=false;i.complete=n;if(s!=="effect"){i.origin=a||["middle","center"];i.restore=true}i.from=t.from||(s==="show"?{height:0,width:0,outerHeight:0,outerWidth:0}:f);i.to={height:f.height*l.y,width:f.width*l.x,outerHeight:f.outerHeight*l.y,outerWidth:f.outerWidth*l.x};if(i.fade){if(s==="show"){i.from.opacity=0;i.to.opacity=1}if(s==="hide"){i.from.opacity=1;i.to.opacity=0}}r.effect(i)};e.effects.effect.size=function(t,n){var r,i,s,o=e(this),u=["position","top","bottom","left","right","width","height","overflow","opacity"],a=["position","top","bottom","left","right","overflow","opacity"],f=["width","height","overflow"],l=["fontSize"],c=["borderTopWidth","borderBottomWidth","paddingTop","paddingBottom"],h=["borderLeftWidth","borderRightWidth","paddingLeft","paddingRight"],p=e.effects.setMode(o,t.mode||"effect"),d=t.restore||p!=="effect",v=t.scale||"both",m=t.origin||["middle","center"],g=o.css("position"),y=d?u:a,b={height:0,width:0,outerHeight:0,outerWidth:0};if(p==="show"){o.show()}r={height:o.height(),width:o.width(),outerHeight:o.outerHeight(),outerWidth:o.outerWidth()};if(t.mode==="toggle"&&p==="show"){o.from=t.to||b;o.to=t.from||r}else{o.from=t.from||(p==="show"?b:r);o.to=t.to||(p==="hide"?b:r)}s={from:{y:o.from.height/r.height,x:o.from.width/r.width},to:{y:o.to.height/r.height,x:o.to.width/r.width}};if(v==="box"||v==="both"){if(s.from.y!==s.to.y){y=y.concat(c);o.from=e.effects.setTransition(o,c,s.from.y,o.from);o.to=e.effects.setTransition(o,c,s.to.y,o.to)}if(s.from.x!==s.to.x){y=y.concat(h);o.from=e.effects.setTransition(o,h,s.from.x,o.from);o.to=e.effects.setTransition(o,h,s.to.x,o.to)}}if(v==="content"||v==="both"){if(s.from.y!==s.to.y){y=y.concat(l).concat(f);o.from=e.effects.setTransition(o,l,s.from.y,o.from);o.to=e.effects.setTransition(o,l,s.to.y,o.to)}}e.effects.save(o,y);o.show();e.effects.createWrapper(o);o.css("overflow","hidden").css(o.from);if(m){i=e.effects.getBaseline(m,r);o.from.top=(r.outerHeight-o.outerHeight())*i.y;o.from.left=(r.outerWidth-o.outerWidth())*i.x;o.to.top=(r.outerHeight-o.to.outerHeight)*i.y;o.to.left=(r.outerWidth-o.to.outerWidth)*i.x}o.css(o.from);if(v==="content"||v==="both"){c=c.concat(["marginTop","marginBottom"]).concat(l);h=h.concat(["marginLeft","marginRight"]);f=u.concat(c).concat(h);o.find("*[width]").each(function(){var n=e(this),r={height:n.height(),width:n.width(),outerHeight:n.outerHeight(),outerWidth:n.outerWidth()};if(d){e.effects.save(n,f)}n.from={height:r.height*s.from.y,width:r.width*s.from.x,outerHeight:r.outerHeight*s.from.y,outerWidth:r.outerWidth*s.from.x};n.to={height:r.height*s.to.y,width:r.width*s.to.x,outerHeight:r.height*s.to.y,outerWidth:r.width*s.to.x};if(s.from.y!==s.to.y){n.from=e.effects.setTransition(n,c,s.from.y,n.from);n.to=e.effects.setTransition(n,c,s.to.y,n.to)}if(s.from.x!==s.to.x){n.from=e.effects.setTransition(n,h,s.from.x,n.from);n.to=e.effects.setTransition(n,h,s.to.x,n.to)}n.css(n.from);n.animate(n.to,t.duration,t.easing,function(){if(d){e.effects.restore(n,f)}})})}o.animate(o.to,{queue:false,duration:t.duration,easing:t.easing,complete:function(){if(o.to.opacity===0){o.css("opacity",o.from.opacity)}if(p==="hide"){o.hide()}e.effects.restore(o,y);if(!d){if(g==="static"){o.css({position:"relative",top:o.to.top,left:o.to.left})}else{e.each(["top","left"],function(e,t){o.css(t,function(t,n){var r=parseInt(n,10),i=e?o.to.left:o.to.top;if(n==="auto"){return i+"px"}return r+i+"px"})})}}e.effects.removeWrapper(o);n()}})}})(jQuery);(function(e,t){e.effects.effect.shake=function(t,n){var r=e(this),i=["position","top","bottom","left","right","height","width"],s=e.effects.setMode(r,t.mode||"effect"),o=t.direction||"left",u=t.distance||20,a=t.times||3,f=a*2+1,l=Math.round(t.duration/f),c=o==="up"||o==="down"?"top":"left",h=o==="up"||o==="left",p={},d={},v={},m,g=r.queue(),y=g.length;e.effects.save(r,i);r.show();e.effects.createWrapper(r);p[c]=(h?"-=":"+=")+u;d[c]=(h?"+=":"-=")+u*2;v[c]=(h?"-=":"+=")+u*2;r.animate(p,l,t.easing);for(m=1;m<a;m++){r.animate(d,l,t.easing).animate(v,l,t.easing)}r.animate(d,l,t.easing).animate(p,l/2,t.easing).queue(function(){if(s==="hide"){r.hide()}e.effects.restore(r,i);e.effects.removeWrapper(r);n()});if(y>1){g.splice.apply(g,[1,0].concat(g.splice(y,f+1)))}r.dequeue()}})(jQuery);(function(e,t){e.effects.effect.slide=function(t,n){var r=e(this),i=["position","top","bottom","left","right","width","height"],s=e.effects.setMode(r,t.mode||"show"),o=s==="show",u=t.direction||"left",a=u==="up"||u==="down"?"top":"left",f=u==="up"||u==="left",l,c={};e.effects.save(r,i);r.show();l=t.distance||r[a==="top"?"outerHeight":"outerWidth"](true);e.effects.createWrapper(r).css({overflow:"hidden"});if(o){r.css(a,f?isNaN(l)?"-"+l:-l:l)}c[a]=(o?f?"+=":"-=":f?"-=":"+=")+l;r.animate(c,{queue:false,duration:t.duration,easing:t.easing,complete:function(){if(s==="hide"){r.hide()}e.effects.restore(r,i);e.effects.removeWrapper(r);n()}})}})(jQuery);(function(e,t){e.effects.effect.transfer=function(t,n){var r=e(this),i=e(t.to),s=i.css("position")==="fixed",o=e("body"),u=s?o.scrollTop():0,a=s?o.scrollLeft():0,f=i.offset(),l={top:f.top-u,left:f.left-a,height:i.innerHeight(),width:i.innerWidth()},c=r.offset(),h=e("<div class='ui-effects-transfer'></div>").appendTo(document.body).addClass(t.className).css({top:c.top-u,left:c.left-a,height:r.innerHeight(),width:r.innerWidth(),position:s?"fixed":"absolute"}).animate(l,t.duration,t.easing,function(){h.remove();n()})}})(jQuery);(function(e,t){e.widget("ui.menu",{version:"1.10.3",defaultElement:"<ul>",delay:300,options:{icons:{submenu:"ui-icon-carat-1-e"},menus:"ul",position:{my:"left top",at:"right top"},role:"menu",blur:null,focus:null,select:null},_create:function(){this.activeMenu=this.element;this.mouseHandled=false;this.element.uniqueId().addClass("ui-menu ui-widget ui-widget-content ui-corner-all").toggleClass("ui-menu-icons",!!this.element.find(".ui-icon").length).attr({role:this.options.role,tabIndex:0}).bind("click"+this.eventNamespace,e.proxy(function(e){if(this.options.disabled){e.preventDefault()}},this));if(this.options.disabled){this.element.addClass("ui-state-disabled").attr("aria-disabled","true")}this._on({"mousedown .ui-menu-item > a":function(e){e.preventDefault()},"click .ui-state-disabled > a":function(e){e.preventDefault()},"click .ui-menu-item:has(a)":function(t){var n=e(t.target).closest(".ui-menu-item");if(!this.mouseHandled&&n.not(".ui-state-disabled").length){this.mouseHandled=true;this.select(t);if(n.has(".ui-menu").length){this.expand(t)}else if(!this.element.is(":focus")){this.element.trigger("focus",[true]);if(this.active&&this.active.parents(".ui-menu").length===1){clearTimeout(this.timer)}}}},"mouseenter .ui-menu-item":function(t){var n=e(t.currentTarget);n.siblings().children(".ui-state-active").removeClass("ui-state-active");this.focus(t,n)},mouseleave:"collapseAll","mouseleave .ui-menu":"collapseAll",focus:function(e,t){var n=this.active||this.element.children(".ui-menu-item").eq(0);if(!t){this.focus(e,n)}},blur:function(t){this._delay(function(){if(!e.contains(this.element[0],this.document[0].activeElement)){this.collapseAll(t)}})},keydown:"_keydown"});this.refresh();this._on(this.document,{click:function(t){if(!e(t.target).closest(".ui-menu").length){this.collapseAll(t)}this.mouseHandled=false}})},_destroy:function(){this.element.removeAttr("aria-activedescendant").find(".ui-menu").addBack().removeClass("ui-menu ui-widget ui-widget-content ui-corner-all ui-menu-icons").removeAttr("role").removeAttr("tabIndex").removeAttr("aria-labelledby").removeAttr("aria-expanded").removeAttr("aria-hidden").removeAttr("aria-disabled").removeUniqueId().show();this.element.find(".ui-menu-item").removeClass("ui-menu-item").removeAttr("role").removeAttr("aria-disabled").children("a").removeUniqueId().removeClass("ui-corner-all ui-state-hover").removeAttr("tabIndex").removeAttr("role").removeAttr("aria-haspopup").children().each(function(){var t=e(this);if(t.data("ui-menu-submenu-carat")){t.remove()}});this.element.find(".ui-menu-divider").removeClass("ui-menu-divider ui-widget-content")},_keydown:function(t){function a(e){return e.replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g,"\\$&")}var n,r,i,s,o,u=true;switch(t.keyCode){case e.ui.keyCode.PAGE_UP:this.previousPage(t);break;case e.ui.keyCode.PAGE_DOWN:this.nextPage(t);break;case e.ui.keyCode.HOME:this._move("first","first",t);break;case e.ui.keyCode.END:this._move("last","last",t);break;case e.ui.keyCode.UP:this.previous(t);break;case e.ui.keyCode.DOWN:this.next(t);break;case e.ui.keyCode.LEFT:this.collapse(t);break;case e.ui.keyCode.RIGHT:if(this.active&&!this.active.is(".ui-state-disabled")){this.expand(t)}break;case e.ui.keyCode.ENTER:case e.ui.keyCode.SPACE:this._activate(t);break;case e.ui.keyCode.ESCAPE:this.collapse(t);break;default:u=false;r=this.previousFilter||"";i=String.fromCharCode(t.keyCode);s=false;clearTimeout(this.filterTimer);if(i===r){s=true}else{i=r+i}o=new RegExp("^"+a(i),"i");n=this.activeMenu.children(".ui-menu-item").filter(function(){return o.test(e(this).children("a").text())});n=s&&n.index(this.active.next())!==-1?this.active.nextAll(".ui-menu-item"):n;if(!n.length){i=String.fromCharCode(t.keyCode);o=new RegExp("^"+a(i),"i");n=this.activeMenu.children(".ui-menu-item").filter(function(){return o.test(e(this).children("a").text())})}if(n.length){this.focus(t,n);if(n.length>1){this.previousFilter=i;this.filterTimer=this._delay(function(){delete this.previousFilter},1e3)}else{delete this.previousFilter}}else{delete this.previousFilter}}if(u){t.preventDefault()}},_activate:function(e){if(!this.active.is(".ui-state-disabled")){if(this.active.children("a[aria-haspopup='true']").length){this.expand(e)}else{this.select(e)}}},refresh:function(){var t,n=this.options.icons.submenu,r=this.element.find(this.options.menus);r.filter(":not(.ui-menu)").addClass("ui-menu ui-widget ui-widget-content ui-corner-all").hide().attr({role:this.options.role,"aria-hidden":"true","aria-expanded":"false"}).each(function(){var t=e(this),r=t.prev("a"),i=e("<span>").addClass("ui-menu-icon ui-icon "+n).data("ui-menu-submenu-carat",true);r.attr("aria-haspopup","true").prepend(i);t.attr("aria-labelledby",r.attr("id"))});t=r.add(this.element);t.children(":not(.ui-menu-item):has(a)").addClass("ui-menu-item").attr("role","presentation").children("a").uniqueId().addClass("ui-corner-all").attr({tabIndex:-1,role:this._itemRole()});t.children(":not(.ui-menu-item)").each(function(){var t=e(this);if(!/[^\-\u2014\u2013\s]/.test(t.text())){t.addClass("ui-widget-content ui-menu-divider")}});t.children(".ui-state-disabled").attr("aria-disabled","true");if(this.active&&!e.contains(this.element[0],this.active[0])){this.blur()}},_itemRole:function(){return{menu:"menuitem",listbox:"option"}[this.options.role]},_setOption:function(e,t){if(e==="icons"){this.element.find(".ui-menu-icon").removeClass(this.options.icons.submenu).addClass(t.submenu)}this._super(e,t)},focus:function(e,t){var n,r;this.blur(e,e&&e.type==="focus");this._scrollIntoView(t);this.active=t.first();r=this.active.children("a").addClass("ui-state-focus");if(this.options.role){this.element.attr("aria-activedescendant",r.attr("id"))}this.active.parent().closest(".ui-menu-item").children("a:first").addClass("ui-state-active");if(e&&e.type==="keydown"){this._close()}else{this.timer=this._delay(function(){this._close()},this.delay)}n=t.children(".ui-menu");if(n.length&&/^mouse/.test(e.type)){this._startOpening(n)}this.activeMenu=t.parent();this._trigger("focus",e,{item:t})},_scrollIntoView:function(t){var n,r,i,s,o,u;if(this._hasScroll()){n=parseFloat(e.css(this.activeMenu[0],"borderTopWidth"))||0;r=parseFloat(e.css(this.activeMenu[0],"paddingTop"))||0;i=t.offset().top-this.activeMenu.offset().top-n-r;s=this.activeMenu.scrollTop();o=this.activeMenu.height();u=t.height();if(i<0){this.activeMenu.scrollTop(s+i)}else if(i+u>o){this.activeMenu.scrollTop(s+i-o+u)}}},blur:function(e,t){if(!t){clearTimeout(this.timer)}if(!this.active){return}this.active.children("a").removeClass("ui-state-focus");this.active=null;this._trigger("blur",e,{item:this.active})},_startOpening:function(e){clearTimeout(this.timer);if(e.attr("aria-hidden")!=="true"){return}this.timer=this._delay(function(){this._close();this._open(e)},this.delay)},_open:function(t){var n=e.extend({of:this.active},this.options.position);clearTimeout(this.timer);this.element.find(".ui-menu").not(t.parents(".ui-menu")).hide().attr("aria-hidden","true");t.show().removeAttr("aria-hidden").attr("aria-expanded","true").position(n)},collapseAll:function(t,n){clearTimeout(this.timer);this.timer=this._delay(function(){var r=n?this.element:e(t&&t.target).closest(this.element.find(".ui-menu"));if(!r.length){r=this.element}this._close(r);this.blur(t);this.activeMenu=r},this.delay)},_close:function(e){if(!e){e=this.active?this.active.parent():this.element}e.find(".ui-menu").hide().attr("aria-hidden","true").attr("aria-expanded","false").end().find("a.ui-state-active").removeClass("ui-state-active")},collapse:function(e){var t=this.active&&this.active.parent().closest(".ui-menu-item",this.element);if(t&&t.length){this._close();this.focus(e,t)}},expand:function(e){var t=this.active&&this.active.children(".ui-menu ").children(".ui-menu-item").first();if(t&&t.length){this._open(t.parent());this._delay(function(){this.focus(e,t)})}},next:function(e){this._move("next","first",e)},previous:function(e){this._move("prev","last",e)},isFirstItem:function(){return this.active&&!this.active.prevAll(".ui-menu-item").length},isLastItem:function(){return this.active&&!this.active.nextAll(".ui-menu-item").length},_move:function(e,t,n){var r;if(this.active){if(e==="first"||e==="last"){r=this.active[e==="first"?"prevAll":"nextAll"](".ui-menu-item").eq(-1)}else{r=this.active[e+"All"](".ui-menu-item").eq(0)}}if(!r||!r.length||!this.active){r=this.activeMenu.children(".ui-menu-item")[t]()}this.focus(n,r)},nextPage:function(t){var n,r,i;if(!this.active){this.next(t);return}if(this.isLastItem()){return}if(this._hasScroll()){r=this.active.offset().top;i=this.element.height();this.active.nextAll(".ui-menu-item").each(function(){n=e(this);return n.offset().top-r-i<0});this.focus(t,n)}else{this.focus(t,this.activeMenu.children(".ui-menu-item")[!this.active?"first":"last"]())}},previousPage:function(t){var n,r,i;if(!this.active){this.next(t);return}if(this.isFirstItem()){return}if(this._hasScroll()){r=this.active.offset().top;i=this.element.height();this.active.prevAll(".ui-menu-item").each(function(){n=e(this);return n.offset().top-r+i>0});this.focus(t,n)}else{this.focus(t,this.activeMenu.children(".ui-menu-item").first())}},_hasScroll:function(){return this.element.outerHeight()<this.element.prop("scrollHeight")},select:function(t){this.active=this.active||e(t.target).closest(".ui-menu-item");var n={item:this.active};if(!this.active.has(".ui-menu").length){this.collapseAll(t,true)}this._trigger("select",t,n)}})})(jQuery);(function(e,t){function h(e,t,n){return[parseFloat(e[0])*(l.test(e[0])?t/100:1),parseFloat(e[1])*(l.test(e[1])?n/100:1)]}function p(t,n){return parseInt(e.css(t,n),10)||0}function d(t){var n=t[0];if(n.nodeType===9){return{width:t.width(),height:t.height(),offset:{top:0,left:0}}}if(e.isWindow(n)){return{width:t.width(),height:t.height(),offset:{top:t.scrollTop(),left:t.scrollLeft()}}}if(n.preventDefault){return{width:0,height:0,offset:{top:n.pageY,left:n.pageX}}}return{width:t.outerWidth(),height:t.outerHeight(),offset:t.offset()}}e.ui=e.ui||{};var n,r=Math.max,i=Math.abs,s=Math.round,o=/left|center|right/,u=/top|center|bottom/,a=/[\+\-]\d+(\.[\d]+)?%?/,f=/^\w+/,l=/%$/,c=e.fn.position;e.position={scrollbarWidth:function(){if(n!==t){return n}var r,i,s=e("<div style='display:block;width:50px;height:50px;overflow:hidden;'><div style='height:100px;width:auto;'></div></div>"),o=s.children()[0];e("body").append(s);r=o.offsetWidth;s.css("overflow","scroll");i=o.offsetWidth;if(r===i){i=s[0].clientWidth}s.remove();return n=r-i},getScrollInfo:function(t){var n=t.isWindow?"":t.element.css("overflow-x"),r=t.isWindow?"":t.element.css("overflow-y"),i=n==="scroll"||n==="auto"&&t.width<t.element[0].scrollWidth,s=r==="scroll"||r==="auto"&&t.height<t.element[0].scrollHeight;return{width:s?e.position.scrollbarWidth():0,height:i?e.position.scrollbarWidth():0}},getWithinInfo:function(t){var n=e(t||window),r=e.isWindow(n[0]);return{element:n,isWindow:r,offset:n.offset()||{left:0,top:0},scrollLeft:n.scrollLeft(),scrollTop:n.scrollTop(),width:r?n.width():n.outerWidth(),height:r?n.height():n.outerHeight()}}};e.fn.position=function(t){if(!t||!t.of){return c.apply(this,arguments)}t=e.extend({},t);var n,l,v,m,g,y,b=e(t.of),w=e.position.getWithinInfo(t.within),E=e.position.getScrollInfo(w),S=(t.collision||"flip").split(" "),x={};y=d(b);if(b[0].preventDefault){t.at="left top"}l=y.width;v=y.height;m=y.offset;g=e.extend({},m);e.each(["my","at"],function(){var e=(t[this]||"").split(" "),n,r;if(e.length===1){e=o.test(e[0])?e.concat(["center"]):u.test(e[0])?["center"].concat(e):["center","center"]}e[0]=o.test(e[0])?e[0]:"center";e[1]=u.test(e[1])?e[1]:"center";n=a.exec(e[0]);r=a.exec(e[1]);x[this]=[n?n[0]:0,r?r[0]:0];t[this]=[f.exec(e[0])[0],f.exec(e[1])[0]]});if(S.length===1){S[1]=S[0]}if(t.at[0]==="right"){g.left+=l}else if(t.at[0]==="center"){g.left+=l/2}if(t.at[1]==="bottom"){g.top+=v}else if(t.at[1]==="center"){g.top+=v/2}n=h(x.at,l,v);g.left+=n[0];g.top+=n[1];return this.each(function(){var o,u,a=e(this),f=a.outerWidth(),c=a.outerHeight(),d=p(this,"marginLeft"),y=p(this,"marginTop"),T=f+d+p(this,"marginRight")+E.width,N=c+y+p(this,"marginBottom")+E.height,C=e.extend({},g),k=h(x.my,a.outerWidth(),a.outerHeight());if(t.my[0]==="right"){C.left-=f}else if(t.my[0]==="center"){C.left-=f/2}if(t.my[1]==="bottom"){C.top-=c}else if(t.my[1]==="center"){C.top-=c/2}C.left+=k[0];C.top+=k[1];if(!e.support.offsetFractions){C.left=s(C.left);C.top=s(C.top)}o={marginLeft:d,marginTop:y};e.each(["left","top"],function(r,i){if(e.ui.position[S[r]]){e.ui.position[S[r]][i](C,{targetWidth:l,targetHeight:v,elemWidth:f,elemHeight:c,collisionPosition:o,collisionWidth:T,collisionHeight:N,offset:[n[0]+k[0],n[1]+k[1]],my:t.my,at:t.at,within:w,elem:a})}});if(t.using){u=function(e){var n=m.left-C.left,s=n+l-f,o=m.top-C.top,u=o+v-c,h={target:{element:b,left:m.left,top:m.top,width:l,height:v},element:{element:a,left:C.left,top:C.top,width:f,height:c},horizontal:s<0?"left":n>0?"right":"center",vertical:u<0?"top":o>0?"bottom":"middle"};if(l<f&&i(n+s)<l){h.horizontal="center"}if(v<c&&i(o+u)<v){h.vertical="middle"}if(r(i(n),i(s))>r(i(o),i(u))){h.important="horizontal"}else{h.important="vertical"}t.using.call(this,e,h)}}a.offset(e.extend(C,{using:u}))})};e.ui.position={fit:{left:function(e,t){var n=t.within,i=n.isWindow?n.scrollLeft:n.offset.left,s=n.width,o=e.left-t.collisionPosition.marginLeft,u=i-o,a=o+t.collisionWidth-s-i,f;if(t.collisionWidth>s){if(u>0&&a<=0){f=e.left+u+t.collisionWidth-s-i;e.left+=u-f}else if(a>0&&u<=0){e.left=i}else{if(u>a){e.left=i+s-t.collisionWidth}else{e.left=i}}}else if(u>0){e.left+=u}else if(a>0){e.left-=a}else{e.left=r(e.left-o,e.left)}},top:function(e,t){var n=t.within,i=n.isWindow?n.scrollTop:n.offset.top,s=t.within.height,o=e.top-t.collisionPosition.marginTop,u=i-o,a=o+t.collisionHeight-s-i,f;if(t.collisionHeight>s){if(u>0&&a<=0){f=e.top+u+t.collisionHeight-s-i;e.top+=u-f}else if(a>0&&u<=0){e.top=i}else{if(u>a){e.top=i+s-t.collisionHeight}else{e.top=i}}}else if(u>0){e.top+=u}else if(a>0){e.top-=a}else{e.top=r(e.top-o,e.top)}}},flip:{left:function(e,t){var n=t.within,r=n.offset.left+n.scrollLeft,s=n.width,o=n.isWindow?n.scrollLeft:n.offset.left,u=e.left-t.collisionPosition.marginLeft,a=u-o,f=u+t.collisionWidth-s-o,l=t.my[0]==="left"?-t.elemWidth:t.my[0]==="right"?t.elemWidth:0,c=t.at[0]==="left"?t.targetWidth:t.at[0]==="right"?-t.targetWidth:0,h=-2*t.offset[0],p,d;if(a<0){p=e.left+l+c+h+t.collisionWidth-s-r;if(p<0||p<i(a)){e.left+=l+c+h}}else if(f>0){d=e.left-t.collisionPosition.marginLeft+l+c+h-o;if(d>0||i(d)<f){e.left+=l+c+h}}},top:function(e,t){var n=t.within,r=n.offset.top+n.scrollTop,s=n.height,o=n.isWindow?n.scrollTop:n.offset.top,u=e.top-t.collisionPosition.marginTop,a=u-o,f=u+t.collisionHeight-s-o,l=t.my[1]==="top",c=l?-t.elemHeight:t.my[1]==="bottom"?t.elemHeight:0,h=t.at[1]==="top"?t.targetHeight:t.at[1]==="bottom"?-t.targetHeight:0,p=-2*t.offset[1],d,v;if(a<0){v=e.top+c+h+p+t.collisionHeight-s-r;if(e.top+c+h+p>a&&(v<0||v<i(a))){e.top+=c+h+p}}else if(f>0){d=e.top-t.collisionPosition.marginTop+c+h+p-o;if(e.top+c+h+p>f&&(d>0||i(d)<f)){e.top+=c+h+p}}}},flipfit:{left:function(){e.ui.position.flip.left.apply(this,arguments);e.ui.position.fit.left.apply(this,arguments)},top:function(){e.ui.position.flip.top.apply(this,arguments);e.ui.position.fit.top.apply(this,arguments)}}};(function(){var t,n,r,i,s,o=document.getElementsByTagName("body")[0],u=document.createElement("div");t=document.createElement(o?"div":"body");r={visibility:"hidden",width:0,height:0,border:0,margin:0,background:"none"};if(o){e.extend(r,{position:"absolute",left:"-1000px",top:"-1000px"})}for(s in r){t.style[s]=r[s]}t.appendChild(u);n=o||document.documentElement;n.insertBefore(t,n.firstChild);u.style.cssText="position: absolute; left: 10.7432222px;";i=e(u).offset().left;e.support.offsetFractions=i>10&&i<11;t.innerHTML="";n.removeChild(t)})()})(jQuery);(function(e,t){e.widget("ui.progressbar",{version:"1.10.3",options:{max:100,value:0,change:null,complete:null},min:0,_create:function(){this.oldValue=this.options.value=this._constrainedValue();this.element.addClass("ui-progressbar ui-widget ui-widget-content ui-corner-all").attr({role:"progressbar","aria-valuemin":this.min});this.valueDiv=e("<div class='ui-progressbar-value ui-widget-header ui-corner-left'></div>").appendTo(this.element);this._refreshValue()},_destroy:function(){this.element.removeClass("ui-progressbar ui-widget ui-widget-content ui-corner-all").removeAttr("role").removeAttr("aria-valuemin").removeAttr("aria-valuemax").removeAttr("aria-valuenow");this.valueDiv.remove()},value:function(e){if(e===t){return this.options.value}this.options.value=this._constrainedValue(e);this._refreshValue()},_constrainedValue:function(e){if(e===t){e=this.options.value}this.indeterminate=e===false;if(typeof e!=="number"){e=0}return this.indeterminate?false:Math.min(this.options.max,Math.max(this.min,e))},_setOptions:function(e){var t=e.value;delete e.value;this._super(e);this.options.value=this._constrainedValue(t);this._refreshValue()},_setOption:function(e,t){if(e==="max"){t=Math.max(this.min,t)}this._super(e,t)},_percentage:function(){return this.indeterminate?100:100*(this.options.value-this.min)/(this.options.max-this.min)},_refreshValue:function(){var t=this.options.value,n=this._percentage();this.valueDiv.toggle(this.indeterminate||t>this.min).toggleClass("ui-corner-right",t===this.options.max).width(n.toFixed(0)+"%");this.element.toggleClass("ui-progressbar-indeterminate",this.indeterminate);if(this.indeterminate){this.element.removeAttr("aria-valuenow");if(!this.overlayDiv){this.overlayDiv=e("<div class='ui-progressbar-overlay'></div>").appendTo(this.valueDiv)}}else{this.element.attr({"aria-valuemax":this.options.max,"aria-valuenow":t});if(this.overlayDiv){this.overlayDiv.remove();this.overlayDiv=null}}if(this.oldValue!==t){this.oldValue=t;this._trigger("change")}if(t===this.options.max){this._trigger("complete")}}})})(jQuery);(function(e,t){var n=5;e.widget("ui.slider",e.ui.mouse,{version:"1.10.3",widgetEventPrefix:"slide",options:{animate:false,distance:0,max:100,min:0,orientation:"horizontal",range:false,step:1,value:0,values:null,change:null,slide:null,start:null,stop:null},_create:function(){this._keySliding=false;this._mouseSliding=false;this._animateOff=true;this._handleIndex=null;this._detectOrientation();this._mouseInit();this.element.addClass("ui-slider"+" ui-slider-"+this.orientation+" ui-widget"+" ui-widget-content"+" ui-corner-all");this._refresh();this._setOption("disabled",this.options.disabled);this._animateOff=false},_refresh:function(){this._createRange();this._createHandles();this._setupEvents();this._refreshValue()},_createHandles:function(){var t,n,r=this.options,i=this.element.find(".ui-slider-handle").addClass("ui-state-default ui-corner-all"),s="<a class='ui-slider-handle ui-state-default ui-corner-all' href='#'></a>",o=[];n=r.values&&r.values.length||1;if(i.length>n){i.slice(n).remove();i=i.slice(0,n)}for(t=i.length;t<n;t++){o.push(s)}this.handles=i.add(e(o.join("")).appendTo(this.element));this.handle=this.handles.eq(0);this.handles.each(function(t){e(this).data("ui-slider-handle-index",t)})},_createRange:function(){var t=this.options,n="";if(t.range){if(t.range===true){if(!t.values){t.values=[this._valueMin(),this._valueMin()]}else if(t.values.length&&t.values.length!==2){t.values=[t.values[0],t.values[0]]}else if(e.isArray(t.values)){t.values=t.values.slice(0)}}if(!this.range||!this.range.length){this.range=e("<div></div>").appendTo(this.element);n="ui-slider-range"+" ui-widget-header ui-corner-all"}else{this.range.removeClass("ui-slider-range-min ui-slider-range-max").css({left:"",bottom:""})}this.range.addClass(n+(t.range==="min"||t.range==="max"?" ui-slider-range-"+t.range:""))}else{this.range=e([])}},_setupEvents:function(){var e=this.handles.add(this.range).filter("a");this._off(e);this._on(e,this._handleEvents);this._hoverable(e);this._focusable(e)},_destroy:function(){this.handles.remove();this.range.remove();this.element.removeClass("ui-slider"+" ui-slider-horizontal"+" ui-slider-vertical"+" ui-widget"+" ui-widget-content"+" ui-corner-all");this._mouseDestroy()},_mouseCapture:function(t){var n,r,i,s,o,u,a,f,l=this,c=this.options;if(c.disabled){return false}this.elementSize={width:this.element.outerWidth(),height:this.element.outerHeight()};this.elementOffset=this.element.offset();n={x:t.pageX,y:t.pageY};r=this._normValueFromMouse(n);i=this._valueMax()-this._valueMin()+1;this.handles.each(function(t){var n=Math.abs(r-l.values(t));if(i>n||i===n&&(t===l._lastChangedValue||l.values(t)===c.min)){i=n;s=e(this);o=t}});u=this._start(t,o);if(u===false){return false}this._mouseSliding=true;this._handleIndex=o;s.addClass("ui-state-active").focus();a=s.offset();f=!e(t.target).parents().addBack().is(".ui-slider-handle");this._clickOffset=f?{left:0,top:0}:{left:t.pageX-a.left-s.width()/2,top:t.pageY-a.top-s.height()/2-(parseInt(s.css("borderTopWidth"),10)||0)-(parseInt(s.css("borderBottomWidth"),10)||0)+(parseInt(s.css("marginTop"),10)||0)};if(!this.handles.hasClass("ui-state-hover")){this._slide(t,o,r)}this._animateOff=true;return true},_mouseStart:function(){return true},_mouseDrag:function(e){var t={x:e.pageX,y:e.pageY},n=this._normValueFromMouse(t);this._slide(e,this._handleIndex,n);return false},_mouseStop:function(e){this.handles.removeClass("ui-state-active");this._mouseSliding=false;this._stop(e,this._handleIndex);this._change(e,this._handleIndex);this._handleIndex=null;this._clickOffset=null;this._animateOff=false;return false},_detectOrientation:function(){this.orientation=this.options.orientation==="vertical"?"vertical":"horizontal"},_normValueFromMouse:function(e){var t,n,r,i,s;if(this.orientation==="horizontal"){t=this.elementSize.width;n=e.x-this.elementOffset.left-(this._clickOffset?this._clickOffset.left:0)}else{t=this.elementSize.height;n=e.y-this.elementOffset.top-(this._clickOffset?this._clickOffset.top:0)}r=n/t;if(r>1){r=1}if(r<0){r=0}if(this.orientation==="vertical"){r=1-r}i=this._valueMax()-this._valueMin();s=this._valueMin()+r*i;return this._trimAlignValue(s)},_start:function(e,t){var n={handle:this.handles[t],value:this.value()};if(this.options.values&&this.options.values.length){n.value=this.values(t);n.values=this.values()}return this._trigger("start",e,n)},_slide:function(e,t,n){var r,i,s;if(this.options.values&&this.options.values.length){r=this.values(t?0:1);if(this.options.values.length===2&&this.options.range===true&&(t===0&&n>r||t===1&&n<r)){n=r}if(n!==this.values(t)){i=this.values();i[t]=n;s=this._trigger("slide",e,{handle:this.handles[t],value:n,values:i});r=this.values(t?0:1);if(s!==false){this.values(t,n,true)}}}else{if(n!==this.value()){s=this._trigger("slide",e,{handle:this.handles[t],value:n});if(s!==false){this.value(n)}}}},_stop:function(e,t){var n={handle:this.handles[t],value:this.value()};if(this.options.values&&this.options.values.length){n.value=this.values(t);n.values=this.values()}this._trigger("stop",e,n)},_change:function(e,t){if(!this._keySliding&&!this._mouseSliding){var n={handle:this.handles[t],value:this.value()};if(this.options.values&&this.options.values.length){n.value=this.values(t);n.values=this.values()}this._lastChangedValue=t;this._trigger("change",e,n)}},value:function(e){if(arguments.length){this.options.value=this._trimAlignValue(e);this._refreshValue();this._change(null,0);return}return this._value()},values:function(t,n){var r,i,s;if(arguments.length>1){this.options.values[t]=this._trimAlignValue(n);this._refreshValue();this._change(null,t);return}if(arguments.length){if(e.isArray(arguments[0])){r=this.options.values;i=arguments[0];for(s=0;s<r.length;s+=1){r[s]=this._trimAlignValue(i[s]);this._change(null,s)}this._refreshValue()}else{if(this.options.values&&this.options.values.length){return this._values(t)}else{return this.value()}}}else{return this._values()}},_setOption:function(t,n){var r,i=0;if(t==="range"&&this.options.range===true){if(n==="min"){this.options.value=this._values(0);this.options.values=null}else if(n==="max"){this.options.value=this._values(this.options.values.length-1);this.options.values=null}}if(e.isArray(this.options.values)){i=this.options.values.length}e.Widget.prototype._setOption.apply(this,arguments);switch(t){case"orientation":this._detectOrientation();this.element.removeClass("ui-slider-horizontal ui-slider-vertical").addClass("ui-slider-"+this.orientation);this._refreshValue();break;case"value":this._animateOff=true;this._refreshValue();this._change(null,0);this._animateOff=false;break;case"values":this._animateOff=true;this._refreshValue();for(r=0;r<i;r+=1){this._change(null,r)}this._animateOff=false;break;case"min":case"max":this._animateOff=true;this._refreshValue();this._animateOff=false;break;case"range":this._animateOff=true;this._refresh();this._animateOff=false;break}},_value:function(){var e=this.options.value;e=this._trimAlignValue(e);return e},_values:function(e){var t,n,r;if(arguments.length){t=this.options.values[e];t=this._trimAlignValue(t);return t}else if(this.options.values&&this.options.values.length){n=this.options.values.slice();for(r=0;r<n.length;r+=1){n[r]=this._trimAlignValue(n[r])}return n}else{return[]}},_trimAlignValue:function(e){if(e<=this._valueMin()){return this._valueMin()}if(e>=this._valueMax()){return this._valueMax()}var t=this.options.step>0?this.options.step:1,n=(e-this._valueMin())%t,r=e-n;if(Math.abs(n)*2>=t){r+=n>0?t:-t}return parseFloat(r.toFixed(5))},_valueMin:function(){return this.options.min},_valueMax:function(){return this.options.max},_refreshValue:function(){var t,n,r,i,s,o=this.options.range,u=this.options,a=this,f=!this._animateOff?u.animate:false,l={};if(this.options.values&&this.options.values.length){this.handles.each(function(r){n=(a.values(r)-a._valueMin())/(a._valueMax()-a._valueMin())*100;l[a.orientation==="horizontal"?"left":"bottom"]=n+"%";e(this).stop(1,1)[f?"animate":"css"](l,u.animate);if(a.options.range===true){if(a.orientation==="horizontal"){if(r===0){a.range.stop(1,1)[f?"animate":"css"]({left:n+"%"},u.animate)}if(r===1){a.range[f?"animate":"css"]({width:n-t+"%"},{queue:false,duration:u.animate})}}else{if(r===0){a.range.stop(1,1)[f?"animate":"css"]({bottom:n+"%"},u.animate)}if(r===1){a.range[f?"animate":"css"]({height:n-t+"%"},{queue:false,duration:u.animate})}}}t=n})}else{r=this.value();i=this._valueMin();s=this._valueMax();n=s!==i?(r-i)/(s-i)*100:0;l[this.orientation==="horizontal"?"left":"bottom"]=n+"%";this.handle.stop(1,1)[f?"animate":"css"](l,u.animate);if(o==="min"&&this.orientation==="horizontal"){this.range.stop(1,1)[f?"animate":"css"]({width:n+"%"},u.animate)}if(o==="max"&&this.orientation==="horizontal"){this.range[f?"animate":"css"]({width:100-n+"%"},{queue:false,duration:u.animate})}if(o==="min"&&this.orientation==="vertical"){this.range.stop(1,1)[f?"animate":"css"]({height:n+"%"},u.animate)}if(o==="max"&&this.orientation==="vertical"){this.range[f?"animate":"css"]({height:100-n+"%"},{queue:false,duration:u.animate})}}},_handleEvents:{keydown:function(t){var r,i,s,o,u=e(t.target).data("ui-slider-handle-index");switch(t.keyCode){case e.ui.keyCode.HOME:case e.ui.keyCode.END:case e.ui.keyCode.PAGE_UP:case e.ui.keyCode.PAGE_DOWN:case e.ui.keyCode.UP:case e.ui.keyCode.RIGHT:case e.ui.keyCode.DOWN:case e.ui.keyCode.LEFT:t.preventDefault();if(!this._keySliding){this._keySliding=true;e(t.target).addClass("ui-state-active");r=this._start(t,u);if(r===false){return}}break}o=this.options.step;if(this.options.values&&this.options.values.length){i=s=this.values(u)}else{i=s=this.value()}switch(t.keyCode){case e.ui.keyCode.HOME:s=this._valueMin();break;case e.ui.keyCode.END:s=this._valueMax();break;case e.ui.keyCode.PAGE_UP:s=this._trimAlignValue(i+(this._valueMax()-this._valueMin())/n);break;case e.ui.keyCode.PAGE_DOWN:s=this._trimAlignValue(i-(this._valueMax()-this._valueMin())/n);break;case e.ui.keyCode.UP:case e.ui.keyCode.RIGHT:if(i===this._valueMax()){return}s=this._trimAlignValue(i+o);break;case e.ui.keyCode.DOWN:case e.ui.keyCode.LEFT:if(i===this._valueMin()){return}s=this._trimAlignValue(i-o);break}this._slide(t,u,s)},click:function(e){e.preventDefault()},keyup:function(t){var n=e(t.target).data("ui-slider-handle-index");if(this._keySliding){this._keySliding=false;this._stop(t,n);this._change(t,n);e(t.target).removeClass("ui-state-active")}}}})})(jQuery);(function(e){function t(e){return function(){var t=this.element.val();e.apply(this,arguments);this._refresh();if(t!==this.element.val()){this._trigger("change")}}}e.widget("ui.spinner",{version:"1.10.3",defaultElement:"<input>",widgetEventPrefix:"spin",options:{culture:null,icons:{down:"ui-icon-triangle-1-s",up:"ui-icon-triangle-1-n"},incremental:true,max:null,min:null,numberFormat:null,page:10,step:1,change:null,spin:null,start:null,stop:null},_create:function(){this._setOption("max",this.options.max);this._setOption("min",this.options.min);this._setOption("step",this.options.step);this._value(this.element.val(),true);this._draw();this._on(this._events);this._refresh();this._on(this.window,{beforeunload:function(){this.element.removeAttr("autocomplete")}})},_getCreateOptions:function(){var t={},n=this.element;e.each(["min","max","step"],function(e,r){var i=n.attr(r);if(i!==undefined&&i.length){t[r]=i}});return t},_events:{keydown:function(e){if(this._start(e)&&this._keydown(e)){e.preventDefault()}},keyup:"_stop",focus:function(){this.previous=this.element.val()},blur:function(e){if(this.cancelBlur){delete this.cancelBlur;return}this._stop();this._refresh();if(this.previous!==this.element.val()){this._trigger("change",e)}},mousewheel:function(e,t){if(!t){return}if(!this.spinning&&!this._start(e)){return false}this._spin((t>0?1:-1)*this.options.step,e);clearTimeout(this.mousewheelTimer);this.mousewheelTimer=this._delay(function(){if(this.spinning){this._stop(e)}},100);e.preventDefault()},"mousedown .ui-spinner-button":function(t){function r(){var e=this.element[0]===this.document[0].activeElement;if(!e){this.element.focus();this.previous=n;this._delay(function(){this.previous=n})}}var n;n=this.element[0]===this.document[0].activeElement?this.previous:this.element.val();t.preventDefault();r.call(this);this.cancelBlur=true;this._delay(function(){delete this.cancelBlur;r.call(this)});if(this._start(t)===false){return}this._repeat(null,e(t.currentTarget).hasClass("ui-spinner-up")?1:-1,t)},"mouseup .ui-spinner-button":"_stop","mouseenter .ui-spinner-button":function(t){if(!e(t.currentTarget).hasClass("ui-state-active")){return}if(this._start(t)===false){return false}this._repeat(null,e(t.currentTarget).hasClass("ui-spinner-up")?1:-1,t)},"mouseleave .ui-spinner-button":"_stop"},_draw:function(){var e=this.uiSpinner=this.element.addClass("ui-spinner-input").attr("autocomplete","off").wrap(this._uiSpinnerHtml()).parent().append(this._buttonHtml());this.element.attr("role","spinbutton");this.buttons=e.find(".ui-spinner-button").attr("tabIndex",-1).button().removeClass("ui-corner-all");if(this.buttons.height()>Math.ceil(e.height()*.5)&&e.height()>0){e.height(e.height())}if(this.options.disabled){this.disable()}},_keydown:function(t){var n=this.options,r=e.ui.keyCode;switch(t.keyCode){case r.UP:this._repeat(null,1,t);return true;case r.DOWN:this._repeat(null,-1,t);return true;case r.PAGE_UP:this._repeat(null,n.page,t);return true;case r.PAGE_DOWN:this._repeat(null,-n.page,t);return true}return false},_uiSpinnerHtml:function(){return"<span class='ui-spinner ui-widget ui-widget-content ui-corner-all'></span>"},_buttonHtml:function(){return""+"<a class='ui-spinner-button ui-spinner-up ui-corner-tr'>"+"<span class='ui-icon "+this.options.icons.up+"'>&#9650;</span>"+"</a>"+"<a class='ui-spinner-button ui-spinner-down ui-corner-br'>"+"<span class='ui-icon "+this.options.icons.down+"'>&#9660;</span>"+"</a>"},_start:function(e){if(!this.spinning&&this._trigger("start",e)===false){return false}if(!this.counter){this.counter=1}this.spinning=true;return true},_repeat:function(e,t,n){e=e||500;clearTimeout(this.timer);this.timer=this._delay(function(){this._repeat(40,t,n)},e);this._spin(t*this.options.step,n)},_spin:function(e,t){var n=this.value()||0;if(!this.counter){this.counter=1}n=this._adjustValue(n+e*this._increment(this.counter));if(!this.spinning||this._trigger("spin",t,{value:n})!==false){this._value(n);this.counter++}},_increment:function(t){var n=this.options.incremental;if(n){return e.isFunction(n)?n(t):Math.floor(t*t*t/5e4-t*t/500+17*t/200+1)}return 1},_precision:function(){var e=this._precisionOf(this.options.step);if(this.options.min!==null){e=Math.max(e,this._precisionOf(this.options.min))}return e},_precisionOf:function(e){var t=e.toString(),n=t.indexOf(".");return n===-1?0:t.length-n-1},_adjustValue:function(e){var t,n,r=this.options;t=r.min!==null?r.min:0;n=e-t;n=Math.round(n/r.step)*r.step;e=t+n;e=parseFloat(e.toFixed(this._precision()));if(r.max!==null&&e>r.max){return r.max}if(r.min!==null&&e<r.min){return r.min}return e},_stop:function(e){if(!this.spinning){return}clearTimeout(this.timer);clearTimeout(this.mousewheelTimer);this.counter=0;this.spinning=false;this._trigger("stop",e)},_setOption:function(e,t){if(e==="culture"||e==="numberFormat"){var n=this._parse(this.element.val());this.options[e]=t;this.element.val(this._format(n));return}if(e==="max"||e==="min"||e==="step"){if(typeof t==="string"){t=this._parse(t)}}if(e==="icons"){this.buttons.first().find(".ui-icon").removeClass(this.options.icons.up).addClass(t.up);this.buttons.last().find(".ui-icon").removeClass(this.options.icons.down).addClass(t.down)}this._super(e,t);if(e==="disabled"){if(t){this.element.prop("disabled",true);this.buttons.button("disable")}else{this.element.prop("disabled",false);this.buttons.button("enable")}}},_setOptions:t(function(e){this._super(e);this._value(this.element.val())}),_parse:function(e){if(typeof e==="string"&&e!==""){e=window.Globalize&&this.options.numberFormat?Globalize.parseFloat(e,10,this.options.culture):+e}return e===""||isNaN(e)?null:e},_format:function(e){if(e===""){return""}return window.Globalize&&this.options.numberFormat?Globalize.format(e,this.options.numberFormat,this.options.culture):e},_refresh:function(){this.element.attr({"aria-valuemin":this.options.min,"aria-valuemax":this.options.max,"aria-valuenow":this._parse(this.element.val())})},_value:function(e,t){var n;if(e!==""){n=this._parse(e);if(n!==null){if(!t){n=this._adjustValue(n)}e=this._format(n)}}this.element.val(e);this._refresh()},_destroy:function(){this.element.removeClass("ui-spinner-input").prop("disabled",false).removeAttr("autocomplete").removeAttr("role").removeAttr("aria-valuemin").removeAttr("aria-valuemax").removeAttr("aria-valuenow");this.uiSpinner.replaceWith(this.element)},stepUp:t(function(e){this._stepUp(e)}),_stepUp:function(e){if(this._start()){this._spin((e||1)*this.options.step);this._stop()}},stepDown:t(function(e){this._stepDown(e)}),_stepDown:function(e){if(this._start()){this._spin((e||1)*-this.options.step);this._stop()}},pageUp:t(function(e){this._stepUp((e||1)*this.options.page)}),pageDown:t(function(e){this._stepDown((e||1)*this.options.page)}),value:function(e){if(!arguments.length){return this._parse(this.element.val())}t(this._value).call(this,e)},widget:function(){return this.uiSpinner}})})(jQuery);(function(e,t){function i(){return++n}function s(e){return e.hash.length>1&&decodeURIComponent(e.href.replace(r,""))===decodeURIComponent(location.href.replace(r,""))}var n=0,r=/#.*$/;e.widget("ui.tabs",{version:"1.10.3",delay:300,options:{active:null,collapsible:false,event:"click",heightStyle:"content",hide:null,show:null,activate:null,beforeActivate:null,beforeLoad:null,load:null},_create:function(){var t=this,n=this.options;this.running=false;this.element.addClass("ui-tabs ui-widget ui-widget-content ui-corner-all").toggleClass("ui-tabs-collapsible",n.collapsible).delegate(".ui-tabs-nav > li","mousedown"+this.eventNamespace,function(t){if(e(this).is(".ui-state-disabled")){t.preventDefault()}}).delegate(".ui-tabs-anchor","focus"+this.eventNamespace,function(){if(e(this).closest("li").is(".ui-state-disabled")){this.blur()}});this._processTabs();n.active=this._initialActive();if(e.isArray(n.disabled)){n.disabled=e.unique(n.disabled.concat(e.map(this.tabs.filter(".ui-state-disabled"),function(e){return t.tabs.index(e)}))).sort()}if(this.options.active!==false&&this.anchors.length){this.active=this._findActive(n.active)}else{this.active=e()}this._refresh();if(this.active.length){this.load(n.active)}},_initialActive:function(){var t=this.options.active,n=this.options.collapsible,r=location.hash.substring(1);if(t===null){if(r){this.tabs.each(function(n,i){if(e(i).attr("aria-controls")===r){t=n;return false}})}if(t===null){t=this.tabs.index(this.tabs.filter(".ui-tabs-active"))}if(t===null||t===-1){t=this.tabs.length?0:false}}if(t!==false){t=this.tabs.index(this.tabs.eq(t));if(t===-1){t=n?false:0}}if(!n&&t===false&&this.anchors.length){t=0}return t},_getCreateEventData:function(){return{tab:this.active,panel:!this.active.length?e():this._getPanelForTab(this.active)}},_tabKeydown:function(t){var n=e(this.document[0].activeElement).closest("li"),r=this.tabs.index(n),i=true;if(this._handlePageNav(t)){return}switch(t.keyCode){case e.ui.keyCode.RIGHT:case e.ui.keyCode.DOWN:r++;break;case e.ui.keyCode.UP:case e.ui.keyCode.LEFT:i=false;r--;break;case e.ui.keyCode.END:r=this.anchors.length-1;break;case e.ui.keyCode.HOME:r=0;break;case e.ui.keyCode.SPACE:t.preventDefault();clearTimeout(this.activating);this._activate(r);return;case e.ui.keyCode.ENTER:t.preventDefault();clearTimeout(this.activating);this._activate(r===this.options.active?false:r);return;default:return}t.preventDefault();clearTimeout(this.activating);r=this._focusNextTab(r,i);if(!t.ctrlKey){n.attr("aria-selected","false");this.tabs.eq(r).attr("aria-selected","true");this.activating=this._delay(function(){this.option("active",r)},this.delay)}},_panelKeydown:function(t){if(this._handlePageNav(t)){return}if(t.ctrlKey&&t.keyCode===e.ui.keyCode.UP){t.preventDefault();this.active.focus()}},_handlePageNav:function(t){if(t.altKey&&t.keyCode===e.ui.keyCode.PAGE_UP){this._activate(this._focusNextTab(this.options.active-1,false));return true}if(t.altKey&&t.keyCode===e.ui.keyCode.PAGE_DOWN){this._activate(this._focusNextTab(this.options.active+1,true));return true}},_findNextTab:function(t,n){function i(){if(t>r){t=0}if(t<0){t=r}return t}var r=this.tabs.length-1;while(e.inArray(i(),this.options.disabled)!==-1){t=n?t+1:t-1}return t},_focusNextTab:function(e,t){e=this._findNextTab(e,t);this.tabs.eq(e).focus();return e},_setOption:function(e,t){if(e==="active"){this._activate(t);return}if(e==="disabled"){this._setupDisabled(t);return}this._super(e,t);if(e==="collapsible"){this.element.toggleClass("ui-tabs-collapsible",t);if(!t&&this.options.active===false){this._activate(0)}}if(e==="event"){this._setupEvents(t)}if(e==="heightStyle"){this._setupHeightStyle(t)}},_tabId:function(e){return e.attr("aria-controls")||"ui-tabs-"+i()},_sanitizeSelector:function(e){return e?e.replace(/[!"$%&'()*+,.\/:;<=>?@\[\]\^`{|}~]/g,"\\$&"):""},refresh:function(){var t=this.options,n=this.tablist.children(":has(a[href])");t.disabled=e.map(n.filter(".ui-state-disabled"),function(e){return n.index(e)});this._processTabs();if(t.active===false||!this.anchors.length){t.active=false;this.active=e()}else if(this.active.length&&!e.contains(this.tablist[0],this.active[0])){if(this.tabs.length===t.disabled.length){t.active=false;this.active=e()}else{this._activate(this._findNextTab(Math.max(0,t.active-1),false))}}else{t.active=this.tabs.index(this.active)}this._refresh()},_refresh:function(){this._setupDisabled(this.options.disabled);this._setupEvents(this.options.event);this._setupHeightStyle(this.options.heightStyle);this.tabs.not(this.active).attr({"aria-selected":"false",tabIndex:-1});this.panels.not(this._getPanelForTab(this.active)).hide().attr({"aria-expanded":"false","aria-hidden":"true"});if(!this.active.length){this.tabs.eq(0).attr("tabIndex",0)}else{this.active.addClass("ui-tabs-active ui-state-active").attr({"aria-selected":"true",tabIndex:0});this._getPanelForTab(this.active).show().attr({"aria-expanded":"true","aria-hidden":"false"})}},_processTabs:function(){var t=this;this.tablist=this._getList().addClass("ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all").attr("role","tablist");this.tabs=this.tablist.find("> li:has(a[href])").addClass("ui-state-default ui-corner-top").attr({role:"tab",tabIndex:-1});this.anchors=this.tabs.map(function(){return e("a",this)[0]}).addClass("ui-tabs-anchor").attr({role:"presentation",tabIndex:-1});this.panels=e();this.anchors.each(function(n,r){var i,o,u,a=e(r).uniqueId().attr("id"),f=e(r).closest("li"),l=f.attr("aria-controls");if(s(r)){i=r.hash;o=t.element.find(t._sanitizeSelector(i))}else{u=t._tabId(f);i="#"+u;o=t.element.find(i);if(!o.length){o=t._createPanel(u);o.insertAfter(t.panels[n-1]||t.tablist)}o.attr("aria-live","polite")}if(o.length){t.panels=t.panels.add(o)}if(l){f.data("ui-tabs-aria-controls",l)}f.attr({"aria-controls":i.substring(1),"aria-labelledby":a});o.attr("aria-labelledby",a)});this.panels.addClass("ui-tabs-panel ui-widget-content ui-corner-bottom").attr("role","tabpanel")},_getList:function(){return this.element.find("ol,ul").eq(0)},_createPanel:function(t){return e("<div>").attr("id",t).addClass("ui-tabs-panel ui-widget-content ui-corner-bottom").data("ui-tabs-destroy",true)},_setupDisabled:function(t){if(e.isArray(t)){if(!t.length){t=false}else if(t.length===this.anchors.length){t=true}}for(var n=0,r;r=this.tabs[n];n++){if(t===true||e.inArray(n,t)!==-1){e(r).addClass("ui-state-disabled").attr("aria-disabled","true")}else{e(r).removeClass("ui-state-disabled").removeAttr("aria-disabled")}}this.options.disabled=t},_setupEvents:function(t){var n={click:function(e){e.preventDefault()}};if(t){e.each(t.split(" "),function(e,t){n[t]="_eventHandler"})}this._off(this.anchors.add(this.tabs).add(this.panels));this._on(this.anchors,n);this._on(this.tabs,{keydown:"_tabKeydown"});this._on(this.panels,{keydown:"_panelKeydown"});this._focusable(this.tabs);this._hoverable(this.tabs)},_setupHeightStyle:function(t){var n,r=this.element.parent();if(t==="fill"){n=r.height();n-=this.element.outerHeight()-this.element.height();this.element.siblings(":visible").each(function(){var t=e(this),r=t.css("position");if(r==="absolute"||r==="fixed"){return}n-=t.outerHeight(true)});this.element.children().not(this.panels).each(function(){n-=e(this).outerHeight(true)});this.panels.each(function(){e(this).height(Math.max(0,n-e(this).innerHeight()+e(this).height()))}).css("overflow","auto")}else if(t==="auto"){n=0;this.panels.each(function(){n=Math.max(n,e(this).height("").height())}).height(n)}},_eventHandler:function(t){var n=this.options,r=this.active,i=e(t.currentTarget),s=i.closest("li"),o=s[0]===r[0],u=o&&n.collapsible,a=u?e():this._getPanelForTab(s),f=!r.length?e():this._getPanelForTab(r),l={oldTab:r,oldPanel:f,newTab:u?e():s,newPanel:a};t.preventDefault();if(s.hasClass("ui-state-disabled")||s.hasClass("ui-tabs-loading")||this.running||o&&!n.collapsible||this._trigger("beforeActivate",t,l)===false){return}n.active=u?false:this.tabs.index(s);this.active=o?e():s;if(this.xhr){this.xhr.abort()}if(!f.length&&!a.length){e.error("jQuery UI Tabs: Mismatching fragment identifier.")}if(a.length){this.load(this.tabs.index(s),t)}this._toggle(t,l)},_toggle:function(t,n){function o(){r.running=false;r._trigger("activate",t,n)}function u(){n.newTab.closest("li").addClass("ui-tabs-active ui-state-active");if(i.length&&r.options.show){r._show(i,r.options.show,o)}else{i.show();o()}}var r=this,i=n.newPanel,s=n.oldPanel;this.running=true;if(s.length&&this.options.hide){this._hide(s,this.options.hide,function(){n.oldTab.closest("li").removeClass("ui-tabs-active ui-state-active");u()})}else{n.oldTab.closest("li").removeClass("ui-tabs-active ui-state-active");s.hide();u()}s.attr({"aria-expanded":"false","aria-hidden":"true"});n.oldTab.attr("aria-selected","false");if(i.length&&s.length){n.oldTab.attr("tabIndex",-1)}else if(i.length){this.tabs.filter(function(){return e(this).attr("tabIndex")===0}).attr("tabIndex",-1)}i.attr({"aria-expanded":"true","aria-hidden":"false"});n.newTab.attr({"aria-selected":"true",tabIndex:0})},_activate:function(t){var n,r=this._findActive(t);if(r[0]===this.active[0]){return}if(!r.length){r=this.active}n=r.find(".ui-tabs-anchor")[0];this._eventHandler({target:n,currentTarget:n,preventDefault:e.noop})},_findActive:function(t){return t===false?e():this.tabs.eq(t)},_getIndex:function(e){if(typeof e==="string"){e=this.anchors.index(this.anchors.filter("[href$='"+e+"']"))}return e},_destroy:function(){if(this.xhr){this.xhr.abort()}this.element.removeClass("ui-tabs ui-widget ui-widget-content ui-corner-all ui-tabs-collapsible");this.tablist.removeClass("ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all").removeAttr("role");this.anchors.removeClass("ui-tabs-anchor").removeAttr("role").removeAttr("tabIndex").removeUniqueId();this.tabs.add(this.panels).each(function(){if(e.data(this,"ui-tabs-destroy")){e(this).remove()}else{e(this).removeClass("ui-state-default ui-state-active ui-state-disabled "+"ui-corner-top ui-corner-bottom ui-widget-content ui-tabs-active ui-tabs-panel").removeAttr("tabIndex").removeAttr("aria-live").removeAttr("aria-busy").removeAttr("aria-selected").removeAttr("aria-labelledby").removeAttr("aria-hidden").removeAttr("aria-expanded").removeAttr("role")}});this.tabs.each(function(){var t=e(this),n=t.data("ui-tabs-aria-controls");if(n){t.attr("aria-controls",n).removeData("ui-tabs-aria-controls")}else{t.removeAttr("aria-controls")}});this.panels.show();if(this.options.heightStyle!=="content"){this.panels.css("height","")}},enable:function(n){var r=this.options.disabled;if(r===false){return}if(n===t){r=false}else{n=this._getIndex(n);if(e.isArray(r)){r=e.map(r,function(e){return e!==n?e:null})}else{r=e.map(this.tabs,function(e,t){return t!==n?t:null})}}this._setupDisabled(r)},disable:function(n){var r=this.options.disabled;if(r===true){return}if(n===t){r=true}else{n=this._getIndex(n);if(e.inArray(n,r)!==-1){return}if(e.isArray(r)){r=e.merge([n],r).sort()}else{r=[n]}}this._setupDisabled(r)},load:function(t,n){t=this._getIndex(t);var r=this,i=this.tabs.eq(t),o=i.find(".ui-tabs-anchor"),u=this._getPanelForTab(i),a={tab:i,panel:u};if(s(o[0])){return}this.xhr=e.ajax(this._ajaxSettings(o,n,a));if(this.xhr&&this.xhr.statusText!=="canceled"){i.addClass("ui-tabs-loading");u.attr("aria-busy","true");this.xhr.success(function(e){setTimeout(function(){u.html(e);r._trigger("load",n,a)},1)}).complete(function(e,t){setTimeout(function(){if(t==="abort"){r.panels.stop(false,true)}i.removeClass("ui-tabs-loading");u.removeAttr("aria-busy");if(e===r.xhr){delete r.xhr}},1)})}},_ajaxSettings:function(t,n,r){var i=this;return{url:t.attr("href"),beforeSend:function(t,s){return i._trigger("beforeLoad",n,e.extend({jqXHR:t,ajaxSettings:s},r))}}},_getPanelForTab:function(t){var n=e(t).attr("aria-controls");return this.element.find(this._sanitizeSelector("#"+n))}})})(jQuery);(function(e){function n(t,n){var r=(t.attr("aria-describedby")||"").split(/\s+/);r.push(n);t.data("ui-tooltip-id",n).attr("aria-describedby",e.trim(r.join(" ")))}function r(t){var n=t.data("ui-tooltip-id"),r=(t.attr("aria-describedby")||"").split(/\s+/),i=e.inArray(n,r);if(i!==-1){r.splice(i,1)}t.removeData("ui-tooltip-id");r=e.trim(r.join(" "));if(r){t.attr("aria-describedby",r)}else{t.removeAttr("aria-describedby")}}var t=0;e.widget("ui.tooltip",{version:"1.10.3",options:{content:function(){var t=e(this).attr("title")||"";return e("<a>").text(t).html()},hide:true,items:"[title]:not([disabled])",position:{my:"left top+15",at:"left bottom",collision:"flipfit flip"},show:true,tooltipClass:null,track:false,close:null,open:null},_create:function(){this._on({mouseover:"open",focusin:"open"});this.tooltips={};this.parents={};if(this.options.disabled){this._disable()}},_setOption:function(t,n){var r=this;if(t==="disabled"){this[n?"_disable":"_enable"]();this.options[t]=n;return}this._super(t,n);if(t==="content"){e.each(this.tooltips,function(e,t){r._updateContent(t)})}},_disable:function(){var t=this;e.each(this.tooltips,function(n,r){var i=e.Event("blur");i.target=i.currentTarget=r[0];t.close(i,true)});this.element.find(this.options.items).addBack().each(function(){var t=e(this);if(t.is("[title]")){t.data("ui-tooltip-title",t.attr("title")).attr("title","")}})},_enable:function(){this.element.find(this.options.items).addBack().each(function(){var t=e(this);if(t.data("ui-tooltip-title")){t.attr("title",t.data("ui-tooltip-title"))}})},open:function(t){var n=this,r=e(t?t.target:this.element).closest(this.options.items);if(!r.length||r.data("ui-tooltip-id")){return}if(r.attr("title")){r.data("ui-tooltip-title",r.attr("title"))}r.data("ui-tooltip-open",true);if(t&&t.type==="mouseover"){r.parents().each(function(){var t=e(this),r;if(t.data("ui-tooltip-open")){r=e.Event("blur");r.target=r.currentTarget=this;n.close(r,true)}if(t.attr("title")){t.uniqueId();n.parents[this.id]={element:this,title:t.attr("title")};t.attr("title","")}})}this._updateContent(r,t)},_updateContent:function(e,t){var n,r=this.options.content,i=this,s=t?t.type:null;if(typeof r==="string"){return this._open(t,e,r)}n=r.call(e[0],function(n){if(!e.data("ui-tooltip-open")){return}i._delay(function(){if(t){t.type=s}this._open(t,e,n)})});if(n){this._open(t,e,n)}},_open:function(t,r,i){function f(e){a.of=e;if(s.is(":hidden")){return}s.position(a)}var s,o,u,a=e.extend({},this.options.position);if(!i){return}s=this._find(r);if(s.length){s.find(".ui-tooltip-content").html(i);return}if(r.is("[title]")){if(t&&t.type==="mouseover"){r.attr("title","")}else{r.removeAttr("title")}}s=this._tooltip(r);n(r,s.attr("id"));s.find(".ui-tooltip-content").html(i);if(this.options.track&&t&&/^mouse/.test(t.type)){this._on(this.document,{mousemove:f});f(t)}else{s.position(e.extend({of:r},this.options.position))}s.hide();this._show(s,this.options.show);if(this.options.show&&this.options.show.delay){u=this.delayedShow=setInterval(function(){if(s.is(":visible")){f(a.of);clearInterval(u)}},e.fx.interval)}this._trigger("open",t,{tooltip:s});o={keyup:function(t){if(t.keyCode===e.ui.keyCode.ESCAPE){var n=e.Event(t);n.currentTarget=r[0];this.close(n,true)}},remove:function(){this._removeTooltip(s)}};if(!t||t.type==="mouseover"){o.mouseleave="close"}if(!t||t.type==="focusin"){o.focusout="close"}this._on(true,r,o)},close:function(t){var n=this,i=e(t?t.currentTarget:this.element),s=this._find(i);if(this.closing){return}clearInterval(this.delayedShow);if(i.data("ui-tooltip-title")){i.attr("title",i.data("ui-tooltip-title"))}r(i);s.stop(true);this._hide(s,this.options.hide,function(){n._removeTooltip(e(this))});i.removeData("ui-tooltip-open");this._off(i,"mouseleave focusout keyup");if(i[0]!==this.element[0]){this._off(i,"remove")}this._off(this.document,"mousemove");if(t&&t.type==="mouseleave"){e.each(this.parents,function(t,r){e(r.element).attr("title",r.title);delete n.parents[t]})}this.closing=true;this._trigger("close",t,{tooltip:s});this.closing=false},_tooltip:function(n){var r="ui-tooltip-"+t++,i=e("<div>").attr({id:r,role:"tooltip"}).addClass("ui-tooltip ui-widget ui-corner-all ui-widget-content "+(this.options.tooltipClass||""));e("<div>").addClass("ui-tooltip-content").appendTo(i);i.appendTo(this.document[0].body);this.tooltips[r]=n;return i},_find:function(t){var n=t.data("ui-tooltip-id");return n?e("#"+n):e()},_removeTooltip:function(e){e.remove();delete this.tooltips[e.attr("id")]},_destroy:function(){var t=this;e.each(this.tooltips,function(n,r){var i=e.Event("blur");i.target=i.currentTarget=r[0];t.close(i,true);e("#"+n).remove();if(r.data("ui-tooltip-title")){r.attr("title",r.data("ui-tooltip-title"));r.removeData("ui-tooltip-title")}})}})})(jQuery);
/* Jquery UI Ends */

/*!
 * jQuery Migrate - v1.1.1 - 2013-02-16
 * https://github.com/jquery/jquery-migrate
 * Copyright 2005, 2013 jQuery Foundation, Inc. and other contributors; Licensed MIT
 */
(function( jQuery, window, undefined ) {
// See http://bugs.jquery.com/ticket/13335
// "use strict";


var warnedAbout = {};

// List of warnings already given; public read only
jQuery.migrateWarnings = [];

// Set to true to prevent console output; migrateWarnings still maintained
// jQuery.migrateMute = false;

// Show a message on the console so devs know we're active
if ( !jQuery.migrateMute && window.console && console.log ) {
	console.log("JQMIGRATE: $p33dy is active");
}

// Set to false to disable traces that appear with warnings
if ( jQuery.migrateTrace === undefined ) {
	jQuery.migrateTrace = true;
}

// Forget any warnings we've already given; public
jQuery.migrateReset = function() {
	warnedAbout = {};
	jQuery.migrateWarnings.length = 0;
};

function migrateWarn( msg) {
	if ( !warnedAbout[ msg ] ) {
		warnedAbout[ msg ] = true;
		jQuery.migrateWarnings.push( msg );
		if ( window.console && console.warn && !jQuery.migrateMute ) {
			console.warn( "JQMIGRATE: " + msg );
			if ( jQuery.migrateTrace && console.trace ) {
				console.trace();
			}
		}
	}
}

function migrateWarnProp( obj, prop, value, msg ) {
	if ( Object.defineProperty ) {
		// On ES5 browsers (non-oldIE), warn if the code tries to get prop;
		// allow property to be overwritten in case some other plugin wants it
		try {
			Object.defineProperty( obj, prop, {
				configurable: true,
				enumerable: true,
				get: function() {
					migrateWarn( msg );
					return value;
				},
				set: function( newValue ) {
					migrateWarn( msg );
					value = newValue;
				}
			});
			return;
		} catch( err ) {
			// IE8 is a dope about Object.defineProperty, can't warn there
		}
	}

	// Non-ES5 (or broken) browser; just set the property
	jQuery._definePropertyBroken = true;
	obj[ prop ] = value;
}

if ( document.compatMode === "BackCompat" ) {
	// jQuery has never supported or tested Quirks Mode
	migrateWarn( "jQuery is not compatible with Quirks Mode" );
}


var attrFn = jQuery( "<input/>", { size: 1 } ).attr("size") && jQuery.attrFn,
	oldAttr = jQuery.attr,
	valueAttrGet = jQuery.attrHooks.value && jQuery.attrHooks.value.get ||
		function() { return null; },
	valueAttrSet = jQuery.attrHooks.value && jQuery.attrHooks.value.set ||
		function() { return undefined; },
	rnoType = /^(?:input|button)$/i,
	rnoAttrNodeType = /^[238]$/,
	rboolean = /^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i,
	ruseDefault = /^(?:checked|selected)$/i;

// jQuery.attrFn
migrateWarnProp( jQuery, "attrFn", attrFn || {}, "jQuery.attrFn is deprecated" );

jQuery.attr = function( elem, name, value, pass ) {
	var lowerName = name.toLowerCase(),
		nType = elem && elem.nodeType;

	if ( pass ) {
		// Since pass is used internally, we only warn for new jQuery
		// versions where there isn't a pass arg in the formal params
		if ( oldAttr.length < 4 ) {
			migrateWarn("jQuery.fn.attr( props, pass ) is deprecated");
		}
		if ( elem && !rnoAttrNodeType.test( nType ) &&
			(attrFn ? name in attrFn : jQuery.isFunction(jQuery.fn[name])) ) {
			return jQuery( elem )[ name ]( value );
		}
	}

	// Warn if user tries to set `type`, since it breaks on IE 6/7/8; by checking
	// for disconnected elements we don't warn on $( "<button>", { type: "button" } ).
	if ( name === "type" && value !== undefined && rnoType.test( elem.nodeName ) && elem.parentNode ) {
		migrateWarn("Can't change the 'type' of an input or button in IE 6/7/8");
	}

	// Restore boolHook for boolean property/attribute synchronization
	if ( !jQuery.attrHooks[ lowerName ] && rboolean.test( lowerName ) ) {
		jQuery.attrHooks[ lowerName ] = {
			get: function( elem, name ) {
				// Align boolean attributes with corresponding properties
				// Fall back to attribute presence where some booleans are not supported
				var attrNode,
					property = jQuery.prop( elem, name );
				return property === true || typeof property !== "boolean" &&
					( attrNode = elem.getAttributeNode(name) ) && attrNode.nodeValue !== false ?

					name.toLowerCase() :
					undefined;
			},
			set: function( elem, value, name ) {
				var propName;
				if ( value === false ) {
					// Remove boolean attributes when set to false
					jQuery.removeAttr( elem, name );
				} else {
					// value is true since we know at this point it's type boolean and not false
					// Set boolean attributes to the same name and set the DOM property
					propName = jQuery.propFix[ name ] || name;
					if ( propName in elem ) {
						// Only set the IDL specifically if it already exists on the element
						elem[ propName ] = true;
					}

					elem.setAttribute( name, name.toLowerCase() );
				}
				return name;
			}
		};

		// Warn only for attributes that can remain distinct from their properties post-1.9
		if ( ruseDefault.test( lowerName ) ) {
			migrateWarn( "jQuery.fn.attr('" + lowerName + "') may use property instead of attribute" );
		}
	}

	return oldAttr.call( jQuery, elem, name, value );
};

// attrHooks: value
jQuery.attrHooks.value = {
	get: function( elem, name ) {
		var nodeName = ( elem.nodeName || "" ).toLowerCase();
		if ( nodeName === "button" ) {
			return valueAttrGet.apply( this, arguments );
		}
		if ( nodeName !== "input" && nodeName !== "option" ) {
			migrateWarn("jQuery.fn.attr('value') no longer gets properties");
		}
		return name in elem ?
			elem.value :
			null;
	},
	set: function( elem, value ) {
		var nodeName = ( elem.nodeName || "" ).toLowerCase();
		if ( nodeName === "button" ) {
			return valueAttrSet.apply( this, arguments );
		}
		if ( nodeName !== "input" && nodeName !== "option" ) {
			migrateWarn("jQuery.fn.attr('value', val) no longer sets properties");
		}
		// Does not return so that setAttribute is also used
		elem.value = value;
	}
};


var matched, browser,
	oldInit = jQuery.fn.init,
	oldParseJSON = jQuery.parseJSON,
	// Note this does NOT include the #9521 XSS fix from 1.7!
	rquickExpr = /^(?:[^<]*(<[\w\W]+>)[^>]*|#([\w\-]*))$/;

// $(html) "looks like html" rule change
jQuery.fn.init = function( selector, context, rootjQuery ) {
	var match;

	if ( selector && typeof selector === "string" && !jQuery.isPlainObject( context ) &&
			(match = rquickExpr.exec( selector )) && match[1] ) {
		// This is an HTML string according to the "old" rules; is it still?
		if ( selector.charAt( 0 ) !== "<" ) {
			migrateWarn("$(html) HTML strings must start with '<' character");
		}
		// Now process using loose rules; let pre-1.8 play too
		if ( context && context.context ) {
			// jQuery object as context; parseHTML expects a DOM object
			context = context.context;
		}
		if ( jQuery.parseHTML ) {
			return oldInit.call( this, jQuery.parseHTML( jQuery.trim(selector), context, true ),
					context, rootjQuery );
		}
	}
	return oldInit.apply( this, arguments );
};
jQuery.fn.init.prototype = jQuery.fn;

// Let $.parseJSON(falsy_value) return null
jQuery.parseJSON = function( json ) {
	if ( !json && json !== null ) {
		migrateWarn("jQuery.parseJSON requires a valid JSON string");
		return null;
	}
	return oldParseJSON.apply( this, arguments );
};

jQuery.uaMatch = function( ua ) {
	ua = ua.toLowerCase();

	var match = /(chrome)[ \/]([\w.]+)/.exec( ua ) ||
		/(webkit)[ \/]([\w.]+)/.exec( ua ) ||
		/(opera)(?:.*version|)[ \/]([\w.]+)/.exec( ua ) ||
		/(msie) ([\w.]+)/.exec( ua ) ||
		ua.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec( ua ) ||
		[];

	return {
		browser: match[ 1 ] || "",
		version: match[ 2 ] || "0"
	};
};

// Don't clobber any existing jQuery.browser in case it's different
if ( !jQuery.browser ) {
	matched = jQuery.uaMatch( navigator.userAgent );
	browser = {};

	if ( matched.browser ) {
		browser[ matched.browser ] = true;
		browser.version = matched.version;
	}

	// Chrome is Webkit, but Webkit is also Safari.
	if ( browser.chrome ) {
		browser.webkit = true;
	} else if ( browser.webkit ) {
		browser.safari = true;
	}

	jQuery.browser = browser;
}

// Warn if the code tries to get jQuery.browser
migrateWarnProp( jQuery, "browser", jQuery.browser, "jQuery.browser is deprecated" );

jQuery.sub = function() {
	function jQuerySub( selector, context ) {
		return new jQuerySub.fn.init( selector, context );
	}
	jQuery.extend( true, jQuerySub, this );
	jQuerySub.superclass = this;
	jQuerySub.fn = jQuerySub.prototype = this();
	jQuerySub.fn.constructor = jQuerySub;
	jQuerySub.sub = this.sub;
	jQuerySub.fn.init = function init( selector, context ) {
		if ( context && context instanceof jQuery && !(context instanceof jQuerySub) ) {
			context = jQuerySub( context );
		}

		return jQuery.fn.init.call( this, selector, context, rootjQuerySub );
	};
	jQuerySub.fn.init.prototype = jQuerySub.fn;
	var rootjQuerySub = jQuerySub(document);
	migrateWarn( "jQuery.sub() is deprecated" );
	return jQuerySub;
};


// Ensure that $.ajax gets the new parseJSON defined in core.js
jQuery.ajaxSetup({
	converters: {
		"text json": jQuery.parseJSON
	}
});


var oldFnData = jQuery.fn.data;

jQuery.fn.data = function( name ) {
	var ret, evt,
		elem = this[0];

	// Handles 1.7 which has this behavior and 1.8 which doesn't
	if ( elem && name === "events" && arguments.length === 1 ) {
		ret = jQuery.data( elem, name );
		evt = jQuery._data( elem, name );
		if ( ( ret === undefined || ret === evt ) && evt !== undefined ) {
			migrateWarn("Use of jQuery.fn.data('events') is deprecated");
			return evt;
		}
	}
	return oldFnData.apply( this, arguments );
};


var rscriptType = /\/(java|ecma)script/i,
	oldSelf = jQuery.fn.andSelf || jQuery.fn.addBack;

jQuery.fn.andSelf = function() {
	migrateWarn("jQuery.fn.andSelf() replaced by jQuery.fn.addBack()");
	return oldSelf.apply( this, arguments );
};

// Since jQuery.clean is used internally on older versions, we only shim if it's missing
if ( !jQuery.clean ) {
	jQuery.clean = function( elems, context, fragment, scripts ) {
		// Set context per 1.8 logic
		context = context || document;
		context = !context.nodeType && context[0] || context;
		context = context.ownerDocument || context;

		migrateWarn("jQuery.clean() is deprecated");

		var i, elem, handleScript, jsTags,
			ret = [];

		jQuery.merge( ret, jQuery.buildFragment( elems, context ).childNodes );

		// Complex logic lifted directly from jQuery 1.8
		if ( fragment ) {
			// Special handling of each script element
			handleScript = function( elem ) {
				// Check if we consider it executable
				if ( !elem.type || rscriptType.test( elem.type ) ) {
					// Detach the script and store it in the scripts array (if provided) or the fragment
					// Return truthy to indicate that it has been handled
					return scripts ?
						scripts.push( elem.parentNode ? elem.parentNode.removeChild( elem ) : elem ) :
						fragment.appendChild( elem );
				}
			};

			for ( i = 0; (elem = ret[i]) != null; i++ ) {
				// Check if we're done after handling an executable script
				if ( !( jQuery.nodeName( elem, "script" ) && handleScript( elem ) ) ) {
					// Append to fragment and handle embedded scripts
					fragment.appendChild( elem );
					if ( typeof elem.getElementsByTagName !== "undefined" ) {
						// handleScript alters the DOM, so use jQuery.merge to ensure snapshot iteration
						jsTags = jQuery.grep( jQuery.merge( [], elem.getElementsByTagName("script") ), handleScript );

						// Splice the scripts into ret after their former ancestor and advance our index beyond them
						ret.splice.apply( ret, [i + 1, 0].concat( jsTags ) );
						i += jsTags.length;
					}
				}
			}
		}

		return ret;
	};
}

var eventAdd = jQuery.event.add,
	eventRemove = jQuery.event.remove,
	eventTrigger = jQuery.event.trigger,
	oldToggle = jQuery.fn.toggle,
	oldLive = jQuery.fn.live,
	oldDie = jQuery.fn.die,
	ajaxEvents = "ajaxStart|ajaxStop|ajaxSend|ajaxComplete|ajaxError|ajaxSuccess",
	rajaxEvent = new RegExp( "\\b(?:" + ajaxEvents + ")\\b" ),
	rhoverHack = /(?:^|\s)hover(\.\S+|)\b/,
	hoverHack = function( events ) {
		if ( typeof( events ) !== "string" || jQuery.event.special.hover ) {
			return events;
		}
		if ( rhoverHack.test( events ) ) {
			migrateWarn("'hover' pseudo-event is deprecated, use 'mouseenter mouseleave'");
		}
		return events && events.replace( rhoverHack, "mouseenter$1 mouseleave$1" );
	};

// Event props removed in 1.9, put them back if needed; no practical way to warn them
if ( jQuery.event.props && jQuery.event.props[ 0 ] !== "attrChange" ) {
	jQuery.event.props.unshift( "attrChange", "attrName", "relatedNode", "srcElement" );
}

// Undocumented jQuery.event.handle was "deprecated" in jQuery 1.7
if ( jQuery.event.dispatch ) {
	migrateWarnProp( jQuery.event, "handle", jQuery.event.dispatch, "jQuery.event.handle is undocumented and deprecated" );
}

// Support for 'hover' pseudo-event and ajax event warnings
jQuery.event.add = function( elem, types, handler, data, selector ){
	if ( elem !== document && rajaxEvent.test( types ) ) {
		migrateWarn( "AJAX events should be attached to document: " + types );
	}
	eventAdd.call( this, elem, hoverHack( types || "" ), handler, data, selector );
};
jQuery.event.remove = function( elem, types, handler, selector, mappedTypes ){
	eventRemove.call( this, elem, hoverHack( types ) || "", handler, selector, mappedTypes );
};

jQuery.fn.error = function() {
	var args = Array.prototype.slice.call( arguments, 0);
	migrateWarn("jQuery.fn.error() is deprecated");
	args.splice( 0, 0, "error" );
	if ( arguments.length ) {
		return this.bind.apply( this, args );
	}
	// error event should not bubble to window, although it does pre-1.7
	this.triggerHandler.apply( this, args );
	return this;
};

jQuery.fn.toggle = function( fn, fn2 ) {

	// Don't mess with animation or css toggles
	if ( !jQuery.isFunction( fn ) || !jQuery.isFunction( fn2 ) ) {
		return oldToggle.apply( this, arguments );
	}
	migrateWarn("jQuery.fn.toggle(handler, handler...) is deprecated");

	// Save reference to arguments for access in closure
	var args = arguments,
		guid = fn.guid || jQuery.guid++,
		i = 0,
		toggler = function( event ) {
			// Figure out which function to execute
			var lastToggle = ( jQuery._data( this, "lastToggle" + fn.guid ) || 0 ) % i;
			jQuery._data( this, "lastToggle" + fn.guid, lastToggle + 1 );

			// Make sure that clicks stop
			event.preventDefault();

			// and execute the function
			return args[ lastToggle ].apply( this, arguments ) || false;
		};

	// link all the functions, so any of them can unbind this click handler
	toggler.guid = guid;
	while ( i < args.length ) {
		args[ i++ ].guid = guid;
	}

	return this.click( toggler );
};

jQuery.fn.live = function( types, data, fn ) {
	migrateWarn("jQuery.fn.live() is deprecated");
	if ( oldLive ) {
		return oldLive.apply( this, arguments );
	}
	jQuery( this.context ).on( types, this.selector, data, fn );
	return this;
};

jQuery.fn.die = function( types, fn ) {
	migrateWarn("jQuery.fn.die() is deprecated");
	if ( oldDie ) {
		return oldDie.apply( this, arguments );
	}
	jQuery( this.context ).off( types, this.selector || "**", fn );
	return this;
};

// Turn global events into document-triggered events
jQuery.event.trigger = function( event, data, elem, onlyHandlers  ){
	if ( !elem && !rajaxEvent.test( event ) ) {
		migrateWarn( "Global events are undocumented and deprecated" );
	}
	return eventTrigger.call( this,  event, data, elem || document, onlyHandlers  );
};
jQuery.each( ajaxEvents.split("|"),
	function( _, name ) {
		jQuery.event.special[ name ] = {
			setup: function() {
				var elem = this;

				// The document needs no shimming; must be !== for oldIE
				if ( elem !== document ) {
					jQuery.event.add( document, name + "." + jQuery.guid, function() {
						jQuery.event.trigger( name, null, elem, true );

					});
					jQuery._data( this, name, jQuery.guid++ );
				}
				return false;
			},
			teardown: function() {
				if ( this !== document ) {
					jQuery.event.remove( document, name + "." + jQuery._data( this, name ) );
				}
				return false;
			}
		};
	}
);


})( jQuery, window );

/* Perfect Scroll */
"use strict";(function(e){if(typeof define==="function"&&define.amd){define(["jquery"],e)}else{e(jQuery)}})(function(e){var t={wheelSpeed:10,wheelPropagation:false,minScrollbarLength:null,useBothWheelAxes:true,useKeyboard:true,suppressScrollX:false,suppressScrollY:false,scrollXMarginOffset:0,scrollYMarginOffset:0};var n=function(){var e=0;return function(){var t=e;e+=1;return".perfect-scrollbar-"+t}}();e.fn.perfectScrollbar=function(r,i){return this.each(function(){var s=e.extend(true,{},t),o=e(this);if(typeof r==="object"){e.extend(true,s,r)}else{i=r}if(i==="update"){if(o.data("perfect-scrollbar-update")){o.data("perfect-scrollbar-update")()}return o}else if(i==="destroy"){if(o.data("perfect-scrollbar-destroy")){o.data("perfect-scrollbar-destroy")()}return o}if(o.data("perfect-scrollbar")){return o.data("perfect-scrollbar")}o.addClass("ps-container");var u=e("<div class='ps-scrollbar-x-rail'></div>").appendTo(o),a=e("<div class='ps-scrollbar-y-rail'></div>").appendTo(o),f=e("<div class='ps-scrollbar-x'></div>").appendTo(u),l=e("<div class='ps-scrollbar-y'></div>").appendTo(a),c,h,p,d,v,m,g,y,b=parseInt(u.css("bottom"),10),w,E,S=parseInt(a.css("right"),10),x=n();var T=function(e,t){var n=e+t,r=d-w;if(n<0){E=0}else if(n>r){E=r}else{E=n}var i=parseInt(E*(m-d)/(d-w),10);o.scrollTop(i);u.css({bottom:b-i})};var N=function(e,t){var n=e+t,r=p-g;if(n<0){y=0}else if(n>r){y=r}else{y=n}var i=parseInt(y*(v-p)/(p-g),10);o.scrollLeft(i);a.css({right:S-i})};var C=function(e){if(s.minScrollbarLength){e=Math.max(e,s.minScrollbarLength)}return e};var k=function(){u.css({left:o.scrollLeft(),bottom:b-o.scrollTop(),width:p,display:s.suppressScrollX?"none":"inherit"});a.css({top:o.scrollTop(),right:S-o.scrollLeft(),height:d,display:s.suppressScrollY?"none":"inherit"});f.css({left:y,width:g});l.css({top:E,height:w})};var L=function(){p=o.width();d=o.height();v=o.prop("scrollWidth");m=o.prop("scrollHeight");if(!s.suppressScrollX&&p+s.scrollXMarginOffset<v){c=true;g=C(parseInt(p*p/v,10));y=parseInt(o.scrollLeft()*(p-g)/(v-p),10)}else{c=false;g=0;y=0;o.scrollLeft(0)}if(!s.suppressScrollY&&d+s.scrollYMarginOffset<m){h=true;w=C(parseInt(d*d/m,10));E=parseInt(o.scrollTop()*(d-w)/(m-d),10)}else{h=false;w=0;E=0;o.scrollTop(0)}if(E>=d-w){E=d-w}if(y>=p-g){y=p-g}k()};var A=function(){var t,n;f.bind("mousedown"+x,function(e){n=e.pageX;t=f.position().left;u.addClass("in-scrolling");e.stopPropagation();e.preventDefault()});e(document).bind("mousemove"+x,function(e){if(u.hasClass("in-scrolling")){N(t,e.pageX-n);e.stopPropagation();e.preventDefault()}});e(document).bind("mouseup"+x,function(e){if(u.hasClass("in-scrolling")){u.removeClass("in-scrolling")}});t=n=null};var O=function(){var t,n;l.bind("mousedown"+x,function(e){n=e.pageY;t=l.position().top;a.addClass("in-scrolling");e.stopPropagation();e.preventDefault()});e(document).bind("mousemove"+x,function(e){if(a.hasClass("in-scrolling")){T(t,e.pageY-n);e.stopPropagation();e.preventDefault()}});e(document).bind("mouseup"+x,function(e){if(a.hasClass("in-scrolling")){a.removeClass("in-scrolling")}});t=n=null};var M=function(e,t){var n=o.scrollTop();if(e===0){if(!h){return false}if(n===0&&t>0||n>=m-d&&t<0){return!s.wheelPropagation}}var r=o.scrollLeft();if(t===0){if(!c){return false}if(r===0&&e<0||r>=v-p&&e>0){return!s.wheelPropagation}}return true};var _=function(){var e=false;o.bind("mousewheel"+x,function(t,n,r,i){if(!s.useBothWheelAxes){o.scrollTop(o.scrollTop()-i*s.wheelSpeed);o.scrollLeft(o.scrollLeft()+r*s.wheelSpeed)}else if(h&&!c){if(i){o.scrollTop(o.scrollTop()-i*s.wheelSpeed)}else{o.scrollTop(o.scrollTop()+r*s.wheelSpeed)}}else if(c&&!h){if(r){o.scrollLeft(o.scrollLeft()+r*s.wheelSpeed)}else{o.scrollLeft(o.scrollLeft()-i*s.wheelSpeed)}}L();e=M(r,i);if(e){t.preventDefault()}});o.bind("MozMousePixelScroll"+x,function(t){if(e){t.preventDefault()}})};var D=function(){var t=false;o.bind("mouseenter"+x,function(e){t=true});o.bind("mouseleave"+x,function(e){t=false});var n=false;e(document).bind("keydown"+x,function(e){if(!t){return}var r=0,i=0;switch(e.which){case 37:r=-3;break;case 38:i=3;break;case 39:r=3;break;case 40:i=-3;break;case 33:i=9;break;case 32:case 34:i=-9;break;case 35:i=-d;break;case 36:i=d;break;default:return}o.scrollTop(o.scrollTop()-i*s.wheelSpeed);o.scrollLeft(o.scrollLeft()+r*s.wheelSpeed);n=M(r,i);if(n){e.preventDefault()}})};var P=function(){var e=function(e){e.stopPropagation()};l.bind("click"+x,e);a.bind("click"+x,function(e){var t=parseInt(w/2,10),n=e.pageY-a.offset().top-t,r=d-w,i=n/r;if(i<0){i=0}else if(i>1){i=1}o.scrollTop((m-d)*i)});f.bind("click"+x,e);u.bind("click"+x,function(e){var t=parseInt(g/2,10),n=e.pageX-u.offset().left-t,r=p-g,i=n/r;if(i<0){i=0}else if(i>1){i=1}o.scrollLeft((v-p)*i)})};var H=function(){var t=function(e,t){o.scrollTop(o.scrollTop()-t);o.scrollLeft(o.scrollLeft()-e);L()};var n={},r=0,i={},s=null,u=false;e(window).bind("touchstart"+x,function(e){u=true});e(window).bind("touchend"+x,function(e){u=false});o.bind("touchstart"+x,function(e){var t=e.originalEvent.targetTouches[0];n.pageX=t.pageX;n.pageY=t.pageY;r=(new Date).getTime();if(s!==null){clearInterval(s)}e.stopPropagation()});o.bind("touchmove"+x,function(e){if(!u&&e.originalEvent.targetTouches.length===1){var s=e.originalEvent.targetTouches[0];var o={};o.pageX=s.pageX;o.pageY=s.pageY;var a=o.pageX-n.pageX,f=o.pageY-n.pageY;t(a,f);n=o;var l=(new Date).getTime();i.x=a/(l-r);i.y=f/(l-r);r=l;e.preventDefault()}});o.bind("touchend"+x,function(e){clearInterval(s);s=setInterval(function(){if(Math.abs(i.x)<.01&&Math.abs(i.y)<.01){clearInterval(s);return}t(i.x*30,i.y*30);i.x*=.8;i.y*=.8},10)})};var B=function(){o.bind("scroll"+x,function(e){L()})};var j=function(){o.unbind(x);e(window).unbind(x);e(document).unbind(x);o.data("perfect-scrollbar",null);o.data("perfect-scrollbar-update",null);o.data("perfect-scrollbar-destroy",null);f.remove();l.remove();u.remove();a.remove();f=l=p=d=v=m=g=y=b=w=E=S=null};var F=function(t){o.addClass("ie").addClass("ie"+t);var n=function(){var t=function(){e(this).addClass("hover")};var n=function(){e(this).removeClass("hover")};o.bind("mouseenter"+x,t).bind("mouseleave"+x,n);u.bind("mouseenter"+x,t).bind("mouseleave"+x,n);a.bind("mouseenter"+x,t).bind("mouseleave"+x,n);f.bind("mouseenter"+x,t).bind("mouseleave"+x,n);l.bind("mouseenter"+x,t).bind("mouseleave"+x,n)};var r=function(){k=function(){f.css({left:y+o.scrollLeft(),bottom:b,width:g});l.css({top:E+o.scrollTop(),right:S,height:w});f.hide().show();l.hide().show()}};if(t===6){n();r()}};var I="ontouchstart"in window||window.DocumentTouch&&document instanceof window.DocumentTouch;var q=function(){var e=navigator.userAgent.toLowerCase().match(/(msie) ([\w.]+)/);if(e&&e[1]==="msie"){F(parseInt(e[2],10))}L();B();A();O();P();if(I){H()}if(o.mousewheel){_()}if(s.useKeyboard){D()}o.data("perfect-scrollbar",o);o.data("perfect-scrollbar-update",L);o.data("perfect-scrollbar-destroy",j)};q();return o})}});


//! moment.js
//! version : 2.7.0
//! authors : Tim Wood, Iskren Chernev, Moment.js contributors
//! license : MIT
//! momentjs.com
(function(a){function b(a,b,c){switch(arguments.length){case 2:return null!=a?a:b;case 3:return null!=a?a:null!=b?b:c;default:throw new Error("Implement me")}}function c(){return{empty:!1,unusedTokens:[],unusedInput:[],overflow:-2,charsLeftOver:0,nullInput:!1,invalidMonth:null,invalidFormat:!1,userInvalidated:!1,iso:!1}}function d(a,b){function c(){mb.suppressDeprecationWarnings===!1&&"undefined"!=typeof console&&console.warn&&console.warn("Deprecation warning: "+a)}var d=!0;return j(function(){return d&&(c(),d=!1),b.apply(this,arguments)},b)}function e(a,b){return function(c){return m(a.call(this,c),b)}}function f(a,b){return function(c){return this.lang().ordinal(a.call(this,c),b)}}function g(){}function h(a){z(a),j(this,a)}function i(a){var b=s(a),c=b.year||0,d=b.quarter||0,e=b.month||0,f=b.week||0,g=b.day||0,h=b.hour||0,i=b.minute||0,j=b.second||0,k=b.millisecond||0;this._milliseconds=+k+1e3*j+6e4*i+36e5*h,this._days=+g+7*f,this._months=+e+3*d+12*c,this._data={},this._bubble()}function j(a,b){for(var c in b)b.hasOwnProperty(c)&&(a[c]=b[c]);return b.hasOwnProperty("toString")&&(a.toString=b.toString),b.hasOwnProperty("valueOf")&&(a.valueOf=b.valueOf),a}function k(a){var b,c={};for(b in a)a.hasOwnProperty(b)&&Ab.hasOwnProperty(b)&&(c[b]=a[b]);return c}function l(a){return 0>a?Math.ceil(a):Math.floor(a)}function m(a,b,c){for(var d=""+Math.abs(a),e=a>=0;d.length<b;)d="0"+d;return(e?c?"+":"":"-")+d}function n(a,b,c,d){var e=b._milliseconds,f=b._days,g=b._months;d=null==d?!0:d,e&&a._d.setTime(+a._d+e*c),f&&hb(a,"Date",gb(a,"Date")+f*c),g&&fb(a,gb(a,"Month")+g*c),d&&mb.updateOffset(a,f||g)}function o(a){return"[object Array]"===Object.prototype.toString.call(a)}function p(a){return"[object Date]"===Object.prototype.toString.call(a)||a instanceof Date}function q(a,b,c){var d,e=Math.min(a.length,b.length),f=Math.abs(a.length-b.length),g=0;for(d=0;e>d;d++)(c&&a[d]!==b[d]||!c&&u(a[d])!==u(b[d]))&&g++;return g+f}function r(a){if(a){var b=a.toLowerCase().replace(/(.)s$/,"$1");a=bc[a]||cc[b]||b}return a}function s(a){var b,c,d={};for(c in a)a.hasOwnProperty(c)&&(b=r(c),b&&(d[b]=a[c]));return d}function t(b){var c,d;if(0===b.indexOf("week"))c=7,d="day";else{if(0!==b.indexOf("month"))return;c=12,d="month"}mb[b]=function(e,f){var g,h,i=mb.fn._lang[b],j=[];if("number"==typeof e&&(f=e,e=a),h=function(a){var b=mb().utc().set(d,a);return i.call(mb.fn._lang,b,e||"")},null!=f)return h(f);for(g=0;c>g;g++)j.push(h(g));return j}}function u(a){var b=+a,c=0;return 0!==b&&isFinite(b)&&(c=b>=0?Math.floor(b):Math.ceil(b)),c}function v(a,b){return new Date(Date.UTC(a,b+1,0)).getUTCDate()}function w(a,b,c){return bb(mb([a,11,31+b-c]),b,c).week}function x(a){return y(a)?366:365}function y(a){return a%4===0&&a%100!==0||a%400===0}function z(a){var b;a._a&&-2===a._pf.overflow&&(b=a._a[tb]<0||a._a[tb]>11?tb:a._a[ub]<1||a._a[ub]>v(a._a[sb],a._a[tb])?ub:a._a[vb]<0||a._a[vb]>23?vb:a._a[wb]<0||a._a[wb]>59?wb:a._a[xb]<0||a._a[xb]>59?xb:a._a[yb]<0||a._a[yb]>999?yb:-1,a._pf._overflowDayOfYear&&(sb>b||b>ub)&&(b=ub),a._pf.overflow=b)}function A(a){return null==a._isValid&&(a._isValid=!isNaN(a._d.getTime())&&a._pf.overflow<0&&!a._pf.empty&&!a._pf.invalidMonth&&!a._pf.nullInput&&!a._pf.invalidFormat&&!a._pf.userInvalidated,a._strict&&(a._isValid=a._isValid&&0===a._pf.charsLeftOver&&0===a._pf.unusedTokens.length)),a._isValid}function B(a){return a?a.toLowerCase().replace("_","-"):a}function C(a,b){return b._isUTC?mb(a).zone(b._offset||0):mb(a).local()}function D(a,b){return b.abbr=a,zb[a]||(zb[a]=new g),zb[a].set(b),zb[a]}function E(a){delete zb[a]}function F(a){var b,c,d,e,f=0,g=function(a){if(!zb[a]&&Bb)try{require("./lang/"+a)}catch(b){}return zb[a]};if(!a)return mb.fn._lang;if(!o(a)){if(c=g(a))return c;a=[a]}for(;f<a.length;){for(e=B(a[f]).split("-"),b=e.length,d=B(a[f+1]),d=d?d.split("-"):null;b>0;){if(c=g(e.slice(0,b).join("-")))return c;if(d&&d.length>=b&&q(e,d,!0)>=b-1)break;b--}f++}return mb.fn._lang}function G(a){return a.match(/\[[\s\S]/)?a.replace(/^\[|\]$/g,""):a.replace(/\\/g,"")}function H(a){var b,c,d=a.match(Fb);for(b=0,c=d.length;c>b;b++)d[b]=hc[d[b]]?hc[d[b]]:G(d[b]);return function(e){var f="";for(b=0;c>b;b++)f+=d[b]instanceof Function?d[b].call(e,a):d[b];return f}}function I(a,b){return a.isValid()?(b=J(b,a.lang()),dc[b]||(dc[b]=H(b)),dc[b](a)):a.lang().invalidDate()}function J(a,b){function c(a){return b.longDateFormat(a)||a}var d=5;for(Gb.lastIndex=0;d>=0&&Gb.test(a);)a=a.replace(Gb,c),Gb.lastIndex=0,d-=1;return a}function K(a,b){var c,d=b._strict;switch(a){case"Q":return Rb;case"DDDD":return Tb;case"YYYY":case"GGGG":case"gggg":return d?Ub:Jb;case"Y":case"G":case"g":return Wb;case"YYYYYY":case"YYYYY":case"GGGGG":case"ggggg":return d?Vb:Kb;case"S":if(d)return Rb;case"SS":if(d)return Sb;case"SSS":if(d)return Tb;case"DDD":return Ib;case"MMM":case"MMMM":case"dd":case"ddd":case"dddd":return Mb;case"a":case"A":return F(b._l)._meridiemParse;case"X":return Pb;case"Z":case"ZZ":return Nb;case"T":return Ob;case"SSSS":return Lb;case"MM":case"DD":case"YY":case"GG":case"gg":case"HH":case"hh":case"mm":case"ss":case"ww":case"WW":return d?Sb:Hb;case"M":case"D":case"d":case"H":case"h":case"m":case"s":case"w":case"W":case"e":case"E":return Hb;case"Do":return Qb;default:return c=new RegExp(T(S(a.replace("\\","")),"i"))}}function L(a){a=a||"";var b=a.match(Nb)||[],c=b[b.length-1]||[],d=(c+"").match(_b)||["-",0,0],e=+(60*d[1])+u(d[2]);return"+"===d[0]?-e:e}function M(a,b,c){var d,e=c._a;switch(a){case"Q":null!=b&&(e[tb]=3*(u(b)-1));break;case"M":case"MM":null!=b&&(e[tb]=u(b)-1);break;case"MMM":case"MMMM":d=F(c._l).monthsParse(b),null!=d?e[tb]=d:c._pf.invalidMonth=b;break;case"D":case"DD":null!=b&&(e[ub]=u(b));break;case"Do":null!=b&&(e[ub]=u(parseInt(b,10)));break;case"DDD":case"DDDD":null!=b&&(c._dayOfYear=u(b));break;case"YY":e[sb]=mb.parseTwoDigitYear(b);break;case"YYYY":case"YYYYY":case"YYYYYY":e[sb]=u(b);break;case"a":case"A":c._isPm=F(c._l).isPM(b);break;case"H":case"HH":case"h":case"hh":e[vb]=u(b);break;case"m":case"mm":e[wb]=u(b);break;case"s":case"ss":e[xb]=u(b);break;case"S":case"SS":case"SSS":case"SSSS":e[yb]=u(1e3*("0."+b));break;case"X":c._d=new Date(1e3*parseFloat(b));break;case"Z":case"ZZ":c._useUTC=!0,c._tzm=L(b);break;case"dd":case"ddd":case"dddd":d=F(c._l).weekdaysParse(b),null!=d?(c._w=c._w||{},c._w.d=d):c._pf.invalidWeekday=b;break;case"w":case"ww":case"W":case"WW":case"d":case"e":case"E":a=a.substr(0,1);case"gggg":case"GGGG":case"GGGGG":a=a.substr(0,2),b&&(c._w=c._w||{},c._w[a]=u(b));break;case"gg":case"GG":c._w=c._w||{},c._w[a]=mb.parseTwoDigitYear(b)}}function N(a){var c,d,e,f,g,h,i,j;c=a._w,null!=c.GG||null!=c.W||null!=c.E?(g=1,h=4,d=b(c.GG,a._a[sb],bb(mb(),1,4).year),e=b(c.W,1),f=b(c.E,1)):(j=F(a._l),g=j._week.dow,h=j._week.doy,d=b(c.gg,a._a[sb],bb(mb(),g,h).year),e=b(c.w,1),null!=c.d?(f=c.d,g>f&&++e):f=null!=c.e?c.e+g:g),i=cb(d,e,f,h,g),a._a[sb]=i.year,a._dayOfYear=i.dayOfYear}function O(a){var c,d,e,f,g=[];if(!a._d){for(e=Q(a),a._w&&null==a._a[ub]&&null==a._a[tb]&&N(a),a._dayOfYear&&(f=b(a._a[sb],e[sb]),a._dayOfYear>x(f)&&(a._pf._overflowDayOfYear=!0),d=Z(f,0,a._dayOfYear),a._a[tb]=d.getUTCMonth(),a._a[ub]=d.getUTCDate()),c=0;3>c&&null==a._a[c];++c)a._a[c]=g[c]=e[c];for(;7>c;c++)a._a[c]=g[c]=null==a._a[c]?2===c?1:0:a._a[c];a._d=(a._useUTC?Z:Y).apply(null,g),null!=a._tzm&&a._d.setUTCMinutes(a._d.getUTCMinutes()+a._tzm)}}function P(a){var b;a._d||(b=s(a._i),a._a=[b.year,b.month,b.day,b.hour,b.minute,b.second,b.millisecond],O(a))}function Q(a){var b=new Date;return a._useUTC?[b.getUTCFullYear(),b.getUTCMonth(),b.getUTCDate()]:[b.getFullYear(),b.getMonth(),b.getDate()]}function R(a){if(a._f===mb.ISO_8601)return void V(a);a._a=[],a._pf.empty=!0;var b,c,d,e,f,g=F(a._l),h=""+a._i,i=h.length,j=0;for(d=J(a._f,g).match(Fb)||[],b=0;b<d.length;b++)e=d[b],c=(h.match(K(e,a))||[])[0],c&&(f=h.substr(0,h.indexOf(c)),f.length>0&&a._pf.unusedInput.push(f),h=h.slice(h.indexOf(c)+c.length),j+=c.length),hc[e]?(c?a._pf.empty=!1:a._pf.unusedTokens.push(e),M(e,c,a)):a._strict&&!c&&a._pf.unusedTokens.push(e);a._pf.charsLeftOver=i-j,h.length>0&&a._pf.unusedInput.push(h),a._isPm&&a._a[vb]<12&&(a._a[vb]+=12),a._isPm===!1&&12===a._a[vb]&&(a._a[vb]=0),O(a),z(a)}function S(a){return a.replace(/\\(\[)|\\(\])|\[([^\]\[]*)\]|\\(.)/g,function(a,b,c,d,e){return b||c||d||e})}function T(a){return a.replace(/[-\/\\^$*+?.()|[\]{}]/g,"\\$&")}function U(a){var b,d,e,f,g;if(0===a._f.length)return a._pf.invalidFormat=!0,void(a._d=new Date(0/0));for(f=0;f<a._f.length;f++)g=0,b=j({},a),b._pf=c(),b._f=a._f[f],R(b),A(b)&&(g+=b._pf.charsLeftOver,g+=10*b._pf.unusedTokens.length,b._pf.score=g,(null==e||e>g)&&(e=g,d=b));j(a,d||b)}function V(a){var b,c,d=a._i,e=Xb.exec(d);if(e){for(a._pf.iso=!0,b=0,c=Zb.length;c>b;b++)if(Zb[b][1].exec(d)){a._f=Zb[b][0]+(e[6]||" ");break}for(b=0,c=$b.length;c>b;b++)if($b[b][1].exec(d)){a._f+=$b[b][0];break}d.match(Nb)&&(a._f+="Z"),R(a)}else a._isValid=!1}function W(a){V(a),a._isValid===!1&&(delete a._isValid,mb.createFromInputFallback(a))}function X(b){var c=b._i,d=Cb.exec(c);c===a?b._d=new Date:d?b._d=new Date(+d[1]):"string"==typeof c?W(b):o(c)?(b._a=c.slice(0),O(b)):p(c)?b._d=new Date(+c):"object"==typeof c?P(b):"number"==typeof c?b._d=new Date(c):mb.createFromInputFallback(b)}function Y(a,b,c,d,e,f,g){var h=new Date(a,b,c,d,e,f,g);return 1970>a&&h.setFullYear(a),h}function Z(a){var b=new Date(Date.UTC.apply(null,arguments));return 1970>a&&b.setUTCFullYear(a),b}function $(a,b){if("string"==typeof a)if(isNaN(a)){if(a=b.weekdaysParse(a),"number"!=typeof a)return null}else a=parseInt(a,10);return a}function _(a,b,c,d,e){return e.relativeTime(b||1,!!c,a,d)}function ab(a,b,c){var d=rb(Math.abs(a)/1e3),e=rb(d/60),f=rb(e/60),g=rb(f/24),h=rb(g/365),i=d<ec.s&&["s",d]||1===e&&["m"]||e<ec.m&&["mm",e]||1===f&&["h"]||f<ec.h&&["hh",f]||1===g&&["d"]||g<=ec.dd&&["dd",g]||g<=ec.dm&&["M"]||g<ec.dy&&["MM",rb(g/30)]||1===h&&["y"]||["yy",h];return i[2]=b,i[3]=a>0,i[4]=c,_.apply({},i)}function bb(a,b,c){var d,e=c-b,f=c-a.day();return f>e&&(f-=7),e-7>f&&(f+=7),d=mb(a).add("d",f),{week:Math.ceil(d.dayOfYear()/7),year:d.year()}}function cb(a,b,c,d,e){var f,g,h=Z(a,0,1).getUTCDay();return h=0===h?7:h,c=null!=c?c:e,f=e-h+(h>d?7:0)-(e>h?7:0),g=7*(b-1)+(c-e)+f+1,{year:g>0?a:a-1,dayOfYear:g>0?g:x(a-1)+g}}function db(b){var c=b._i,d=b._f;return null===c||d===a&&""===c?mb.invalid({nullInput:!0}):("string"==typeof c&&(b._i=c=F().preparse(c)),mb.isMoment(c)?(b=k(c),b._d=new Date(+c._d)):d?o(d)?U(b):R(b):X(b),new h(b))}function eb(a,b){var c,d;if(1===b.length&&o(b[0])&&(b=b[0]),!b.length)return mb();for(c=b[0],d=1;d<b.length;++d)b[d][a](c)&&(c=b[d]);return c}function fb(a,b){var c;return"string"==typeof b&&(b=a.lang().monthsParse(b),"number"!=typeof b)?a:(c=Math.min(a.date(),v(a.year(),b)),a._d["set"+(a._isUTC?"UTC":"")+"Month"](b,c),a)}function gb(a,b){return a._d["get"+(a._isUTC?"UTC":"")+b]()}function hb(a,b,c){return"Month"===b?fb(a,c):a._d["set"+(a._isUTC?"UTC":"")+b](c)}function ib(a,b){return function(c){return null!=c?(hb(this,a,c),mb.updateOffset(this,b),this):gb(this,a)}}function jb(a){mb.duration.fn[a]=function(){return this._data[a]}}function kb(a,b){mb.duration.fn["as"+a]=function(){return+this/b}}function lb(a){"undefined"==typeof ender&&(nb=qb.moment,qb.moment=a?d("Accessing Moment through the global scope is deprecated, and will be removed in an upcoming release.",mb):mb)}for(var mb,nb,ob,pb="2.7.0",qb="undefined"!=typeof global?global:this,rb=Math.round,sb=0,tb=1,ub=2,vb=3,wb=4,xb=5,yb=6,zb={},Ab={_isAMomentObject:null,_i:null,_f:null,_l:null,_strict:null,_tzm:null,_isUTC:null,_offset:null,_pf:null,_lang:null},Bb="undefined"!=typeof module&&module.exports,Cb=/^\/?Date\((\-?\d+)/i,Db=/(\-)?(?:(\d*)\.)?(\d+)\:(\d+)(?:\:(\d+)\.?(\d{3})?)?/,Eb=/^(-)?P(?:(?:([0-9,.]*)Y)?(?:([0-9,.]*)M)?(?:([0-9,.]*)D)?(?:T(?:([0-9,.]*)H)?(?:([0-9,.]*)M)?(?:([0-9,.]*)S)?)?|([0-9,.]*)W)$/,Fb=/(\[[^\[]*\])|(\\)?(Mo|MM?M?M?|Do|DDDo|DD?D?D?|ddd?d?|do?|w[o|w]?|W[o|W]?|Q|YYYYYY|YYYYY|YYYY|YY|gg(ggg?)?|GG(GGG?)?|e|E|a|A|hh?|HH?|mm?|ss?|S{1,4}|X|zz?|ZZ?|.)/g,Gb=/(\[[^\[]*\])|(\\)?(LT|LL?L?L?|l{1,4})/g,Hb=/\d\d?/,Ib=/\d{1,3}/,Jb=/\d{1,4}/,Kb=/[+\-]?\d{1,6}/,Lb=/\d+/,Mb=/[0-9]*['a-z\u00A0-\u05FF\u0700-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+|[\u0600-\u06FF\/]+(\s*?[\u0600-\u06FF]+){1,2}/i,Nb=/Z|[\+\-]\d\d:?\d\d/gi,Ob=/T/i,Pb=/[\+\-]?\d+(\.\d{1,3})?/,Qb=/\d{1,2}/,Rb=/\d/,Sb=/\d\d/,Tb=/\d{3}/,Ub=/\d{4}/,Vb=/[+-]?\d{6}/,Wb=/[+-]?\d+/,Xb=/^\s*(?:[+-]\d{6}|\d{4})-(?:(\d\d-\d\d)|(W\d\d$)|(W\d\d-\d)|(\d\d\d))((T| )(\d\d(:\d\d(:\d\d(\.\d+)?)?)?)?([\+\-]\d\d(?::?\d\d)?|\s*Z)?)?$/,Yb="YYYY-MM-DDTHH:mm:ssZ",Zb=[["YYYYYY-MM-DD",/[+-]\d{6}-\d{2}-\d{2}/],["YYYY-MM-DD",/\d{4}-\d{2}-\d{2}/],["GGGG-[W]WW-E",/\d{4}-W\d{2}-\d/],["GGGG-[W]WW",/\d{4}-W\d{2}/],["YYYY-DDD",/\d{4}-\d{3}/]],$b=[["HH:mm:ss.SSSS",/(T| )\d\d:\d\d:\d\d\.\d+/],["HH:mm:ss",/(T| )\d\d:\d\d:\d\d/],["HH:mm",/(T| )\d\d:\d\d/],["HH",/(T| )\d\d/]],_b=/([\+\-]|\d\d)/gi,ac=("Date|Hours|Minutes|Seconds|Milliseconds".split("|"),{Milliseconds:1,Seconds:1e3,Minutes:6e4,Hours:36e5,Days:864e5,Months:2592e6,Years:31536e6}),bc={ms:"millisecond",s:"second",m:"minute",h:"hour",d:"day",D:"date",w:"week",W:"isoWeek",M:"month",Q:"quarter",y:"year",DDD:"dayOfYear",e:"weekday",E:"isoWeekday",gg:"weekYear",GG:"isoWeekYear"},cc={dayofyear:"dayOfYear",isoweekday:"isoWeekday",isoweek:"isoWeek",weekyear:"weekYear",isoweekyear:"isoWeekYear"},dc={},ec={s:45,m:45,h:22,dd:25,dm:45,dy:345},fc="DDD w W M D d".split(" "),gc="M D H h m s w W".split(" "),hc={M:function(){return this.month()+1},MMM:function(a){return this.lang().monthsShort(this,a)},MMMM:function(a){return this.lang().months(this,a)},D:function(){return this.date()},DDD:function(){return this.dayOfYear()},d:function(){return this.day()},dd:function(a){return this.lang().weekdaysMin(this,a)},ddd:function(a){return this.lang().weekdaysShort(this,a)},dddd:function(a){return this.lang().weekdays(this,a)},w:function(){return this.week()},W:function(){return this.isoWeek()},YY:function(){return m(this.year()%100,2)},YYYY:function(){return m(this.year(),4)},YYYYY:function(){return m(this.year(),5)},YYYYYY:function(){var a=this.year(),b=a>=0?"+":"-";return b+m(Math.abs(a),6)},gg:function(){return m(this.weekYear()%100,2)},gggg:function(){return m(this.weekYear(),4)},ggggg:function(){return m(this.weekYear(),5)},GG:function(){return m(this.isoWeekYear()%100,2)},GGGG:function(){return m(this.isoWeekYear(),4)},GGGGG:function(){return m(this.isoWeekYear(),5)},e:function(){return this.weekday()},E:function(){return this.isoWeekday()},a:function(){return this.lang().meridiem(this.hours(),this.minutes(),!0)},A:function(){return this.lang().meridiem(this.hours(),this.minutes(),!1)},H:function(){return this.hours()},h:function(){return this.hours()%12||12},m:function(){return this.minutes()},s:function(){return this.seconds()},S:function(){return u(this.milliseconds()/100)},SS:function(){return m(u(this.milliseconds()/10),2)},SSS:function(){return m(this.milliseconds(),3)},SSSS:function(){return m(this.milliseconds(),3)},Z:function(){var a=-this.zone(),b="+";return 0>a&&(a=-a,b="-"),b+m(u(a/60),2)+":"+m(u(a)%60,2)},ZZ:function(){var a=-this.zone(),b="+";return 0>a&&(a=-a,b="-"),b+m(u(a/60),2)+m(u(a)%60,2)},z:function(){return this.zoneAbbr()},zz:function(){return this.zoneName()},X:function(){return this.unix()},Q:function(){return this.quarter()}},ic=["months","monthsShort","weekdays","weekdaysShort","weekdaysMin"];fc.length;)ob=fc.pop(),hc[ob+"o"]=f(hc[ob],ob);for(;gc.length;)ob=gc.pop(),hc[ob+ob]=e(hc[ob],2);for(hc.DDDD=e(hc.DDD,3),j(g.prototype,{set:function(a){var b,c;for(c in a)b=a[c],"function"==typeof b?this[c]=b:this["_"+c]=b},_months:"January_February_March_April_May_June_July_August_September_October_November_December".split("_"),months:function(a){return this._months[a.month()]},_monthsShort:"Jan_Feb_Mar_Apr_May_Jun_Jul_Aug_Sep_Oct_Nov_Dec".split("_"),monthsShort:function(a){return this._monthsShort[a.month()]},monthsParse:function(a){var b,c,d;for(this._monthsParse||(this._monthsParse=[]),b=0;12>b;b++)if(this._monthsParse[b]||(c=mb.utc([2e3,b]),d="^"+this.months(c,"")+"|^"+this.monthsShort(c,""),this._monthsParse[b]=new RegExp(d.replace(".",""),"i")),this._monthsParse[b].test(a))return b},_weekdays:"Sunday_Monday_Tuesday_Wednesday_Thursday_Friday_Saturday".split("_"),weekdays:function(a){return this._weekdays[a.day()]},_weekdaysShort:"Sun_Mon_Tue_Wed_Thu_Fri_Sat".split("_"),weekdaysShort:function(a){return this._weekdaysShort[a.day()]},_weekdaysMin:"Su_Mo_Tu_We_Th_Fr_Sa".split("_"),weekdaysMin:function(a){return this._weekdaysMin[a.day()]},weekdaysParse:function(a){var b,c,d;for(this._weekdaysParse||(this._weekdaysParse=[]),b=0;7>b;b++)if(this._weekdaysParse[b]||(c=mb([2e3,1]).day(b),d="^"+this.weekdays(c,"")+"|^"+this.weekdaysShort(c,"")+"|^"+this.weekdaysMin(c,""),this._weekdaysParse[b]=new RegExp(d.replace(".",""),"i")),this._weekdaysParse[b].test(a))return b},_longDateFormat:{LT:"h:mm A",L:"MM/DD/YYYY",LL:"MMMM D YYYY",LLL:"MMMM D YYYY LT",LLLL:"dddd, MMMM D YYYY LT"},longDateFormat:function(a){var b=this._longDateFormat[a];return!b&&this._longDateFormat[a.toUpperCase()]&&(b=this._longDateFormat[a.toUpperCase()].replace(/MMMM|MM|DD|dddd/g,function(a){return a.slice(1)}),this._longDateFormat[a]=b),b},isPM:function(a){return"p"===(a+"").toLowerCase().charAt(0)},_meridiemParse:/[ap]\.?m?\.?/i,meridiem:function(a,b,c){return a>11?c?"pm":"PM":c?"am":"AM"},_calendar:{sameDay:"[Today at] LT",nextDay:"[Tomorrow at] LT",nextWeek:"dddd [at] LT",lastDay:"[Yesterday at] LT",lastWeek:"[Last] dddd [at] LT",sameElse:"L"},calendar:function(a,b){var c=this._calendar[a];return"function"==typeof c?c.apply(b):c},_relativeTime:{future:"in %s",past:"%s ago",s:"a few seconds",m:"a minute",mm:"%d minutes",h:"an hour",hh:"%d hours",d:"a day",dd:"%d days",M:"a month",MM:"%d months",y:"a year",yy:"%d years"},relativeTime:function(a,b,c,d){var e=this._relativeTime[c];return"function"==typeof e?e(a,b,c,d):e.replace(/%d/i,a)},pastFuture:function(a,b){var c=this._relativeTime[a>0?"future":"past"];return"function"==typeof c?c(b):c.replace(/%s/i,b)},ordinal:function(a){return this._ordinal.replace("%d",a)},_ordinal:"%d",preparse:function(a){return a},postformat:function(a){return a},week:function(a){return bb(a,this._week.dow,this._week.doy).week},_week:{dow:0,doy:6},_invalidDate:"Invalid date",invalidDate:function(){return this._invalidDate}}),mb=function(b,d,e,f){var g;return"boolean"==typeof e&&(f=e,e=a),g={},g._isAMomentObject=!0,g._i=b,g._f=d,g._l=e,g._strict=f,g._isUTC=!1,g._pf=c(),db(g)},mb.suppressDeprecationWarnings=!1,mb.createFromInputFallback=d("moment construction falls back to js Date. This is discouraged and will be removed in upcoming major release. Please refer to https://github.com/moment/moment/issues/1407 for more info.",function(a){a._d=new Date(a._i)}),mb.min=function(){var a=[].slice.call(arguments,0);return eb("isBefore",a)},mb.max=function(){var a=[].slice.call(arguments,0);return eb("isAfter",a)},mb.utc=function(b,d,e,f){var g;return"boolean"==typeof e&&(f=e,e=a),g={},g._isAMomentObject=!0,g._useUTC=!0,g._isUTC=!0,g._l=e,g._i=b,g._f=d,g._strict=f,g._pf=c(),db(g).utc()},mb.unix=function(a){return mb(1e3*a)},mb.duration=function(a,b){var c,d,e,f=a,g=null;return mb.isDuration(a)?f={ms:a._milliseconds,d:a._days,M:a._months}:"number"==typeof a?(f={},b?f[b]=a:f.milliseconds=a):(g=Db.exec(a))?(c="-"===g[1]?-1:1,f={y:0,d:u(g[ub])*c,h:u(g[vb])*c,m:u(g[wb])*c,s:u(g[xb])*c,ms:u(g[yb])*c}):(g=Eb.exec(a))&&(c="-"===g[1]?-1:1,e=function(a){var b=a&&parseFloat(a.replace(",","."));return(isNaN(b)?0:b)*c},f={y:e(g[2]),M:e(g[3]),d:e(g[4]),h:e(g[5]),m:e(g[6]),s:e(g[7]),w:e(g[8])}),d=new i(f),mb.isDuration(a)&&a.hasOwnProperty("_lang")&&(d._lang=a._lang),d},mb.version=pb,mb.defaultFormat=Yb,mb.ISO_8601=function(){},mb.momentProperties=Ab,mb.updateOffset=function(){},mb.relativeTimeThreshold=function(b,c){return ec[b]===a?!1:(ec[b]=c,!0)},mb.lang=function(a,b){var c;return a?(b?D(B(a),b):null===b?(E(a),a="en"):zb[a]||F(a),c=mb.duration.fn._lang=mb.fn._lang=F(a),c._abbr):mb.fn._lang._abbr},mb.langData=function(a){return a&&a._lang&&a._lang._abbr&&(a=a._lang._abbr),F(a)},mb.isMoment=function(a){return a instanceof h||null!=a&&a.hasOwnProperty("_isAMomentObject")},mb.isDuration=function(a){return a instanceof i},ob=ic.length-1;ob>=0;--ob)t(ic[ob]);mb.normalizeUnits=function(a){return r(a)},mb.invalid=function(a){var b=mb.utc(0/0);return null!=a?j(b._pf,a):b._pf.userInvalidated=!0,b},mb.parseZone=function(){return mb.apply(null,arguments).parseZone()},mb.parseTwoDigitYear=function(a){return u(a)+(u(a)>68?1900:2e3)},j(mb.fn=h.prototype,{clone:function(){return mb(this)},valueOf:function(){return+this._d+6e4*(this._offset||0)},unix:function(){return Math.floor(+this/1e3)},toString:function(){return this.clone().lang("en").format("ddd MMM DD YYYY HH:mm:ss [GMT]ZZ")},toDate:function(){return this._offset?new Date(+this):this._d},toISOString:function(){var a=mb(this).utc();return 0<a.year()&&a.year()<=9999?I(a,"YYYY-MM-DD[T]HH:mm:ss.SSS[Z]"):I(a,"YYYYYY-MM-DD[T]HH:mm:ss.SSS[Z]")},toArray:function(){var a=this;return[a.year(),a.month(),a.date(),a.hours(),a.minutes(),a.seconds(),a.milliseconds()]},isValid:function(){return A(this)},isDSTShifted:function(){return this._a?this.isValid()&&q(this._a,(this._isUTC?mb.utc(this._a):mb(this._a)).toArray())>0:!1},parsingFlags:function(){return j({},this._pf)},invalidAt:function(){return this._pf.overflow},utc:function(){return this.zone(0)},local:function(){return this.zone(0),this._isUTC=!1,this},format:function(a){var b=I(this,a||mb.defaultFormat);return this.lang().postformat(b)},add:function(a,b){var c;return c="string"==typeof a&&"string"==typeof b?mb.duration(isNaN(+b)?+a:+b,isNaN(+b)?b:a):"string"==typeof a?mb.duration(+b,a):mb.duration(a,b),n(this,c,1),this},subtract:function(a,b){var c;return c="string"==typeof a&&"string"==typeof b?mb.duration(isNaN(+b)?+a:+b,isNaN(+b)?b:a):"string"==typeof a?mb.duration(+b,a):mb.duration(a,b),n(this,c,-1),this},diff:function(a,b,c){var d,e,f=C(a,this),g=6e4*(this.zone()-f.zone());return b=r(b),"year"===b||"month"===b?(d=432e5*(this.daysInMonth()+f.daysInMonth()),e=12*(this.year()-f.year())+(this.month()-f.month()),e+=(this-mb(this).startOf("month")-(f-mb(f).startOf("month")))/d,e-=6e4*(this.zone()-mb(this).startOf("month").zone()-(f.zone()-mb(f).startOf("month").zone()))/d,"year"===b&&(e/=12)):(d=this-f,e="second"===b?d/1e3:"minute"===b?d/6e4:"hour"===b?d/36e5:"day"===b?(d-g)/864e5:"week"===b?(d-g)/6048e5:d),c?e:l(e)},from:function(a,b){return mb.duration(this.diff(a)).lang(this.lang()._abbr).humanize(!b)},fromNow:function(a){return this.from(mb(),a)},calendar:function(a){var b=a||mb(),c=C(b,this).startOf("day"),d=this.diff(c,"days",!0),e=-6>d?"sameElse":-1>d?"lastWeek":0>d?"lastDay":1>d?"sameDay":2>d?"nextDay":7>d?"nextWeek":"sameElse";return this.format(this.lang().calendar(e,this))},isLeapYear:function(){return y(this.year())},isDST:function(){return this.zone()<this.clone().month(0).zone()||this.zone()<this.clone().month(5).zone()},day:function(a){var b=this._isUTC?this._d.getUTCDay():this._d.getDay();return null!=a?(a=$(a,this.lang()),this.add({d:a-b})):b},month:ib("Month",!0),startOf:function(a){switch(a=r(a)){case"year":this.month(0);case"quarter":case"month":this.date(1);case"week":case"isoWeek":case"day":this.hours(0);case"hour":this.minutes(0);case"minute":this.seconds(0);case"second":this.milliseconds(0)}return"week"===a?this.weekday(0):"isoWeek"===a&&this.isoWeekday(1),"quarter"===a&&this.month(3*Math.floor(this.month()/3)),this},endOf:function(a){return a=r(a),this.startOf(a).add("isoWeek"===a?"week":a,1).subtract("ms",1)},isAfter:function(a,b){return b="undefined"!=typeof b?b:"millisecond",+this.clone().startOf(b)>+mb(a).startOf(b)},isBefore:function(a,b){return b="undefined"!=typeof b?b:"millisecond",+this.clone().startOf(b)<+mb(a).startOf(b)},isSame:function(a,b){return b=b||"ms",+this.clone().startOf(b)===+C(a,this).startOf(b)},min:d("moment().min is deprecated, use moment.min instead. https://github.com/moment/moment/issues/1548",function(a){return a=mb.apply(null,arguments),this>a?this:a}),max:d("moment().max is deprecated, use moment.max instead. https://github.com/moment/moment/issues/1548",function(a){return a=mb.apply(null,arguments),a>this?this:a}),zone:function(a,b){var c=this._offset||0;return null==a?this._isUTC?c:this._d.getTimezoneOffset():("string"==typeof a&&(a=L(a)),Math.abs(a)<16&&(a=60*a),this._offset=a,this._isUTC=!0,c!==a&&(!b||this._changeInProgress?n(this,mb.duration(c-a,"m"),1,!1):this._changeInProgress||(this._changeInProgress=!0,mb.updateOffset(this,!0),this._changeInProgress=null)),this)},zoneAbbr:function(){return this._isUTC?"UTC":""},zoneName:function(){return this._isUTC?"Coordinated Universal Time":""},parseZone:function(){return this._tzm?this.zone(this._tzm):"string"==typeof this._i&&this.zone(this._i),this},hasAlignedHourOffset:function(a){return a=a?mb(a).zone():0,(this.zone()-a)%60===0},daysInMonth:function(){return v(this.year(),this.month())},dayOfYear:function(a){var b=rb((mb(this).startOf("day")-mb(this).startOf("year"))/864e5)+1;return null==a?b:this.add("d",a-b)},quarter:function(a){return null==a?Math.ceil((this.month()+1)/3):this.month(3*(a-1)+this.month()%3)},weekYear:function(a){var b=bb(this,this.lang()._week.dow,this.lang()._week.doy).year;return null==a?b:this.add("y",a-b)},isoWeekYear:function(a){var b=bb(this,1,4).year;return null==a?b:this.add("y",a-b)},week:function(a){var b=this.lang().week(this);return null==a?b:this.add("d",7*(a-b))},isoWeek:function(a){var b=bb(this,1,4).week;return null==a?b:this.add("d",7*(a-b))},weekday:function(a){var b=(this.day()+7-this.lang()._week.dow)%7;return null==a?b:this.add("d",a-b)},isoWeekday:function(a){return null==a?this.day()||7:this.day(this.day()%7?a:a-7)},isoWeeksInYear:function(){return w(this.year(),1,4)},weeksInYear:function(){var a=this._lang._week;return w(this.year(),a.dow,a.doy)},get:function(a){return a=r(a),this[a]()},set:function(a,b){return a=r(a),"function"==typeof this[a]&&this[a](b),this},lang:function(b){return b===a?this._lang:(this._lang=F(b),this)}}),mb.fn.millisecond=mb.fn.milliseconds=ib("Milliseconds",!1),mb.fn.second=mb.fn.seconds=ib("Seconds",!1),mb.fn.minute=mb.fn.minutes=ib("Minutes",!1),mb.fn.hour=mb.fn.hours=ib("Hours",!0),mb.fn.date=ib("Date",!0),mb.fn.dates=d("dates accessor is deprecated. Use date instead.",ib("Date",!0)),mb.fn.year=ib("FullYear",!0),mb.fn.years=d("years accessor is deprecated. Use year instead.",ib("FullYear",!0)),mb.fn.days=mb.fn.day,mb.fn.months=mb.fn.month,mb.fn.weeks=mb.fn.week,mb.fn.isoWeeks=mb.fn.isoWeek,mb.fn.quarters=mb.fn.quarter,mb.fn.toJSON=mb.fn.toISOString,j(mb.duration.fn=i.prototype,{_bubble:function(){var a,b,c,d,e=this._milliseconds,f=this._days,g=this._months,h=this._data;h.milliseconds=e%1e3,a=l(e/1e3),h.seconds=a%60,b=l(a/60),h.minutes=b%60,c=l(b/60),h.hours=c%24,f+=l(c/24),h.days=f%30,g+=l(f/30),h.months=g%12,d=l(g/12),h.years=d},weeks:function(){return l(this.days()/7)},valueOf:function(){return this._milliseconds+864e5*this._days+this._months%12*2592e6+31536e6*u(this._months/12)},humanize:function(a){var b=+this,c=ab(b,!a,this.lang());return a&&(c=this.lang().pastFuture(b,c)),this.lang().postformat(c)},add:function(a,b){var c=mb.duration(a,b);return this._milliseconds+=c._milliseconds,this._days+=c._days,this._months+=c._months,this._bubble(),this},subtract:function(a,b){var c=mb.duration(a,b);return this._milliseconds-=c._milliseconds,this._days-=c._days,this._months-=c._months,this._bubble(),this},get:function(a){return a=r(a),this[a.toLowerCase()+"s"]()},as:function(a){return a=r(a),this["as"+a.charAt(0).toUpperCase()+a.slice(1)+"s"]()},lang:mb.fn.lang,toIsoString:function(){var a=Math.abs(this.years()),b=Math.abs(this.months()),c=Math.abs(this.days()),d=Math.abs(this.hours()),e=Math.abs(this.minutes()),f=Math.abs(this.seconds()+this.milliseconds()/1e3);return this.asSeconds()?(this.asSeconds()<0?"-":"")+"P"+(a?a+"Y":"")+(b?b+"M":"")+(c?c+"D":"")+(d||e||f?"T":"")+(d?d+"H":"")+(e?e+"M":"")+(f?f+"S":""):"P0D"}});for(ob in ac)ac.hasOwnProperty(ob)&&(kb(ob,ac[ob]),jb(ob.toLowerCase()));kb("Weeks",6048e5),mb.duration.fn.asMonths=function(){return(+this-31536e6*this.years())/2592e6+12*this.years()},mb.lang("en",{ordinal:function(a){var b=a%10,c=1===u(a%100/10)?"th":1===b?"st":2===b?"nd":3===b?"rd":"th";return a+c}}),Bb?module.exports=mb:"function"==typeof define&&define.amd?(define("moment",function(a,b,c){return c.config&&c.config()&&c.config().noGlobal===!0&&(qb.moment=nb),mb}),lb(!0)):lb()}).call(this);


/*!
 * FullCalendar v2.0.2
 * Docs & License: http://arshaw.com/fullcalendar/
 * (c) 2013 Adam Shaw
 */
(function(t){"function"==typeof define&&define.amd?define(["jquery","moment"],t):t(jQuery,moment)})(function(t,e){function n(t,e){return e.longDateFormat("LT").replace(":mm","(:mm)").replace(/(\Wmm)$/,"($1)").replace(/\s*a$/i,"t")}function r(t,e){var n=e.longDateFormat("L");return n=n.replace(/^Y+[^\w\s]*|[^\w\s]*Y+$/g,""),t.isRTL?n+=" ddd":n="ddd "+n,n}function a(t){o(xe,t)}function o(e){function n(n,r){t.isPlainObject(r)&&t.isPlainObject(e[n])&&!i(n)?e[n]=o({},e[n],r):void 0!==r&&(e[n]=r)}for(var r=1;arguments.length>r;r++)t.each(arguments[r],n);return e}function i(t){return/(Time|Duration)$/.test(t)}function s(n,r){function a(t){se?f()&&(b(),m(t)):i()}function i(){le=ne.theme?"ui":"fc",n.addClass("fc"),ne.isRTL?n.addClass("fc-rtl"):n.addClass("fc-ltr"),ne.theme&&n.addClass("ui-widget"),se=t("<div class='fc-content' />").prependTo(n),oe=new l(te,ne),ie=oe.render(),ie&&n.prepend(ie),h(ne.defaultView),ne.handleWindowResize&&t(window).resize(w),v()||s()}function s(){setTimeout(function(){!ce.start&&v()&&g()},0)}function d(){ce&&(Q("viewDestroy",ce,ce,ce.element),ce.triggerEventDestroy()),t(window).unbind("resize",w),ne.droppable&&t(document).off("dragstart",J).off("dragstop",K),ce.selectionManagerDestroy&&ce.selectionManagerDestroy(),oe.destroy(),se.remove(),n.removeClass("fc fc-ltr fc-rtl ui-widget")}function f(){return n.is(":visible")}function v(){return t("body").is(":visible")}function h(t){ce&&t==ce.name||p(t)}function p(e){ye++,ce&&(Q("viewDestroy",ce,ce,ce.element),N(),ce.triggerEventDestroy(),$(),ce.element.remove(),oe.deactivateButton(ce.name)),oe.activateButton(e),ce=new _e[e](t("<div class='fc-view fc-view-"+e+"' />").appendTo(se),te),g(),V(),ye--}function g(t){ce.start&&!t&&fe.isWithin(ce.intervalStart,ce.intervalEnd)||f()&&m(t)}function m(t){ye++,ce.start&&(Q("viewDestroy",ce,ce,ce.element),N(),x()),$(),t&&(fe=ce.incrementDate(fe,t)),ce.render(fe.clone()),D(),V(),(ce.afterRender||k)(),H(),F(),Q("viewRender",ce,ce,ce.element),ye--,M()}function y(){f()&&(N(),x(),b(),D(),S())}function b(){ue=ne.contentHeight?ne.contentHeight:ne.height?ne.height-(ie?ie.height():0)-T(se):Math.round(se.width()/Math.max(ne.aspectRatio,.5))}function D(){void 0===ue&&b(),ye++,ce.setHeight(ue),ce.setWidth(se.width()),ye--,de=n.outerWidth()}function w(t){if(!ye&&t.target===window)if(ce.start){var e=++me;setTimeout(function(){e==me&&!ye&&f()&&de!=(de=n.outerWidth())&&(ye++,y(),ce.trigger("windowResize",ge),ye--)},ne.windowResizeDelay)}else s()}function C(){x(),z()}function E(t){x(),S(t)}function S(t){f()&&(ce.renderEvents(be,t),ce.trigger("eventAfterAllRender"))}function x(){ce.triggerEventDestroy(),ce.clearEvents(),ce.clearEventData()}function M(){!ne.lazyFetching||he(ce.start,ce.end)?z():S()}function z(){pe(ce.start,ce.end)}function R(t){be=t,S()}function _(t){E(t)}function H(){oe.updateTitle(ce.title)}function F(){var t=te.getNow();t.isWithin(ce.intervalStart,ce.intervalEnd)?oe.disableButton("today"):oe.enableButton("today")}function A(t,e){ce.select(t,e)}function N(){ce&&ce.unselect()}function Y(){g(-1)}function O(){g(1)}function W(){fe.add("years",-1),g()}function L(){fe.add("years",1),g()}function Z(){fe=te.getNow(),g()}function P(t){fe=te.moment(t),g()}function j(t){fe.add(e.duration(t)),g()}function q(){return fe.clone()}function $(){se.css({width:"100%",height:se.height(),overflow:"hidden"})}function V(){se.css({width:"",height:"",overflow:""})}function X(){return te}function U(){return ce}function G(t,e){return void 0===e?ne[t]:(("height"==t||"contentHeight"==t||"aspectRatio"==t)&&(ne[t]=e,y()),void 0)}function Q(t,e){return ne[t]?ne[t].apply(e||ge,Array.prototype.slice.call(arguments,2)):void 0}function J(e,n){var r=e.target,a=t(r);if(!a.parents(".fc").length){var o=ne.dropAccept;(t.isFunction(o)?o.call(r,a):a.is(o))&&(ve=r,ce.dragStart(ve,e,n))}}function K(t,e){ve&&(ce.dragStop(ve,t,e),ve=null)}var te=this;r=r||{};var ee,ne=o({},xe,r);ee=ne.lang in Me?Me[ne.lang]:Me[xe.lang],ee&&(ne=o({},xe,ee,r)),ne.isRTL&&(ne=o({},xe,ze,ee||{},r)),te.options=ne,te.render=a,te.destroy=d,te.refetchEvents=C,te.reportEvents=R,te.reportEventChange=_,te.rerenderEvents=E,te.changeView=h,te.select=A,te.unselect=N,te.prev=Y,te.next=O,te.prevYear=W,te.nextYear=L,te.today=Z,te.gotoDate=P,te.incrementDate=j,te.getDate=q,te.getCalendar=X,te.getView=U,te.option=G,te.trigger=Q;var re=u(e.langData(ne.lang));if(ne.monthNames&&(re._months=ne.monthNames),ne.monthNamesShort&&(re._monthsShort=ne.monthNamesShort),ne.dayNames&&(re._weekdays=ne.dayNames),ne.dayNamesShort&&(re._weekdaysShort=ne.dayNamesShort),null!=ne.firstDay){var ae=u(re._week);ae.dow=ne.firstDay,re._week=ae}te.defaultAllDayEventDuration=e.duration(ne.defaultAllDayEventDuration),te.defaultTimedEventDuration=e.duration(ne.defaultTimedEventDuration),te.moment=function(){var t;return"local"===ne.timezone?(t=Re.moment.apply(null,arguments),t.hasTime()&&t.local()):t="UTC"===ne.timezone?Re.moment.utc.apply(null,arguments):Re.moment.parseZone.apply(null,arguments),t._lang=re,t},te.getIsAmbigTimezone=function(){return"local"!==ne.timezone&&"UTC"!==ne.timezone},te.rezoneDate=function(t){return te.moment(t.toArray())},te.getNow=function(){var t=ne.now;return"function"==typeof t&&(t=t()),te.moment(t)},te.calculateWeekNumber=function(t){var e=ne.weekNumberCalculation;return"function"==typeof e?e(t):"local"===e?t.week():"ISO"===e.toUpperCase()?t.isoWeek():void 0},te.getEventEnd=function(t){return t.end?t.end.clone():te.getDefaultEventEnd(t.allDay,t.start)},te.getDefaultEventEnd=function(t,e){var n=e.clone();return t?n.stripTime().add(te.defaultAllDayEventDuration):n.add(te.defaultTimedEventDuration),te.getIsAmbigTimezone()&&n.stripZone(),n},te.formatRange=function(t,e,n){return"function"==typeof n&&(n=n.call(te,ne,re)),I(t,e,n,null,ne.isRTL)},te.formatDate=function(t,e){return"function"==typeof e&&(e=e.call(te,ne,re)),B(t,e)},c.call(te,ne);var oe,ie,se,le,ce,de,ue,fe,ve,he=te.isFetchNeeded,pe=te.fetchEvents,ge=n[0],me=0,ye=0,be=[];fe=null!=ne.defaultDate?te.moment(ne.defaultDate):te.getNow(),ne.droppable&&t(document).on("dragstart",J).on("dragstop",K)}function l(e,n){function r(){f=n.theme?"ui":"fc";var e=n.header;return e?v=t("<table class='fc-header' style='width:100%'/>").append(t("<tr/>").append(o("left")).append(o("center")).append(o("right"))):void 0}function a(){v.remove()}function o(r){var a=t("<td class='fc-header-"+r+"'/>"),o=n.header[r];return o&&t.each(o.split(" "),function(r){r>0&&a.append("<span class='fc-header-space'/>");var o;t.each(this.split(","),function(r,i){if("title"==i)a.append("<span class='fc-header-title'><h2>&nbsp;</h2></span>"),o&&o.addClass(f+"-corner-right"),o=null;else{var s;if(e[i]?s=e[i]:_e[i]&&(s=function(){h.removeClass(f+"-state-hover"),e.changeView(i)}),s){var l,c=z(n.themeButtonIcons,i),d=z(n.buttonIcons,i),u=z(n.defaultButtonText,i),v=z(n.buttonText,i);l=v?R(v):c&&n.theme?"<span class='ui-icon ui-icon-"+c+"'></span>":d&&!n.theme?"<span class='fc-icon fc-icon-"+d+"'></span>":R(u||i);var h=t("<span class='fc-button fc-button-"+i+" "+f+"-state-default'>"+l+"</span>").click(function(){h.hasClass(f+"-state-disabled")||s()}).mousedown(function(){h.not("."+f+"-state-active").not("."+f+"-state-disabled").addClass(f+"-state-down")}).mouseup(function(){h.removeClass(f+"-state-down")}).hover(function(){h.not("."+f+"-state-active").not("."+f+"-state-disabled").addClass(f+"-state-hover")},function(){h.removeClass(f+"-state-hover").removeClass(f+"-state-down")}).appendTo(a);H(h),o||h.addClass(f+"-corner-left"),o=h}}}),o&&o.addClass(f+"-corner-right")}),a}function i(t){v.find("h2").html(t)}function s(t){v.find("span.fc-button-"+t).addClass(f+"-state-active")}function l(t){v.find("span.fc-button-"+t).removeClass(f+"-state-active")}function c(t){v.find("span.fc-button-"+t).addClass(f+"-state-disabled")}function d(t){v.find("span.fc-button-"+t).removeClass(f+"-state-disabled")}var u=this;u.render=r,u.destroy=a,u.updateTitle=i,u.activateButton=s,u.deactivateButton=l,u.disableButton=c,u.enableButton=d;var f,v=t([])}function c(e){function n(t,e){return!E||t.clone().stripZone()<E.clone().stripZone()||e.clone().stripZone()>S.clone().stripZone()}function r(t,e){E=t,S=e,O=[];var n=++H,r=_.length;F=r;for(var o=0;r>o;o++)a(_[o],n)}function a(e,n){o(e,function(r){var a,o,i=t.isArray(e.events);if(n==H){if(r)for(a=0;r.length>a;a++)o=r[a],i||(o=D(o,e)),o&&O.push(o);F--,F||M(O)}})}function o(n,r){var a,i,s=Re.sourceFetchers;for(a=0;s.length>a;a++){if(i=s[a].call(C,n,E.clone(),S.clone(),e.timezone,r),i===!0)return;if("object"==typeof i)return o(i,r),void 0}var l=n.events;if(l)t.isFunction(l)?(y(),l.call(C,E.clone(),S.clone(),e.timezone,function(t){r(t),b()})):t.isArray(l)?r(l):r();else{var c=n.url;if(c){var d,u=n.success,f=n.error,v=n.complete;d=t.isFunction(n.data)?n.data():n.data;var h=t.extend({},d||{}),p=Y(n.startParam,e.startParam),g=Y(n.endParam,e.endParam),m=Y(n.timezoneParam,e.timezoneParam);p&&(h[p]=E.format()),g&&(h[g]=S.format()),e.timezone&&"local"!=e.timezone&&(h[m]=e.timezone),y(),t.ajax(t.extend({},He,n,{data:h,success:function(e){e=e||[];var n=N(u,this,arguments);t.isArray(n)&&(e=n),r(e)},error:function(){N(f,this,arguments),r()},complete:function(){N(v,this,arguments),b()}}))}else r()}}function i(t){var e=s(t);e&&(_.push(e),F++,a(e,H))}function s(e){var n,r,a=Re.sourceNormalizers;if(t.isFunction(e)||t.isArray(e)?n={events:e}:"string"==typeof e?n={url:e}:"object"==typeof e&&(n=t.extend({},e),"string"==typeof n.className&&(n.className=n.className.split(/\s+/))),n){for(t.isArray(n.events)&&(n.events=t.map(n.events,function(t){return D(t,n)})),r=0;a.length>r;r++)a[r].call(C,n);return n}}function l(e){_=t.grep(_,function(t){return!c(t,e)}),O=t.grep(O,function(t){return!c(t.source,e)}),M(O)}function c(t,e){return t&&e&&u(t)==u(e)}function u(t){return("object"==typeof t?t.events||t.url:"")||t}function f(t){t.start=C.moment(t.start),t.end&&(t.end=C.moment(t.end)),w(t),h(t),M(O)}function h(t){var e,n,r,a;for(e=0;O.length>e;e++)if(n=O[e],n._id==t._id&&n!==t)for(r=0;W.length>r;r++)a=W[r],void 0!==t[a]&&(n[a]=t[a])}function p(t,e){var n=D(t);n&&(n.source||(e&&(R.events.push(n),n.source=R),O.push(n)),M(O))}function g(e){var n,r;for(null==e?e=function(){return!0}:t.isFunction(e)||(n=e+"",e=function(t){return t._id==n}),O=t.grep(O,e,!0),r=0;_.length>r;r++)t.isArray(_[r].events)&&(_[r].events=t.grep(_[r].events,e,!0));M(O)}function m(e){return t.isFunction(e)?t.grep(O,e):null!=e?(e+="",t.grep(O,function(t){return t._id==e})):O}function y(){A++||k("loading",null,!0,x())}function b(){--A||k("loading",null,!1,x())}function D(n,r){var a,o,i,s,l={};return e.eventDataTransform&&(n=e.eventDataTransform(n)),r&&r.eventDataTransform&&(n=r.eventDataTransform(n)),a=C.moment(n.start||n.date),a.isValid()&&(o=null,!n.end||(o=C.moment(n.end),o.isValid()))?(i=n.allDay,void 0===i&&(s=Y(r?r.allDayDefault:void 0,e.allDayDefault),i=void 0!==s?s:!(a.hasTime()||o&&o.hasTime())),i?(a.hasTime()&&a.stripTime(),o&&o.hasTime()&&o.stripTime()):(a.hasTime()||(a=C.rezoneDate(a)),o&&!o.hasTime()&&(o=C.rezoneDate(o))),t.extend(l,n),r&&(l.source=r),l._id=n._id||(void 0===n.id?"_fc"+Fe++:n.id+""),l.className=n.className?"string"==typeof n.className?n.className.split(/\s+/):n.className:[],l.allDay=i,l.start=a,l.end=o,e.forceEventDuration&&!l.end&&(l.end=z(l)),d(l),l):void 0}function w(t,e,n){var r,a,o,i,s=t._allDay,l=t._start,c=t._end,d=!1;return e||n||(e=t.start,n=t.end),r=t.allDay!=s?t.allDay:!(e||n).hasTime(),r&&(e&&(e=e.clone().stripTime()),n&&(n=n.clone().stripTime())),e&&(a=r?v(e,l.clone().stripTime()):v(e,l)),r!=s?d=!0:n&&(o=v(n||C.getDefaultEventEnd(r,e||l),e||l).subtract(v(c||C.getDefaultEventEnd(s,l),l))),i=T(m(t._id),d,r,a,o),{dateDelta:a,durationDelta:o,undo:i}}function T(n,r,a,o,i){var s=C.getIsAmbigTimezone(),l=[];return t.each(n,function(t,n){var c=n._allDay,u=n._start,f=n._end,v=null!=a?a:c,h=u.clone(),p=!r&&f?f.clone():null;v?(h.stripTime(),p&&p.stripTime()):(h.hasTime()||(h=C.rezoneDate(h)),p&&!p.hasTime()&&(p=C.rezoneDate(p))),p||!e.forceEventDuration&&!+i||(p=C.getDefaultEventEnd(v,h)),h.add(o),p&&p.add(o).add(i),s&&(+o||+i)&&(h.stripZone(),p&&p.stripZone()),n.allDay=v,n.start=h,n.end=p,d(n),l.push(function(){n.allDay=c,n.start=u,n.end=f,d(n)})}),function(){for(var t=0;l.length>t;t++)l[t]()}}var C=this;C.isFetchNeeded=n,C.fetchEvents=r,C.addEventSource=i,C.removeEventSource=l,C.updateEvent=f,C.renderEvent=p,C.removeEvents=g,C.clientEvents=m,C.mutateEvent=w;var E,S,k=C.trigger,x=C.getView,M=C.reportEvents,z=C.getEventEnd,R={events:[]},_=[R],H=0,F=0,A=0,O=[];t.each((e.events?[e.events]:[]).concat(e.eventSources||[]),function(t,e){var n=s(e);n&&_.push(n)});var W=["title","url","allDay","className","editable","color","backgroundColor","borderColor","textColor"]}function d(t){t._allDay=t.allDay,t._start=t.start.clone(),t._end=t.end?t.end.clone():null}function u(t){var e=function(){};return e.prototype=t,new e}function f(t,e){for(var n in e)e.hasOwnProperty(n)&&(t[n]=e[n])}function v(t,n){return e.duration({days:t.clone().stripTime().diff(n.clone().stripTime(),"days"),ms:t.time()-n.time()})}function h(t){return"[object Date]"===Object.prototype.toString.call(t)||t instanceof Date}function p(e,n,r){e.unbind("mouseover").mouseover(function(e){for(var a,o,i,s=e.target;s!=this;)a=s,s=s.parentNode;void 0!==(o=a._fci)&&(a._fci=void 0,i=n[o],r(i.event,i.element,i),t(e.target).trigger(e)),e.stopPropagation()})}function g(e,n,r){for(var a,o=0;e.length>o;o++)a=t(e[o]),a.width(Math.max(0,n-y(a,r)))}function m(e,n,r){for(var a,o=0;e.length>o;o++)a=t(e[o]),a.height(Math.max(0,n-T(a,r)))}function y(t,e){return b(t)+w(t)+(e?D(t):0)}function b(e){return(parseFloat(t.css(e[0],"paddingLeft",!0))||0)+(parseFloat(t.css(e[0],"paddingRight",!0))||0)}function D(e){return(parseFloat(t.css(e[0],"marginLeft",!0))||0)+(parseFloat(t.css(e[0],"marginRight",!0))||0)}function w(e){return(parseFloat(t.css(e[0],"borderLeftWidth",!0))||0)+(parseFloat(t.css(e[0],"borderRightWidth",!0))||0)}function T(t,e){return C(t)+S(t)+(e?E(t):0)}function C(e){return(parseFloat(t.css(e[0],"paddingTop",!0))||0)+(parseFloat(t.css(e[0],"paddingBottom",!0))||0)}function E(e){return(parseFloat(t.css(e[0],"marginTop",!0))||0)+(parseFloat(t.css(e[0],"marginBottom",!0))||0)}function S(e){return(parseFloat(t.css(e[0],"borderTopWidth",!0))||0)+(parseFloat(t.css(e[0],"borderBottomWidth",!0))||0)}function k(){}function x(t,e){return t-e}function M(t){return Math.max.apply(Math,t)}function z(t,e){if(t=t||{},void 0!==t[e])return t[e];for(var n,r=e.split(/(?=[A-Z])/),a=r.length-1;a>=0;a--)if(n=t[r[a].toLowerCase()],void 0!==n)return n;return t["default"]}function R(t){return(t+"").replace(/&/g,"&amp;").replace(/</g,"&lt;").replace(/>/g,"&gt;").replace(/'/g,"&#039;").replace(/"/g,"&quot;").replace(/\n/g,"<br />")}function _(t){return t.replace(/&.*?;/g,"")}function H(t){t.attr("unselectable","on").css("MozUserSelect","none").bind("selectstart.ui",function(){return!1})}function F(t){t.children().removeClass("fc-first fc-last").filter(":first-child").addClass("fc-first").end().filter(":last-child").addClass("fc-last")}function A(t,e){var n=t.source||{},r=t.color,a=n.color,o=e("eventColor"),i=t.backgroundColor||r||n.backgroundColor||a||e("eventBackgroundColor")||o,s=t.borderColor||r||n.borderColor||a||e("eventBorderColor")||o,l=t.textColor||n.textColor||e("eventTextColor"),c=[];return i&&c.push("background-color:"+i),s&&c.push("border-color:"+s),l&&c.push("color:"+l),c.join(";")}function N(e,n,r){if(t.isFunction(e)&&(e=[e]),e){var a,o;for(a=0;e.length>a;a++)o=e[a].apply(n,r)||o;return o}}function Y(){for(var t=0;arguments.length>t;t++)if(void 0!==arguments[t])return arguments[t]}function O(n,r,a){var o,i,s,l,c=n[0],d=1==n.length&&"string"==typeof c;return e.isMoment(c)?(l=e.apply(null,n),c._ambigTime&&(l._ambigTime=!0),c._ambigZone&&(l._ambigZone=!0)):h(c)||void 0===c?l=e.apply(null,n):(o=!1,i=!1,d?Ne.test(c)?(c+="-01",n=[c],o=!0,i=!0):(s=Ye.exec(c))&&(o=!s[5],i=!0):t.isArray(c)&&(i=!0),l=r?e.utc.apply(e,n):e.apply(null,n),o?(l._ambigTime=!0,l._ambigZone=!0):a&&(i?l._ambigZone=!0:d&&l.zone(c))),new W(l)}function W(t){f(this,t)}function L(t){var e,n=[],r=!1,a=!1;for(e=0;t.length>e;e++)n.push(Re.moment(t[e])),r=r||n[e]._ambigTime,a=a||n[e]._ambigZone;for(e=0;n.length>e;e++)r?n[e].stripTime():a&&n[e].stripZone();return n}function Z(t,n){return e.fn.format.call(t,n)}function B(t,e){return P(t,V(e))}function P(t,e){var n,r="";for(n=0;e.length>n;n++)r+=j(t,e[n]);return r}function j(t,e){var n,r;return"string"==typeof e?e:(n=e.token)?Oe[n]?Oe[n](t):Z(t,n):e.maybe&&(r=P(t,e.maybe),r.match(/[1-9]/))?r:""}function I(t,e,n,r,a){return t=Re.moment.parseZone(t),e=Re.moment.parseZone(e),n=t.lang().longDateFormat(n)||n,r=r||" - ",q(t,e,V(n),r,a)}function q(t,e,n,r,a){var o,i,s,l,c="",d="",u="",f="",v="";for(i=0;n.length>i&&(o=$(t,e,n[i]),o!==!1);i++)c+=o;for(s=n.length-1;s>i&&(o=$(t,e,n[s]),o!==!1);s--)d=o+d;for(l=i;s>=l;l++)u+=j(t,n[l]),f+=j(e,n[l]);return(u||f)&&(v=a?f+r+u:u+r+f),c+v+d}function $(t,e,n){var r,a;return"string"==typeof n?n:(r=n.token)&&(a=We[r.charAt(0)],a&&t.isSame(e,a))?Z(t,r):!1}function V(t){return t in Le?Le[t]:Le[t]=X(t)}function X(t){for(var e,n=[],r=/\[([^\]]*)\]|\(([^\)]*)\)|(LT|(\w)\4*o?)|([^\w\[\(]+)/g;e=r.exec(t);)e[1]?n.push(e[1]):e[2]?n.push({maybe:X(e[2])}):e[3]?n.push({token:e[3]}):e[5]&&n.push(e[5]);return n}function U(t,e){function n(t,e){return t.clone().stripTime().add("months",e).startOf("month")}function r(t){a.intervalStart=t.clone().stripTime().startOf("month"),a.intervalEnd=a.intervalStart.clone().add("months",1),a.start=a.intervalStart.clone(),a.start=a.skipHiddenDays(a.start),a.start.startOf("week"),a.start=a.skipHiddenDays(a.start),a.end=a.intervalEnd.clone(),a.end=a.skipHiddenDays(a.end,-1,!0),a.end.add("days",(7-a.end.weekday())%7),a.end=a.skipHiddenDays(a.end,-1,!0);var n=Math.ceil(a.end.diff(a.start,"weeks",!0));"fixed"==a.opt("weekMode")&&(a.end.add("weeks",6-n),n=6),a.title=e.formatDate(a.intervalStart,a.opt("titleFormat")),a.renderBasic(n,a.getCellsPerWeek(),!0)}var a=this;a.incrementDate=n,a.render=r,J.call(a,t,e,"month")}function G(t,e){function n(t,e){return t.clone().stripTime().add("weeks",e).startOf("week")}function r(t){a.intervalStart=t.clone().stripTime().startOf("week"),a.intervalEnd=a.intervalStart.clone().add("weeks",1),a.start=a.skipHiddenDays(a.intervalStart),a.end=a.skipHiddenDays(a.intervalEnd,-1,!0),a.title=e.formatRange(a.start,a.end.clone().subtract(1),a.opt("titleFormat")," — "),a.renderBasic(1,a.getCellsPerWeek(),!1)}var a=this;a.incrementDate=n,a.render=r,J.call(a,t,e,"basicWeek")}function Q(t,e){function n(t,e){var n=t.clone().stripTime().add("days",e);return n=a.skipHiddenDays(n,0>e?-1:1)}function r(t){a.start=a.intervalStart=t.clone().stripTime(),a.end=a.intervalEnd=a.start.clone().add("days",1),a.title=e.formatDate(a.start,a.opt("titleFormat")),a.renderBasic(1,1,!1)}var a=this;a.incrementDate=n,a.render=r,J.call(a,t,e,"basicDay")}function J(e,n,r){function a(t,e,n){U=t,G=e,Q=n,o(),W||i(),s()}function o(){re=ie("theme")?"ui":"fc",ae=ie("columnFormat"),oe=ie("weekNumbers")}function i(){I=t("<div class='fc-event-container' style='position:absolute;z-index:8;top:0;left:0'/>").appendTo(e)}function s(){var n=l();N&&N.remove(),N=t(n).appendTo(e),Y=N.find("thead"),O=Y.find(".fc-day-header"),W=N.find("tbody"),L=W.find("tr"),Z=W.find(".fc-day"),B=L.find("td:first-child"),P=L.eq(0).find(".fc-day > div"),j=L.eq(0).find(".fc-day-content > div"),F(Y.add(Y.find("tr"))),F(L),L.eq(0).addClass("fc-first"),L.filter(":last").addClass("fc-last"),Z.each(function(e,n){var r=ue(Math.floor(e/G),e%G);se("dayRender",A,r,t(n))}),h(Z)}function l(){var t="<table class='fc-border-separate' style='width:100%' cellspacing='0'>"+c()+d()+"</table>";return t}function c(){var t,e,n=re+"-widget-header",r="";for(r+="<thead><tr>",oe&&(r+="<th class='fc-week-number "+n+"'>"+R(ie("weekNumberTitle"))+"</th>"),t=0;G>t;t++)e=ue(0,t),r+="<th class='fc-day-header fc-"+Ae[e.day()]+" "+n+"'>"+R(he(e,ae))+"</th>";return r+="</tr></thead>"}function d(){var t,e,n,r=re+"-widget-content",a="";for(a+="<tbody>",t=0;U>t;t++){for(a+="<tr class='fc-week'>",oe&&(n=ue(t,0),a+="<td class='fc-week-number "+r+"'>"+"<div>"+R(pe(n))+"</div>"+"</td>"),e=0;G>e;e++)n=ue(t,e),a+=u(n);a+="</tr>"}return a+="</tbody>"}function u(t){var e=A.intervalStart.month(),r=n.getNow().stripTime(),a="",o=re+"-widget-content",i=["fc-day","fc-"+Ae[t.day()],o];return t.month()!=e&&i.push("fc-other-month"),t.isSame(r,"day")?i.push("fc-today",re+"-state-highlight"):r>t?i.push("fc-past"):i.push("fc-future"),a+="<td class='"+i.join(" ")+"'"+" data-date='"+t.format()+"'"+">"+"<div>",Q&&(a+="<div class='fc-day-number'>"+t.date()+"</div>"),a+="<div class='fc-day-content'><div style='position:relative'>&nbsp;</div></div></div></td>"}function f(e){$=e;var n,r,a,o=Math.max($-Y.height(),0);"variable"==ie("weekMode")?n=r=Math.floor(o/(1==U?2:6)):(n=Math.floor(o/U),r=o-n*(U-1)),B.each(function(e,o){U>e&&(a=t(o),a.find("> div").css("min-height",(e==U-1?r:n)-T(a)))})}function v(t){q=t,ee.clear(),ne.clear(),X=0,oe&&(X=Y.find("th.fc-week-number").outerWidth()),V=Math.floor((q-X)/G),g(O.slice(0,-1),V)}function h(t){t.click(p).mousedown(de)}function p(e){if(!ie("selectable")){var r=n.moment(t(this).data("date"));se("dayClick",this,r,e)}}function m(t,e,n){n&&J.build();for(var r=ve(t,e),a=0;r.length>a;a++){var o=r[a];h(y(o.row,o.leftCol,o.row,o.rightCol))}}function y(t,n,r,a){var o=J.rect(t,n,r,a,e);return le(o,e)}function b(t){return t.clone().stripTime().add("days",1)}function D(t,e){m(t,e,!0)}function w(){ce()}function C(t,e){var n=fe(t),r=Z[n.row*G+n.col];se("dayClick",r,t,e)}function E(t,e){te.start(function(t){if(ce(),t){var e=ue(t),r=e.clone().add(n.defaultAllDayEventDuration);m(e,r)}},e)}function S(t,e,n){var r=te.stop();ce(),r&&se("drop",t,ue(r),e,n)}function k(t){return ee.left(t)}function x(t){return ee.right(t)}function M(t){return ne.left(t)}function z(t){return ne.right(t)}function _(t){return L.eq(t)}var A=this;A.renderBasic=a,A.setHeight=f,A.setWidth=v,A.renderDayOverlay=m,A.defaultSelectionEnd=b,A.renderSelection=D,A.clearSelection=w,A.reportDayClick=C,A.dragStart=E,A.dragStop=S,A.getHoverListener=function(){return te},A.colLeft=k,A.colRight=x,A.colContentLeft=M,A.colContentRight=z,A.getIsCellAllDay=function(){return!0},A.allDayRow=_,A.getRowCnt=function(){return U},A.getColCnt=function(){return G},A.getColWidth=function(){return V},A.getDaySegmentContainer=function(){return I},ge.call(A,e,n,r),Te.call(A),we.call(A),K.call(A);var N,Y,O,W,L,Z,B,P,j,I,q,$,V,X,U,G,Q,J,te,ee,ne,re,ae,oe,ie=A.opt,se=A.trigger,le=A.renderOverlay,ce=A.clearOverlays,de=A.daySelectionMousedown,ue=A.cellToDate,fe=A.dateToCell,ve=A.rangeToSegments,he=n.formatDate,pe=n.calculateWeekNumber;H(e.addClass("fc-grid")),J=new Ce(function(e,n){var r,a,o;O.each(function(e,i){r=t(i),a=r.offset().left,e&&(o[1]=a),o=[a],n[e]=o}),o[1]=a+r.outerWidth(),L.each(function(n,i){U>n&&(r=t(i),a=r.offset().top,n&&(o[1]=a),o=[a],e[n]=o)}),o[1]=a+r.outerHeight()}),te=new Ee(J),ee=new ke(function(t){return P.eq(t)}),ne=new ke(function(t){return j.eq(t)})}function K(){function t(t,e){n.renderDayEvents(t,e)}function e(){n.getDaySegmentContainer().empty()}var n=this;n.renderEvents=t,n.clearEvents=e,me.call(n)}function te(t,e){function n(t,e){return t.clone().stripTime().add("weeks",e).startOf("week")}function r(t){a.intervalStart=t.clone().stripTime().startOf("week"),a.intervalEnd=a.intervalStart.clone().add("weeks",1),a.start=a.skipHiddenDays(a.intervalStart),a.end=a.skipHiddenDays(a.intervalEnd,-1,!0),a.title=e.formatRange(a.start,a.end.clone().subtract(1),a.opt("titleFormat")," — "),a.renderAgenda(a.getCellsPerWeek())}var a=this;a.incrementDate=n,a.render=r,ae.call(a,t,e,"agendaWeek")}function ee(t,e){function n(t,e){var n=t.clone().stripTime().add("days",e);return n=a.skipHiddenDays(n,0>e?-1:1)}function r(t){a.start=a.intervalStart=t.clone().stripTime(),a.end=a.intervalEnd=a.start.clone().add("days",1),a.title=e.formatDate(a.start,a.opt("titleFormat")),a.renderAgenda(1)}var a=this;a.incrementDate=n,a.render=r,ae.call(a,t,e,"agendaDay")}function ne(t,e){return e.longDateFormat("LT").replace(":mm","(:mm)").replace(/(\Wmm)$/,"($1)").replace(/\s*a$/i,"a")}function re(t,e){return e.longDateFormat("LT").replace(/\s*a$/i,"")}function ae(n,r,a){function o(t){xe=t,i(),$?l():s()}function i(){Fe=Le("theme")?"ui":"fc",Ne=Le("isRTL"),We=Le("columnFormat"),Ye=e.duration(Le("minTime")),Oe=e.duration(Le("maxTime")),me=e.duration(Le("slotDuration")),be=Le("snapDuration"),be=be?e.duration(be):me}function s(){var r,a,o,i,s=Fe+"-widget-header",c=Fe+"-widget-content",d=0===me.asMinutes()%15;for(l(),ee=t("<div style='position:absolute;z-index:2;left:0;width:100%'/>").appendTo(n),Le("allDaySlot")?(ne=t("<div class='fc-event-container' style='position:absolute;z-index:8;top:0;left:0'/>").appendTo(ee),r="<table style='width:100%' class='fc-agenda-allday' cellspacing='0'><tr><th class='"+s+" fc-agenda-axis'>"+(Le("allDayHTML")||R(Le("allDayText")))+"</th>"+"<td>"+"<div class='fc-day-content'><div style='position:relative'/></div>"+"</td>"+"<th class='"+s+" fc-agenda-gutter'>&nbsp;</th>"+"</tr>"+"</table>",re=t(r).appendTo(ee),ae=re.find("tr"),y(ae.find("td")),ee.append("<div class='fc-agenda-divider "+s+"'>"+"<div class='fc-agenda-divider-inner'/>"+"</div>")):ne=t([]),ie=t("<div style='position:absolute;width:100%;overflow-x:hidden;overflow-y:auto'/>").appendTo(ee),se=t("<div style='position:relative;width:100%;overflow:hidden'/>").appendTo(ie),le=t("<div class='fc-event-container' style='position:absolute;z-index:8;top:0;left:0'/>").appendTo(se),r="<table class='fc-agenda-slots' style='width:100%' cellspacing='0'><tbody>",a=e.duration(+Ye),Me=0;Oe>a;)o=q.start.clone().time(a),i=o.minutes(),r+="<tr class='fc-slot"+Me+" "+(i?"fc-minor":"")+"'>"+"<th class='fc-agenda-axis "+s+"'>"+(d&&i?"&nbsp;":R(Ge(o,Le("axisFormat"))))+"</th>"+"<td class='"+c+"'>"+"<div style='position:relative'>&nbsp;</div>"+"</td>"+"</tr>",a.add(me),Me++;r+="</tbody></table>",ce=t(r).appendTo(se),b(ce.find("td"))}function l(){var e=c();$&&$.remove(),$=t(e).appendTo(n),V=$.find("thead"),X=V.find("th").slice(1,-1),U=$.find("tbody"),G=U.find("td").slice(0,-1),Q=G.find("> div"),J=G.find(".fc-day-content > div"),K=G.eq(0),te=Q.eq(0),F(V.add(V.find("tr"))),F(U.add(U.find("tr")))}function c(){var t="<table style='width:100%' class='fc-agenda-days fc-border-separate' cellspacing='0'>"+d()+u()+"</table>";return t}function d(){var t,e,n,r=Fe+"-widget-header",a="";for(a+="<thead><tr>",Le("weekNumbers")?(t=Ve(0,0),e=Qe(t),Ne?e+=Le("weekNumberTitle"):e=Le("weekNumberTitle")+e,a+="<th class='fc-agenda-axis fc-week-number "+r+"'>"+R(e)+"</th>"):a+="<th class='fc-agenda-axis "+r+"'>&nbsp;</th>",n=0;xe>n;n++)t=Ve(0,n),a+="<th class='fc-"+Ae[t.day()]+" fc-col"+n+" "+r+"'>"+R(Ge(t,We))+"</th>";return a+="<th class='fc-agenda-gutter "+r+"'>&nbsp;</th>"+"</tr>"+"</thead>"}function u(){var t,e,n,a,o,i=Fe+"-widget-header",s=Fe+"-widget-content",l=r.getNow().stripTime(),c="";for(c+="<tbody><tr><th class='fc-agenda-axis "+i+"'>&nbsp;</th>",n="",e=0;xe>e;e++)t=Ve(0,e),o=["fc-col"+e,"fc-"+Ae[t.day()],s],t.isSame(l,"day")?o.push(Fe+"-state-highlight","fc-today"):l>t?o.push("fc-past"):o.push("fc-future"),a="<td class='"+o.join(" ")+"'>"+"<div>"+"<div class='fc-day-content'>"+"<div style='position:relative'>&nbsp;</div>"+"</div>"+"</div>"+"</td>",n+=a;return c+=n,c+="<td class='fc-agenda-gutter "+s+"'>&nbsp;</td>"+"</tr>"+"</tbody>"}function f(t){void 0===t&&(t=fe),fe=t,Je={};var e=U.position().top,n=ie.position().top,r=Math.min(t-e,ce.height()+n+1);te.height(r-T(K)),ee.css("top",e),ie.height(r-n-1);var a=ce.find("tr:first").height()+1,o=ce.find("tr:eq(1)").height();ye=(a+o)/2,De=me/be,Se=ye/De}function v(e){ue=e,_e.clear(),He.clear();var n=V.find("th:first");re&&(n=n.add(re.find("th:first"))),n=n.add(ce.find("th:first")),ve=0,g(n.width("").each(function(e,n){ve=Math.max(ve,t(n).outerWidth())}),ve);var r=$.find(".fc-agenda-gutter");re&&(r=r.add(re.find("th.fc-agenda-gutter")));var a=ie[0].clientWidth;pe=ie.width()-a,pe?(g(r,pe),r.show().prev().removeClass("fc-last")):r.hide().prev().addClass("fc-last"),he=Math.floor((a-ve)/xe),g(X.slice(0,-1),he)}function h(){function t(){ie.scrollTop(n)}var n=Y(e.duration(Le("scrollTime")))+1;t(),setTimeout(t,0)}function p(){h()}function y(t){t.click(D).mousedown(qe)}function b(t){t.click(D).mousedown(B)}function D(t){if(!Le("selectable")){var e=Math.min(xe-1,Math.floor((t.pageX-$.offset().left-ve)/he)),n=Ve(0,e),a=this.parentNode.className.match(/fc-slot(\d+)/);if(a){var o=parseInt(a[1],10);n.add(Ye+o*me),n=r.rezoneDate(n),Ze("dayClick",G[e],n,t)}else Ze("dayClick",G[e],n,t)}}function w(t,e,n){n&&ze.build();for(var r=Ue(t,e),a=0;r.length>a;a++){var o=r[a];y(C(o.row,o.leftCol,o.row,o.rightCol))}}function C(t,e,n,r){var a=ze.rect(t,e,n,r,ee);return Be(a,ee)}function E(t,e){t=t.clone().stripZone(),e=e.clone().stripZone();for(var n=0;xe>n;n++){var r=Ve(0,n),a=r.clone().add("days",1),o=t>r?t:r,i=e>a?a:e;if(i>o){var s=ze.rect(0,n,0,n,se),l=N(o,r),c=N(i,r);s.top=l,s.height=c-l,b(Be(s,se))}}}function S(t){return _e.left(t)}function k(t){return He.left(t)}function M(t){return _e.right(t)}function z(t){return He.right(t)}function _(t){return Le("allDaySlot")&&!t.row}function A(t){var n=Ve(0,t.col),a=t.row;return Le("allDaySlot")&&a--,a>=0&&(n.time(e.duration(Ye+a*be)),n=r.rezoneDate(n)),n}function N(t,n){return Y(e.duration(t.clone().stripZone()-n.clone().stripTime()))}function Y(t){if(Ye>t)return 0;if(t>=Oe)return ce.height();var e=(t-Ye)/me,n=Math.floor(e),r=e-n,a=Je[n];void 0===a&&(a=Je[n]=ce.find("tr").eq(n).find("td div")[0].offsetTop);var o=a-1+r*ye;return o=Math.max(o,0)}function O(t){return t.hasTime()?t.clone().add(me):t.clone().add("days",1)}function W(t,e){t.hasTime()||e.hasTime()?L(t,e):Le("allDaySlot")&&w(t,e,!0)}function L(e,n){var r=Le("selectHelper");if(ze.build(),r){var a=Xe(e).col;if(a>=0&&xe>a){var o=ze.rect(0,a,0,a,se),i=N(e,e),s=N(n,e);if(s>i){if(o.top=i,o.height=s-i,o.left+=2,o.width-=5,t.isFunction(r)){var l=r(e,n);l&&(o.position="absolute",de=t(l).css(o).appendTo(se))}else o.isStart=!0,o.isEnd=!0,de=t($e({title:"",start:e,end:n,className:["fc-select-helper"],editable:!1},o)),de.css("opacity",Le("dragOpacity"));de&&(b(de),se.append(de),g(de,o.width,!0),m(de,o.height,!0))}}}else E(e,n)}function Z(){Pe(),de&&(de.remove(),de=null)}function B(e){if(1==e.which&&Le("selectable")){Ie(e);var n;Re.start(function(t,e){if(Z(),t&&t.col==e.col&&!_(t)){var r=A(e),a=A(t);n=[r,r.clone().add(be),a,a.clone().add(be)].sort(x),L(n[0],n[3])}else n=null},e),t(document).one("mouseup",function(t){Re.stop(),n&&(+n[0]==+n[1]&&P(n[0],t),je(n[0],n[3],t))})}}function P(t,e){Ze("dayClick",G[Xe(t).col],t,e)}function j(t,e){Re.start(function(t){if(Pe(),t){var e=A(t),n=e.clone();e.hasTime()?(n.add(r.defaultTimedEventDuration),E(e,n)):(n.add(r.defaultAllDayEventDuration),w(e,n))}},e)}function I(t,e,n){var r=Re.stop();Pe(),r&&Ze("drop",t,A(r),e,n)}var q=this;q.renderAgenda=o,q.setWidth=v,q.setHeight=f,q.afterRender=p,q.computeDateTop=N,q.getIsCellAllDay=_,q.allDayRow=function(){return ae},q.getCoordinateGrid=function(){return ze},q.getHoverListener=function(){return Re},q.colLeft=S,q.colRight=M,q.colContentLeft=k,q.colContentRight=z,q.getDaySegmentContainer=function(){return ne},q.getSlotSegmentContainer=function(){return le},q.getSlotContainer=function(){return se},q.getRowCnt=function(){return 1},q.getColCnt=function(){return xe},q.getColWidth=function(){return he},q.getSnapHeight=function(){return Se},q.getSnapDuration=function(){return be},q.getSlotHeight=function(){return ye},q.getSlotDuration=function(){return me},q.getMinTime=function(){return Ye},q.getMaxTime=function(){return Oe},q.defaultSelectionEnd=O,q.renderDayOverlay=w,q.renderSelection=W,q.clearSelection=Z,q.reportDayClick=P,q.dragStart=j,q.dragStop=I,ge.call(q,n,r,a),Te.call(q),we.call(q),oe.call(q);var $,V,X,U,G,Q,J,K,te,ee,ne,re,ae,ie,se,le,ce,de,ue,fe,ve,he,pe,me,ye,be,De,Se,xe,Me,ze,Re,_e,He,Fe,Ne,Ye,Oe,We,Le=q.opt,Ze=q.trigger,Be=q.renderOverlay,Pe=q.clearOverlays,je=q.reportSelection,Ie=q.unselect,qe=q.daySelectionMousedown,$e=q.slotSegHtml,Ve=q.cellToDate,Xe=q.dateToCell,Ue=q.rangeToSegments,Ge=r.formatDate,Qe=r.calculateWeekNumber,Je={};
H(n.addClass("fc-agenda")),ze=new Ce(function(e,n){function r(t){return Math.max(l,Math.min(c,t))}var a,o,i;X.each(function(e,r){a=t(r),o=a.offset().left,e&&(i[1]=o),i=[o],n[e]=i}),i[1]=o+a.outerWidth(),Le("allDaySlot")&&(a=ae,o=a.offset().top,e[0]=[o,o+a.outerHeight()]);for(var s=se.offset().top,l=ie.offset().top,c=l+ie.outerHeight(),d=0;Me*De>d;d++)e.push([r(s+Se*d),r(s+Se*(d+1))])}),Re=new Ee(ze),_e=new ke(function(t){return Q.eq(t)}),He=new ke(function(t){return J.eq(t)})}function oe(){function n(t,e){var n,r=t.length,o=[],s=[];for(n=0;r>n;n++)t[n].allDay?o.push(t[n]):s.push(t[n]);v("allDaySlot")&&(V(o,e),w()),i(a(s),e)}function r(){C().empty(),E().empty()}function a(t){var e,n,r,a,i,s=H(),l=X(),c=U(),d=[];for(n=0;s>n;n++)for(e=_(0,n),i=o(t,e.clone().time(l),e.clone().time(c)),i=ie(i),r=0;i.length>r;r++)a=i[r],a.col=n,d.push(a);return d}function o(t,e,n){e=e.clone().stripZone(),n=n.clone().stripZone();var r,a,o,i,s,l,c,d,u=[],f=t.length;for(r=0;f>r;r++)a=t[r],o=a.start.clone().stripZone(),i=J(a).stripZone(),i>e&&n>o&&(e>o?(s=e.clone(),c=!1):(s=o,c=!0),i>n?(l=n.clone(),d=!1):(l=i,d=!0),u.push({event:a,start:s,end:l,isStart:c,isEnd:d}));return u.sort(pe)}function i(e,n){var r,a,o,i,c,d,u,f,g,m,b,D,w,C,S,x,R=e.length,_="",H=E(),F=v("isRTL");for(r=0;R>r;r++)a=e[r],o=a.event,i=k(a.start,a.start),c=k(a.end,a.start),d=M(a.col),u=z(a.col),f=u-d,u-=.025*f,f=u-d,g=f*(a.forwardCoord-a.backwardCoord),v("slotEventOverlap")&&(g=Math.max(2*(g-10),g)),F?(b=u-a.backwardCoord*f,m=b-g):(m=d+a.backwardCoord*f,b=m+g),m=Math.max(m,d),b=Math.min(b,u),g=b-m,a.top=i,a.left=m,a.outerWidth=g,a.outerHeight=c-i,_+=s(o,a);for(H[0].innerHTML=_,D=H.children(),r=0;R>r;r++)a=e[r],o=a.event,w=t(D[r]),C=h("eventRender",o,o,w),C===!1?w.remove():(C&&C!==!0&&(w.remove(),w=t(C).css({position:"absolute",top:a.top,left:a.left}).appendTo(H)),a.element=w,o._id===n?l(o,w,a):w[0]._fci=r,Z(o,w));for(p(H,e,l),r=0;R>r;r++)a=e[r],(w=a.element)&&(a.vsides=T(w,!0),a.hsides=y(w,!0),S=w.find(".fc-event-title"),S.length&&(a.contentTop=S[0].offsetTop));for(r=0;R>r;r++)a=e[r],(w=a.element)&&(w[0].style.width=Math.max(0,a.outerWidth-a.hsides)+"px",x=Math.max(0,a.outerHeight-a.vsides),w[0].style.height=x+"px",o=a.event,void 0!==a.contentTop&&10>x-a.contentTop&&(w.find("div.fc-event-time").text(Q(o.start,v("timeFormat"))+" - "+o.title),w.find("div.fc-event-title").remove()),h("eventAfterRender",o,o,w))}function s(t,e){var n="<",r=t.url,a=A(t,v),o=["fc-event","fc-event-vert"];return g(t)&&o.push("fc-event-draggable"),e.isStart&&o.push("fc-event-start"),e.isEnd&&o.push("fc-event-end"),o=o.concat(t.className),t.source&&(o=o.concat(t.source.className||[])),n+=r?"a href='"+R(t.url)+"'":"div",n+=" class='"+o.join(" ")+"'"+" style="+"'"+"position:absolute;"+"top:"+e.top+"px;"+"left:"+e.left+"px;"+a+"'"+">"+"<div class='fc-event-inner'>"+"<div class='fc-event-time'>"+R(f.getEventTimeText(t))+"</div>"+"<div class='fc-event-title'>"+R(t.title||"")+"</div>"+"</div>"+"<div class='fc-event-bg'></div>",e.isEnd&&b(t)&&(n+="<div class='ui-resizable-handle ui-resizable-s'>=</div>"),n+="</"+(r?"a":"div")+">"}function l(t,e,n){var r=e.find("div.fc-event-time");g(t)&&d(t,e,r),n.isEnd&&b(t)&&u(t,e,r),D(t,e)}function c(t,n,r){function a(){c||(n.width(o).height("").draggable("option","grid",null),c=!0)}var o,i,s,l=r.isStart,c=!0,d=S(),u=F(),f=X(),p=W(),g=O(),y=Y(),b=N();n.draggable({opacity:v("dragOpacity","month"),revertDuration:v("dragRevertDuration"),start:function(e,r){h("eventDragStart",n[0],t,e,r),P(t,n),o=n.width(),d.start(function(e,r){if($(),e){i=!1;var o=_(0,r.col),d=_(0,e.col);s=d.diff(o,"days"),e.row?l?c&&(n.width(u-10),m(n,G.defaultTimedEventDuration/p*g),n.draggable("option","grid",[u,1]),c=!1):i=!0:(q(t.start.clone().add("days",s),J(t).add("days",s)),a()),i=i||c&&!s}else a(),i=!0;n.draggable("option","revert",i)},e,"drag")},stop:function(r,o){if(d.stop(),$(),h("eventDragStop",n[0],t,r,o),i)a(),n.css("filter",""),B(t,n);else{var l,u,v=t.start.clone().add("days",s);c||(u=Math.round((n.offset().top-L().offset().top)/b),l=e.duration(f+u*y),v=G.rezoneDate(v.clone().time(l))),j(n[0],t,v,r,o)}}})}function d(t,e,n){function r(){$(),s&&(c?(n.hide(),e.draggable("option","grid",null),q(b,D)):(a(),n.css("display",""),e.draggable("option","grid",[C,E])))}function a(){b&&n.text(f.getEventTimeText(b,t.end?D:null))}var o,i,s,l,c,d,u,p,g,m,y,b,D,w=f.getCoordinateGrid(),T=H(),C=F(),E=N(),S=Y();e.draggable({scroll:!1,grid:[C,E],axis:1==T?"y":!1,opacity:v("dragOpacity"),revertDuration:v("dragRevertDuration"),start:function(n,r){h("eventDragStart",e[0],t,n,r),P(t,e),w.build(),o=e.position(),i=w.cell(n.pageX,n.pageY),s=l=!0,c=d=x(i),u=p=0,g=0,m=y=0,b=null,D=null},drag:function(n,a){var f=w.cell(n.pageX,n.pageY);if(s=!!f){if(c=x(f),u=Math.round((a.position.left-o.left)/C),u!=p){var v=_(0,i.col),h=i.col+u;h=Math.max(0,h),h=Math.min(T-1,h);var k=_(0,h);g=k.diff(v,"days")}c||(m=Math.round((a.position.top-o.top)/E))}(s!=l||c!=d||u!=p||m!=y)&&(c?(b=t.start.clone().stripTime().add("days",g),D=b.clone().add(G.defaultAllDayEventDuration)):(b=t.start.clone().add(m*S).add("days",g),D=J(t).add(m*S).add("days",g)),r(),l=s,d=c,p=u,y=m),e.draggable("option","revert",!s)},stop:function(n,a){$(),h("eventDragStop",e[0],t,n,a),s&&(c||g||m)?j(e[0],t,b,n,a):(s=!0,c=!1,u=0,g=0,m=0,r(),e.css("filter",""),e.css(o),B(t,e))}})}function u(t,e,n){var r,a,o,i=N(),s=Y();e.resizable({handles:{s:".ui-resizable-handle"},grid:i,start:function(n,o){r=a=0,P(t,e),h("eventResizeStart",e[0],t,n,o)},resize:function(l,c){if(r=Math.round((Math.max(i,e.height())-c.originalSize.height)/i),r!=a){o=J(t).add(s*r);var d;d=r?f.getEventTimeText(t.start,o):f.getEventTimeText(t),n.text(d),a=r}},stop:function(n,a){h("eventResizeStop",e[0],t,n,a),r?I(e[0],t,o,n,a):B(t,e)}})}var f=this;f.renderEvents=n,f.clearEvents=r,f.slotSegHtml=s,me.call(f);var v=f.opt,h=f.trigger,g=f.isEventDraggable,b=f.isEventResizable,D=f.eventElementHandlers,w=f.setHeight,C=f.getDaySegmentContainer,E=f.getSlotSegmentContainer,S=f.getHoverListener,k=f.computeDateTop,x=f.getIsCellAllDay,M=f.colContentLeft,z=f.colContentRight,_=f.cellToDate,H=f.getColCnt,F=f.getColWidth,N=f.getSnapHeight,Y=f.getSnapDuration,O=f.getSlotHeight,W=f.getSlotDuration,L=f.getSlotContainer,Z=f.reportEventElement,B=f.showEvents,P=f.hideEvents,j=f.eventDrop,I=f.eventResize,q=f.renderDayOverlay,$=f.clearOverlays,V=f.renderDayEvents,X=f.getMinTime,U=f.getMaxTime,G=f.calendar,Q=G.formatDate,J=G.getEventEnd;f.draggableDayEvent=c}function ie(t){var e,n=se(t),r=n[0];if(le(n),r){for(e=0;r.length>e;e++)ce(r[e]);for(e=0;r.length>e;e++)de(r[e],0,0)}return ue(n)}function se(t){var e,n,r,a=[];for(e=0;t.length>e;e++){for(n=t[e],r=0;a.length>r&&fe(n,a[r]).length;r++);(a[r]||(a[r]=[])).push(n)}return a}function le(t){var e,n,r,a,o;for(e=0;t.length>e;e++)for(n=t[e],r=0;n.length>r;r++)for(a=n[r],a.forwardSegs=[],o=e+1;t.length>o;o++)fe(a,t[o],a.forwardSegs)}function ce(t){var e,n,r=t.forwardSegs,a=0;if(void 0===t.forwardPressure){for(e=0;r.length>e;e++)n=r[e],ce(n),a=Math.max(a,1+n.forwardPressure);t.forwardPressure=a}}function de(t,e,n){var r,a=t.forwardSegs;if(void 0===t.forwardCoord)for(a.length?(a.sort(he),de(a[0],e+1,n),t.forwardCoord=a[0].backwardCoord):t.forwardCoord=1,t.backwardCoord=t.forwardCoord-(t.forwardCoord-n)/(e+1),r=0;a.length>r;r++)de(a[r],0,t.forwardCoord)}function ue(t){var e,n,r,a=[];for(e=0;t.length>e;e++)for(n=t[e],r=0;n.length>r;r++)a.push(n[r]);return a}function fe(t,e,n){n=n||[];for(var r=0;e.length>r;r++)ve(t,e[r])&&n.push(e[r]);return n}function ve(t,e){return t.end>e.start&&t.start<e.end}function he(t,e){return e.forwardPressure-t.forwardPressure||(t.backwardCoord||0)-(e.backwardCoord||0)||pe(t,e)}function pe(t,e){return t.start-e.start||e.end-e.start-(t.end-t.start)||(t.event.title||"").localeCompare(e.event.title)}function ge(n,r,a){function o(e,n){var r=O[e];return t.isPlainObject(r)&&!i(e)?z(r,n||a):r}function s(t,e){return r.trigger.apply(r,[t,e||H].concat(Array.prototype.slice.call(arguments,2),[H]))}function l(t){var e=t.source||{};return Y(t.startEditable,e.startEditable,o("eventStartEditable"),t.editable,e.editable,o("editable"))}function c(t){var e=t.source||{};return Y(t.durationEditable,e.durationEditable,o("eventDurationEditable"),t.editable,e.editable,o("editable"))}function d(){A={},N=[]}function u(t,e){N.push({event:t,element:e}),A[t._id]?A[t._id].push(e):A[t._id]=[e]}function f(){t.each(N,function(t,e){H.trigger("eventDestroy",e.event,e.event,e.element)})}function v(t,e){e.click(function(n){return e.hasClass("ui-draggable-dragging")||e.hasClass("ui-resizable-resizing")?void 0:s("eventClick",this,t,n)}).hover(function(e){s("eventMouseover",this,t,e)},function(e){s("eventMouseout",this,t,e)})}function h(t,e){g(t,e,"show")}function p(t,e){g(t,e,"hide")}function g(t,e,n){var r,a=A[t._id],o=a.length;for(r=0;o>r;r++)e&&a[r][0]==e[0]||a[r][n]()}function m(t,e,n,a,o){var i=r.mutateEvent(e,n,null);s("eventDrop",t,e,i.dateDelta,function(){i.undo(),F(e._id)},a,o),F(e._id)}function y(t,e,n,a,o){var i=r.mutateEvent(e,null,n);s("eventResize",t,e,i.durationDelta,function(){i.undo(),F(e._id)},a,o),F(e._id)}function b(t){return e.isMoment(t)&&(t=t.day()),B[t]}function D(){return L}function w(t,e,n){var r=t.clone();for(e=e||1;B[(r.day()+(n?e:0)+7)%7];)r.add("days",e);return r}function T(){var t=C.apply(null,arguments),e=E(t),n=S(e);return n}function C(t,e){var n=H.getColCnt(),r=I?-1:1,a=I?n-1:0;"object"==typeof t&&(e=t.col,t=t.row);var o=t*n+(e*r+a);return o}function E(t){var e=H.start.day();return t+=P[e],7*Math.floor(t/L)+j[(t%L+L)%L]-e}function S(t){return H.start.clone().add("days",t)}function k(t){var e=x(t),n=M(e),r=R(n);return r}function x(t){return t.clone().stripTime().diff(H.start,"days")}function M(t){var e=H.start.day();return t+=e,Math.floor(t/7)*L+P[(t%7+7)%7]-P[e]}function R(t){var e=H.getColCnt(),n=I?-1:1,r=I?e-1:0,a=Math.floor(t/e),o=(t%e+e)%e*n+r;return{row:a,col:o}}function _(t,e){var n=H.getRowCnt(),r=H.getColCnt(),a=[],o=x(t),i=x(e),s=+e.time();s&&s>=W&&i++,i=Math.max(i,o+1);for(var l=M(o),c=M(i)-1,d=0;n>d;d++){var u=d*r,f=u+r-1,v=Math.max(l,u),h=Math.min(c,f);if(h>=v){var p=R(v),g=R(h),m=[p.col,g.col].sort(),y=E(v)==o,b=E(h)+1==i;a.push({row:d,leftCol:m[0],rightCol:m[1],isStart:y,isEnd:b})}}return a}var H=this;H.element=n,H.calendar=r,H.name=a,H.opt=o,H.trigger=s,H.isEventDraggable=l,H.isEventResizable=c,H.clearEventData=d,H.reportEventElement=u,H.triggerEventDestroy=f,H.eventElementHandlers=v,H.showEvents=h,H.hideEvents=p,H.eventDrop=m,H.eventResize=y;var F=r.reportEventChange,A={},N=[],O=r.options,W=e.duration(O.nextDayThreshold);H.getEventTimeText=function(t){var e,n;return 2===arguments.length?(e=arguments[0],n=arguments[1]):(e=t.start,n=t.end),n&&o("displayEventEnd")?r.formatRange(e,n,o("timeFormat")):r.formatDate(e,o("timeFormat"))},H.isHiddenDay=b,H.skipHiddenDays=w,H.getCellsPerWeek=D,H.dateToCell=k,H.dateToDayOffset=x,H.dayOffsetToCellOffset=M,H.cellOffsetToCell=R,H.cellToDate=T,H.cellToCellOffset=C,H.cellOffsetToDayOffset=E,H.dayOffsetToDate=S,H.rangeToSegments=_;var L,Z=o("hiddenDays")||[],B=[],P=[],j=[],I=o("isRTL");(function(){o("weekends")===!1&&Z.push(0,6);for(var e=0,n=0;7>e;e++)P[e]=n,B[e]=-1!=t.inArray(e,Z),B[e]||(j[n]=e,n++);if(L=n,!L)throw"invalid hiddenDays"})()}function me(){function e(t,e){var n=r(t,!1,!0);be(n,function(t,e){x(t.event,e)}),m(n,e),be(n,function(t,e){E("eventAfterRender",t.event,t.event,e)})}function n(t,e,n){var a=r([t],!0,!1),o=[];return be(a,function(t,r){t.row===e&&r.css("top",n),o.push(r[0])}),o}function r(e,n,r){var o,l,u=I(),f=n?t("<div/>"):u,v=a(e);return i(v),o=s(v),f[0].innerHTML=o,l=f.children(),n&&u.append(l),c(v,l),be(v,function(t,e){t.hsides=y(e,!0)}),be(v,function(t,e){e.width(Math.max(0,t.outerWidth-t.hsides))}),be(v,function(t,e){t.outerHeight=e.outerHeight(!0)}),d(v,r),v}function a(t){for(var e=[],n=0;t.length>n;n++){var r=o(t[n]);e.push.apply(e,r)}return e}function o(t){for(var e=U(t.start,ne(t)),n=0;e.length>n;n++)e[n].event=t;return e}function i(t){for(var e=C("isRTL"),n=0;t.length>n;n++){var r=t[n],a=(e?r.isEnd:r.isStart)?P:Z,o=(e?r.isStart:r.isEnd)?j:B,i=a(r.leftCol),s=o(r.rightCol);r.left=i,r.outerWidth=s-i}}function s(t){for(var e="",n=0;t.length>n;n++)e+=l(t[n]);return e}function l(t){var e="",n=C("isRTL"),r=t.event,a=r.url,o=["fc-event","fc-event-hori"];S(r)&&o.push("fc-event-draggable"),t.isStart&&o.push("fc-event-start"),t.isEnd&&o.push("fc-event-end"),o=o.concat(r.className),r.source&&(o=o.concat(r.source.className||[]));var i=A(r,C);return e+=a?"<a href='"+R(a)+"'":"<div",e+=" class='"+o.join(" ")+"'"+" style="+"'"+"position:absolute;"+"left:"+t.left+"px;"+i+"'"+">"+"<div class='fc-event-inner'>",!r.allDay&&t.isStart&&(e+="<span class='fc-event-time'>"+R(T.getEventTimeText(r))+"</span>"),e+="<span class='fc-event-title'>"+R(r.title||"")+"</span>"+"</div>",r.allDay&&t.isEnd&&k(r)&&(e+="<div class='ui-resizable-handle ui-resizable-"+(n?"w":"e")+"'>"+"&nbsp;&nbsp;&nbsp;"+"</div>"),e+="</"+(a?"a":"div")+">"}function c(e,n){for(var r=0;e.length>r;r++){var a=e[r],o=a.event,i=n.eq(r),s=E("eventRender",o,o,i);s===!1?i.remove():(s&&s!==!0&&(s=t(s).css({position:"absolute",left:a.left}),i.replaceWith(s),i=s),a.element=i)}}function d(t,e){var n,r=u(t),a=g(),o=[];if(e)for(n=0;a.length>n;n++)a[n].height(r[n]);for(n=0;a.length>n;n++)o.push(a[n].position().top);be(t,function(t,e){e.css("top",o[t.row]+t.top)})}function u(t){for(var e,n=O(),r=W(),a=[],o=f(t),i=0;n>i;i++){var s=o[i],l=[];for(e=0;r>e;e++)l.push(0);for(var c=0;s.length>c;c++){var d=s[c];for(d.top=M(l.slice(d.leftCol,d.rightCol+1)),e=d.leftCol;d.rightCol>=e;e++)l[e]=d.top+d.outerHeight}a.push(M(l))}return a}function f(t){var e,n,r,a=O(),o=[];for(e=0;t.length>e;e++)n=t[e],r=n.row,n.element&&(o[r]?o[r].push(n):o[r]=[n]);for(r=0;a>r;r++)o[r]=v(o[r]||[]);return o}function v(t){for(var e=[],n=h(t),r=0;n.length>r;r++)e.push.apply(e,n[r]);return e}function h(t){t.sort(De);for(var e=[],n=0;t.length>n;n++){for(var r=t[n],a=0;e.length>a&&ye(r,e[a]);a++);e[a]?e[a].push(r):e[a]=[r]}return e}function g(){var t,e=O(),n=[];for(t=0;e>t;t++)n[t]=L(t).find("div.fc-day-content > div");return n}function m(t,e){var n=I();be(t,function(t,n,r){var a=t.event;a._id===e?b(a,n,t):n[0]._fci=r}),p(n,t,b)}function b(t,e,n){S(t)&&T.draggableDayEvent(t,e,n),t.allDay&&n.isEnd&&k(t)&&T.resizableDayEvent(t,e,n),z(t,e)}function D(t,e){var n,r,a=X();e.draggable({delay:50,opacity:C("dragOpacity"),revertDuration:C("dragRevertDuration"),start:function(o,i){E("eventDragStart",e[0],t,o,i),F(t,e),a.start(function(a,o,i,s){if(e.draggable("option","revert",!a||!i&&!s),$(),a){var l=G(o),c=G(a);n=c.diff(l,"days"),r=t.start.clone().add("days",n),q(r,ne(t).add("days",n))}else n=0},o,"drag")},stop:function(o,i){a.stop(),$(),E("eventDragStop",e[0],t,o,i),n?N(e[0],t,r,o,i):(e.css("filter",""),_(t,e))}})}function w(e,r,a){var o=C("isRTL"),i=o?"w":"e",s=r.find(".ui-resizable-"+i),l=!1;H(r),r.mousedown(function(t){t.preventDefault()}).click(function(t){l&&(t.preventDefault(),t.stopImmediatePropagation())}),s.mousedown(function(o){function s(n){E("eventResizeStop",r[0],e,n,{}),t("body").css("cursor",""),f.stop(),$(),c&&Y(r[0],e,d,n,{}),setTimeout(function(){l=!1},0)}if(1==o.which){l=!0;var c,d,u,f=X(),v=r.css("top"),h=t.extend({},e),p=te(K(e.start));V(),t("body").css("cursor",i+"-resize").one("mouseup",s),E("eventResizeStart",r[0],e,o,{}),f.start(function(r,o){if(r){var s=Q(o),l=Q(r);if(l=Math.max(l,p),c=J(l)-J(s),d=ne(e).add("days",c),c){h.end=d;var f=u;u=n(h,a.row,v),u=t(u),u.find("*").css("cursor",i+"-resize"),f&&f.remove(),F(e)}else u&&(_(e),u.remove(),u=null);$(),q(e.start,d)}},o)}})}var T=this;T.renderDayEvents=e,T.draggableDayEvent=D,T.resizableDayEvent=w;var C=T.opt,E=T.trigger,S=T.isEventDraggable,k=T.isEventResizable,x=T.reportEventElement,z=T.eventElementHandlers,_=T.showEvents,F=T.hideEvents,N=T.eventDrop,Y=T.eventResize,O=T.getRowCnt,W=T.getColCnt,L=T.allDayRow,Z=T.colLeft,B=T.colRight,P=T.colContentLeft,j=T.colContentRight,I=T.getDaySegmentContainer,q=T.renderDayOverlay,$=T.clearOverlays,V=T.clearSelection,X=T.getHoverListener,U=T.rangeToSegments,G=T.cellToDate,Q=T.cellToCellOffset,J=T.cellOffsetToDayOffset,K=T.dateToDayOffset,te=T.dayOffsetToCellOffset,ee=T.calendar,ne=ee.getEventEnd}function ye(t,e){for(var n=0;e.length>n;n++){var r=e[n];if(r.leftCol<=t.rightCol&&r.rightCol>=t.leftCol)return!0}return!1}function be(t,e){for(var n=0;t.length>n;n++){var r=t[n],a=r.element;a&&e(r,a,n)}}function De(t,e){return e.rightCol-e.leftCol-(t.rightCol-t.leftCol)||e.event.allDay-t.event.allDay||t.event.start-e.event.start||(t.event.title||"").localeCompare(e.event.title)}function we(){function e(e){var n=c("unselectCancel");n&&t(e.target).parents(n).length||r(e)}function n(t,e){r(),t=l.moment(t),e=e?l.moment(e):u(t),f(t,e),a(t,e)}function r(t){h&&(h=!1,v(),d("unselect",null,t))}function a(t,e,n){h=!0,d("select",null,t,e,n)}function o(e){var n=s.cellToDate,o=s.getIsCellAllDay,i=s.getHoverListener(),l=s.reportDayClick;if(1==e.which&&c("selectable")){r(e);var d;i.start(function(t,e){v(),t&&o(t)?(d=[n(e),n(t)].sort(x),f(d[0],d[1].clone().add("days",1))):d=null},e),t(document).one("mouseup",function(t){i.stop(),d&&(+d[0]==+d[1]&&l(d[0],t),a(d[0],d[1].clone().add("days",1),t))})}}function i(){t(document).off("mousedown",e)}var s=this;s.select=n,s.unselect=r,s.reportSelection=a,s.daySelectionMousedown=o,s.selectionManagerDestroy=i;var l=s.calendar,c=s.opt,d=s.trigger,u=s.defaultSelectionEnd,f=s.renderSelection,v=s.clearSelection,h=!1;c("selectable")&&c("unselectAuto")&&t(document).on("mousedown",e)}function Te(){function e(e,n){var r=o.shift();return r||(r=t("<div class='fc-cell-overlay' style='position:absolute;z-index:3'/>")),r[0].parentNode!=n[0]&&r.appendTo(n),a.push(r.css(e).show()),r}function n(){for(var t;t=a.shift();)o.push(t.hide().unbind())}var r=this;r.renderOverlay=e,r.clearOverlays=n;var a=[],o=[]}function Ce(t){var e,n,r=this;r.build=function(){e=[],n=[],t(e,n)},r.cell=function(t,r){var a,o=e.length,i=n.length,s=-1,l=-1;for(a=0;o>a;a++)if(r>=e[a][0]&&e[a][1]>r){s=a;break}for(a=0;i>a;a++)if(t>=n[a][0]&&n[a][1]>t){l=a;break}return s>=0&&l>=0?{row:s,col:l}:null},r.rect=function(t,r,a,o,i){var s=i.offset();return{top:e[t][0]-s.top,left:n[r][0]-s.left,width:n[o][1]-n[r][0],height:e[a][1]-e[t][0]}}}function Ee(e){function n(t){Se(t);var n=e.cell(t.pageX,t.pageY);(Boolean(n)!==Boolean(i)||n&&(n.row!=i.row||n.col!=i.col))&&(n?(o||(o=n),a(n,o,n.row-o.row,n.col-o.col)):a(n,o),i=n)}var r,a,o,i,s=this;s.start=function(s,l,c){a=s,o=i=null,e.build(),n(l),r=c||"mousemove",t(document).bind(r,n)},s.stop=function(){return t(document).unbind(r,n),i}}function Se(t){void 0===t.pageX&&(t.pageX=t.originalEvent.pageX,t.pageY=t.originalEvent.pageY)}function ke(t){function e(e){return r[e]=r[e]||t(e)}var n=this,r={},a={},o={};n.left=function(t){return a[t]=void 0===a[t]?e(t).position().left:a[t]},n.right=function(t){return o[t]=void 0===o[t]?n.left(t)+e(t).width():o[t]},n.clear=function(){r={},a={},o={}}}var xe={lang:"en",defaultTimedEventDuration:"02:00:00",defaultAllDayEventDuration:{days:1},forceEventDuration:!1,nextDayThreshold:"09:00:00",defaultView:"month",aspectRatio:1.35,header:{left:"title",center:"",right:"today prev,next"},weekends:!0,weekNumbers:!1,weekNumberTitle:"W",weekNumberCalculation:"local",lazyFetching:!0,startParam:"start",endParam:"end",timezoneParam:"timezone",timezone:!1,titleFormat:{month:"MMMM YYYY",week:"ll",day:"LL"},columnFormat:{month:"ddd",week:r,day:"dddd"},timeFormat:{"default":n},displayEventEnd:{month:!1,basicWeek:!1,"default":!0},isRTL:!1,defaultButtonText:{prev:"prev",next:"next",prevYear:"prev year",nextYear:"next year",today:"today",month:"month",week:"week",day:"day"},buttonIcons:{prev:"left-single-arrow",next:"right-single-arrow",prevYear:"left-double-arrow",nextYear:"right-double-arrow"},theme:!1,themeButtonIcons:{prev:"circle-triangle-w",next:"circle-triangle-e",prevYear:"seek-prev",nextYear:"seek-next"},unselectAuto:!0,dropAccept:"*",handleWindowResize:!0,windowResizeDelay:200},Me={en:{columnFormat:{week:"ddd M/D"}}},ze={header:{left:"next,prev today",center:"",right:"title"},buttonIcons:{prev:"right-single-arrow",next:"left-single-arrow",prevYear:"right-double-arrow",nextYear:"left-double-arrow"},themeButtonIcons:{prev:"circle-triangle-e",next:"circle-triangle-w",nextYear:"seek-prev",prevYear:"seek-next"}},Re=t.fullCalendar={version:"2.0.2"},_e=Re.views={};t.fn.fullCalendar=function(e){var n=Array.prototype.slice.call(arguments,1),r=this;return this.each(function(a,o){var i,l=t(o),c=l.data("fullCalendar");"string"==typeof e?c&&t.isFunction(c[e])&&(i=c[e].apply(c,n),a||(r=i),"destroy"===e&&l.removeData("fullCalendar")):c||(c=new s(l,e),l.data("fullCalendar",c),c.render())}),r},Re.langs=Me,Re.datepickerLang=function(e,n,r){var a=Me[e];a||(a=Me[e]={}),o(a,{isRTL:r.isRTL,weekNumberTitle:r.weekHeader,titleFormat:{month:r.showMonthAfterYear?"YYYY["+r.yearSuffix+"] MMMM":"MMMM YYYY["+r.yearSuffix+"]"},defaultButtonText:{prev:_(r.prevText),next:_(r.nextText),today:_(r.currentText)}}),t.datepicker&&(t.datepicker.regional[n]=t.datepicker.regional[e]=r,t.datepicker.regional.en=t.datepicker.regional[""],t.datepicker.setDefaults(r))},Re.lang=function(t,e){var n;e&&(n=Me[t],n||(n=Me[t]={}),o(n,e||{})),xe.lang=t},Re.sourceNormalizers=[],Re.sourceFetchers=[];var He={dataType:"json",cache:!1},Fe=1;Re.applyAll=N;var Ae=["sun","mon","tue","wed","thu","fri","sat"],Ne=/^\s*\d{4}-\d\d$/,Ye=/^\s*\d{4}-(?:(\d\d-\d\d)|(W\d\d$)|(W\d\d-\d)|(\d\d\d))((T| )(\d\d(:\d\d(:\d\d(\.\d+)?)?)?)?)?$/;Re.moment=function(){return O(arguments)},Re.moment.utc=function(){var t=O(arguments,!0);return t.hasTime()&&t.utc(),t},Re.moment.parseZone=function(){return O(arguments,!0,!0)},W.prototype=u(e.fn),W.prototype.clone=function(){return O([this])},W.prototype.time=function(t){if(null==t)return e.duration({hours:this.hours(),minutes:this.minutes(),seconds:this.seconds(),milliseconds:this.milliseconds()});delete this._ambigTime,e.isDuration(t)||e.isMoment(t)||(t=e.duration(t));var n=0;return e.isDuration(t)&&(n=24*Math.floor(t.asDays())),this.hours(n+t.hours()).minutes(t.minutes()).seconds(t.seconds()).milliseconds(t.milliseconds())},W.prototype.stripTime=function(){var t=this.toArray();return e.fn.utc.call(this),this.year(t[0]).month(t[1]).date(t[2]).hours(0).minutes(0).seconds(0).milliseconds(0),this._ambigTime=!0,this._ambigZone=!0,this},W.prototype.hasTime=function(){return!this._ambigTime},W.prototype.stripZone=function(){var t=this.toArray(),n=this._ambigTime;return e.fn.utc.call(this),this.year(t[0]).month(t[1]).date(t[2]).hours(t[3]).minutes(t[4]).seconds(t[5]).milliseconds(t[6]),n&&(this._ambigTime=!0),this._ambigZone=!0,this},W.prototype.hasZone=function(){return!this._ambigZone},W.prototype.zone=function(t){return null!=t&&(delete this._ambigTime,delete this._ambigZone),e.fn.zone.apply(this,arguments)},W.prototype.local=function(){var t=this.toArray(),n=this._ambigZone;return delete this._ambigTime,delete this._ambigZone,e.fn.local.apply(this,arguments),n&&this.year(t[0]).month(t[1]).date(t[2]).hours(t[3]).minutes(t[4]).seconds(t[5]).milliseconds(t[6]),this},W.prototype.utc=function(){return delete this._ambigTime,delete this._ambigZone,e.fn.utc.apply(this,arguments)},W.prototype.format=function(){return arguments[0]?B(this,arguments[0]):this._ambigTime?Z(this,"YYYY-MM-DD"):this._ambigZone?Z(this,"YYYY-MM-DD[T]HH:mm:ss"):Z(this)},W.prototype.toISOString=function(){return this._ambigTime?Z(this,"YYYY-MM-DD"):this._ambigZone?Z(this,"YYYY-MM-DD[T]HH:mm:ss"):e.fn.toISOString.apply(this,arguments)},W.prototype.isWithin=function(t,e){var n=L([this,t,e]);return n[0]>=n[1]&&n[0]<n[2]},t.each(["isBefore","isAfter","isSame"],function(t,n){W.prototype[n]=function(t,r){var a=L([this,t]);return e.fn[n].call(a[0],a[1],r)}});var Oe={t:function(t){return Z(t,"a").charAt(0)},T:function(t){return Z(t,"A").charAt(0)}};Re.formatRange=I;var We={Y:"year",M:"month",D:"day",d:"day",A:"second",a:"second",T:"second",t:"second",H:"second",h:"second",m:"second",s:"second"},Le={};_e.month=U,_e.basicWeek=G,_e.basicDay=Q,a({weekMode:"fixed"}),_e.agendaWeek=te,_e.agendaDay=ee,a({allDaySlot:!0,allDayText:"all-day",scrollTime:"06:00:00",slotDuration:"00:30:00",axisFormat:ne,timeFormat:{agenda:re},dragOpacity:{agenda:.5},minTime:"00:00:00",maxTime:"24:00:00",slotEventOverlap:!0})});

/*! jCarousel - v0.3.0 - 2013-11-22
 * http://sorgalla.com/jcarousel
 * Copyright (c) 2013 Jan Sorgalla; Licensed MIT */
(function (t) {
    "use strict";
    var i = t.jCarousel = {};
    i.version = "0.3.0";
    var s = /^([+\-]=)?(.+)$/;
    i.parseTarget = function (t) {
        var i = !1,
            e = "object" != typeof t ? s.exec(t) : null;
        return e ? (t = parseInt(e[2], 10) || 0, e[1] && (i = !0, "-=" === e[1] && (t *= -1))) : "object" != typeof t && (t = parseInt(t, 10) || 0), {
            target: t,
            relative: i
        }
    }, i.detectCarousel = function (t) {
        for (var i; t.length > 0;) {
            if (i = t.filter("[data-jcarousel]"), i.length > 0) return i;
            if (i = t.find("[data-jcarousel]"), i.length > 0) return i;
            t = t.parent()
        }
        return null
    }, i.base = function (s) {
        return {
            version: i.version,
            _options: {},
            _element: null,
            _carousel: null,
            _init: t.noop,
            _create: t.noop,
            _destroy: t.noop,
            _reload: t.noop,
            create: function () {
                return this._element.attr("data-" + s.toLowerCase(), !0).data(s, this), !1 === this._trigger("create") ? this : (this._create(), this._trigger("createend"), this)
            },
            destroy: function () {
                return !1 === this._trigger("destroy") ? this : (this._destroy(), this._trigger("destroyend"), this._element.removeData(s).removeAttr("data-" + s.toLowerCase()), this)
            },
            reload: function (t) {
                return !1 === this._trigger("reload") ? this : (t && this.options(t), this._reload(), this._trigger("reloadend"), this)
            },
            element: function () {
                return this._element
            },
            options: function (i, s) {
                if (0 === arguments.length) return t.extend({}, this._options);
                if ("string" == typeof i) {
                    if (s === void 0) return this._options[i] === void 0 ? null : this._options[i];
                    this._options[i] = s
                } else this._options = t.extend({}, this._options, i);
                return this
            },
            carousel: function () {
                return this._carousel || (this._carousel = i.detectCarousel(this.options("carousel") || this._element), this._carousel || t.error('Could not detect carousel for plugin "' + s + '"')), this._carousel
            },
            _trigger: function (i, e, r) {
                var n, o = !1;
                return r = [this].concat(r || []), (e || this._element).each(function () {
                    n = t.Event((s + ":" + i).toLowerCase()), t(this).trigger(n, r), n.isDefaultPrevented() && (o = !0)
                }), !o
            }
        }
    }, i.plugin = function (s, e) {
        var r = t[s] = function (i, s) {
            this._element = t(i), this.options(s), this._init(), this.create()
        };
        return r.fn = r.prototype = t.extend({}, i.base(s), e), t.fn[s] = function (i) {
            var e = Array.prototype.slice.call(arguments, 1),
                n = this;
            return "string" == typeof i ? this.each(function () {
                var r = t(this).data(s);
                if (!r) return t.error("Cannot call methods on " + s + " prior to initialization; " + 'attempted to call method "' + i + '"');
                if (!t.isFunction(r[i]) || "_" === i.charAt(0)) return t.error('No such method "' + i + '" for ' + s + " instance");
                var o = r[i].apply(r, e);
                return o !== r && o !== void 0 ? (n = o, !1) : void 0
            }) : this.each(function () {
                var e = t(this).data(s);
                e instanceof r ? e.reload(i) : new r(this, i)
            }), n
        }, r
    }
})(jQuery),
function (t, i) {
    "use strict";
    var s = function (t) {
        return parseFloat(t) || 0
    };
    t.jCarousel.plugin("jcarousel", {
        animating: !1,
        tail: 0,
        inTail: !1,
        resizeTimer: null,
        lt: null,
        vertical: !1,
        rtl: !1,
        circular: !1,
        underflow: !1,
        relative: !1,
        _options: {
            list: function () {
                return this.element().children().eq(0)
            },
            items: function () {
                return this.list().children()
            },
            animation: 400,
            transitions: !1,
            wrap: null,
            vertical: null,
            rtl: null,
            center: !1
        },
        _list: null,
        _items: null,
        _target: null,
        _first: null,
        _last: null,
        _visible: null,
        _fullyvisible: null,
        _init: function () {
            var t = this;
            return this.onWindowResize = function () {
                t.resizeTimer && clearTimeout(t.resizeTimer), t.resizeTimer = setTimeout(function () {
                    t.reload()
                }, 100)
            }, this
        },
        _create: function () {
            this._reload(), t(i).on("resize.jcarousel", this.onWindowResize)
        },
        _destroy: function () {
            t(i).off("resize.jcarousel", this.onWindowResize)
        },
        _reload: function () {
            this.vertical = this.options("vertical"), null == this.vertical && (this.vertical = this.list().height() > this.list().width()), this.rtl = this.options("rtl"), null == this.rtl && (this.rtl = function (i) {
                if ("rtl" === ("" + i.attr("dir")).toLowerCase()) return !0;
                var s = !1;
                return i.parents("[dir]").each(function () {
                    return /rtl/i.test(t(this).attr("dir")) ? (s = !0, !1) : void 0
                }), s
            }(this._element)), this.lt = this.vertical ? "top" : "left", this.relative = "relative" === this.list().css("position"), this._list = null, this._items = null;
            var i = this._target && this.index(this._target) >= 0 ? this._target : this.closest();
            this.circular = "circular" === this.options("wrap"), this.underflow = !1;
            var s = {
                left: 0,
                top: 0
            };
            return i.length > 0 && (this._prepare(i), this.list().find("[data-jcarousel-clone]").remove(), this._items = null, this.underflow = this._fullyvisible.length >= this.items().length, this.circular = this.circular && !this.underflow, s[this.lt] = this._position(i) + "px"), this.move(s), this
        },
        list: function () {
            if (null === this._list) {
                var i = this.options("list");
                this._list = t.isFunction(i) ? i.call(this) : this._element.find(i)
            }
            return this._list
        },
        items: function () {
            if (null === this._items) {
                var i = this.options("items");
                this._items = (t.isFunction(i) ? i.call(this) : this.list().find(i)).not("[data-jcarousel-clone]")
            }
            return this._items
        },
        index: function (t) {
            return this.items().index(t)
        },
        closest: function () {
            var i, e = this,
                r = this.list().position()[this.lt],
                n = t(),
                o = !1,
                l = this.vertical ? "bottom" : this.rtl && !this.relative ? "left" : "right";
            return this.rtl && this.relative && !this.vertical && (r += this.list().width() - this.clipping()), this.items().each(function () {
                if (n = t(this), o) return !1;
                var a = e.dimension(n);
                if (r += a, r >= 0) {
                    if (i = a - s(n.css("margin-" + l)), !(0 >= Math.abs(r) - a + i / 2)) return !1;
                    o = !0
                }
            }), n
        },
        target: function () {
            return this._target
        },
        first: function () {
            return this._first
        },
        last: function () {
            return this._last
        },
        visible: function () {
            return this._visible
        },
        fullyvisible: function () {
            return this._fullyvisible
        },
        hasNext: function () {
            if (!1 === this._trigger("hasnext")) return !0;
            var t = this.options("wrap"),
                i = this.items().length - 1;
            return i >= 0 && (t && "first" !== t || i > this.index(this._last) || this.tail && !this.inTail) ? !0 : !1
        },
        hasPrev: function () {
            if (!1 === this._trigger("hasprev")) return !0;
            var t = this.options("wrap");
            return this.items().length > 0 && (t && "last" !== t || this.index(this._first) > 0 || this.tail && this.inTail) ? !0 : !1
        },
        clipping: function () {
            return this._element["inner" + (this.vertical ? "Height" : "Width")]()
        },
        dimension: function (t) {
            return t["outer" + (this.vertical ? "Height" : "Width")](!0)
        },
        scroll: function (i, s, e) {
            if (this.animating) return this;
            if (!1 === this._trigger("scroll", null, [i, s])) return this;
            t.isFunction(s) && (e = s, s = !0);
            var r = t.jCarousel.parseTarget(i);
            if (r.relative) {
                var n, o, l, a, h, u, c, f, d = this.items().length - 1,
                    _ = Math.abs(r.target),
                    p = this.options("wrap");
                if (r.target > 0) {
                    var v = this.index(this._last);
                    if (v >= d && this.tail) this.inTail ? "both" === p || "last" === p ? this._scroll(0, s, e) : t.isFunction(e) && e.call(this, !1) : this._scrollTail(s, e);
                    else if (n = this.index(this._target), this.underflow && n === d && ("circular" === p || "both" === p || "last" === p) || !this.underflow && v === d && ("both" === p || "last" === p)) this._scroll(0, s, e);
                    else if (l = n + _, this.circular && l > d) {
                        for (f = d, h = this.items().get(-1); l > f++;) h = this.items().eq(0), u = this._visible.index(h) >= 0, u && h.after(h.clone(!0).attr("data-jcarousel-clone", !0)), this.list().append(h), u || (c = {}, c[this.lt] = this.dimension(h), this.moveBy(c)), this._items = null;
                        this._scroll(h, s, e)
                    } else this._scroll(Math.min(l, d), s, e)
                } else if (this.inTail) this._scroll(Math.max(this.index(this._first) - _ + 1, 0), s, e);
                else if (o = this.index(this._first), n = this.index(this._target), a = this.underflow ? n : o, l = a - _, 0 >= a && (this.underflow && "circular" === p || "both" === p || "first" === p)) this._scroll(d, s, e);
                else if (this.circular && 0 > l) {
                    for (f = l, h = this.items().get(0); 0 > f++;) {
                        h = this.items().eq(-1), u = this._visible.index(h) >= 0, u && h.after(h.clone(!0).attr("data-jcarousel-clone", !0)), this.list().prepend(h), this._items = null;
                        var g = this.dimension(h);
                        c = {}, c[this.lt] = -g, this.moveBy(c)
                    }
                    this._scroll(h, s, e)
                } else this._scroll(Math.max(l, 0), s, e)
            } else this._scroll(r.target, s, e);
            return this._trigger("scrollend"), this
        },
        moveBy: function (t, i) {
            var e = this.list().position(),
                r = 1,
                n = 0;
            return this.rtl && !this.vertical && (r = -1, this.relative && (n = this.list().width() - this.clipping())), t.left && (t.left = e.left + n + s(t.left) * r + "px"), t.top && (t.top = e.top + n + s(t.top) * r + "px"), this.move(t, i)
        },
        move: function (i, s) {
            s = s || {};
            var e = this.options("transitions"),
                r = !! e,
                n = !! e.transforms,
                o = !! e.transforms3d,
                l = s.duration || 0,
                a = this.list();
            if (!r && l > 0) return a.animate(i, s), void 0;
            var h = s.complete || t.noop,
                u = {};
            if (r) {
                var c = a.css(["transitionDuration", "transitionTimingFunction", "transitionProperty"]),
                    f = h;
                h = function () {
                    t(this).css(c), f.call(this)
                }, u = {
                    transitionDuration: (l > 0 ? l / 1e3 : 0) + "s",
                    transitionTimingFunction: e.easing || s.easing,
                    transitionProperty: l > 0 ? function () {
                        return n || o ? "all" : i.left ? "left" : "top"
                    }() : "none",
                    transform: "none"
                }
            }
            o ? u.transform = "translate3d(" + (i.left || 0) + "," + (i.top || 0) + ",0)" : n ? u.transform = "translate(" + (i.left || 0) + "," + (i.top || 0) + ")" : t.extend(u, i), r && l > 0 && a.one("transitionend webkitTransitionEnd oTransitionEnd otransitionend MSTransitionEnd", h), a.css(u), 0 >= l && a.each(function () {
                h.call(this)
            })
        },
        _scroll: function (i, s, e) {
            if (this.animating) return t.isFunction(e) && e.call(this, !1), this;
            if ("object" != typeof i ? i = this.items().eq(i) : i.jquery === void 0 && (i = t(i)), 0 === i.length) return t.isFunction(e) && e.call(this, !1), this;
            this.inTail = !1, this._prepare(i);
            var r = this._position(i),
                n = this.list().position()[this.lt];
            if (r === n) return t.isFunction(e) && e.call(this, !1), this;
            var o = {};
            return o[this.lt] = r + "px", this._animate(o, s, e), this
        },
        _scrollTail: function (i, s) {
            if (this.animating || !this.tail) return t.isFunction(s) && s.call(this, !1), this;
            var e = this.list().position()[this.lt];
            this.rtl && this.relative && !this.vertical && (e += this.list().width() - this.clipping()), this.rtl && !this.vertical ? e += this.tail : e -= this.tail, this.inTail = !0;
            var r = {};
            return r[this.lt] = e + "px", this._update({
                target: this._target.next(),
                fullyvisible: this._fullyvisible.slice(1).add(this._visible.last())
            }), this._animate(r, i, s), this
        },
        _animate: function (i, s, e) {
            if (e = e || t.noop, !1 === this._trigger("animate")) return e.call(this, !1), this;
            this.animating = !0;
            var r = this.options("animation"),
                n = t.proxy(function () {
                    this.animating = !1;
                    var t = this.list().find("[data-jcarousel-clone]");
                    t.length > 0 && (t.remove(), this._reload()), this._trigger("animateend"), e.call(this, !0)
                }, this),
                o = "object" == typeof r ? t.extend({}, r) : {
                    duration: r
                }, l = o.complete || t.noop;
            return s === !1 ? o.duration = 0 : t.fx.speeds[o.duration] !== void 0 && (o.duration = t.fx.speeds[o.duration]), o.complete = function () {
                n(), l.call(this)
            }, this.move(i, o), this
        },
        _prepare: function (i) {
            var e, r, n, o, l = this.index(i),
                a = l,
                h = this.dimension(i),
                u = this.clipping(),
                c = this.vertical ? "bottom" : this.rtl ? "left" : "right",
                f = this.options("center"),
                d = {
                    target: i,
                    first: i,
                    last: i,
                    visible: i,
                    fullyvisible: u >= h ? i : t()
                };
            if (f && (h /= 2, u /= 2), u > h)
                for (;;) {
                    if (e = this.items().eq(++a), 0 === e.length) {
                        if (!this.circular) break;
                        if (e = this.items().eq(0), i.get(0) === e.get(0)) break;
                        if (r = this._visible.index(e) >= 0, r && e.after(e.clone(!0).attr("data-jcarousel-clone", !0)), this.list().append(e), !r) {
                            var _ = {};
                            _[this.lt] = this.dimension(e), this.moveBy(_)
                        }
                        this._items = null
                    }
                    if (o = this.dimension(e), 0 === o) break;
                    if (h += o, d.last = e, d.visible = d.visible.add(e), n = s(e.css("margin-" + c)), u >= h - n && (d.fullyvisible = d.fullyvisible.add(e)), h >= u) break
                }
            if (!this.circular && !f && u > h)
                for (a = l;;) {
                    if (0 > --a) break;
                    if (e = this.items().eq(a), 0 === e.length) break;
                    if (o = this.dimension(e), 0 === o) break;
                    if (h += o, d.first = e, d.visible = d.visible.add(e), n = s(e.css("margin-" + c)), u >= h - n && (d.fullyvisible = d.fullyvisible.add(e)), h >= u) break
                }
            return this._update(d), this.tail = 0, f || "circular" === this.options("wrap") || "custom" === this.options("wrap") || this.index(d.last) !== this.items().length - 1 || (h -= s(d.last.css("margin-" + c)), h > u && (this.tail = h - u)), this
        },
        _position: function (t) {
            var i = this._first,
                s = i.position()[this.lt],
                e = this.options("center"),
                r = e ? this.clipping() / 2 - this.dimension(i) / 2 : 0;
            return this.rtl && !this.vertical ? (s -= this.relative ? this.list().width() - this.dimension(i) : this.clipping() - this.dimension(i), s += r) : s -= r, !e && (this.index(t) > this.index(i) || this.inTail) && this.tail ? (s = this.rtl && !this.vertical ? s - this.tail : s + this.tail, this.inTail = !0) : this.inTail = !1, -s
        },
        _update: function (i) {
            var s, e = this,
                r = {
                    target: this._target || t(),
                    first: this._first || t(),
                    last: this._last || t(),
                    visible: this._visible || t(),
                    fullyvisible: this._fullyvisible || t()
                }, n = this.index(i.first || r.first) < this.index(r.first),
                o = function (s) {
                    var o = [],
                        l = [];
                    i[s].each(function () {
                        0 > r[s].index(this) && o.push(this)
                    }), r[s].each(function () {
                        0 > i[s].index(this) && l.push(this)
                    }), n ? o = o.reverse() : l = l.reverse(), e._trigger(s + "in", t(o)), e._trigger(s + "out", t(l)), e["_" + s] = i[s]
                };
            for (s in i) o(s);
            return this
        }
    })
}(jQuery, window),
function (t) {
    "use strict";
    t.jcarousel.fn.scrollIntoView = function (i, s, e) {
        var r, n = t.jCarousel.parseTarget(i),
            o = this.index(this._fullyvisible.first()),
            l = this.index(this._fullyvisible.last());
        if (r = n.relative ? 0 > n.target ? Math.max(0, o + n.target) : l + n.target : "object" != typeof n.target ? n.target : this.index(n.target), o > r) return this.scroll(r, s, e);
        if (r >= o && l >= r) return t.isFunction(e) && e.call(this, !1), this;
        for (var a, h = this.items(), u = this.clipping(), c = this.vertical ? "bottom" : this.rtl ? "left" : "right", f = 0;;) {
            if (a = h.eq(r), 0 === a.length) break;
            if (f += this.dimension(a), f >= u) {
                var d = parseFloat(a.css("margin-" + c)) || 0;
                f - d !== u && r++;
                break
            }
            if (0 >= r) break;
            r--
        }
        return this.scroll(r, s, e)
    }
}(jQuery),
function (t) {
    "use strict";
    t.jCarousel.plugin("jcarouselControl", {
        _options: {
            target: "+=1",
            event: "click",
            method: "scroll"
        },
        _active: null,
        _init: function () {
            this.onDestroy = t.proxy(function () {
                this._destroy(), this.carousel().one("jcarousel:createend", t.proxy(this._create, this))
            }, this), this.onReload = t.proxy(this._reload, this), this.onEvent = t.proxy(function (i) {
                i.preventDefault();
                var s = this.options("method");
                t.isFunction(s) ? s.call(this) : this.carousel().jcarousel(this.options("method"), this.options("target"))
            }, this)
        },
        _create: function () {
            this.carousel().one("jcarousel:destroy", this.onDestroy).on("jcarousel:reloadend jcarousel:scrollend", this.onReload), this._element.on(this.options("event") + ".jcarouselcontrol", this.onEvent), this._reload()
        },
        _destroy: function () {
            this._element.off(".jcarouselcontrol", this.onEvent), this.carousel().off("jcarousel:destroy", this.onDestroy).off("jcarousel:reloadend jcarousel:scrollend", this.onReload)
        },
        _reload: function () {
            var i, s = t.jCarousel.parseTarget(this.options("target")),
                e = this.carousel();
            if (s.relative) i = e.jcarousel(s.target > 0 ? "hasNext" : "hasPrev");
            else {
                var r = "object" != typeof s.target ? e.jcarousel("items").eq(s.target) : s.target;
                i = e.jcarousel("target").index(r) >= 0
            }
            return this._active !== i && (this._trigger(i ? "active" : "inactive"), this._active = i), this
        }
    })
}(jQuery),
function (t) {
    "use strict";
    t.jCarousel.plugin("jcarouselPagination", {
        _options: {
            perPage: null,
            item: function (t) {
                return '<a href="#' + t + '">' + t + "</a>"
            },
            event: "click",
            method: "scroll"
        },
        _pages: {},
        _items: {},
        _currentPage: null,
        _init: function () {
            this.onDestroy = t.proxy(function () {
                this._destroy(), this.carousel().one("jcarousel:createend", t.proxy(this._create, this))
            }, this), this.onReload = t.proxy(this._reload, this), this.onScroll = t.proxy(this._update, this)
        },
        _create: function () {
            this.carousel().one("jcarousel:destroy", this.onDestroy).on("jcarousel:reloadend", this.onReload).on("jcarousel:scrollend", this.onScroll), this._reload()
        },
        _destroy: function () {
            this._clear(), this.carousel().off("jcarousel:destroy", this.onDestroy).off("jcarousel:reloadend", this.onReload).off("jcarousel:scrollend", this.onScroll)
        },
        _reload: function () {
            var i = this.options("perPage");
            if (this._pages = {}, this._items = {}, t.isFunction(i) && (i = i.call(this)), null == i) this._pages = this._calculatePages();
            else
                for (var s, e = parseInt(i, 10) || 0, r = this.carousel().jcarousel("items"), n = 1, o = 0;;) {
                    if (s = r.eq(o++), 0 === s.length) break;
                    this._pages[n] = this._pages[n] ? this._pages[n].add(s) : s, 0 === o % e && n++
                }
            this._clear();
            var l = this,
                a = this.carousel().data("jcarousel"),
                h = this._element,
                u = this.options("item");
            t.each(this._pages, function (i, s) {
                var e = l._items[i] = t(u.call(l, i, s));
                e.on(l.options("event") + ".jcarouselpagination", t.proxy(function () {
                    var t = s.eq(0);
                    if (a.circular) {
                        var e = a.index(a.target()),
                            r = a.index(t);
                        parseFloat(i) > parseFloat(l._currentPage) ? e > r && (t = "+=" + (a.items().length - e + r)) : r > e && (t = "-=" + (e + (a.items().length - r)))
                    }
                    a[this.options("method")](t)
                }, l)), h.append(e)
            }), this._update()
        },
        _update: function () {
            var i, s = this.carousel().jcarousel("target");
            t.each(this._pages, function (t, e) {
                return e.each(function () {
                    return s.is(this) ? (i = t, !1) : void 0
                }), i ? !1 : void 0
            }), this._currentPage !== i && (this._trigger("inactive", this._items[this._currentPage]), this._trigger("active", this._items[i])), this._currentPage = i
        },
        items: function () {
            return this._items
        },
        _clear: function () {
            this._element.empty(), this._currentPage = null
        },
        _calculatePages: function () {
            for (var t, i = this.carousel().data("jcarousel"), s = i.items(), e = i.clipping(), r = 0, n = 0, o = 1, l = {};;) {
                if (t = s.eq(n++), 0 === t.length) break;
                l[o] = l[o] ? l[o].add(t) : t, r += i.dimension(t), r >= e && (o++, r = 0)
            }
            return l
        }
    })
}(jQuery),
function (t) {
    "use strict";
    t.jCarousel.plugin("jcarouselAutoscroll", {
        _options: {
            target: "+=1",
            interval: 3e3,
            autostart: !0
        },
        _timer: null,
        _init: function () {
            this.onDestroy = t.proxy(function () {
                this._destroy(), this.carousel().one("jcarousel:createend", t.proxy(this._create, this))
            }, this), this.onAnimateEnd = t.proxy(this.start, this)
        },
        _create: function () {
            this.carousel().one("jcarousel:destroy", this.onDestroy), this.options("autostart") && this.start()
        },
        _destroy: function () {
            this.stop(), this.carousel().off("jcarousel:destroy", this.onDestroy)
        },
        start: function () {
            return this.stop(), this.carousel().one("jcarousel:animateend", this.onAnimateEnd), this._timer = setTimeout(t.proxy(function () {
                this.carousel().jcarousel("scroll", this.options("target"))
            }, this), this.options("interval")), this
        },
        stop: function () {
            return this._timer && (this._timer = clearTimeout(this._timer)), this.carousel().off("jcarousel:animateend", this.onAnimateEnd), this
        }
    })
}(jQuery);


! function (o) {
    o(function () {
        o(".growth-jcarousel, .perform-jcarousel").jcarousel({}), o(".growth-prev, .perform-prev").on("jcarouselcontrol:active", function () {
            o(this).removeClass("inactive")
        }).on("jcarouselcontrol:inactive", function () {
            o(this).addClass("inactive")
        }).jcarouselControl({
            target: "-=1"
        }), o(".growth-next, .perform-next").on("jcarouselcontrol:active", function () {
            o(this).removeClass("inactive")
        }).on("jcarouselcontrol:inactive", function () {
            o(this).addClass("inactive")
        }).jcarouselControl({
            target: "+=1"
        })
    })
}(jQuery);


/* Place Holder */
! function (e) {
    var a = 0;
    e.fn.placeholder = function () {
        return this.bind({
            focus: function () {
                e(this).parent().addClass("placeholder-focus")
            },
            blur: function () {
                e(this).parent().removeClass("placeholder-focus")
            },
            "keyup input change": function () {
                e(this).parent().toggleClass("placeholder-changed", "" !== this.value)
            }
        }).each(function () {
            var t = e(this);
            this.id || (this.id = "ph_" + a++), e('<span class="placeholderWrap"><label for="' + this.id + '">' + t.attr("placeholder") + "</label></span>").insertAfter(t).append(t), t.attr("placeholder", "").keyup(), e.browser.mozilla && "1.9" == e.browser.version.slice(0, 3) && t.focus(function () {
                var a = this.value,
                    t = this,
                    l = e(this);
                l.data("ph_timer", setInterval(function () {
                    a != t.value && l.change()
                }, 100))
            }).blur(function () {
                clearInterval(e(this).data("ph_timer"))
            })
        })
    }, e(function () {
        e("input[placeholder]").placeholder()
    })
}(jQuery);

$(function () {

    /* ADD CLASSES */
    $('[href="#"]').attr("href", "javascript:;");
    $('ul li:last-child, table tr:last-child, table tr td:last-child, table tr th:last-child').addClass('last');
    $('ul li:first-child, table tr:first-child, table tr td:first-child, table tr th:first-child').addClass('first');
    $('ul li:even').addClass('even');
    $('ul li:odd').addClass('odd');

    //$('.xscroller').jScrollPane();

    /* Accordian */
    //$('.accordian-btn').click(function(){
    $('body').delegate(".accordian-btn div", "click", function () {
        $(this).parent().parent().next('.accrodian-content').slideToggle('slow');
        $(this).parent().parent().toggleClass('actived');
    });
    $('body').delegate(".updateState li", "click", function () {
        $(this).siblings().removeClass('checked');
        $(this).addClass('checked');

    });

    /* Profile Tabs */
    var tabs = function (e) {
        e.preventDefault();
        var t = '.tab-panes > div[data-name=' + $(this).attr("href") + ']';
        $(this).parent('li').parent('.tabs_btns').children('.active').removeClass('active');
        $(this).parent('li').parent('.tabs_btns').next('.tab-panes').children('div').css('display', 'none');
        $(this).parent('li').parent('.tabs_btns').next('.tab-panes').children(t).css('display', 'block');
        $(this).parent('li').addClass('active')
    }
    $(".tabs_btns a").bind("click", tabs);

    $('.tab-close').click(function () {
        $(this).parent('div').css('display', 'none');
        $(".first.even, .odd, .even").removeClass('active');
    });

    var popup = function (e) {
        e.preventDefault();
        var p = $(this).attr("href");
        //alert (p);
        $(p).fadeIn('fast');
        $('.overlay').fadeIn('fast');
        $('body').css('overflow', 'hidden');
        //$(p +' iframe')[0].contentWindow.myfc();

        var src = $(p + ' .popup-fix').attr('data-src');
        var ht = $(p + ' .popup-fix').attr('data-height');
        var wdh = $(p + ' .popup-fix').attr('data-width');

        //$(p +' iframe').attr('src',src);
        $(p + ' .popup-fix').append('<iframe frameborder="0" src="' + src + '" height="' + ht + '" width="' + wdh + '"></iframe>');
    }

    $(".xpop").bind("click", popup);


    $('.overlay, .popcls').click(function () {
        $('.pop-container').css('display', 'none');
        $('.overlay').fadeOut('fast');
        $('body').css('overflow', 'inherit');
        $(".popup-fix iframe").remove();
    });


    /*$('.xpop').bind('click',function(){
		var src = $(this).attr('data-src'), id=$(this).attr('href');
		//console.log(src);
		$(id).find('iframe').attr('src',src);
	});*/

    $('.view-comment').click(function () {
        //$(this).parent('.list-action').children('.comment-tip').fadeIn('fast');
    });



    $(function () {
        var availableTags = [
            "ActionScript",
            "AppleScript",
            "Asp",
            "BASIC",
            "C",
            "C++",
            "Clojure",
            "COBOL",
            "ColdFusion",
            "Erlang",
            "Fortran",
            "Groovy",
            "Haskell",
            "Java",
            "JavaScript",
            "Lisp",
            "Perl",
            "PHP",
            "Python",
            "Ruby",
            "Scala",
            "Scheme",
            "Naeem",
            "Nadia Hassan",
            "Naveed Noushad",
            "Naveed Saghir"
        ];
        $("#tags, #tags2").autocomplete({
            source: availableTags
        });		
    });



});


/*
 * jQuery Plugin: Tokenizing Autocomplete Text Entry
 * Version 1.6.1
 *
 * Copyright (c) 2009 James Smith (http://loopj.com)
 * Licensed jointly under the GPL and MIT licenses,
 * choose which one suits your project best!
 *
 */

(function ($) {
// Default settings
var DEFAULT_SETTINGS = {
    // Search settings
    method: "GET",
    queryParam: "q",
    searchDelay: 300,
    minChars: 1,
    propertyToSearch: "name",
    jsonContainer: null,
    contentType: "json",

    // Prepopulation settings
    prePopulate: null,
    processPrePopulate: false,

    // Display settings
    hintText: "Enter Keyword",
    noResultsText: "No results found.",
    searchingText: "Searching...",
    deleteText: "&#215;",
    animateDropdown: true,
    placeholder: null,
    theme: null,
    zindex: 999,
    resultsLimit: null,

    enableHTML: false,

    resultsFormatter: function(item) {
      var string = item[this.propertyToSearch];
      return "<li>" + (this.enableHTML ? string : _escapeHTML(string)) + "</li>";
    },

    tokenFormatter: function(item) {
      var string = item[this.propertyToSearch];
      return "<li><p>" + (this.enableHTML ? string : _escapeHTML(string)) + "</p></li>";
    },

    // Tokenization settings
    tokenLimit: null,
    tokenDelimiter: ",",
    preventDuplicates: false,
    tokenValue: "id",

    // Behavioral settings
    allowFreeTagging: false,
    allowTabOut: false,

    // Callbacks
    onResult: null,
    onCachedResult: null,
    onAdd: null,
    onFreeTaggingAdd: null,
    onDelete: null,
    onReady: null,

    // Other settings
    idPrefix: "token-input-",

    // Keep track if the input is currently in disabled mode
    disabled: false
};

// Default classes to use when theming
var DEFAULT_CLASSES = {
    tokenList: "token-input-list",
    token: "token-input-token",
    tokenReadOnly: "token-input-token-readonly",
    tokenDelete: "token-input-delete-token",
    selectedToken: "token-input-selected-token",
    highlightedToken: "token-input-highlighted-token",
    dropdown: "token-input-dropdown",
    dropdownItem: "token-input-dropdown-item",
    dropdownItem2: "token-input-dropdown-item2",
    selectedDropdownItem: "token-input-selected-dropdown-item",
    inputToken: "token-input-input-token",
    focused: "token-input-focused",
    disabled: "token-input-disabled"
};

// Input box position "enum"
var POSITION = {
    BEFORE: 0,
    AFTER: 1,
    END: 2
};

// Keys "enum"
var KEY = {
    BACKSPACE: 8,
    TAB: 9,
    ENTER: 13,
    ESCAPE: 27,
    SPACE: 32,
    PAGE_UP: 33,
    PAGE_DOWN: 34,
    END: 35,
    HOME: 36,
    LEFT: 37,
    UP: 38,
    RIGHT: 39,
    DOWN: 40,
    NUMPAD_ENTER: 108,
    COMMA: 188
};

var HTML_ESCAPES = {
  '&': '&amp;',
  '<': '&lt;',
  '>': '&gt;',
  '"': '&quot;',
  "'": '&#x27;',
  '/': '&#x2F;'
};

var HTML_ESCAPE_CHARS = /[&<>"'\/]/g;

function coerceToString(val) {
  return String((val === null || val === undefined) ? '' : val);
}

function _escapeHTML(text) {
  return coerceToString(text).replace(HTML_ESCAPE_CHARS, function(match) {
    return HTML_ESCAPES[match];
  });
}

// Additional public (exposed) methods
var methods = {
    init: function(url_or_data_or_function, options) {
        var settings = $.extend({}, DEFAULT_SETTINGS, options || {});

        return this.each(function () {
            $(this).data("settings", settings);
            $(this).data("tokenInputObject", new $.TokenList(this, url_or_data_or_function, settings));
        });
    },
    clear: function() {
        this.data("tokenInputObject").clear();
        return this;
    },
    add: function(item) {
        this.data("tokenInputObject").add(item);
        return this;
    },
    remove: function(item) {
        this.data("tokenInputObject").remove(item);
        return this;
    },
    get: function() {
        return this.data("tokenInputObject").getTokens();
    },
    toggleDisabled: function(disable) {
        this.data("tokenInputObject").toggleDisabled(disable);
        return this;
    },
    setOptions: function(options){
        $(this).data("settings", $.extend({}, $(this).data("settings"), options || {}));
        return this;
    },
    destroy: function () {
        if(this.data("tokenInputObject")){
            this.data("tokenInputObject").clear();
            var tmpInput = this;
            var closest = this.parent();
            closest.empty();
            tmpInput.show();
            closest.append(tmpInput);
            return tmpInput;
        }
    }
};

// Expose the .tokenInput function to jQuery as a plugin
$.fn.tokenInput = function (method) {
    // Method calling and initialization logic
    if(methods[method]) {
        return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
    } else {
        return methods.init.apply(this, arguments);
    }
};

// TokenList class for each input
$.TokenList = function (input, url_or_data, settings) {
    //
    // Initialization
    //

    // Configure the data source
    if($.type(url_or_data) === "string" || $.type(url_or_data) === "function") {
        // Set the url to query against
        $(input).data("settings").url = url_or_data;

        // If the URL is a function, evaluate it here to do our initalization work
        var url = computeURL();

        // Make a smart guess about cross-domain if it wasn't explicitly specified
        if($(input).data("settings").crossDomain === undefined && typeof url === "string") {
            if(url.indexOf("://") === -1) {
                $(input).data("settings").crossDomain = false;
            } else {
                $(input).data("settings").crossDomain = (location.href.split(/\/+/g)[1] !== url.split(/\/+/g)[1]);
            }
        }
    } else if(typeof(url_or_data) === "object") {
        // Set the local data to search through
        $(input).data("settings").local_data = url_or_data;
    }

    // Build class names
    if($(input).data("settings").classes) {
        // Use custom class names
        $(input).data("settings").classes = $.extend({}, DEFAULT_CLASSES, $(input).data("settings").classes);
    } else if($(input).data("settings").theme) {
        // Use theme-suffixed default class names
        $(input).data("settings").classes = {};
        $.each(DEFAULT_CLASSES, function(key, value) {
            $(input).data("settings").classes[key] = value + "-" + $(input).data("settings").theme;
        });
    } else {
        $(input).data("settings").classes = DEFAULT_CLASSES;
    }


    // Save the tokens
    var saved_tokens = [];

    // Keep track of the number of tokens in the list
    var token_count = 0;

    // Basic cache to save on db hits
    var cache = new $.TokenList.Cache();

    // Keep track of the timeout, old vals
    var timeout;
    var input_val;

    // Create a new text input an attach keyup events
    var input_box = $("<input type=\"text\"  autocomplete=\"off\" autocapitalize=\"off\"/>")
	//var input_box = $("<input type=\"text\"  autocomplete=\"off\" placeholder=\""+DEFAULT_SETTINGS["placeholder"]+"\">")
        .css({
            outline: "none"
        })
        .attr("id", $(input).data("settings").idPrefix + input.id)
        .focus(function () {
            if ($(input).data("settings").disabled) {
                return false;
            } else
            if ($(input).data("settings").tokenLimit === null || $(input).data("settings").tokenLimit !== token_count) {
                show_dropdown_hint();
            }
            token_list.addClass($(input).data("settings").classes.focused);
        })
        .blur(function () {
            hide_dropdown();

            if ($(input).data("settings").allowFreeTagging) {
              add_freetagging_tokens();
            }

            $(this).val("");
            token_list.removeClass($(input).data("settings").classes.focused);
        })
        .bind("keyup keydown blur update", resize_input)
        .keydown(function (event) {
            var previous_token;
            var next_token;

            switch(event.keyCode) {
                case KEY.LEFT:
                case KEY.RIGHT:
                case KEY.UP:
                case KEY.DOWN:
                    if(!$(this).val()) {
                        previous_token = input_token.prev();
                        next_token = input_token.next();

                        if((previous_token.length && previous_token.get(0) === selected_token) || (next_token.length && next_token.get(0) === selected_token)) {
                            // Check if there is a previous/next token and it is selected
                            if(event.keyCode === KEY.LEFT || event.keyCode === KEY.UP) {
                                deselect_token($(selected_token), POSITION.BEFORE);
                            } else {
                                deselect_token($(selected_token), POSITION.AFTER);
                            }
                        } else if((event.keyCode === KEY.LEFT || event.keyCode === KEY.UP) && previous_token.length) {
                            // We are moving left, select the previous token if it exists
                            select_token($(previous_token.get(0)));
                        } else if((event.keyCode === KEY.RIGHT || event.keyCode === KEY.DOWN) && next_token.length) {
                            // We are moving right, select the next token if it exists
                            select_token($(next_token.get(0)));
                        }
                    } else {
                        var dropdown_item = null;

                        if(event.keyCode === KEY.DOWN || event.keyCode === KEY.RIGHT) {
                            dropdown_item = $(selected_dropdown_item).next();
                        } else {
                            dropdown_item = $(selected_dropdown_item).prev();
                        }

                        if(dropdown_item.length) {
                            select_dropdown_item(dropdown_item);
                        }
                    }
                    return false;
                    break;

                case KEY.BACKSPACE:
                    previous_token = input_token.prev();

                    if(!$(this).val().length) {
                        if(selected_token) {
                            delete_token($(selected_token));
                            hidden_input.change();
                        } else if(previous_token.length) {
                            select_token($(previous_token.get(0)));
                        }

                        return false;
                    } else if($(this).val().length === 1) {
                        hide_dropdown();
                    } else {
                        // set a timeout just long enough to let this function finish.
                        setTimeout(function(){do_search();}, 5);
                    }
                    break;

                case KEY.TAB:
                case KEY.ENTER:
                case KEY.NUMPAD_ENTER:
                case KEY.COMMA:
                  if(selected_dropdown_item) {
                    add_token($(selected_dropdown_item).data("tokeninput"));
                    hidden_input.change();
                  } else {
                    if ($(input).data("settings").allowFreeTagging) {
                      if($(input).data("settings").allowTabOut && $(this).val() === "") {
                        return true;
                      } else {
                        add_freetagging_tokens();
                      }
                    } else {
                      $(this).val("");
                      if($(input).data("settings").allowTabOut) {
                        return true;
                      }
                    }
                    event.stopPropagation();
                    event.preventDefault();
                  }
                  return false;

                case KEY.ESCAPE:
                  hide_dropdown();
                  return true;

                default:
                    if(String.fromCharCode(event.which)) {
                        // set a timeout just long enough to let this function finish.
                        setTimeout(function(){do_search();}, 5);
                    }
                    break;
            }
        });

    // Keep reference for placeholder
    if (settings.placeholder)
        input_box.attr("placeholder", settings.placeholder)

    // Keep a reference to the original input box
    var hidden_input = $(input)
                           .hide()
                           .val("")
                           .focus(function () {
                               focus_with_timeout(input_box);
                           })
                           .blur(function () {
                               input_box.blur();
                               //return the object to this can be referenced in the callback functions.
                               return hidden_input;
                           });

    // Keep a reference to the selected token and dropdown item
    var selected_token = null;
    var selected_token_index = 0;
    var selected_dropdown_item = null;

    // The list to store the token items in
    var token_list = $("<ul />")
        .addClass($(input).data("settings").classes.tokenList)
        .click(function (event) {
            var li = $(event.target).closest("li");
            if(li && li.get(0) && $.data(li.get(0), "tokeninput")) {
                toggle_select_token(li);
            } else {
                // Deselect selected token
                if(selected_token) {
                    deselect_token($(selected_token), POSITION.END);
                }

                // Focus input box
                focus_with_timeout(input_box);
            }
        })
        .mouseover(function (event) {
            var li = $(event.target).closest("li");
            if(li && selected_token !== this) {
                li.addClass($(input).data("settings").classes.highlightedToken);
            }
        })
        .mouseout(function (event) {
            var li = $(event.target).closest("li");
            if(li && selected_token !== this) {
                li.removeClass($(input).data("settings").classes.highlightedToken);
            }
        })
        .insertBefore(hidden_input);

    // The token holding the input box
    var input_token = $("<li />")
        .addClass($(input).data("settings").classes.inputToken)
        .appendTo(token_list)
        .append(input_box);

    // The list to store the dropdown items in
    var dropdown = $("<div/>")
        .addClass($(input).data("settings").classes.dropdown)
        .appendTo("body")
        .hide();

    // Magic element to help us resize the text input
    var input_resizer = $("<tester/>")
        .insertAfter(input_box)
        .css({
            position: "absolute",
            top: -9999,
            left: -9999,
            width: "auto",
            fontSize: input_box.css("fontSize"),
            fontFamily: input_box.css("fontFamily"),
            fontWeight: input_box.css("fontWeight"),
            letterSpacing: input_box.css("letterSpacing"),
            whiteSpace: "nowrap"
        });

    // Pre-populate list if items exist
    hidden_input.val("");
    var li_data = $(input).data("settings").prePopulate || hidden_input.data("pre");
    if($(input).data("settings").processPrePopulate && $.isFunction($(input).data("settings").onResult)) {
        li_data = $(input).data("settings").onResult.call(hidden_input, li_data);
    }
    if(li_data && li_data.length) {
        $.each(li_data, function (index, value) {
            insert_token(value);
            checkTokenLimit();
            input_box.attr("placeholder", null)
        });
    }

    // Check if widget should initialize as disabled
    if ($(input).data("settings").disabled) {
        toggleDisabled(true);
    }

    // Initialization is done
    if($.isFunction($(input).data("settings").onReady)) {
        $(input).data("settings").onReady.call();
    }

    //
    // Public functions
    //

    this.clear = function() {
        token_list.children("li").each(function() {
            if ($(this).children("input").length === 0) {
                delete_token($(this));
            }
        });
    };

    this.add = function(item) {
        add_token(item);
    };

    this.remove = function(item) {
        token_list.children("li").each(function() {
            if ($(this).children("input").length === 0) {
                var currToken = $(this).data("tokeninput");
                var match = true;
                for (var prop in item) {
                    if (item[prop] !== currToken[prop]) {
                        match = false;
                        break;
                    }
                }
                if (match) {
                    delete_token($(this));
                }
            }
        });
    };

    this.getTokens = function() {
        return saved_tokens;
    };

    this.toggleDisabled = function(disable) {
        toggleDisabled(disable);
    };

    // Resize input to maximum width so the placeholder can be seen
    resize_input();

    //
    // Private functions
    //

    function escapeHTML(text) {
      return $(input).data("settings").enableHTML ? text : _escapeHTML(text);
    }

    // Toggles the widget between enabled and disabled state, or according
    // to the [disable] parameter.
    function toggleDisabled(disable) {
        if (typeof disable === 'boolean') {
            $(input).data("settings").disabled = disable
        } else {
            $(input).data("settings").disabled = !$(input).data("settings").disabled;
        }
        input_box.attr('disabled', $(input).data("settings").disabled);
        token_list.toggleClass($(input).data("settings").classes.disabled, $(input).data("settings").disabled);
        // if there is any token selected we deselect it
        if(selected_token) {
            deselect_token($(selected_token), POSITION.END);
        }
        hidden_input.attr('disabled', $(input).data("settings").disabled);
    }

    function checkTokenLimit() {
        if($(input).data("settings").tokenLimit !== null && token_count >= $(input).data("settings").tokenLimit) {
            input_box.hide();
            hide_dropdown();
            return;
        }
    }

    function resize_input() {
        if(input_val === (input_val = input_box.val())) {return;}

        // Get width left on the current line
        var width_left = token_list.width() - input_box.offset().left - token_list.offset().left;
        // Enter new content into resizer and resize input accordingly
        input_resizer.html(_escapeHTML(input_val) || _escapeHTML(settings.placeholder));
        // Get maximum width, minimum the size of input and maximum the widget's width
        input_box.width(Math.min(token_list.width(),
                                 Math.max(width_left, input_resizer.width() + 30)));
    }

    function is_printable_character(keycode) {
        return ((keycode >= 48 && keycode <= 90) ||     // 0-1a-z
                (keycode >= 96 && keycode <= 111) ||    // numpad 0-9 + - / * .
                (keycode >= 186 && keycode <= 192) ||   // ; = , - . / ^
                (keycode >= 219 && keycode <= 222));    // ( \ ) '
    }

    function add_freetagging_tokens() {
        var value = $.trim(input_box.val());
        var tokens = value.split($(input).data("settings").tokenDelimiter);
        $.each(tokens, function(i, token) {
          if (!token) {
            return;
          }

          if ($.isFunction($(input).data("settings").onFreeTaggingAdd)) {
            token = $(input).data("settings").onFreeTaggingAdd.call(hidden_input, token);
          }
          var object = {};
          object[$(input).data("settings").tokenValue] = object[$(input).data("settings").propertyToSearch] = token;
          add_token(object);
        });
    }

    // Inner function to a token to the list
    function insert_token(item) {
        var $this_token = $($(input).data("settings").tokenFormatter(item));
        var readonly = item.readonly === true ? true : false;

        if(readonly) $this_token.addClass($(input).data("settings").classes.tokenReadOnly);

        $this_token.addClass($(input).data("settings").classes.token).insertBefore(input_token);

        // The 'delete token' button
        if(!readonly) {
          $("<span>" + $(input).data("settings").deleteText + "</span>")
              .addClass($(input).data("settings").classes.tokenDelete)
              .appendTo($this_token)
              .click(function () {
                  if (!$(input).data("settings").disabled) {
                      delete_token($(this).parent());
                      hidden_input.change();
                      return false;
                  }
              });
        }

        // Store data on the token
        var token_data = item;
        $.data($this_token.get(0), "tokeninput", item);

        // Save this token for duplicate checking
        saved_tokens = saved_tokens.slice(0,selected_token_index).concat([token_data]).concat(saved_tokens.slice(selected_token_index));
        selected_token_index++;

        // Update the hidden input
        update_hidden_input(saved_tokens, hidden_input);

        token_count += 1;

        // Check the token limit
        if($(input).data("settings").tokenLimit !== null && token_count >= $(input).data("settings").tokenLimit) {
            input_box.hide();
            hide_dropdown();
        }

        return $this_token;
    }

    // Add a token to the token list based on user input
    function add_token (item) {
        var callback = $(input).data("settings").onAdd;

        // See if the token already exists and select it if we don't want duplicates
        if(token_count > 0 && $(input).data("settings").preventDuplicates) {
            var found_existing_token = null;
            token_list.children().each(function () {
                var existing_token = $(this);
                var existing_data = $.data(existing_token.get(0), "tokeninput");
                if(existing_data && existing_data[settings.tokenValue] === item[settings.tokenValue]) {
                    found_existing_token = existing_token;
                    return false;
                }
            });

            if(found_existing_token) {
                select_token(found_existing_token);
                input_token.insertAfter(found_existing_token);
                focus_with_timeout(input_box);
                return;
            }
        }

        // Squeeze input_box so we force no unnecessary line break
        input_box.width(1);

        // Insert the new tokens
        if($(input).data("settings").tokenLimit == null || token_count < $(input).data("settings").tokenLimit) {
            insert_token(item);
            // Remove the placeholder so it's not seen after you've added a token
            input_box.attr("placeholder", null)
            checkTokenLimit();
        }

        // Clear input box
        input_box.val("");

        // Don't show the help dropdown, they've got the idea
        hide_dropdown();

        // Execute the onAdd callback if defined
        if($.isFunction(callback)) {
            callback.call(hidden_input,item);
        }
    }

    // Select a token in the token list
    function select_token (token) {
        if (!$(input).data("settings").disabled) {
            token.addClass($(input).data("settings").classes.selectedToken);
            selected_token = token.get(0);

            // Hide input box
            input_box.val("");

            // Hide dropdown if it is visible (eg if we clicked to select token)
            hide_dropdown();
        }
    }

    // Deselect a token in the token list
    function deselect_token (token, position) {
        token.removeClass($(input).data("settings").classes.selectedToken);
        selected_token = null;

        if(position === POSITION.BEFORE) {
            input_token.insertBefore(token);
            selected_token_index--;
        } else if(position === POSITION.AFTER) {
            input_token.insertAfter(token);
            selected_token_index++;
        } else {
            input_token.appendTo(token_list);
            selected_token_index = token_count;
        }

        // Show the input box and give it focus again
        focus_with_timeout(input_box);
    }

    // Toggle selection of a token in the token list
    function toggle_select_token(token) {
        var previous_selected_token = selected_token;

        if(selected_token) {
            deselect_token($(selected_token), POSITION.END);
        }

        if(previous_selected_token === token.get(0)) {
            deselect_token(token, POSITION.END);
        } else {
            select_token(token);
        }
    }

    // Delete a token from the token list
    function delete_token (token) {
        // Remove the id from the saved list
        var token_data = $.data(token.get(0), "tokeninput");
        var callback = $(input).data("settings").onDelete;

        var index = token.prevAll().length;
        if(index > selected_token_index) index--;

        // Delete the token
        token.remove();
        selected_token = null;

        // Show the input box and give it focus again
        focus_with_timeout(input_box);

        // Remove this token from the saved list
        saved_tokens = saved_tokens.slice(0,index).concat(saved_tokens.slice(index+1));
        if (saved_tokens.length == 0) {
            input_box.attr("placeholder", settings.placeholder)
        }
        if(index < selected_token_index) selected_token_index--;

        // Update the hidden input
        update_hidden_input(saved_tokens, hidden_input);

        token_count -= 1;

        if($(input).data("settings").tokenLimit !== null) {
            input_box
                .show()
                .val("");
            focus_with_timeout(input_box);
        }

        // Execute the onDelete callback if defined
        if($.isFunction(callback)) {
            callback.call(hidden_input,token_data);
        }
    }

    // Update the hidden input box value
    function update_hidden_input(saved_tokens, hidden_input) {
        var token_values = $.map(saved_tokens, function (el) {
            if(typeof $(input).data("settings").tokenValue == 'function')
              return $(input).data("settings").tokenValue.call(this, el);

            return el[$(input).data("settings").tokenValue];
        });
        hidden_input.val(token_values.join($(input).data("settings").tokenDelimiter));

    }

    // Hide and clear the results dropdown
    function hide_dropdown () {
        dropdown.hide().empty();
        selected_dropdown_item = null;
    }

    function show_dropdown() {
        dropdown
            .css({
                position: "absolute",
                top: token_list.offset().top + token_list.outerHeight(),
                left: token_list.offset().left,
                width: token_list.width(),
                'z-index': $(input).data("settings").zindex
            })
            .show();
    }

    function show_dropdown_searching () {
        if($(input).data("settings").searchingText) {
            dropdown.html("<p>" + escapeHTML($(input).data("settings").searchingText) + "</p>");
            show_dropdown();
        }
    }

    function show_dropdown_hint () {
        if($(input).data("settings").hintText) {
            dropdown.html("<p>" + escapeHTML($(input).data("settings").hintText) + "</p>");
            show_dropdown();
        }
    }

    var regexp_special_chars = new RegExp('[.\\\\+*?\\[\\^\\]$(){}=!<>|:\\-]', 'g');
    function regexp_escape(term) {
        return term.replace(regexp_special_chars, '\\$&');
    }

    // Highlight the query part of the search term
    function highlight_term(value, term) {
        return value.replace(
          new RegExp(
            "(?![^&;]+;)(?!<[^<>]*)(" + regexp_escape(term) + ")(?![^<>]*>)(?![^&;]+;)",
            "gi"
          ), function(match, p1) {
            return "<b>" + escapeHTML(p1) + "</b>";
          }
        );
    }

    function find_value_and_highlight_term(template, value, term) {
        return template.replace(new RegExp("(?![^&;]+;)(?!<[^<>]*)(" + regexp_escape(value) + ")(?![^<>]*>)(?![^&;]+;)", "g"), highlight_term(value, term));
    }

    // Populate the results dropdown with some results
    function populate_dropdown (query, results) {
        if(results && results.length) {
            dropdown.empty();
            var dropdown_ul = $("<ul/>")
                .appendTo(dropdown)
                .mouseover(function (event) {
                    select_dropdown_item($(event.target).closest("li"));
                })
                .mousedown(function (event) {
                    add_token($(event.target).closest("li").data("tokeninput"));
                    hidden_input.change();
                    return false;
                })
                .hide();

            if ($(input).data("settings").resultsLimit && results.length > $(input).data("settings").resultsLimit) {
                results = results.slice(0, $(input).data("settings").resultsLimit);
            }

            $.each(results, function(index, value) {
                var this_li = $(input).data("settings").resultsFormatter(value);

                this_li = find_value_and_highlight_term(this_li ,value[$(input).data("settings").propertyToSearch], query);

                this_li = $(this_li).appendTo(dropdown_ul);

                if(index % 2) {
                    this_li.addClass($(input).data("settings").classes.dropdownItem);
                } else {
                    this_li.addClass($(input).data("settings").classes.dropdownItem2);
                }

                if(index === 0) {
                    select_dropdown_item(this_li);
                }

                $.data(this_li.get(0), "tokeninput", value);
            });

            show_dropdown();

            if($(input).data("settings").animateDropdown) {
                dropdown_ul.slideDown("fast");
            } else {
                dropdown_ul.show();
            }
        } else {
            if($(input).data("settings").noResultsText) {
                dropdown.html("<p>" + escapeHTML($(input).data("settings").noResultsText) + "</p>");
                show_dropdown();
            }
        }
    }

    // Highlight an item in the results dropdown
    function select_dropdown_item (item) {
        if(item) {
            if(selected_dropdown_item) {
                deselect_dropdown_item($(selected_dropdown_item));
            }

            item.addClass($(input).data("settings").classes.selectedDropdownItem);
            selected_dropdown_item = item.get(0);
        }
    }

    // Remove highlighting from an item in the results dropdown
    function deselect_dropdown_item (item) {
        item.removeClass($(input).data("settings").classes.selectedDropdownItem);
        selected_dropdown_item = null;
    }

    // Do a search and show the "searching" dropdown if the input is longer
    // than $(input).data("settings").minChars
    function do_search() {
        var query = input_box.val();

        if(query && query.length) {
            if(selected_token) {
                deselect_token($(selected_token), POSITION.AFTER);
            }

            if(query.length >= $(input).data("settings").minChars) {
                show_dropdown_searching();
                clearTimeout(timeout);

                timeout = setTimeout(function(){
                    run_search(query);
                }, $(input).data("settings").searchDelay);
            } else {
                hide_dropdown();
            }
        }
    }

    // Do the actual search
    function run_search(query) {
        var cache_key = query + computeURL();
        var cached_results = cache.get(cache_key);
        if(cached_results) {
            if ($.isFunction($(input).data("settings").onCachedResult)) {
              cached_results = $(input).data("settings").onCachedResult.call(hidden_input, cached_results);
            }
            populate_dropdown(query, cached_results);
        } else {
            // Are we doing an ajax search or local data search?
            if($(input).data("settings").url) {
                var url = computeURL();
                // Extract exisiting get params
                var ajax_params = {};
                ajax_params.data = {};
                if(url.indexOf("?") > -1) {
                    var parts = url.split("?");
                    ajax_params.url = parts[0];

                    var param_array = parts[1].split("&");
                    $.each(param_array, function (index, value) {
                        var kv = value.split("=");
                        ajax_params.data[kv[0]] = kv[1];
                    });
                } else {
                    ajax_params.url = url;
                }

                // Prepare the request
                ajax_params.data[$(input).data("settings").queryParam] = query;
                ajax_params.type = $(input).data("settings").method;
                ajax_params.dataType = $(input).data("settings").contentType;
                if($(input).data("settings").crossDomain) {
                    ajax_params.dataType = "jsonp";
                }

                // Attach the success callback
                ajax_params.success = function(results) {
                  cache.add(cache_key, $(input).data("settings").jsonContainer ? results[$(input).data("settings").jsonContainer] : results);
                  if($.isFunction($(input).data("settings").onResult)) {
                      results = $(input).data("settings").onResult.call(hidden_input, results);
                  }

                  // only populate the dropdown if the results are associated with the active search query
                  if(input_box.val() === query) {
                      populate_dropdown(query, $(input).data("settings").jsonContainer ? results[$(input).data("settings").jsonContainer] : results);
                  }
                };

                // Provide a beforeSend callback
                if (settings.onSend) {
                  settings.onSend(ajax_params);
                }

                // Make the request
                $.ajax(ajax_params);
            } else if($(input).data("settings").local_data) {
                // Do the search through local data
                var results = $.grep($(input).data("settings").local_data, function (row) {
                    return row[$(input).data("settings").propertyToSearch].toLowerCase().indexOf(query.toLowerCase()) > -1;
                });

                cache.add(cache_key, results);
                if($.isFunction($(input).data("settings").onResult)) {
                    results = $(input).data("settings").onResult.call(hidden_input, results);
                }
                populate_dropdown(query, results);
            }
        }
    }

    // compute the dynamic URL
    function computeURL() {
        var url = $(input).data("settings").url;
        if(typeof $(input).data("settings").url == 'function') {
            url = $(input).data("settings").url.call($(input).data("settings"));
        }
        return url;
    }

    // Bring browser focus to the specified object.
    // Use of setTimeout is to get around an IE bug.
    // (See, e.g., http://stackoverflow.com/questions/2600186/focus-doesnt-work-in-ie)
    //
    // obj: a jQuery object to focus()
    function focus_with_timeout(obj) {
        setTimeout(function() { obj.focus(); }, 50);
    }

};

// Really basic cache for the results
$.TokenList.Cache = function (options) {
    var settings = $.extend({
        max_size: 500
    }, options);

    var data = {};
    var size = 0;

    var flush = function () {
        data = {};
        size = 0;
    };

    this.add = function (query, results) {
        if(size > settings.max_size) {
            flush();
        }

        if(!data[query]) {
            size += 1;
        }

        data[query] = results;
    };

    this.get = function (query) {
        return data[query];
    };
};
}(jQuery));


/* ToolTip */
/* qTip2 v2.2.0 tips viewport modal | qtip2.com | Licensed MIT, GPL | Sat Nov 30 2013 06:44:17 */

! function (a, b, c) {
    ! function (a) {
        "use strict";
        "function" == typeof define && define.amd ? define(["jquery"], a) : jQuery && !jQuery.fn.qtip && a(jQuery)
    }(function (d) {
        "use strict";

        function e(a, b, c, e) {
            this.id = c, this.target = a, this.tooltip = F, this.elements = {
                target: a
            }, this._id = S + "-" + c, this.timers = {
                img: {}
            }, this.options = b, this.plugins = {}, this.cache = {
                event: {},
                target: d(),
                disabled: E,
                attr: e,
                onTooltip: E,
                lastClass: ""
            }, this.rendered = this.destroyed = this.disabled = this.waiting = this.hiddenDuringWait = this.positioning = this.triggering = E
        }

        function f(a) {
            return a === F || "object" !== d.type(a)
        }

        function g(a) {
            return !(d.isFunction(a) || a && a.attr || a.length || "object" === d.type(a) && (a.jquery || a.then))
        }

        function h(a) {
            var b, c, e, h;
            return f(a) ? E : (f(a.metadata) && (a.metadata = {
                type: a.metadata
            }), "content" in a && (b = a.content, f(b) || b.jquery || b.done ? b = a.content = {
                text: c = g(b) ? E : b
            } : c = b.text, "ajax" in b && (e = b.ajax, h = e && e.once !== E, delete b.ajax, b.text = function (a, b) {
                var f = c || d(this).attr(b.options.content.attr) || "Loading...",
                    g = d.ajax(d.extend({}, e, {
                        context: b
                    })).then(e.success, F, e.error).then(function (a) {
                        return a && h && b.set("content.text", a), a
                    }, function (a, c, d) {
                        b.destroyed || 0 === a.status || b.set("content.text", c + ": " + d)
                    });
                return h ? f : (b.set("content.text", f), g)
            }), "title" in b && (f(b.title) || (b.button = b.title.button, b.title = b.title.text), g(b.title || E) && (b.title = E))), "position" in a && f(a.position) && (a.position = {
                my: a.position,
                at: a.position
            }), "show" in a && f(a.show) && (a.show = a.show.jquery ? {
                target: a.show
            } : a.show === D ? {
                ready: D
            } : {
                event: a.show
            }), "hide" in a && f(a.hide) && (a.hide = a.hide.jquery ? {
                target: a.hide
            } : {
                event: a.hide
            }), "style" in a && f(a.style) && (a.style = {
                classes: a.style
            }), d.each(R, function () {
                this.sanitize && this.sanitize(a)
            }), a)
        }

        function i(a, b) {
            for (var c, d = 0, e = a, f = b.split("."); e = e[f[d++]];) d < f.length && (c = e);
            return [c || a, f.pop()]
        }

        function j(a, b) {
            var c, d, e;
            for (c in this.checks)
                for (d in this.checks[c])(e = new RegExp(d, "i").exec(a)) && (b.push(e), ("builtin" === c || this.plugins[c]) && this.checks[c][d].apply(this.plugins[c] || this, b))
        }

        function k(a) {
            return V.concat("").join(a ? "-" + a + " " : " ")
        }

        function l(c) {
            return c && {
                type: c.type,
                pageX: c.pageX,
                pageY: c.pageY,
                target: c.target,
                relatedTarget: c.relatedTarget,
                scrollX: c.scrollX || a.pageXOffset || b.body.scrollLeft || b.documentElement.scrollLeft,
                scrollY: c.scrollY || a.pageYOffset || b.body.scrollTop || b.documentElement.scrollTop
            } || {}
        }

        function m(a, b) {
            return b > 0 ? setTimeout(d.proxy(a, this), b) : (a.call(this), void 0)
        }

        function n(a) {
            return this.tooltip.hasClass(ab) ? E : (clearTimeout(this.timers.show), clearTimeout(this.timers.hide), this.timers.show = m.call(this, function () {
                this.toggle(D, a)
            }, this.options.show.delay), void 0)
        }

        function o(a) {
            if (this.tooltip.hasClass(ab)) return E;
            var b = d(a.relatedTarget),
                c = b.closest(W)[0] === this.tooltip[0],
                e = b[0] === this.options.show.target[0];
            if (clearTimeout(this.timers.show), clearTimeout(this.timers.hide), this !== b[0] && "mouse" === this.options.position.target && c || this.options.hide.fixed && /mouse(out|leave|move)/.test(a.type) && (c || e)) try {
                a.preventDefault(), a.stopImmediatePropagation()
            } catch (f) {} else this.timers.hide = m.call(this, function () {
                this.toggle(E, a)
            }, this.options.hide.delay, this)
        }

        function p(a) {
            return this.tooltip.hasClass(ab) || !this.options.hide.inactive ? E : (clearTimeout(this.timers.inactive), this.timers.inactive = m.call(this, function () {
                this.hide(a)
            }, this.options.hide.inactive), void 0)
        }

        function q(a) {
            this.rendered && this.tooltip[0].offsetWidth > 0 && this.reposition(a)
        }

        function r(a, c, e) {
            d(b.body).delegate(a, (c.split ? c : c.join(hb + " ")) + hb, function () {
                var a = y.api[d.attr(this, U)];
                a && !a.disabled && e.apply(a, arguments)
            })
        }

        function s(a, c, f) {
            var g, i, j, k, l, m = d(b.body),
                n = a[0] === b ? m : a,
                o = a.metadata ? a.metadata(f.metadata) : F,
                p = "html5" === f.metadata.type && o ? o[f.metadata.name] : F,
                q = a.data(f.metadata.name || "qtipopts");
            try {
                q = "string" == typeof q ? d.parseJSON(q) : q
            } catch (r) {}
            if (k = d.extend(D, {}, y.defaults, f, "object" == typeof q ? h(q) : F, h(p || o)), i = k.position, k.id = c, "boolean" == typeof k.content.text) {
                if (j = a.attr(k.content.attr), k.content.attr === E || !j) return E;
                k.content.text = j
            }
            if (i.container.length || (i.container = m), i.target === E && (i.target = n), k.show.target === E && (k.show.target = n), k.show.solo === D && (k.show.solo = i.container.closest("body")), k.hide.target === E && (k.hide.target = n), k.position.viewport === D && (k.position.viewport = i.container), i.container = i.container.eq(0), i.at = new A(i.at, D), i.my = new A(i.my), a.data(S))
                if (k.overwrite) a.qtip("destroy", !0);
                else if (k.overwrite === E) return E;
            return a.attr(T, c), k.suppress && (l = a.attr("title")) && a.removeAttr("title").attr(cb, l).attr("title", ""), g = new e(a, k, c, !! j), a.data(S, g), a.one("remove.qtip-" + c + " removeqtip.qtip-" + c, function () {
                var a;
                (a = d(this).data(S)) && a.destroy(!0)
            }), g
        }

        function t(a) {
            return a.charAt(0).toUpperCase() + a.slice(1)
        }

        function u(a, b) {
            var d, e, f = b.charAt(0).toUpperCase() + b.slice(1),
                g = (b + " " + sb.join(f + " ") + f).split(" "),
                h = 0;
            if (rb[b]) return a.css(rb[b]);
            for (; d = g[h++];)
                if ((e = a.css(d)) !== c) return rb[b] = d, e
        }

        function v(a, b) {
            return Math.ceil(parseFloat(u(a, b)))
        }

        function w(a, b) {
            this._ns = "tip", this.options = b, this.offset = b.offset, this.size = [b.width, b.height], this.init(this.qtip = a)
        }

        function x(a, b) {
            this.options = b, this._ns = "-modal", this.init(this.qtip = a)
        }
        var y, z, A, B, C, D = !0,
            E = !1,
            F = null,
            G = "x",
            H = "y",
            I = "width",
            J = "height",
            K = "top",
            L = "left",
            M = "bottom",
            N = "right",
            O = "center",
            P = "flipinvert",
            Q = "shift",
            R = {}, S = "qtip",
            T = "data-hasqtip",
            U = "data-qtip-id",
            V = ["ui-widget", "ui-tooltip"],
            W = "." + S,
            X = "click dblclick mousedown mouseup mousemove mouseleave mouseenter".split(" "),
            Y = S + "-fixed",
            Z = S + "-default",
            $ = S + "-focus",
            _ = S + "-hover",
            ab = S + "-disabled",
            bb = "_replacedByqTip",
            cb = "oldtitle",
            db = {
                ie: function () {
                    for (var a = 3, c = b.createElement("div");
                        (c.innerHTML = "<!--[if gt IE " + ++a + "]><i></i><![endif]-->") && c.getElementsByTagName("i")[0];);
                    return a > 4 ? a : 0 / 0
                }(),
                iOS: parseFloat(("" + (/CPU.*OS ([0-9_]{1,5})|(CPU like).*AppleWebKit.*Mobile/i.exec(navigator.userAgent) || [0, ""])[1]).replace("undefined", "3_2").replace("_", ".").replace("_", "")) || E
            };
        z = e.prototype, z._when = function (a) {
            return d.when.apply(d, a)
        }, z.render = function (a) {
            if (this.rendered || this.destroyed) return this;
            var b, c = this,
                e = this.options,
                f = this.cache,
                g = this.elements,
                h = e.content.text,
                i = e.content.title,
                j = e.content.button,
                k = e.position,
                l = ("." + this._id + " ", []);
            return d.attr(this.target[0], "aria-describedby", this._id), this.tooltip = g.tooltip = b = d("<div/>", {
                id: this._id,
                "class": [S, Z, e.style.classes, S + "-pos-" + e.position.my.abbrev()].join(" "),
                width: e.style.width || "",
                height: e.style.height || "",
                tracking: "mouse" === k.target && k.adjust.mouse,
                role: "alert",
                "aria-live": "polite",
                "aria-atomic": E,
                "aria-describedby": this._id + "-content",
                "aria-hidden": D
            }).toggleClass(ab, this.disabled).attr(U, this.id).data(S, this).appendTo(k.container).append(g.content = d("<div />", {
                "class": S + "-content",
                id: this._id + "-content",
                "aria-atomic": D
            })), this.rendered = -1, this.positioning = D, i && (this._createTitle(), d.isFunction(i) || l.push(this._updateTitle(i, E))), j && this._createButton(), d.isFunction(h) || l.push(this._updateContent(h, E)), this.rendered = D, this._setWidget(), d.each(R, function (a) {
                var b;
                "render" === this.initialize && (b = this(c)) && (c.plugins[a] = b)
            }), this._unassignEvents(), this._assignEvents(), this._when(l).then(function () {
                c._trigger("render"), c.positioning = E, c.hiddenDuringWait || !e.show.ready && !a || c.toggle(D, f.event, E), c.hiddenDuringWait = E
            }), y.api[this.id] = this, this
        }, z.destroy = function (a) {
            function b() {
                if (!this.destroyed) {
                    this.destroyed = D;
                    var a = this.target,
                        b = a.attr(cb);
                    this.rendered && this.tooltip.stop(1, 0).find("*").remove().end().remove(), d.each(this.plugins, function () {
                        this.destroy && this.destroy()
                    }), clearTimeout(this.timers.show), clearTimeout(this.timers.hide), this._unassignEvents(), a.removeData(S).removeAttr(U).removeAttr(T).removeAttr("aria-describedby"), this.options.suppress && b && a.attr("title", b).removeAttr(cb), this._unbind(a), this.options = this.elements = this.cache = this.timers = this.plugins = this.mouse = F, delete y.api[this.id]
                }
            }
            return this.destroyed ? this.target : (a === D && "hide" !== this.triggering || !this.rendered ? b.call(this) : (this.tooltip.one("tooltiphidden", d.proxy(b, this)), !this.triggering && this.hide()), this.target)
        }, B = z.checks = {
            builtin: {
                "^id$": function (a, b, c, e) {
                    var f = c === D ? y.nextid : c,
                        g = S + "-" + f;
                    f !== E && f.length > 0 && !d("#" + g).length ? (this._id = g, this.rendered && (this.tooltip[0].id = this._id, this.elements.content[0].id = this._id + "-content", this.elements.title[0].id = this._id + "-title")) : a[b] = e
                },
                "^prerender": function (a, b, c) {
                    c && !this.rendered && this.render(this.options.show.ready)
                },
                "^content.text$": function (a, b, c) {
                    this._updateContent(c)
                },
                "^content.attr$": function (a, b, c, d) {
                    this.options.content.text === this.target.attr(d) && this._updateContent(this.target.attr(c))
                },
                "^content.title$": function (a, b, c) {
                    return c ? (c && !this.elements.title && this._createTitle(), this._updateTitle(c), void 0) : this._removeTitle()
                },
                "^content.button$": function (a, b, c) {
                    this._updateButton(c)
                },
                "^content.title.(text|button)$": function (a, b, c) {
                    this.set("content." + b, c)
                },
                "^position.(my|at)$": function (a, b, c) {
                    "string" == typeof c && (a[b] = new A(c, "at" === b))
                },
                "^position.container$": function (a, b, c) {
                    this.rendered && this.tooltip.appendTo(c)
                },
                "^show.ready$": function (a, b, c) {
                    c && (!this.rendered && this.render(D) || this.toggle(D))
                },
                "^style.classes$": function (a, b, c, d) {
                    this.rendered && this.tooltip.removeClass(d).addClass(c)
                },
                "^style.(width|height)": function (a, b, c) {
                    this.rendered && this.tooltip.css(b, c)
                },
                "^style.widget|content.title": function () {
                    this.rendered && this._setWidget()
                },
                "^style.def": function (a, b, c) {
                    this.rendered && this.tooltip.toggleClass(Z, !! c)
                },
                "^events.(render|show|move|hide|focus|blur)$": function (a, b, c) {
                    this.rendered && this.tooltip[(d.isFunction(c) ? "" : "un") + "bind"]("tooltip" + b, c)
                },
                "^(show|hide|position).(event|target|fixed|inactive|leave|distance|viewport|adjust)": function () {
                    if (this.rendered) {
                        var a = this.options.position;
                        this.tooltip.attr("tracking", "mouse" === a.target && a.adjust.mouse), this._unassignEvents(), this._assignEvents()
                    }
                }
            }
        }, z.get = function (a) {
            if (this.destroyed) return this;
            var b = i(this.options, a.toLowerCase()),
                c = b[0][b[1]];
            return c.precedance ? c.string() : c
        };
        var eb = /^position\.(my|at|adjust|target|container|viewport)|style|content|show\.ready/i,
            fb = /^prerender|show\.ready/i;
        z.set = function (a, b) {
            if (this.destroyed) return this; {
                var c, e = this.rendered,
                    f = E,
                    g = this.options;
                this.checks
            }
            return "string" == typeof a ? (c = a, a = {}, a[c] = b) : a = d.extend({}, a), d.each(a, function (b, c) {
                if (e && fb.test(b)) return delete a[b], void 0;
                var h, j = i(g, b.toLowerCase());
                h = j[0][j[1]], j[0][j[1]] = c && c.nodeType ? d(c) : c, f = eb.test(b) || f, a[b] = [j[0], j[1], c, h]
            }), h(g), this.positioning = D, d.each(a, d.proxy(j, this)), this.positioning = E, this.rendered && this.tooltip[0].offsetWidth > 0 && f && this.reposition("mouse" === g.position.target ? F : this.cache.event), this
        }, z._update = function (a, b) {
            var c = this,
                e = this.cache;
            return this.rendered && a ? (d.isFunction(a) && (a = a.call(this.elements.target, e.event, this) || ""), d.isFunction(a.then) ? (e.waiting = D, a.then(function (a) {
                return e.waiting = E, c._update(a, b)
            }, F, function (a) {
                return c._update(a, b)
            })) : a === E || !a && "" !== a ? E : (a.jquery && a.length > 0 ? b.empty().append(a.css({
                display: "block",
                visibility: "visible"
            })) : b.html(a), this._waitForContent(b).then(function (a) {
                a.images && a.images.length && c.rendered && c.tooltip[0].offsetWidth > 0 && c.reposition(e.event, !a.length)
            }))) : E
        }, z._waitForContent = function (a) {
            var b = this.cache;
            return b.waiting = D, (d.fn.imagesLoaded ? a.imagesLoaded() : d.Deferred().resolve([])).done(function () {
                b.waiting = E
            }).promise()
        }, z._updateContent = function (a, b) {
            this._update(a, this.elements.content, b)
        }, z._updateTitle = function (a, b) {
            this._update(a, this.elements.title, b) === E && this._removeTitle(E)
        }, z._createTitle = function () {
            var a = this.elements,
                b = this._id + "-title";
            a.titlebar && this._removeTitle(), a.titlebar = d("<div />", {
                "class": S + "-titlebar " + (this.options.style.widget ? k("header") : "")
            }).append(a.title = d("<div />", {
                id: b,
                "class": S + "-title",
                "aria-atomic": D
            })).insertBefore(a.content).delegate(".qtip-close", "mousedown keydown mouseup keyup mouseout", function (a) {
                d(this).toggleClass("ui-state-active ui-state-focus", "down" === a.type.substr(-4))
            }).delegate(".qtip-close", "mouseover mouseout", function (a) {
                d(this).toggleClass("ui-state-hover", "mouseover" === a.type)
            }), this.options.content.button && this._createButton()
        }, z._removeTitle = function (a) {
            var b = this.elements;
            b.title && (b.titlebar.remove(), b.titlebar = b.title = b.button = F, a !== E && this.reposition())
        }, z.reposition = function (c, e) {
            if (!this.rendered || this.positioning || this.destroyed) return this;
            this.positioning = D;
            var f, g, h = this.cache,
                i = this.tooltip,
                j = this.options.position,
                k = j.target,
                l = j.my,
                m = j.at,
                n = j.viewport,
                o = j.container,
                p = j.adjust,
                q = p.method.split(" "),
                r = i.outerWidth(E),
                s = i.outerHeight(E),
                t = 0,
                u = 0,
                v = i.css("position"),
                w = {
                    left: 0,
                    top: 0
                }, x = i[0].offsetWidth > 0,
                y = c && "scroll" === c.type,
                z = d(a),
                A = o[0].ownerDocument,
                B = this.mouse;
            if (d.isArray(k) && 2 === k.length) m = {
                x: L,
                y: K
            }, w = {
                left: k[0],
                top: k[1]
            };
            else if ("mouse" === k) m = {
                x: L,
                y: K
            }, !B || !B.pageX || !p.mouse && c && c.pageX ? c && c.pageX || ((!p.mouse || this.options.show.distance) && h.origin && h.origin.pageX ? c = h.origin : (!c || c && ("resize" === c.type || "scroll" === c.type)) && (c = h.event)) : c = B, "static" !== v && (w = o.offset()), A.body.offsetWidth !== (a.innerWidth || A.documentElement.clientWidth) && (g = d(b.body).offset()), w = {
                left: c.pageX - w.left + (g && g.left || 0),
                top: c.pageY - w.top + (g && g.top || 0)
            }, p.mouse && y && B && (w.left -= (B.scrollX || 0) - z.scrollLeft(), w.top -= (B.scrollY || 0) - z.scrollTop());
            else {
                if ("event" === k ? c && c.target && "scroll" !== c.type && "resize" !== c.type ? h.target = d(c.target) : c.target || (h.target = this.elements.target) : "event" !== k && (h.target = d(k.jquery ? k : this.elements.target)), k = h.target, k = d(k).eq(0), 0 === k.length) return this;
                k[0] === b || k[0] === a ? (t = db.iOS ? a.innerWidth : k.width(), u = db.iOS ? a.innerHeight : k.height(), k[0] === a && (w = {
                    top: (n || k).scrollTop(),
                    left: (n || k).scrollLeft()
                })) : R.imagemap && k.is("area") ? f = R.imagemap(this, k, m, R.viewport ? q : E) : R.svg && k && k[0].ownerSVGElement ? f = R.svg(this, k, m, R.viewport ? q : E) : (t = k.outerWidth(E), u = k.outerHeight(E), w = k.offset()), f && (t = f.width, u = f.height, g = f.offset, w = f.position), w = this.reposition.offset(k, w, o), (db.iOS > 3.1 && db.iOS < 4.1 || db.iOS >= 4.3 && db.iOS < 4.33 || !db.iOS && "fixed" === v) && (w.left -= z.scrollLeft(), w.top -= z.scrollTop()), (!f || f && f.adjustable !== E) && (w.left += m.x === N ? t : m.x === O ? t / 2 : 0, w.top += m.y === M ? u : m.y === O ? u / 2 : 0)
            }
            return w.left += p.x + (l.x === N ? -r : l.x === O ? -r / 2 : 0), w.top += p.y + (l.y === M ? -s : l.y === O ? -s / 2 : 0), R.viewport ? (w.adjusted = R.viewport(this, w, j, t, u, r, s), g && w.adjusted.left && (w.left += g.left), g && w.adjusted.top && (w.top += g.top)) : w.adjusted = {
                left: 0,
                top: 0
            }, this._trigger("move", [w, n.elem || n], c) ? (delete w.adjusted, e === E || !x || isNaN(w.left) || isNaN(w.top) || "mouse" === k || !d.isFunction(j.effect) ? i.css(w) : d.isFunction(j.effect) && (j.effect.call(i, this, d.extend({}, w)), i.queue(function (a) {
                d(this).css({
                    opacity: "",
                    height: ""
                }), db.ie && this.style.removeAttribute("filter"), a()
            })), this.positioning = E, this) : this
        }, z.reposition.offset = function (a, c, e) {
            function f(a, b) {
                c.left += b * a.scrollLeft(), c.top += b * a.scrollTop()
            }
            if (!e[0]) return c;
            var g, h, i, j, k = d(a[0].ownerDocument),
                l = !! db.ie && "CSS1Compat" !== b.compatMode,
                m = e[0];
            do "static" !== (h = d.css(m, "position")) && ("fixed" === h ? (i = m.getBoundingClientRect(), f(k, -1)) : (i = d(m).position(), i.left += parseFloat(d.css(m, "borderLeftWidth")) || 0, i.top += parseFloat(d.css(m, "borderTopWidth")) || 0), c.left -= i.left + (parseFloat(d.css(m, "marginLeft")) || 0), c.top -= i.top + (parseFloat(d.css(m, "marginTop")) || 0), g || "hidden" === (j = d.css(m, "overflow")) || "visible" === j || (g = d(m))); while (m = m.offsetParent);
            return g && (g[0] !== k[0] || l) && f(g, 1), c
        };
        var gb = (A = z.reposition.Corner = function (a, b) {
            a = ("" + a).replace(/([A-Z])/, " $1").replace(/middle/gi, O).toLowerCase(), this.x = (a.match(/left|right/i) || a.match(/center/) || ["inherit"])[0].toLowerCase(), this.y = (a.match(/top|bottom|center/i) || ["inherit"])[0].toLowerCase(), this.forceY = !! b;
            var c = a.charAt(0);
            this.precedance = "t" === c || "b" === c ? H : G
        }).prototype;
        gb.invert = function (a, b) {
            this[a] = this[a] === L ? N : this[a] === N ? L : b || this[a]
        }, gb.string = function () {
            var a = this.x,
                b = this.y;
            return a === b ? a : this.precedance === H || this.forceY && "center" !== b ? b + " " + a : a + " " + b
        }, gb.abbrev = function () {
            var a = this.string().split(" ");
            return a[0].charAt(0) + (a[1] && a[1].charAt(0) || "")
        }, gb.clone = function () {
            return new A(this.string(), this.forceY)
        }, z.toggle = function (a, c) {
            var e = this.cache,
                f = this.options,
                g = this.tooltip;
            if (c) {
                if (/over|enter/.test(c.type) && /out|leave/.test(e.event.type) && f.show.target.add(c.target).length === f.show.target.length && g.has(c.relatedTarget).length) return this;
                e.event = l(c)
            }
            if (this.waiting && !a && (this.hiddenDuringWait = D), !this.rendered) return a ? this.render(1) : this;
            if (this.destroyed || this.disabled) return this;
            var h, i, j, k = a ? "show" : "hide",
                m = this.options[k],
                n = (this.options[a ? "hide" : "show"], this.options.position),
                o = this.options.content,
                p = this.tooltip.css("width"),
                q = this.tooltip.is(":visible"),
                r = a || 1 === m.target.length,
                s = !c || m.target.length < 2 || e.target[0] === c.target;
            return (typeof a).search("boolean|number") && (a = !q), h = !g.is(":animated") && q === a && s, i = h ? F : !! this._trigger(k, [90]), this.destroyed ? this : (i !== E && a && this.focus(c), !i || h ? this : (d.attr(g[0], "aria-hidden", !a), a ? (e.origin = l(this.mouse), d.isFunction(o.text) && this._updateContent(o.text, E), d.isFunction(o.title) && this._updateTitle(o.title, E), !C && "mouse" === n.target && n.adjust.mouse && (d(b).bind("mousemove." + S, this._storeMouse), C = D), p || g.css("width", g.outerWidth(E)), this.reposition(c, arguments[2]), p || g.css("width", ""), m.solo && ("string" == typeof m.solo ? d(m.solo) : d(W, m.solo)).not(g).not(m.target).qtip("hide", d.Event("tooltipsolo"))) : (clearTimeout(this.timers.show), delete e.origin, C && !d(W + '[tracking="true"]:visible', m.solo).not(g).length && (d(b).unbind("mousemove." + S), C = E), this.blur(c)), j = d.proxy(function () {
                a ? (db.ie && g[0].style.removeAttribute("filter"), g.css("overflow", ""), "string" == typeof m.autofocus && d(this.options.show.autofocus, g).focus(), this.options.show.target.trigger("qtip-" + this.id + "-inactive")) : g.css({
                    display: "",
                    visibility: "",
                    opacity: "",
                    left: "",
                    top: ""
                }), this._trigger(a ? "visible" : "hidden")
            }, this), m.effect === E || r === E ? (g[k](), j()) : d.isFunction(m.effect) ? (g.stop(1, 1), m.effect.call(g, this), g.queue("fx", function (a) {
                j(), a()
            })) : g.fadeTo(90, a ? 1 : 0, j), a && m.target.trigger("qtip-" + this.id + "-inactive"), this))
        }, z.show = function (a) {
            return this.toggle(D, a)
        }, z.hide = function (a) {
            return this.toggle(E, a)
        }, z.focus = function (a) {
            if (!this.rendered || this.destroyed) return this;
            var b = d(W),
                c = this.tooltip,
                e = parseInt(c[0].style.zIndex, 10),
                f = y.zindex + b.length;
            return c.hasClass($) || this._trigger("focus", [f], a) && (e !== f && (b.each(function () {
                this.style.zIndex > e && (this.style.zIndex = this.style.zIndex - 1)
            }), b.filter("." + $).qtip("blur", a)), c.addClass($)[0].style.zIndex = f), this
        }, z.blur = function (a) {
            return !this.rendered || this.destroyed ? this : (this.tooltip.removeClass($), this._trigger("blur", [this.tooltip.css("zIndex")], a), this)
        }, z.disable = function (a) {
            return this.destroyed ? this : ("toggle" === a ? a = !(this.rendered ? this.tooltip.hasClass(ab) : this.disabled) : "boolean" != typeof a && (a = D), this.rendered && this.tooltip.toggleClass(ab, a).attr("aria-disabled", a), this.disabled = !! a, this)
        }, z.enable = function () {
            return this.disable(E)
        }, z._createButton = function () {
            var a = this,
                b = this.elements,
                c = b.tooltip,
                e = this.options.content.button,
                f = "string" == typeof e,
                g = f ? e : "Close tooltip";
            b.button && b.button.remove(), b.button = e.jquery ? e : d("<a />", {
                "class": "qtip-close " + (this.options.style.widget ? "" : S + "-icon"),
                title: g,
                "aria-label": g
            }).prepend(d("<span />", {
                "class": "ui-icon ui-icon-close",
                html: "&times;"
            })), b.button.appendTo(b.titlebar || c).attr("role", "button").click(function (b) {
                return c.hasClass(ab) || a.hide(b), E
            })
        }, z._updateButton = function (a) {
            if (!this.rendered) return E;
            var b = this.elements.button;
            a ? this._createButton() : b.remove()
        }, z._setWidget = function () {
            var a = this.options.style.widget,
                b = this.elements,
                c = b.tooltip,
                d = c.hasClass(ab);
            c.removeClass(ab), ab = a ? "ui-state-disabled" : "qtip-disabled", c.toggleClass(ab, d), c.toggleClass("ui-helper-reset " + k(), a).toggleClass(Z, this.options.style.def && !a), b.content && b.content.toggleClass(k("content"), a), b.titlebar && b.titlebar.toggleClass(k("header"), a), b.button && b.button.toggleClass(S + "-icon", !a)
        }, z._storeMouse = function (a) {
            (this.mouse = l(a)).type = "mousemove"
        }, z._bind = function (a, b, c, e, f) {
            var g = "." + this._id + (e ? "-" + e : "");
            b.length && d(a).bind((b.split ? b : b.join(g + " ")) + g, d.proxy(c, f || this))
        }, z._unbind = function (a, b) {
            d(a).unbind("." + this._id + (b ? "-" + b : ""))
        };
        var hb = "." + S;
        d(function () {
            r(W, ["mouseenter", "mouseleave"], function (a) {
                var b = "mouseenter" === a.type,
                    c = d(a.currentTarget),
                    e = d(a.relatedTarget || a.target),
                    f = this.options;
                b ? (this.focus(a), c.hasClass(Y) && !c.hasClass(ab) && clearTimeout(this.timers.hide)) : "mouse" === f.position.target && f.hide.event && f.show.target && !e.closest(f.show.target[0]).length && this.hide(a), c.toggleClass(_, b)
            }), r("[" + U + "]", X, p)
        }), z._trigger = function (a, b, c) {
            var e = d.Event("tooltip" + a);
            return e.originalEvent = c && d.extend({}, c) || this.cache.event || F, this.triggering = a, this.tooltip.trigger(e, [this].concat(b || [])), this.triggering = E, !e.isDefaultPrevented()
        }, z._bindEvents = function (a, b, c, e, f, g) {
            if (e.add(c).length === e.length) {
                var h = [];
                b = d.map(b, function (b) {
                    var c = d.inArray(b, a);
                    return c > -1 ? (h.push(a.splice(c, 1)[0]), void 0) : b
                }), h.length && this._bind(c, h, function (a) {
                    var b = this.rendered ? this.tooltip[0].offsetWidth > 0 : !1;
                    (b ? g : f).call(this, a)
                })
            }
            this._bind(c, a, f), this._bind(e, b, g)
        }, z._assignInitialEvents = function (a) {
            function b(a) {
                return this.disabled || this.destroyed ? E : (this.cache.event = l(a), this.cache.target = a ? d(a.target) : [c], clearTimeout(this.timers.show), this.timers.show = m.call(this, function () {
                    this.render("object" == typeof a || e.show.ready)
                }, e.show.delay), void 0)
            }
            var e = this.options,
                f = e.show.target,
                g = e.hide.target,
                h = e.show.event ? d.trim("" + e.show.event).split(" ") : [],
                i = e.hide.event ? d.trim("" + e.hide.event).split(" ") : [];
            /mouse(over|enter)/i.test(e.show.event) && !/mouse(out|leave)/i.test(e.hide.event) && i.push("mouseleave"), this._bind(f, "mousemove", function (a) {
                this._storeMouse(a), this.cache.onTarget = D
            }), this._bindEvents(h, i, f, g, b, function () {
                clearTimeout(this.timers.show)
            }), (e.show.ready || e.prerender) && b.call(this, a)
        }, z._assignEvents = function () {
            var c = this,
                e = this.options,
                f = e.position,
                g = this.tooltip,
                h = e.show.target,
                i = e.hide.target,
                j = f.container,
                k = f.viewport,
                l = d(b),
                m = (d(b.body), d(a)),
                r = e.show.event ? d.trim("" + e.show.event).split(" ") : [],
                s = e.hide.event ? d.trim("" + e.hide.event).split(" ") : [];
            d.each(e.events, function (a, b) {
                c._bind(g, "toggle" === a ? ["tooltipshow", "tooltiphide"] : ["tooltip" + a], b, null, g)
            }), /mouse(out|leave)/i.test(e.hide.event) && "window" === e.hide.leave && this._bind(l, ["mouseout", "blur"], function (a) {
                /select|option/.test(a.target.nodeName) || a.relatedTarget || this.hide(a)
            }), e.hide.fixed ? i = i.add(g.addClass(Y)) : /mouse(over|enter)/i.test(e.show.event) && this._bind(i, "mouseleave", function () {
                clearTimeout(this.timers.show)
            }), ("" + e.hide.event).indexOf("unfocus") > -1 && this._bind(j.closest("html"), ["mousedown", "touchstart"], function (a) {
                var b = d(a.target),
                    c = this.rendered && !this.tooltip.hasClass(ab) && this.tooltip[0].offsetWidth > 0,
                    e = b.parents(W).filter(this.tooltip[0]).length > 0;
                b[0] === this.target[0] || b[0] === this.tooltip[0] || e || this.target.has(b[0]).length || !c || this.hide(a)
            }), "number" == typeof e.hide.inactive && (this._bind(h, "qtip-" + this.id + "-inactive", p), this._bind(i.add(g), y.inactiveEvents, p, "-inactive")), this._bindEvents(r, s, h, i, n, o), this._bind(h.add(g), "mousemove", function (a) {
                if ("number" == typeof e.hide.distance) {
                    var b = this.cache.origin || {}, c = this.options.hide.distance,
                        d = Math.abs;
                    (d(a.pageX - b.pageX) >= c || d(a.pageY - b.pageY) >= c) && this.hide(a)
                }
                this._storeMouse(a)
            }), "mouse" === f.target && f.adjust.mouse && (e.hide.event && this._bind(h, ["mouseenter", "mouseleave"], function (a) {
                this.cache.onTarget = "mouseenter" === a.type
            }), this._bind(l, "mousemove", function (a) {
                this.rendered && this.cache.onTarget && !this.tooltip.hasClass(ab) && this.tooltip[0].offsetWidth > 0 && this.reposition(a)
            })), (f.adjust.resize || k.length) && this._bind(d.event.special.resize ? k : m, "resize", q), f.adjust.scroll && this._bind(m.add(f.container), "scroll", q)
        }, z._unassignEvents = function () {
            var c = [this.options.show.target[0], this.options.hide.target[0], this.rendered && this.tooltip[0], this.options.position.container[0], this.options.position.viewport[0], this.options.position.container.closest("html")[0], a, b];
            this._unbind(d([]).pushStack(d.grep(c, function (a) {
                return "object" == typeof a
            })))
        }, y = d.fn.qtip = function (a, b, e) {
            var f = ("" + a).toLowerCase(),
                g = F,
                i = d.makeArray(arguments).slice(1),
                j = i[i.length - 1],
                k = this[0] ? d.data(this[0], S) : F;
            return !arguments.length && k || "api" === f ? k : "string" == typeof a ? (this.each(function () {
                var a = d.data(this, S);
                if (!a) return D;
                if (j && j.timeStamp && (a.cache.event = j), !b || "option" !== f && "options" !== f) a[f] && a[f].apply(a, i);
                else {
                    if (e === c && !d.isPlainObject(b)) return g = a.get(b), E;
                    a.set(b, e)
                }
            }), g !== F ? g : this) : "object" != typeof a && arguments.length ? void 0 : (k = h(d.extend(D, {}, a)), this.each(function (a) {
                var b, c;
                return c = d.isArray(k.id) ? k.id[a] : k.id, c = !c || c === E || c.length < 1 || y.api[c] ? y.nextid++ : c, b = s(d(this), c, k), b === E ? D : (y.api[c] = b, d.each(R, function () {
                    "initialize" === this.initialize && this(b)
                }), b._assignInitialEvents(j), void 0)
            }))
        }, d.qtip = e, y.api = {}, d.each({
            attr: function (a, b) {
                if (this.length) {
                    var c = this[0],
                        e = "title",
                        f = d.data(c, "qtip");
                    if (a === e && f && "object" == typeof f && f.options.suppress) return arguments.length < 2 ? d.attr(c, cb) : (f && f.options.content.attr === e && f.cache.attr && f.set("content.text", b), this.attr(cb, b))
                }
                return d.fn["attr" + bb].apply(this, arguments)
            },
            clone: function (a) {
                var b = (d([]), d.fn["clone" + bb].apply(this, arguments));
                return a || b.filter("[" + cb + "]").attr("title", function () {
                    return d.attr(this, cb)
                }).removeAttr(cb), b
            }
        }, function (a, b) {
            if (!b || d.fn[a + bb]) return D;
            var c = d.fn[a + bb] = d.fn[a];
            d.fn[a] = function () {
                return b.apply(this, arguments) || c.apply(this, arguments)
            }
        }), d.ui || (d["cleanData" + bb] = d.cleanData, d.cleanData = function (a) {
            for (var b, c = 0;
                (b = d(a[c])).length; c++)
                if (b.attr(T)) try {
                    b.triggerHandler("removeqtip")
                } catch (e) {}
                d["cleanData" + bb].apply(this, arguments)
        }), y.version = "2.2.0", y.nextid = 0, y.inactiveEvents = X, y.zindex = 15e3, y.defaults = {
            prerender: E,
            id: E,
            overwrite: D,
            suppress: D,
            content: {
                text: D,
                attr: "title",
                title: E,
                button: E
            },
            position: {
                my: "top left",
                at: "bottom right",
                target: E,
                container: E,
                viewport: E,
                adjust: {
                    x: 0,
                    y: 0,
                    mouse: D,
                    scroll: D,
                    resize: D,
                    method: "flipinvert flipinvert"
                },
                effect: function (a, b) {
                    d(this).animate(b, {
                        duration: 200,
                        queue: E
                    })
                }
            },
            show: {
                target: E,
                event: "mouseenter",
                effect: D,
                delay: 90,
                solo: E,
                ready: E,
                autofocus: E
            },
            hide: {
                target: E,
                event: "mouseleave",
                effect: D,
                delay: 0,
                fixed: E,
                inactive: E,
                leave: "window",
                distance: E
            },
            style: {
                classes: "",
                widget: E,
                width: E,
                height: E,
                def: D
            },
            events: {
                render: F,
                move: F,
                show: F,
                hide: F,
                toggle: F,
                visible: F,
                hidden: F,
                focus: F,
                blur: F
            }
        };
        var ib, jb = "margin",
            kb = "border",
            lb = "color",
            mb = "background-color",
            nb = "transparent",
            ob = " !important",
            pb = !! b.createElement("canvas").getContext,
            qb = /rgba?\(0, 0, 0(, 0)?\)|transparent|#123456/i,
            rb = {}, sb = ["Webkit", "O", "Moz", "ms"];
        if (pb) var tb = a.devicePixelRatio || 1,
        ub = function () {
            var a = b.createElement("canvas").getContext("2d");
            return a.backingStorePixelRatio || a.webkitBackingStorePixelRatio || a.mozBackingStorePixelRatio || a.msBackingStorePixelRatio || a.oBackingStorePixelRatio || 1
        }(), vb = tb / ub;
        else var wb = function (a, b, c) {
            return "<qtipvml:" + a + ' xmlns="urn:schemas-microsoft.com:vml" class="qtip-vml" ' + (b || "") + ' style="behavior: url(#default#VML); ' + (c || "") + '" />'
        };
        d.extend(w.prototype, {
            init: function (a) {
                var b, c;
                c = this.element = a.elements.tip = d("<div />", {
                    "class": S + "-tip"
                }).prependTo(a.tooltip), pb ? (b = d("<canvas />").appendTo(this.element)[0].getContext("2d"), b.lineJoin = "miter", b.miterLimit = 1e5, b.save()) : (b = wb("shape", 'coordorigin="0,0"', "position:absolute;"), this.element.html(b + b), a._bind(d("*", c).add(c), ["click", "mousedown"], function (a) {
                    a.stopPropagation()
                }, this._ns)), a._bind(a.tooltip, "tooltipmove", this.reposition, this._ns, this), this.create()
            },
            _swapDimensions: function () {
                this.size[0] = this.options.height, this.size[1] = this.options.width
            },
            _resetDimensions: function () {
                this.size[0] = this.options.width, this.size[1] = this.options.height
            },
            _useTitle: function (a) {
                var b = this.qtip.elements.titlebar;
                return b && (a.y === K || a.y === O && this.element.position().top + this.size[1] / 2 + this.options.offset < b.outerHeight(D))
            },
            _parseCorner: function (a) {
                var b = this.qtip.options.position.my;
                return a === E || b === E ? a = E : a === D ? a = new A(b.string()) : a.string || (a = new A(a), a.fixed = D), a
            },
            _parseWidth: function (a, b, c) {
                var d = this.qtip.elements,
                    e = kb + t(b) + "Width";
                return (c ? v(c, e) : v(d.content, e) || v(this._useTitle(a) && d.titlebar || d.content, e) || v(d.tooltip, e)) || 0
            },
            _parseRadius: function (a) {
                var b = this.qtip.elements,
                    c = kb + t(a.y) + t(a.x) + "Radius";
                return db.ie < 9 ? 0 : v(this._useTitle(a) && b.titlebar || b.content, c) || v(b.tooltip, c) || 0
            },
            _invalidColour: function (a, b, c) {
                var d = a.css(b);
                return !d || c && d === a.css(c) || qb.test(d) ? E : d
            },
            _parseColours: function (a) {
                var b = this.qtip.elements,
                    c = this.element.css("cssText", ""),
                    e = kb + t(a[a.precedance]) + t(lb),
                    f = this._useTitle(a) && b.titlebar || b.content,
                    g = this._invalidColour,
                    h = [];
                return h[0] = g(c, mb) || g(f, mb) || g(b.content, mb) || g(b.tooltip, mb) || c.css(mb), h[1] = g(c, e, lb) || g(f, e, lb) || g(b.content, e, lb) || g(b.tooltip, e, lb) || b.tooltip.css(e), d("*", c).add(c).css("cssText", mb + ":" + nb + ob + ";" + kb + ":0" + ob + ";"), h
            },
            _calculateSize: function (a) {
                var b, c, d, e = a.precedance === H,
                    f = this.options.width,
                    g = this.options.height,
                    h = "c" === a.abbrev(),
                    i = (e ? f : g) * (h ? .5 : 1),
                    j = Math.pow,
                    k = Math.round,
                    l = Math.sqrt(j(i, 2) + j(g, 2)),
                    m = [this.border / i * l, this.border / g * l];
                return m[2] = Math.sqrt(j(m[0], 2) - j(this.border, 2)), m[3] = Math.sqrt(j(m[1], 2) - j(this.border, 2)), b = l + m[2] + m[3] + (h ? 0 : m[0]), c = b / l, d = [k(c * f), k(c * g)], e ? d : d.reverse()
            },
            _calculateTip: function (a, b, c) {
                c = c || 1, b = b || this.size;
                var d = b[0] * c,
                    e = b[1] * c,
                    f = Math.ceil(d / 2),
                    g = Math.ceil(e / 2),
                    h = {
                        br: [0, 0, d, e, d, 0],
                        bl: [0, 0, d, 0, 0, e],
                        tr: [0, e, d, 0, d, e],
                        tl: [0, 0, 0, e, d, e],
                        tc: [0, e, f, 0, d, e],
                        bc: [0, 0, d, 0, f, e],
                        rc: [0, 0, d, g, 0, e],
                        lc: [d, 0, d, e, 0, g]
                    };
                return h.lt = h.br, h.rt = h.bl, h.lb = h.tr, h.rb = h.tl, h[a.abbrev()]
            },
            _drawCoords: function (a, b) {
                a.beginPath(), a.moveTo(b[0], b[1]), a.lineTo(b[2], b[3]), a.lineTo(b[4], b[5]), a.closePath()
            },
            create: function () {
                var a = this.corner = (pb || db.ie) && this._parseCorner(this.options.corner);
                return (this.enabled = !! this.corner && "c" !== this.corner.abbrev()) && (this.qtip.cache.corner = a.clone(), this.update()), this.element.toggle(this.enabled), this.corner
            },
            update: function (b, c) {
                if (!this.enabled) return this;
                var e, f, g, h, i, j, k, l, m = this.qtip.elements,
                    n = this.element,
                    o = n.children(),
                    p = this.options,
                    q = this.size,
                    r = p.mimic,
                    s = Math.round;
                b || (b = this.qtip.cache.corner || this.corner), r === E ? r = b : (r = new A(r), r.precedance = b.precedance, "inherit" === r.x ? r.x = b.x : "inherit" === r.y ? r.y = b.y : r.x === r.y && (r[b.precedance] = b[b.precedance])), f = r.precedance, b.precedance === G ? this._swapDimensions() : this._resetDimensions(), e = this.color = this._parseColours(b), e[1] !== nb ? (l = this.border = this._parseWidth(b, b[b.precedance]), p.border && 1 > l && !qb.test(e[1]) && (e[0] = e[1]), this.border = l = p.border !== D ? p.border : l) : this.border = l = 0, k = this.size = this._calculateSize(b), n.css({
                    width: k[0],
                    height: k[1],
                    lineHeight: k[1] + "px"
                }), j = b.precedance === H ? [s(r.x === L ? l : r.x === N ? k[0] - q[0] - l : (k[0] - q[0]) / 2), s(r.y === K ? k[1] - q[1] : 0)] : [s(r.x === L ? k[0] - q[0] : 0), s(r.y === K ? l : r.y === M ? k[1] - q[1] - l : (k[1] - q[1]) / 2)], pb ? (g = o[0].getContext("2d"), g.restore(), g.save(), g.clearRect(0, 0, 6e3, 6e3), h = this._calculateTip(r, q, vb), i = this._calculateTip(r, this.size, vb), o.attr(I, k[0] * vb).attr(J, k[1] * vb), o.css(I, k[0]).css(J, k[1]), this._drawCoords(g, i), g.fillStyle = e[1], g.fill(), g.translate(j[0] * vb, j[1] * vb), this._drawCoords(g, h), g.fillStyle = e[0], g.fill()) : (h = this._calculateTip(r), h = "m" + h[0] + "," + h[1] + " l" + h[2] + "," + h[3] + " " + h[4] + "," + h[5] + " xe", j[2] = l && /^(r|b)/i.test(b.string()) ? 8 === db.ie ? 2 : 1 : 0, o.css({
                    coordsize: k[0] + l + " " + (k[1] + l),
                    antialias: "" + (r.string().indexOf(O) > -1),
                    left: j[0] - j[2] * Number(f === G),
                    top: j[1] - j[2] * Number(f === H),
                    width: k[0] + l,
                    height: k[1] + l
                }).each(function (a) {
                    var b = d(this);
                    b[b.prop ? "prop" : "attr"]({
                        coordsize: k[0] + l + " " + (k[1] + l),
                        path: h,
                        fillcolor: e[0],
                        filled: !! a,
                        stroked: !a
                    }).toggle(!(!l && !a)), !a && b.html(wb("stroke", 'weight="' + 2 * l + 'px" color="' + e[1] + '" miterlimit="1000" joinstyle="miter"'))
                })), a.opera && setTimeout(function () {
                    m.tip.css({
                        display: "inline-block",
                        visibility: "visible"
                    })
                }, 1), c !== E && this.calculate(b, k)
            },
            calculate: function (a, b) {
                if (!this.enabled) return E;
                var c, e, f = this,
                    g = this.qtip.elements,
                    h = this.element,
                    i = this.options.offset,
                    j = (g.tooltip.hasClass("ui-widget"), {});
                return a = a || this.corner, c = a.precedance, b = b || this._calculateSize(a), e = [a.x, a.y], c === G && e.reverse(), d.each(e, function (d, e) {
                    var h, k, l;
                    e === O ? (h = c === H ? L : K, j[h] = "50%", j[jb + "-" + h] = -Math.round(b[c === H ? 0 : 1] / 2) + i) : (h = f._parseWidth(a, e, g.tooltip), k = f._parseWidth(a, e, g.content), l = f._parseRadius(a), j[e] = Math.max(-f.border, d ? k : i + (l > h ? l : -h)))
                }), j[a[c]] -= b[c === G ? 0 : 1], h.css({
                    margin: "",
                    top: "",
                    bottom: "",
                    left: "",
                    right: ""
                }).css(j), j
            },
            reposition: function (a, b, d) {
                function e(a, b, c, d, e) {
                    a === Q && j.precedance === b && k[d] && j[c] !== O ? j.precedance = j.precedance === G ? H : G : a !== Q && k[d] && (j[b] = j[b] === O ? k[d] > 0 ? d : e : j[b] === d ? e : d)
                }

                function f(a, b, e) {
                    j[a] === O ? p[jb + "-" + b] = o[a] = g[jb + "-" + b] - k[b] : (h = g[e] !== c ? [k[b], -g[b]] : [-k[b], g[b]], (o[a] = Math.max(h[0], h[1])) > h[0] && (d[b] -= k[b], o[b] = E), p[g[e] !== c ? e : b] = o[a])
                }
                if (this.enabled) {
                    var g, h, i = b.cache,
                        j = this.corner.clone(),
                        k = d.adjusted,
                        l = b.options.position.adjust.method.split(" "),
                        m = l[0],
                        n = l[1] || l[0],
                        o = {
                            left: E,
                            top: E,
                            x: 0,
                            y: 0
                        }, p = {};
                    this.corner.fixed !== D && (e(m, G, H, L, N), e(n, H, G, K, M), j.string() === i.corner.string() || i.cornerTop === k.top && i.cornerLeft === k.left || this.update(j, E)), g = this.calculate(j), g.right !== c && (g.left = -g.right), g.bottom !== c && (g.top = -g.bottom), g.user = this.offset, (o.left = m === Q && !! k.left) && f(G, L, N), (o.top = n === Q && !! k.top) && f(H, K, M), this.element.css(p).toggle(!(o.x && o.y || j.x === O && o.y || j.y === O && o.x)), d.left -= g.left.charAt ? g.user : m !== Q || o.top || !o.left && !o.top ? g.left + this.border : 0, d.top -= g.top.charAt ? g.user : n !== Q || o.left || !o.left && !o.top ? g.top + this.border : 0, i.cornerLeft = k.left, i.cornerTop = k.top, i.corner = j.clone()
                }
            },
            destroy: function () {
                this.qtip._unbind(this.qtip.tooltip, this._ns), this.qtip.elements.tip && this.qtip.elements.tip.find("*").remove().end().remove()
            }
        }), ib = R.tip = function (a) {
            return new w(a, a.options.style.tip)
        }, ib.initialize = "render", ib.sanitize = function (a) {
            if (a.style && "tip" in a.style) {
                var b = a.style.tip;
                "object" != typeof b && (b = a.style.tip = {
                    corner: b
                }), /string|boolean/i.test(typeof b.corner) || (b.corner = D)
            }
        }, B.tip = {
            "^position.my|style.tip.(corner|mimic|border)$": function () {
                this.create(), this.qtip.reposition()
            },
            "^style.tip.(height|width)$": function (a) {
                this.size = [a.width, a.height], this.update(), this.qtip.reposition()
            },
            "^content.title|style.(classes|widget)$": function () {
                this.update()
            }
        }, d.extend(D, y.defaults, {
            style: {
                tip: {
                    corner: D,
                    mimic: E,
                    width: 6,
                    height: 6,
                    border: D,
                    offset: 0
                }
            }
        }), R.viewport = function (c, d, e, f, g, h, i) {
            function j(a, b, c, e, f, g, h, i, j) {
                var k = d[f],
                    m = v[a],
                    t = w[a],
                    u = c === Q,
                    x = m === f ? j : m === g ? -j : -j / 2,
                    y = t === f ? i : t === g ? -i : -i / 2,
                    z = r[f] + s[f] - (o ? 0 : n[f]),
                    A = z - k,
                    B = k + j - (h === I ? p : q) - z,
                    C = x - (v.precedance === a || m === v[b] ? y : 0) - (t === O ? i / 2 : 0);
                return u ? (C = (m === f ? 1 : -1) * x, d[f] += A > 0 ? A : B > 0 ? -B : 0, d[f] = Math.max(-n[f] + s[f], k - C, Math.min(Math.max(-n[f] + s[f] + (h === I ? p : q), k + C), d[f], "center" === m ? k - x : 1e9))) : (e *= c === P ? 2 : 0, A > 0 && (m !== f || B > 0) ? (d[f] -= C + e, l.invert(a, f)) : B > 0 && (m !== g || A > 0) && (d[f] -= (m === O ? -C : C) + e, l.invert(a, g)), d[f] < r && -d[f] > B && (d[f] = k, l = v.clone())), d[f] - k
            }
            var k, l, m, n, o, p, q, r, s, t = e.target,
                u = c.elements.tooltip,
                v = e.my,
                w = e.at,
                x = e.adjust,
                y = x.method.split(" "),
                z = y[0],
                A = y[1] || y[0],
                B = e.viewport,
                C = e.container,
                D = c.cache,
                F = {
                    left: 0,
                    top: 0
                };
            return B.jquery && t[0] !== a && t[0] !== b.body && "none" !== x.method ? (n = C.offset() || F, o = "static" === C.css("position"), k = "fixed" === u.css("position"), p = B[0] === a ? B.width() : B.outerWidth(E), q = B[0] === a ? B.height() : B.outerHeight(E), r = {
                left: k ? 0 : B.scrollLeft(),
                top: k ? 0 : B.scrollTop()
            }, s = B.offset() || F, ("shift" !== z || "shift" !== A) && (l = v.clone()), F = {
                left: "none" !== z ? j(G, H, z, x.x, L, N, I, f, h) : 0,
                top: "none" !== A ? j(H, G, A, x.y, K, M, J, g, i) : 0
            }, l && D.lastClass !== (m = S + "-pos-" + l.abbrev()) && u.removeClass(c.cache.lastClass).addClass(c.cache.lastClass = m), F) : F
        };
        var xb, yb, zb = "qtip-modal",
            Ab = "." + zb;
        yb = function () {
            function a(a) {
                if (d.expr[":"].focusable) return d.expr[":"].focusable;
                var b, c, e, f = !isNaN(d.attr(a, "tabindex")),
                    g = a.nodeName && a.nodeName.toLowerCase();
                return "area" === g ? (b = a.parentNode, c = b.name, a.href && c && "map" === b.nodeName.toLowerCase() ? (e = d("img[usemap=#" + c + "]")[0], !! e && e.is(":visible")) : !1) : /input|select|textarea|button|object/.test(g) ? !a.disabled : "a" === g ? a.href || f : f
            }

            function c(a) {
                k.length < 1 && a.length ? a.not("body").blur() : k.first().focus()
            }

            function e(a) {
                if (i.is(":visible")) {
                    var b, e = d(a.target),
                        h = f.tooltip,
                        j = e.closest(W);
                    b = j.length < 1 ? E : parseInt(j[0].style.zIndex, 10) > parseInt(h[0].style.zIndex, 10), b || e.closest(W)[0] === h[0] || c(e), g = a.target === k[k.length - 1]
                }
            }
            var f, g, h, i, j = this,
                k = {};
            d.extend(j, {
                init: function () {
                    return i = j.elem = d("<div />", {
                        id: "qtip-overlay",
                        html: "<div></div>",
                        mousedown: function () {
                            return E
                        }
                    }).hide(), d(b.body).bind("focusin" + Ab, e), d(b).bind("keydown" + Ab, function (a) {
                        f && f.options.show.modal.escape && 27 === a.keyCode && f.hide(a)
                    }), i.bind("click" + Ab, function (a) {
                        f && f.options.show.modal.blur && f.hide(a)
                    }), j
                },
                update: function (b) {
                    f = b, k = b.options.show.modal.stealfocus !== E ? b.tooltip.find("*").filter(function () {
                        return a(this)
                    }) : []
                },
                toggle: function (a, e, g) {
                    var k = (d(b.body), a.tooltip),
                        l = a.options.show.modal,
                        m = l.effect,
                        n = e ? "show" : "hide",
                        o = i.is(":visible"),
                        p = d(Ab).filter(":visible:not(:animated)").not(k);
                    return j.update(a), e && l.stealfocus !== E && c(d(":focus")), i.toggleClass("blurs", l.blur), e && i.appendTo(b.body), i.is(":animated") && o === e && h !== E || !e && p.length ? j : (i.stop(D, E), d.isFunction(m) ? m.call(i, e) : m === E ? i[n]() : i.fadeTo(parseInt(g, 10) || 90, e ? 1 : 0, function () {
                        e || i.hide()
                    }), e || i.queue(function (a) {
                        i.css({
                            left: "",
                            top: ""
                        }), d(Ab).length || i.detach(), a()
                    }), h = e, f.destroyed && (f = F), j)
                }
            }), j.init()
        }, yb = new yb, d.extend(x.prototype, {
            init: function (a) {
                var b = a.tooltip;
                return this.options.on ? (a.elements.overlay = yb.elem, b.addClass(zb).css("z-index", y.modal_zindex + d(Ab).length), a._bind(b, ["tooltipshow", "tooltiphide"], function (a, c, e) {
                    var f = a.originalEvent;
                    if (a.target === b[0])
                        if (f && "tooltiphide" === a.type && /mouse(leave|enter)/.test(f.type) && d(f.relatedTarget).closest(yb.elem[0]).length) try {
                            a.preventDefault()
                        } catch (g) {} else(!f || f && "tooltipsolo" !== f.type) && this.toggle(a, "tooltipshow" === a.type, e)
                }, this._ns, this), a._bind(b, "tooltipfocus", function (a, c) {
                    if (!a.isDefaultPrevented() && a.target === b[0]) {
                        var e = d(Ab),
                            f = y.modal_zindex + e.length,
                            g = parseInt(b[0].style.zIndex, 10);
                        yb.elem[0].style.zIndex = f - 1, e.each(function () {
                            this.style.zIndex > g && (this.style.zIndex -= 1)
                        }), e.filter("." + $).qtip("blur", a.originalEvent), b.addClass($)[0].style.zIndex = f, yb.update(c);
                        try {
                            a.preventDefault()
                        } catch (h) {}
                    }
                }, this._ns, this), a._bind(b, "tooltiphide", function (a) {
                    a.target === b[0] && d(Ab).filter(":visible").not(b).last().qtip("focus", a)
                }, this._ns, this), void 0) : this
            },
            toggle: function (a, b, c) {
                return a && a.isDefaultPrevented() ? this : (yb.toggle(this.qtip, !! b, c), void 0)
            },
            destroy: function () {
                this.qtip.tooltip.removeClass(zb), this.qtip._unbind(this.qtip.tooltip, this._ns), yb.toggle(this.qtip, E), delete this.qtip.elements.overlay
            }
        }), xb = R.modal = function (a) {
            return new x(a, a.options.show.modal)
        }, xb.sanitize = function (a) {
            a.show && ("object" != typeof a.show.modal ? a.show.modal = {
                on: !! a.show.modal
            } : "undefined" == typeof a.show.modal.on && (a.show.modal.on = D))
        }, y.modal_zindex = y.zindex - 200, xb.initialize = "render", B.modal = {
            "^show.modal.(on|blur)$": function () {
                this.destroy(), this.init(), this.qtip.elems.overlay.toggle(this.qtip.tooltip[0].offsetWidth > 0)
            }
        }, d.extend(D, y.defaults, {
            show: {
                modal: {
                    on: E,
                    effect: D,
                    blur: D,
                    stealfocus: D,
                    escape: D
                }
            }
        })
    })
}(window, document);
//# sourceMappingURL=http://cdnjs.cloudflare.com/ajax/libs/qtip2/2.2.0//var/www/qtip2/build/tmp/tmp-19072486i6yo/jquery.qtip.min.map

/* Fancy Box */
(function(e,t,n,r){"use strict";var i=n("html"),s=n(e),o=n(t),u=n.fancybox=function(){u.open.apply(this,arguments)},a=navigator.userAgent.match(/msie/i),f=null,l=t.createTouch!==r,c=function(e){return e&&e.hasOwnProperty&&e instanceof n},h=function(e){return e&&n.type(e)==="string"},p=function(e){return h(e)&&e.indexOf("%")>0},d=function(e){return e&&!(e.style.overflow&&e.style.overflow==="hidden")&&(e.clientWidth&&e.scrollWidth>e.clientWidth||e.clientHeight&&e.scrollHeight>e.clientHeight)},v=function(e,t){var n=parseInt(e,10)||0;if(t&&p(e)){n=u.getViewport()[t]/100*n}return Math.ceil(n)},m=function(e,t){return v(e,t)+"px"};n.extend(u,{version:"2.1.5",defaults:{padding:15,margin:20,width:800,height:600,minWidth:100,minHeight:100,maxWidth:9999,maxHeight:9999,pixelRatio:1,autoSize:true,autoHeight:false,autoWidth:false,autoResize:true,autoCenter:!l,fitToView:true,aspectRatio:false,topRatio:.5,leftRatio:.5,scrolling:"auto",wrapCSS:"",arrows:true,closeBtn:true,closeClick:false,nextClick:false,mouseWheel:true,autoPlay:false,playSpeed:3e3,preload:3,modal:false,loop:true,ajax:{dataType:"html",headers:{"X-fancyBox":true}},iframe:{scrolling:"auto",preload:true},swf:{wmode:"transparent",allowfullscreen:"true",allowscriptaccess:"always"},keys:{next:{13:"left",34:"up",39:"left",40:"up"},prev:{8:"right",33:"down",37:"right",38:"down"},close:[27],play:[32],toggle:[70]},direction:{next:"left",prev:"right"},scrollOutside:true,index:0,type:null,href:null,content:null,title:null,tpl:{wrap:'<div class="fancybox-wrap" tabIndex="-1"><div class="fancybox-skin"><div class="fancybox-outer"><div class="fancybox-inner"></div></div></div></div>',image:'<img class="fancybox-image" src="{href}" alt="" />',iframe:'<iframe id="fancybox-frame{rnd}" name="fancybox-frame{rnd}" class="fancybox-iframe" frameborder="0" vspace="0" hspace="0" webkitAllowFullScreen mozallowfullscreen allowFullScreen'+(a?' allowtransparency="true"':"")+"></iframe>",error:'<p class="fancybox-error">The requested content cannot be loaded.<br/>Please try again later.</p>',closeBtn:'<a title="Close" class="fancybox-item fancybox-close" href="javascript:;"></a>',next:'<a title="Next" class="fancybox-nav fancybox-next" href="javascript:;"><span></span></a>',prev:'<a title="Previous" class="fancybox-nav fancybox-prev" href="javascript:;"><span></span></a>'},openEffect:"fade",openSpeed:250,openEasing:"swing",openOpacity:true,openMethod:"zoomIn",closeEffect:"fade",closeSpeed:250,closeEasing:"swing",closeOpacity:true,closeMethod:"zoomOut",nextEffect:"elastic",nextSpeed:250,nextEasing:"swing",nextMethod:"changeIn",prevEffect:"elastic",prevSpeed:250,prevEasing:"swing",prevMethod:"changeOut",helpers:{overlay:true,title:true},onCancel:n.noop,beforeLoad:n.noop,afterLoad:n.noop,beforeShow:n.noop,afterShow:n.noop,beforeChange:n.noop,beforeClose:n.noop,afterClose:n.noop},group:{},opts:{},previous:null,coming:null,current:null,isActive:false,isOpen:false,isOpened:false,wrap:null,skin:null,outer:null,inner:null,player:{timer:null,isActive:false},ajaxLoad:null,imgPreload:null,transitions:{},helpers:{},open:function(e,t){if(!e){return}if(!n.isPlainObject(t)){t={}}if(false===u.close(true)){return}if(!n.isArray(e)){e=c(e)?n(e).get():[e]}n.each(e,function(i,s){var o={},a,f,l,p,d,v,m;if(n.type(s)==="object"){if(s.nodeType){s=n(s)}if(c(s)){o={href:s.data("fancybox-href")||s.attr("href"),title:s.data("fancybox-title")||s.attr("title"),isDom:true,element:s};if(n.metadata){n.extend(true,o,s.metadata())}}else{o=s}}a=t.href||o.href||(h(s)?s:null);f=t.title!==r?t.title:o.title||"";l=t.content||o.content;p=l?"html":t.type||o.type;if(!p&&o.isDom){p=s.data("fancybox-type");if(!p){d=s.prop("class").match(/fancybox\.(\w+)/);p=d?d[1]:null}}if(h(a)){if(!p){if(u.isImage(a)){p="image"}else if(u.isSWF(a)){p="swf"}else if(a.charAt(0)==="#"){p="inline"}else if(h(s)){p="html";l=s}}if(p==="ajax"){v=a.split(/\s+/,2);a=v.shift();m=v.shift()}}if(!l){if(p==="inline"){if(a){l=n(h(a)?a.replace(/.*(?=#[^\s]+$)/,""):a)}else if(o.isDom){l=s}}else if(p==="html"){l=a}else if(!p&&!a&&o.isDom){p="inline";l=s}}n.extend(o,{href:a,type:p,content:l,title:f,selector:m});e[i]=o});u.opts=n.extend(true,{},u.defaults,t);if(t.keys!==r){u.opts.keys=t.keys?n.extend({},u.defaults.keys,t.keys):false}u.group=e;return u._start(u.opts.index)},cancel:function(){var e=u.coming;if(!e||false===u.trigger("onCancel")){return}u.hideLoading();if(u.ajaxLoad){u.ajaxLoad.abort()}u.ajaxLoad=null;if(u.imgPreload){u.imgPreload.onload=u.imgPreload.onerror=null}if(e.wrap){e.wrap.stop(true,true).trigger("onReset").remove()}u.coming=null;if(!u.current){u._afterZoomOut(e)}},close:function(e){u.cancel();if(false===u.trigger("beforeClose")){return}u.unbindEvents();if(!u.isActive){return}if(!u.isOpen||e===true){n(".fancybox-wrap").stop(true).trigger("onReset").remove();u._afterZoomOut()}else{u.isOpen=u.isOpened=false;u.isClosing=true;n(".fancybox-item, .fancybox-nav").remove();u.wrap.stop(true,true).removeClass("fancybox-opened");u.transitions[u.current.closeMethod]()}},play:function(e){var t=function(){clearTimeout(u.player.timer)},n=function(){t();if(u.current&&u.player.isActive){u.player.timer=setTimeout(u.next,u.current.playSpeed)}},r=function(){t();o.unbind(".player");u.player.isActive=false;u.trigger("onPlayEnd")},i=function(){if(u.current&&(u.current.loop||u.current.index<u.group.length-1)){u.player.isActive=true;o.bind({"onCancel.player beforeClose.player":r,"onUpdate.player":n,"beforeLoad.player":t});n();u.trigger("onPlayStart")}};if(e===true||!u.player.isActive&&e!==false){i()}else{r()}},next:function(e){var t=u.current;if(t){if(!h(e)){e=t.direction.next}u.jumpto(t.index+1,e,"next")}},prev:function(e){var t=u.current;if(t){if(!h(e)){e=t.direction.prev}u.jumpto(t.index-1,e,"prev")}},jumpto:function(e,t,n){var i=u.current;if(!i){return}e=v(e);u.direction=t||i.direction[e>=i.index?"next":"prev"];u.router=n||"jumpto";if(i.loop){if(e<0){e=i.group.length+e%i.group.length}e=e%i.group.length}if(i.group[e]!==r){u.cancel();u._start(e)}},reposition:function(e,t){var r=u.current,i=r?r.wrap:null,s;if(i){s=u._getPosition(t);if(e&&e.type==="scroll"){delete s.position;i.stop(true,true).animate(s,200)}else{i.css(s);r.pos=n.extend({},r.dim,s)}}},update:function(e){var t=e&&e.type,n=!t||t==="orientationchange";if(n){clearTimeout(f);f=null}if(!u.isOpen||f){return}f=setTimeout(function(){var r=u.current;if(!r||u.isClosing){return}u.wrap.removeClass("fancybox-tmp");if(n||t==="load"||t==="resize"&&r.autoResize){u._setDimension()}if(!(t==="scroll"&&r.canShrink)){u.reposition(e)}u.trigger("onUpdate");f=null},n&&!l?0:300)},toggle:function(e){if(u.isOpen){u.current.fitToView=n.type(e)==="boolean"?e:!u.current.fitToView;if(l){u.wrap.removeAttr("style").addClass("fancybox-tmp");u.trigger("onUpdate")}u.update()}},hideLoading:function(){o.unbind(".loading");n("#fancybox-loading").remove()},showLoading:function(){var e,t;u.hideLoading();e=n('<div id="fancybox-loading"><div></div></div>').click(u.cancel).appendTo("body");o.bind("keydown.loading",function(e){if((e.which||e.keyCode)===27){e.preventDefault();u.cancel()}});if(!u.defaults.fixed){t=u.getViewport();e.css({position:"absolute",top:t.h*.5+t.y,left:t.w*.5+t.x})}},getViewport:function(){var t=u.current&&u.current.locked||false,n={x:s.scrollLeft(),y:s.scrollTop()};if(t){n.w=t[0].clientWidth;n.h=t[0].clientHeight}else{n.w=l&&e.innerWidth?e.innerWidth:s.width();n.h=l&&e.innerHeight?e.innerHeight:s.height()}return n},unbindEvents:function(){if(u.wrap&&c(u.wrap)){u.wrap.unbind(".fb")}o.unbind(".fb");s.unbind(".fb")},bindEvents:function(){var e=u.current,t;if(!e){return}s.bind("orientationchange.fb"+(l?"":" resize.fb")+(e.autoCenter&&!e.locked?" scroll.fb":""),u.update);t=e.keys;if(t){o.bind("keydown.fb",function(i){var s=i.which||i.keyCode,o=i.target||i.srcElement;if(s===27&&u.coming){return false}if(!i.ctrlKey&&!i.altKey&&!i.shiftKey&&!i.metaKey&&!(o&&(o.type||n(o).is("[contenteditable]")))){n.each(t,function(t,o){if(e.group.length>1&&o[s]!==r){u[t](o[s]);i.preventDefault();return false}if(n.inArray(s,o)>-1){u[t]();i.preventDefault();return false}})}})}if(n.fn.mousewheel&&e.mouseWheel){u.wrap.bind("mousewheel.fb",function(t,r,i,s){var o=t.target||null,a=n(o),f=false;while(a.length){if(f||a.is(".fancybox-skin")||a.is(".fancybox-wrap")){break}f=d(a[0]);a=n(a).parent()}if(r!==0&&!f){if(u.group.length>1&&!e.canShrink){if(s>0||i>0){u.prev(s>0?"down":"left")}else if(s<0||i<0){u.next(s<0?"up":"right")}t.preventDefault()}}})}},trigger:function(e,t){var r,i=t||u.coming||u.current;if(!i){return}if(n.isFunction(i[e])){r=i[e].apply(i,Array.prototype.slice.call(arguments,1))}if(r===false){return false}if(i.helpers){n.each(i.helpers,function(t,r){if(r&&u.helpers[t]&&n.isFunction(u.helpers[t][e])){u.helpers[t][e](n.extend(true,{},u.helpers[t].defaults,r),i)}})}o.trigger(e)},isImage:function(e){return h(e)&&e.match(/(^data:image\/.*,)|(\.(jp(e|g|eg)|gif|png|bmp|webp|svg)((\?|#).*)?$)/i)},isSWF:function(e){return h(e)&&e.match(/\.(swf)((\?|#).*)?$/i)},_start:function(e){var t={},r,i,s,o,a;e=v(e);r=u.group[e]||null;if(!r){return false}t=n.extend(true,{},u.opts,r);o=t.margin;a=t.padding;if(n.type(o)==="number"){t.margin=[o,o,o,o]}if(n.type(a)==="number"){t.padding=[a,a,a,a]}if(t.modal){n.extend(true,t,{closeBtn:false,closeClick:false,nextClick:false,arrows:false,mouseWheel:false,keys:null,helpers:{overlay:{closeClick:false}}})}if(t.autoSize){t.autoWidth=t.autoHeight=true}if(t.width==="auto"){t.autoWidth=true}if(t.height==="auto"){t.autoHeight=true}t.group=u.group;t.index=e;u.coming=t;if(false===u.trigger("beforeLoad")){u.coming=null;return}s=t.type;i=t.href;if(!s){u.coming=null;if(u.current&&u.router&&u.router!=="jumpto"){u.current.index=e;return u[u.router](u.direction)}return false}u.isActive=true;if(s==="image"||s==="swf"){t.autoHeight=t.autoWidth=false;t.scrolling="visible"}if(s==="image"){t.aspectRatio=true}if(s==="iframe"&&l){t.scrolling="scroll"}t.wrap=n(t.tpl.wrap).addClass("fancybox-"+(l?"mobile":"desktop")+" fancybox-type-"+s+" fancybox-tmp "+t.wrapCSS).appendTo(t.parent||"body");n.extend(t,{skin:n(".fancybox-skin",t.wrap),outer:n(".fancybox-outer",t.wrap),inner:n(".fancybox-inner",t.wrap)});n.each(["Top","Right","Bottom","Left"],function(e,n){t.skin.css("padding"+n,m(t.padding[e]))});u.trigger("onReady");if(s==="inline"||s==="html"){if(!t.content||!t.content.length){return u._error("content")}}else if(!i){return u._error("href")}if(s==="image"){u._loadImage()}else if(s==="ajax"){u._loadAjax()}else if(s==="iframe"){u._loadIframe()}else{u._afterLoad()}},_error:function(e){n.extend(u.coming,{type:"html",autoWidth:true,autoHeight:true,minWidth:0,minHeight:0,scrolling:"no",hasError:e,content:u.coming.tpl.error});u._afterLoad()},_loadImage:function(){var e=u.imgPreload=new Image;e.onload=function(){this.onload=this.onerror=null;u.coming.width=this.width/u.opts.pixelRatio;u.coming.height=this.height/u.opts.pixelRatio;u._afterLoad()};e.onerror=function(){this.onload=this.onerror=null;u._error("image")};e.src=u.coming.href;if(e.complete!==true){u.showLoading()}},_loadAjax:function(){var e=u.coming;u.showLoading();u.ajaxLoad=n.ajax(n.extend({},e.ajax,{url:e.href,error:function(e,t){if(u.coming&&t!=="abort"){u._error("ajax",e)}else{u.hideLoading()}},success:function(t,n){if(n==="success"){e.content=t;u._afterLoad()}}}))},_loadIframe:function(){var e=u.coming,t=n(e.tpl.iframe.replace(/\{rnd\}/g,(new Date).getTime())).attr("scrolling",l?"auto":e.iframe.scrolling).attr("src",e.href);n(e.wrap).bind("onReset",function(){try{n(this).find("iframe").hide().attr("src","//about:blank").end().empty()}catch(e){}});if(e.iframe.preload){u.showLoading();t.one("load",function(){n(this).data("ready",1);if(!l){n(this).bind("load.fb",u.update)}n(this).parents(".fancybox-wrap").width("100%").removeClass("fancybox-tmp").show();u._afterLoad()})}e.content=t.appendTo(e.inner);if(!e.iframe.preload){u._afterLoad()}},_preloadImages:function(){var e=u.group,t=u.current,n=e.length,r=t.preload?Math.min(t.preload,n-1):0,i,s;for(s=1;s<=r;s+=1){i=e[(t.index+s)%n];if(i.type==="image"&&i.href){(new Image).src=i.href}}},_afterLoad:function(){var e=u.coming,t=u.current,r="fancybox-placeholder",i,s,o,a,f,l;u.hideLoading();if(!e||u.isActive===false){return}if(false===u.trigger("afterLoad",e,t)){e.wrap.stop(true).trigger("onReset").remove();u.coming=null;return}if(t){u.trigger("beforeChange",t);t.wrap.stop(true).removeClass("fancybox-opened").find(".fancybox-item, .fancybox-nav").remove()}u.unbindEvents();i=e;s=e.content;o=e.type;a=e.scrolling;n.extend(u,{wrap:i.wrap,skin:i.skin,outer:i.outer,inner:i.inner,current:i,previous:t});f=i.href;switch(o){case"inline":case"ajax":case"html":if(i.selector){s=n("<div>").html(s).find(i.selector)}else if(c(s)){if(!s.data(r)){s.data(r,n('<div class="'+r+'"></div>').insertAfter(s).hide())}s=s.show().detach();i.wrap.bind("onReset",function(){if(n(this).find(s).length){s.hide().replaceAll(s.data(r)).data(r,false)}})}break;case"image":s=i.tpl.image.replace("{href}",f);break;case"swf":s='<object id="fancybox-swf" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="100%" height="100%"><param name="movie" value="'+f+'"></param>';l="";n.each(i.swf,function(e,t){s+='<param name="'+e+'" value="'+t+'"></param>';l+=" "+e+'="'+t+'"'});s+='<embed src="'+f+'" type="application/x-shockwave-flash" width="100%" height="100%"'+l+"></embed></object>";break}if(!(c(s)&&s.parent().is(i.inner))){i.inner.append(s)}u.trigger("beforeShow");i.inner.css("overflow",a==="yes"?"scroll":a==="no"?"hidden":a);u._setDimension();u.reposition();u.isOpen=false;u.coming=null;u.bindEvents();if(!u.isOpened){n(".fancybox-wrap").not(i.wrap).stop(true).trigger("onReset").remove()}else if(t.prevMethod){u.transitions[t.prevMethod]()}u.transitions[u.isOpened?i.nextMethod:i.openMethod]();u._preloadImages()},_setDimension:function(){var e=u.getViewport(),t=0,r=false,i=false,s=u.wrap,o=u.skin,a=u.inner,f=u.current,l=f.width,c=f.height,h=f.minWidth,d=f.minHeight,g=f.maxWidth,y=f.maxHeight,b=f.scrolling,w=f.scrollOutside?f.scrollbarWidth:0,E=f.margin,S=v(E[1]+E[3]),x=v(E[0]+E[2]),T,N,C,k,L,A,O,M,_,D,P,H,B,j,I;s.add(o).add(a).width("auto").height("auto").removeClass("fancybox-tmp");T=v(o.outerWidth(true)-o.width());N=v(o.outerHeight(true)-o.height());C=S+T;k=x+N;L=p(l)?(e.w-C)*v(l)/100:l;A=p(c)?(e.h-k)*v(c)/100:c;if(f.type==="iframe"){j=f.content;if(f.autoHeight&&j.data("ready")===1){try{if(j[0].contentWindow.document.location){a.width(L).height(9999);I=j.contents().find("body");if(w){I.css("overflow-x","hidden")}A=I.outerHeight(true)}}catch(q){}}}else if(f.autoWidth||f.autoHeight){a.addClass("fancybox-tmp");if(!f.autoWidth){a.width(L)}if(!f.autoHeight){a.height(A)}if(f.autoWidth){L=a.width()}if(f.autoHeight){A=a.height()}a.removeClass("fancybox-tmp")}l=v(L);c=v(A);_=L/A;h=v(p(h)?v(h,"w")-C:h);g=v(p(g)?v(g,"w")-C:g);d=v(p(d)?v(d,"h")-k:d);y=v(p(y)?v(y,"h")-k:y);O=g;M=y;if(f.fitToView){g=Math.min(e.w-C,g);y=Math.min(e.h-k,y)}H=e.w-S;B=e.h-x;if(f.aspectRatio){if(l>g){l=g;c=v(l/_)}if(c>y){c=y;l=v(c*_)}if(l<h){l=h;c=v(l/_)}if(c<d){c=d;l=v(c*_)}}else{l=Math.max(h,Math.min(l,g));if(f.autoHeight&&f.type!=="iframe"){a.width(l);c=a.height()}c=Math.max(d,Math.min(c,y))}if(f.fitToView){a.width(l).height(c);s.width(l+T);D=s.width();P=s.height();if(f.aspectRatio){while((D>H||P>B)&&l>h&&c>d){if(t++>19){break}c=Math.max(d,Math.min(y,c-10));l=v(c*_);if(l<h){l=h;c=v(l/_)}if(l>g){l=g;c=v(l/_)}a.width(l).height(c);s.width(l+T);D=s.width();P=s.height()}}else{l=Math.max(h,Math.min(l,l-(D-H)));c=Math.max(d,Math.min(c,c-(P-B)))}}if(w&&b==="auto"&&c<A&&l+T+w<H){l+=w}a.width(l).height(c);s.width(l+T);D=s.width();P=s.height();r=(D>H||P>B)&&l>h&&c>d;i=f.aspectRatio?l<O&&c<M&&l<L&&c<A:(l<O||c<M)&&(l<L||c<A);n.extend(f,{dim:{width:m(D),height:m(P)},origWidth:L,origHeight:A,canShrink:r,canExpand:i,wPadding:T,hPadding:N,wrapSpace:P-o.outerHeight(true),skinSpace:o.height()-c});if(!j&&f.autoHeight&&c>d&&c<y&&!i){a.height("auto")}},_getPosition:function(e){var t=u.current,n=u.getViewport(),r=t.margin,i=u.wrap.width()+r[1]+r[3],s=u.wrap.height()+r[0]+r[2],o={position:"absolute",top:r[0],left:r[3]};if(t.autoCenter&&t.fixed&&!e&&s<=n.h&&i<=n.w){o.position="fixed"}else if(!t.locked){o.top+=n.y;o.left+=n.x}o.top=m(Math.max(o.top,o.top+(n.h-s)*t.topRatio));o.left=m(Math.max(o.left,o.left+(n.w-i)*t.leftRatio));return o},_afterZoomIn:function(){var e=u.current;if(!e){return}u.isOpen=u.isOpened=true;u.wrap.css("overflow","visible").addClass("fancybox-opened");u.update();if(e.closeClick||e.nextClick&&u.group.length>1){u.inner.css("cursor","pointer").bind("click.fb",function(t){if(!n(t.target).is("a")&&!n(t.target).parent().is("a")){t.preventDefault();u[e.closeClick?"close":"next"]()}})}if(e.closeBtn){n(e.tpl.closeBtn).appendTo(u.skin).bind("click.fb",function(e){e.preventDefault();u.close()})}if(e.arrows&&u.group.length>1){if(e.loop||e.index>0){n(e.tpl.prev).appendTo(u.outer).bind("click.fb",u.prev)}if(e.loop||e.index<u.group.length-1){n(e.tpl.next).appendTo(u.outer).bind("click.fb",u.next)}}u.trigger("afterShow");if(!e.loop&&e.index===e.group.length-1){u.play(false)}else if(u.opts.autoPlay&&!u.player.isActive){u.opts.autoPlay=false;u.play()}},_afterZoomOut:function(e){e=e||u.current;n(".fancybox-wrap").trigger("onReset").remove();n.extend(u,{group:{},opts:{},router:false,current:null,isActive:false,isOpened:false,isOpen:false,isClosing:false,wrap:null,skin:null,outer:null,inner:null});u.trigger("afterClose",e)}});u.transitions={getOrigPosition:function(){var e=u.current,t=e.element,n=e.orig,r={},i=50,s=50,o=e.hPadding,a=e.wPadding,f=u.getViewport();if(!n&&e.isDom&&t.is(":visible")){n=t.find("img:first");if(!n.length){n=t}}if(c(n)){r=n.offset();if(n.is("img")){i=n.outerWidth();s=n.outerHeight()}}else{r.top=f.y+(f.h-s)*e.topRatio;r.left=f.x+(f.w-i)*e.leftRatio}if(u.wrap.css("position")==="fixed"||e.locked){r.top-=f.y;r.left-=f.x}r={top:m(r.top-o*e.topRatio),left:m(r.left-a*e.leftRatio),width:m(i+a),height:m(s+o)};return r},step:function(e,t){var n,r,i,s=t.prop,o=u.current,a=o.wrapSpace,f=o.skinSpace;if(s==="width"||s==="height"){n=t.end===t.start?1:(e-t.start)/(t.end-t.start);if(u.isClosing){n=1-n}r=s==="width"?o.wPadding:o.hPadding;i=e-r;u.skin[s](v(s==="width"?i:i-a*n));u.inner[s](v(s==="width"?i:i-a*n-f*n))}},zoomIn:function(){var e=u.current,t=e.pos,r=e.openEffect,i=r==="elastic",s=n.extend({opacity:1},t);delete s.position;if(i){t=this.getOrigPosition();if(e.openOpacity){t.opacity=.1}}else if(r==="fade"){t.opacity=.1}u.wrap.css(t).animate(s,{duration:r==="none"?0:e.openSpeed,easing:e.openEasing,step:i?this.step:null,complete:u._afterZoomIn})},zoomOut:function(){var e=u.current,t=e.closeEffect,n=t==="elastic",r={opacity:.1};if(n){r=this.getOrigPosition();if(e.closeOpacity){r.opacity=.1}}u.wrap.animate(r,{duration:t==="none"?0:e.closeSpeed,easing:e.closeEasing,step:n?this.step:null,complete:u._afterZoomOut})},changeIn:function(){var e=u.current,t=e.nextEffect,n=e.pos,r={opacity:1},i=u.direction,s=200,o;n.opacity=.1;if(t==="elastic"){o=i==="down"||i==="up"?"top":"left";if(i==="down"||i==="right"){n[o]=m(v(n[o])-s);r[o]="+="+s+"px"}else{n[o]=m(v(n[o])+s);r[o]="-="+s+"px"}}if(t==="none"){u._afterZoomIn()}else{u.wrap.css(n).animate(r,{duration:e.nextSpeed,easing:e.nextEasing,complete:u._afterZoomIn})}},changeOut:function(){var e=u.previous,t=e.prevEffect,r={opacity:.1},i=u.direction,s=200;if(t==="elastic"){r[i==="down"||i==="up"?"top":"left"]=(i==="up"||i==="left"?"-":"+")+"="+s+"px"}e.wrap.animate(r,{duration:t==="none"?0:e.prevSpeed,easing:e.prevEasing,complete:function(){n(this).trigger("onReset").remove()}})}};u.helpers.overlay={defaults:{closeClick:true,speedOut:200,showEarly:true,css:{},locked:!l,fixed:true},overlay:null,fixed:false,el:n("html"),create:function(e){e=n.extend({},this.defaults,e);if(this.overlay){this.close()}this.overlay=n('<div class="fancybox-overlay"></div>').appendTo(u.coming?u.coming.parent:e.parent);this.fixed=false;if(e.fixed&&u.defaults.fixed){this.overlay.addClass("fancybox-overlay-fixed");this.fixed=true}},open:function(e){var t=this;e=n.extend({},this.defaults,e);if(this.overlay){this.overlay.unbind(".overlay").width("auto").height("auto")}else{this.create(e)}if(!this.fixed){s.bind("resize.overlay",n.proxy(this.update,this));this.update()}if(e.closeClick){this.overlay.bind("click.overlay",function(e){if(n(e.target).hasClass("fancybox-overlay")){if(u.isActive){u.close()}else{t.close()}return false}})}this.overlay.css(e.css).show()},close:function(){var e,t;s.unbind("resize.overlay");if(this.el.hasClass("fancybox-lock")){n(".fancybox-margin").removeClass("fancybox-margin");e=s.scrollTop();t=s.scrollLeft();this.el.removeClass("fancybox-lock");s.scrollTop(e).scrollLeft(t)}n(".fancybox-overlay").remove().hide();n.extend(this,{overlay:null,fixed:false})},update:function(){var e="100%",n;this.overlay.width(e).height("100%");if(a){n=Math.max(t.documentElement.offsetWidth,t.body.offsetWidth);if(o.width()>n){e=o.width()}}else if(o.width()>s.width()){e=o.width()}this.overlay.width(e).height(o.height())},onReady:function(e,t){var r=this.overlay;n(".fancybox-overlay").stop(true,true);if(!r){this.create(e)}if(e.locked&&this.fixed&&t.fixed){if(!r){this.margin=o.height()>s.height()?n("html").css("margin-right").replace("px",""):false}t.locked=this.overlay.append(t.wrap);t.fixed=false}if(e.showEarly===true){this.beforeShow.apply(this,arguments)}},beforeShow:function(e,t){var r,i;if(t.locked){if(this.margin!==false){n("*").filter(function(){return n(this).css("position")==="fixed"&&!n(this).hasClass("fancybox-overlay")&&!n(this).hasClass("fancybox-wrap")}).addClass("fancybox-margin");this.el.addClass("fancybox-margin")}r=s.scrollTop();i=s.scrollLeft();this.el.addClass("fancybox-lock");s.scrollTop(r).scrollLeft(i)}this.open(e)},onUpdate:function(){if(!this.fixed){this.update()}},afterClose:function(e){if(this.overlay&&!u.coming){this.overlay.fadeOut(e.speedOut,n.proxy(this.close,this))}}};u.helpers.title={defaults:{type:"float",position:"bottom"},beforeShow:function(e){var t=u.current,r=t.title,i=e.type,s,o;if(n.isFunction(r)){r=r.call(t.element,t)}if(!h(r)||n.trim(r)===""){return}s=n('<div class="fancybox-title fancybox-title-'+i+'-wrap">'+r+"</div>");switch(i){case"inside":o=u.skin;break;case"outside":o=u.wrap;break;case"over":o=u.inner;break;default:o=u.skin;s.appendTo("body");if(a){s.width(s.width())}s.wrapInner('<span class="child"></span>');u.current.margin[2]+=Math.abs(v(s.css("margin-bottom")));break}s[e.position==="top"?"prependTo":"appendTo"](o)}};n.fn.fancybox=function(e){var t,r=n(this),i=this.selector||"",s=function(s){var o=n(this).blur(),a=t,f,l;if(!(s.ctrlKey||s.altKey||s.shiftKey||s.metaKey)&&!o.is(".fancybox-wrap")){f=e.groupAttr||"data-fancybox-group";l=o.attr(f);if(!l){f="rel";l=o.get(0)[f]}if(l&&l!==""&&l!=="nofollow"){o=i.length?n(i):r;o=o.filter("["+f+'="'+l+'"]');a=o.index(this)}e.index=a;if(u.open(o,e)!==false){s.preventDefault()}}};e=e||{};t=e.index||0;if(!i||e.live===false){r.unbind("click.fb-start").bind("click.fb-start",s)}else{o.undelegate(i,"click.fb-start").delegate(i+":not('.fancybox-item, .fancybox-nav')","click.fb-start",s)}this.filter("[data-fancybox-start=1]").trigger("click");return this};o.ready(function(){var t,s;if(n.scrollbarWidth===r){n.scrollbarWidth=function(){var e=n('<div style="width:50px;height:50px;overflow:auto"><div/></div>').appendTo("body"),t=e.children(),r=t.innerWidth()-t.height(99).innerWidth();e.remove();return r}}if(n.support.fixedPosition===r){n.support.fixedPosition=function(){var e=n('<div style="position:fixed;top:20px;"></div>').appendTo("body"),t=e[0].offsetTop===20||e[0].offsetTop===15;e.remove();return t}()}n.extend(u.defaults,{scrollbarWidth:n.scrollbarWidth(),fixed:n.support.fixedPosition,parent:n("body")});t=n(e).width();i.addClass("fancybox-lock-test");s=n(e).width();i.removeClass("fancybox-lock-test");n("<style type='text/css'>.fancybox-margin{margin-right:"+(s-t)+"px;}</style>").appendTo("head")})})(window,document,jQuery);

/*! Copyright (c) 2011 Brandon Aaron (http://brandonaaron.net)
 * Licensed under the MIT License (LICENSE.txt).
 *
 * Thanks to: http://adomas.org/javascript-mouse-wheel/ for some pointers.
 * Thanks to: Mathias Bank(http://www.mathias-bank.de) for a scope bug fix.
 * Thanks to: Seamus Leahy for adding deltaX and deltaY
 *
 * Version: 3.0.6
 * 
 * Requires: 1.2.2+
 */
(function(a){function d(b){var c=b||window.event,d=[].slice.call(arguments,1),e=0,f=!0,g=0,h=0;return b=a.event.fix(c),b.type="mousewheel",c.wheelDelta&&(e=c.wheelDelta/120),c.detail&&(e=-c.detail/3),h=e,c.axis!==undefined&&c.axis===c.HORIZONTAL_AXIS&&(h=0,g=-1*e),c.wheelDeltaY!==undefined&&(h=c.wheelDeltaY/120),c.wheelDeltaX!==undefined&&(g=-1*c.wheelDeltaX/120),d.unshift(b,e,g,h),(a.event.dispatch||a.event.handle).apply(this,d)}var b=["DOMMouseScroll","mousewheel"];if(a.event.fixHooks)for(var c=b.length;c;)a.event.fixHooks[b[--c]]=a.event.mouseHooks;a.event.special.mousewheel={setup:function(){if(this.addEventListener)for(var a=b.length;a;)this.addEventListener(b[--a],d,!1);else this.onmousewheel=d},teardown:function(){if(this.removeEventListener)for(var a=b.length;a;)this.removeEventListener(b[--a],d,!1);else this.onmousewheel=null}},a.fn.extend({mousewheel:function(a){return a?this.bind("mousewheel",a):this.trigger("mousewheel")},unmousewheel:function(a){return this.unbind("mousewheel",a)}})})(jQuery)

/*== MCOSTUME SCROLL-BAR ==*/
"use strict";(function(e){if(typeof define==="function"&&define.amd){define(["jquery"],e)}else{e(jQuery)}})(function(e){var t={wheelSpeed:10,wheelPropagation:false,minScrollbarLength:null,useBothWheelAxes:false,useKeyboard:true,suppressScrollX:false,suppressScrollY:false,scrollXMarginOffset:0,scrollYMarginOffset:0};var n=function(){var e=0;return function(){var t=e;e+=1;return".perfect-scrollbar-"+t}}();e.fn.perfectScrollbar=function(r,i){return this.each(function(){var s=e.extend(true,{},t),o=e(this);if(typeof r==="object"){e.extend(true,s,r)}else{i=r}if(i==="update"){if(o.data("perfect-scrollbar-update")){o.data("perfect-scrollbar-update")()}return o}else if(i==="destroy"){if(o.data("perfect-scrollbar-destroy")){o.data("perfect-scrollbar-destroy")()}return o}if(o.data("perfect-scrollbar")){return o.data("perfect-scrollbar")}o.addClass("ps-container");var u=e("<div class='ps-scrollbar-x-rail'></div>").appendTo(o),a=e("<div class='ps-scrollbar-y-rail'></div>").appendTo(o),f=e("<div class='ps-scrollbar-x'></div>").appendTo(u),l=e("<div class='ps-scrollbar-y'></div>").appendTo(a),c,h,p,d,v,m,g,y,b=parseInt(u.css("bottom"),10),w,E,S=parseInt(a.css("right"),10),x=n();var T=function(e,t){var n=e+t,r=d-w;if(n<0){E=0}else if(n>r){E=r}else{E=n}var i=parseInt(E*(m-d)/(d-w),10);o.scrollTop(i);u.css({bottom:b-i})};var N=function(e,t){var n=e+t,r=p-g;if(n<0){y=0}else if(n>r){y=r}else{y=n}var i=parseInt(y*(v-p)/(p-g),10);o.scrollLeft(i);a.css({right:S-i})};var C=function(e){if(s.minScrollbarLength){e=Math.max(e,s.minScrollbarLength)}return e};var k=function(){u.css({left:o.scrollLeft(),bottom:b-o.scrollTop(),width:p,display:c?"inherit":"none"});a.css({top:o.scrollTop(),right:S-o.scrollLeft(),height:d,display:h?"inherit":"none"});f.css({left:y,width:g});l.css({top:E,height:w})};var L=function(){p=o.width();d=o.height();v=o.prop("scrollWidth");m=o.prop("scrollHeight");if(!s.suppressScrollX&&p+s.scrollXMarginOffset<v){c=true;g=C(parseInt(p*p/v,10));y=parseInt(o.scrollLeft()*(p-g)/(v-p),10)}else{c=false;g=0;y=0;o.scrollLeft(0)}if(!s.suppressScrollY&&d+s.scrollYMarginOffset<m){h=true;w=C(parseInt(d*d/m,10));E=parseInt(o.scrollTop()*(d-w)/(m-d),10)}else{h=false;w=0;E=0;o.scrollTop(0)}if(E>=d-w){E=d-w}if(y>=p-g){y=p-g}k()};var A=function(){var t,n;f.bind("mousedown"+x,function(e){n=e.pageX;t=f.position().left;u.addClass("in-scrolling");e.stopPropagation();e.preventDefault()});e(document).bind("mousemove"+x,function(e){if(u.hasClass("in-scrolling")){N(t,e.pageX-n);e.stopPropagation();e.preventDefault()}});e(document).bind("mouseup"+x,function(e){if(u.hasClass("in-scrolling")){u.removeClass("in-scrolling")}});t=n=null};var O=function(){var t,n;l.bind("mousedown"+x,function(e){n=e.pageY;t=l.position().top;a.addClass("in-scrolling");e.stopPropagation();e.preventDefault()});e(document).bind("mousemove"+x,function(e){if(a.hasClass("in-scrolling")){T(t,e.pageY-n);e.stopPropagation();e.preventDefault()}});e(document).bind("mouseup"+x,function(e){if(a.hasClass("in-scrolling")){a.removeClass("in-scrolling")}});t=n=null};var M=function(e,t){var n=o.scrollTop();if(e===0){if(!h){return false}if(n===0&&t>0||n>=m-d&&t<0){return!s.wheelPropagation}}var r=o.scrollLeft();if(t===0){if(!c){return false}if(r===0&&e<0||r>=v-p&&e>0){return!s.wheelPropagation}}return true};var _=function(){var e=false;o.bind("mousewheel"+x,function(t,n,r,i){if(!s.useBothWheelAxes){o.scrollTop(o.scrollTop()-i*s.wheelSpeed);o.scrollLeft(o.scrollLeft()+r*s.wheelSpeed)}else if(h&&!c){if(i){o.scrollTop(o.scrollTop()-i*s.wheelSpeed)}else{o.scrollTop(o.scrollTop()+r*s.wheelSpeed)}}else if(c&&!h){if(r){o.scrollLeft(o.scrollLeft()+r*s.wheelSpeed)}else{o.scrollLeft(o.scrollLeft()-i*s.wheelSpeed)}}L();e=M(r,i);if(e){t.preventDefault()}});o.bind("MozMousePixelScroll"+x,function(t){if(e){t.preventDefault()}})};var D=function(){var t=false;o.bind("mouseenter"+x,function(e){t=true});o.bind("mouseleave"+x,function(e){t=false});var n=false;e(document).bind("keydown"+x,function(e){if(!t){return}var r=0,i=0;switch(e.which){case 37:r=-3;break;case 38:i=3;break;case 39:r=3;break;case 40:i=-3;break;case 33:i=9;break;case 32:case 34:i=-9;break;case 35:i=-d;break;case 36:i=d;break;default:return}o.scrollTop(o.scrollTop()-i*s.wheelSpeed);o.scrollLeft(o.scrollLeft()+r*s.wheelSpeed);n=M(r,i);if(n){e.preventDefault()}})};var P=function(){var e=function(e){e.stopPropagation()};l.bind("click"+x,e);a.bind("click"+x,function(e){var t=parseInt(w/2,10),n=e.pageY-a.offset().top-t,r=d-w,i=n/r;if(i<0){i=0}else if(i>1){i=1}o.scrollTop((m-d)*i)});f.bind("click"+x,e);u.bind("click"+x,function(e){var t=parseInt(g/2,10),n=e.pageX-u.offset().left-t,r=p-g,i=n/r;if(i<0){i=0}else if(i>1){i=1}o.scrollLeft((v-p)*i)})};var H=function(){var t=function(e,t){o.scrollTop(o.scrollTop()-t);o.scrollLeft(o.scrollLeft()-e);L()};var n={},r=0,i={},s=null,u=false;e(window).bind("touchstart"+x,function(e){u=true});e(window).bind("touchend"+x,function(e){u=false});o.bind("touchstart"+x,function(e){var t=e.originalEvent.targetTouches[0];n.pageX=t.pageX;n.pageY=t.pageY;r=(new Date).getTime();if(s!==null){clearInterval(s)}e.stopPropagation()});o.bind("touchmove"+x,function(e){if(!u&&e.originalEvent.targetTouches.length===1){var s=e.originalEvent.targetTouches[0];var o={};o.pageX=s.pageX;o.pageY=s.pageY;var a=o.pageX-n.pageX,f=o.pageY-n.pageY;t(a,f);n=o;var l=(new Date).getTime();i.x=a/(l-r);i.y=f/(l-r);r=l;e.preventDefault()}});o.bind("touchend"+x,function(e){clearInterval(s);s=setInterval(function(){if(Math.abs(i.x)<.01&&Math.abs(i.y)<.01){clearInterval(s);return}t(i.x*30,i.y*30);i.x*=.8;i.y*=.8},10)})};var B=function(){o.bind("scroll"+x,function(e){L()})};var j=function(){o.unbind(x);e(window).unbind(x);e(document).unbind(x);o.data("perfect-scrollbar",null);o.data("perfect-scrollbar-update",null);o.data("perfect-scrollbar-destroy",null);f.remove();l.remove();u.remove();a.remove();f=l=p=d=v=m=g=y=b=w=E=S=null};var F=function(t){o.addClass("ie").addClass("ie"+t);var n=function(){var t=function(){e(this).addClass("hover")};var n=function(){e(this).removeClass("hover")};o.bind("mouseenter"+x,t).bind("mouseleave"+x,n);u.bind("mouseenter"+x,t).bind("mouseleave"+x,n);a.bind("mouseenter"+x,t).bind("mouseleave"+x,n);f.bind("mouseenter"+x,t).bind("mouseleave"+x,n);l.bind("mouseenter"+x,t).bind("mouseleave"+x,n)};var r=function(){k=function(){f.css({left:y+o.scrollLeft(),bottom:b,width:g});l.css({top:E+o.scrollTop(),right:S,height:w});f.hide().show();l.hide().show()}};if(t===6){n();r()}};var I="ontouchstart"in window||window.DocumentTouch&&document instanceof window.DocumentTouch;var q=function(){var e=navigator.userAgent.toLowerCase().match(/(msie) ([\w.]+)/);if(e&&e[1]==="msie"){F(parseInt(e[2],10))}L();B();A();O();P();if(I){H()}if(o.mousewheel){_()}if(s.useKeyboard){D()}o.data("perfect-scrollbar",o);o.data("perfect-scrollbar-update",L);o.data("perfect-scrollbar-destroy",j)};q();return o})}});



function iOSVersion(){var e=window.navigator.userAgent,t=e.indexOf("OS ");if((e.indexOf("iPhone")>-1||e.indexOf("iPad")>-1)&&t>-1){return window.Number(e.substr(t+3,3).replace("_","."))}return 0}(function(e){var t={init:function(t){function r(){return!!("ontouchstart"in window)?1:0}var n={set_width:false,set_height:false,horizontalScroll:false,scrollInertia:550,scrollEasing:"easeOutCirc",mouseWheel:"pixels",mouseWheelPixels:60,autoDraggerLength:true,scrollButtons:{enable:false,scrollType:"continuous",scrollSpeed:20,scrollAmount:40},advanced:{updateOnBrowserResize:true,updateOnContentResize:false,autoExpandHorizontalScroll:false,autoScrollOnFocus:true},callbacks:{onScrollStart:function(){},onScroll:function(){},onTotalScroll:function(){},onTotalScrollBack:function(){},onTotalScrollOffset:0,whileScrolling:false,whileScrollingInterval:30}},t=e.extend(true,n,t);e(document).data("mCS-is-touch-device",false);if(r()){e(document).data("mCS-is-touch-device",true)}return this.each(function(){var n=e(this);if(t.set_width){n.css("width",t.set_width)}if(t.set_height){n.css("height",t.set_height)}if(!e(document).data("mCustomScrollbar-index")){e(document).data("mCustomScrollbar-index","1")}else{var r=parseInt(e(document).data("mCustomScrollbar-index"));e(document).data("mCustomScrollbar-index",r+1)}n.wrapInner("<div class='mCustomScrollBox' id='mCSB_"+e(document).data("mCustomScrollbar-index")+"' style='position:relative; height:100%; overflow:hidden; max-width:100%;' />").addClass("mCustomScrollbar _mCS_"+e(document).data("mCustomScrollbar-index"));var i=n.children(".mCustomScrollBox");if(t.horizontalScroll){i.addClass("mCSB_horizontal").wrapInner("<div class='mCSB_h_wrapper' style='position:relative; left:0; width:999999px;' />");var s=i.children(".mCSB_h_wrapper");s.wrapInner("<div class='mCSB_container' style='position:absolute; left:0;' />").children(".mCSB_container").css({width:s.children().outerWidth(),position:"relative"}).unwrap()}else{i.wrapInner("<div class='mCSB_container' style='position:relative; top:0;' />")}var o=i.children(".mCSB_container");if(e(document).data("mCS-is-touch-device")){o.addClass("mCS_touch")}o.after("<div class='mCSB_scrollTools' style='position:absolute;'><div class='mCSB_draggerContainer' style='position:relative;'><div class='mCSB_dragger' style='position:absolute;'><div class='mCSB_dragger_bar' style='position:relative;'></div></div><div class='mCSB_draggerRail'></div></div></div>");var u=i.children(".mCSB_scrollTools"),a=u.children(".mCSB_draggerContainer"),f=a.children(".mCSB_dragger");if(t.horizontalScroll){f.data("minDraggerWidth",f.width())}else{f.data("minDraggerHeight",f.height())}if(t.scrollButtons.enable){if(t.horizontalScroll){u.prepend("<a class='mCSB_buttonLeft' style='display:block; position:relative;'></a>").append("<a class='mCSB_buttonRight' style='display:block; position:relative;'></a>")}else{u.prepend("<a class='mCSB_buttonUp' style='display:block; position:relative;'></a>").append("<a class='mCSB_buttonDown' style='display:block; position:relative;'></a>")}}i.bind("scroll",function(){if(!n.is(".mCS_disabled")){i.scrollTop(0).scrollLeft(0)}});n.data({mCS_Init:true,horizontalScroll:t.horizontalScroll,scrollInertia:t.scrollInertia,scrollEasing:t.scrollEasing,mouseWheel:t.mouseWheel,mouseWheelPixels:t.mouseWheelPixels,autoDraggerLength:t.autoDraggerLength,scrollButtons_enable:t.scrollButtons.enable,scrollButtons_scrollType:t.scrollButtons.scrollType,scrollButtons_scrollSpeed:t.scrollButtons.scrollSpeed,scrollButtons_scrollAmount:t.scrollButtons.scrollAmount,autoExpandHorizontalScroll:t.advanced.autoExpandHorizontalScroll,autoScrollOnFocus:t.advanced.autoScrollOnFocus,onScrollStart_Callback:t.callbacks.onScrollStart,onScroll_Callback:t.callbacks.onScroll,onTotalScroll_Callback:t.callbacks.onTotalScroll,onTotalScrollBack_Callback:t.callbacks.onTotalScrollBack,onTotalScroll_Offset:t.callbacks.onTotalScrollOffset,whileScrolling_Callback:t.callbacks.whileScrolling,whileScrolling_Interval:t.callbacks.whileScrollingInterval,bindEvent_scrollbar_click:false,bindEvent_mousewheel:false,bindEvent_focusin:false,bindEvent_buttonsContinuous_y:false,bindEvent_buttonsContinuous_x:false,bindEvent_buttonsPixels_y:false,bindEvent_buttonsPixels_x:false,bindEvent_scrollbar_touch:false,bindEvent_content_touch:false,mCSB_buttonScrollRight:false,mCSB_buttonScrollLeft:false,mCSB_buttonScrollDown:false,mCSB_buttonScrollUp:false,whileScrolling:false}).mCustomScrollbar("update");if(t.horizontalScroll){if(n.css("max-width")!=="none"){if(!t.advanced.updateOnContentResize){t.advanced.updateOnContentResize=true}n.data({mCS_maxWidth:parseInt(n.css("max-width")),mCS_maxWidth_Interval:setInterval(function(){if(o.outerWidth()>n.data("mCS_maxWidth")){clearInterval(n.data("mCS_maxWidth_Interval"));n.mCustomScrollbar("update")}},150)})}}else{if(n.css("max-height")!=="none"){n.data({mCS_maxHeight:parseInt(n.css("max-height")),mCS_maxHeight_Interval:setInterval(function(){i.css("max-height",n.data("mCS_maxHeight"));if(o.outerHeight()>n.data("mCS_maxHeight")){clearInterval(n.data("mCS_maxHeight_Interval"));n.mCustomScrollbar("update")}},150)})}}if(t.advanced.updateOnBrowserResize){var l;e(window).resize(function(){if(l){clearTimeout(l)}l=setTimeout(function(){if(!n.is(".mCS_disabled")&&!n.is(".mCS_destroyed")){n.mCustomScrollbar("update")}},150)})}if(t.advanced.updateOnContentResize){var c;if(t.horizontalScroll){var h=o.outerWidth()}else{var h=o.outerHeight()}c=setInterval(function(){if(t.horizontalScroll){if(t.advanced.autoExpandHorizontalScroll){o.css({position:"absolute",width:"auto"}).wrap("<div class='mCSB_h_wrapper' style='position:relative; left:0; width:999999px;' />").css({width:o.outerWidth(),position:"relative"}).unwrap()}var e=o.outerWidth()}else{var e=o.outerHeight()}if(e!=h){n.mCustomScrollbar("update");h=e}},300)}})},update:function(){var t=e(this),n=t.children(".mCustomScrollBox"),r=n.children(".mCSB_container");r.removeClass("mCS_no_scrollbar");t.removeClass("mCS_disabled mCS_destroyed");n.scrollTop(0).scrollLeft(0);var i=n.children(".mCSB_scrollTools"),s=i.children(".mCSB_draggerContainer"),o=s.children(".mCSB_dragger");if(t.data("horizontalScroll")){var u=i.children(".mCSB_buttonLeft"),a=i.children(".mCSB_buttonRight"),f=n.width();if(t.data("autoExpandHorizontalScroll")){r.css({position:"absolute",width:"auto"}).wrap("<div class='mCSB_h_wrapper' style='position:relative; left:0; width:999999px;' />").css({width:r.outerWidth(),position:"relative"}).unwrap()}var l=r.outerWidth()}else{var c=i.children(".mCSB_buttonUp"),h=i.children(".mCSB_buttonDown"),p=n.height(),d=r.outerHeight()}if(d>p&&!t.data("horizontalScroll")){i.css("display","block");var v=s.height();if(t.data("autoDraggerLength")){var m=Math.round(p/d*v),g=o.data("minDraggerHeight");if(m<=g){o.css({height:g})}else if(m>=v-10){var y=v-10;o.css({height:y})}else{o.css({height:m})}o.children(".mCSB_dragger_bar").css({"line-height":o.height()+"px"})}var b=o.height(),w=(d-p)/(v-b);t.data("scrollAmount",w).mCustomScrollbar("scrolling",n,r,s,o,c,h,u,a);var E=Math.abs(Math.round(r.position().top));t.mCustomScrollbar("scrollTo",E,{callback:false})}else if(l>f&&t.data("horizontalScroll")){i.css("display","block");var S=s.width();if(t.data("autoDraggerLength")){var x=Math.round(f/l*S),T=o.data("minDraggerWidth");if(x<=T){o.css({width:T})}else if(x>=S-10){var N=S-10;o.css({width:N})}else{o.css({width:x})}}var C=o.width(),w=(l-f)/(S-C);t.data("scrollAmount",w).mCustomScrollbar("scrolling",n,r,s,o,c,h,u,a);var E=Math.abs(Math.round(r.position().left));t.mCustomScrollbar("scrollTo",E,{callback:false})}else{n.unbind("mousewheel focusin");if(t.data("horizontalScroll")){o.add(r).css("left",0)}else{o.add(r).css("top",0)}i.css("display","none");r.addClass("mCS_no_scrollbar");t.data({bindEvent_mousewheel:false,bindEvent_focusin:false})}},scrolling:function(t,n,r,i,s,o,u,a){var f=e(this);f.mCustomScrollbar("callbacks","whileScrolling");if(!i.hasClass("ui-draggable")){if(f.data("horizontalScroll")){var l="x"}else{var l="y"}i.draggable({axis:l,containment:"parent",drag:function(e,t){f.mCustomScrollbar("scroll");i.addClass("mCSB_dragger_onDrag")},stop:function(e,t){i.removeClass("mCSB_dragger_onDrag")}})}if(!f.data("bindEvent_scrollbar_click")){r.bind("click",function(e){if(f.data("horizontalScroll")){var t=e.pageX-r.offset().left;if(t<i.position().left||t>i.position().left+i.width()){var n=t;if(n>=r.width()-i.width()){n=r.width()-i.width()}i.css("left",n);f.mCustomScrollbar("scroll")}}else{var t=e.pageY-r.offset().top;if(t<i.position().top||t>i.position().top+i.height()){var n=t;if(n>=r.height()-i.height()){n=r.height()-i.height()}i.css("top",n);f.mCustomScrollbar("scroll")}}});f.data({bindEvent_scrollbar_click:true})}if(f.data("mouseWheel")){var c=f.data("mouseWheel");if(f.data("mouseWheel")==="auto"){c=8;var h=navigator.userAgent;if(h.indexOf("Mac")!=-1&&h.indexOf("Safari")!=-1&&h.indexOf("AppleWebKit")!=-1&&h.indexOf("Chrome")==-1){c=1}}if(!f.data("bindEvent_mousewheel")){t.bind("mousewheel",function(e,t){e.preventDefault();var s=Math.abs(t*c);if(f.data("horizontalScroll")){if(f.data("mouseWheel")==="pixels"){if(t<0){t=-1}else{t=1}var o=Math.abs(Math.round(n.position().left))-t*f.data("mouseWheelPixels");f.mCustomScrollbar("scrollTo",o)}else{var u=i.position().left-t*s;i.css("left",u);if(i.position().left<0){i.css("left",0)}var a=r.width(),l=i.width();if(i.position().left>a-l){i.css("left",a-l)}f.mCustomScrollbar("scroll")}}else{if(f.data("mouseWheel")==="pixels"){if(t<0){t=-1}else{t=1}var o=Math.abs(Math.round(n.position().top))-t*f.data("mouseWheelPixels");f.mCustomScrollbar("scrollTo",o)}else{var h=i.position().top-t*s;i.css("top",h);if(i.position().top<0){i.css("top",0)}var p=r.height(),d=i.height();if(i.position().top>p-d){i.css("top",p-d)}f.mCustomScrollbar("scroll")}}});f.data({bindEvent_mousewheel:true})}}if(f.data("scrollButtons_enable")){if(f.data("scrollButtons_scrollType")==="pixels"){var p;if(e.browser.msie&&parseInt(e.browser.version)<9){f.data("scrollInertia",0)}if(f.data("horizontalScroll")){a.add(u).unbind("mousedown touchstart onmsgesturestart mouseup mouseout touchend onmsgestureend",d,v);f.data({bindEvent_buttonsContinuous_x:false});if(!f.data("bindEvent_buttonsPixels_x")){a.bind("click",function(e){e.preventDefault();if(!n.is(":animated")){p=Math.abs(n.position().left)+f.data("scrollButtons_scrollAmount");f.mCustomScrollbar("scrollTo",p)}});u.bind("click",function(e){e.preventDefault();if(!n.is(":animated")){p=Math.abs(n.position().left)-f.data("scrollButtons_scrollAmount");if(n.position().left>=-f.data("scrollButtons_scrollAmount")){p="left"}f.mCustomScrollbar("scrollTo",p)}});f.data({bindEvent_buttonsPixels_x:true})}}else{o.add(s).unbind("mousedown touchstart onmsgesturestart mouseup mouseout touchend onmsgestureend",d,v);f.data({bindEvent_buttonsContinuous_y:false});if(!f.data("bindEvent_buttonsPixels_y")){o.bind("click",function(e){e.preventDefault();if(!n.is(":animated")){p=Math.abs(n.position().top)+f.data("scrollButtons_scrollAmount");f.mCustomScrollbar("scrollTo",p)}});s.bind("click",function(e){e.preventDefault();if(!n.is(":animated")){p=Math.abs(n.position().top)-f.data("scrollButtons_scrollAmount");if(n.position().top>=-f.data("scrollButtons_scrollAmount")){p="top"}f.mCustomScrollbar("scrollTo",p)}});f.data({bindEvent_buttonsPixels_y:true})}}}else{if(f.data("horizontalScroll")){a.add(u).unbind("click");f.data({bindEvent_buttonsPixels_x:false});if(!f.data("bindEvent_buttonsContinuous_x")){a.bind("mousedown touchstart onmsgesturestart",function(e){e.preventDefault();e.stopPropagation();f.data({mCSB_buttonScrollRight:setInterval(function(){var e=Math.round((Math.abs(Math.round(n.position().left))+f.data("scrollButtons_scrollSpeed"))/f.data("scrollAmount"));f.mCustomScrollbar("scrollTo",e,{moveDragger:true})},30)})});var d=function(e){e.preventDefault();e.stopPropagation();clearInterval(f.data("mCSB_buttonScrollRight"))};a.bind("mouseup touchend onmsgestureend mouseout",d);u.bind("mousedown touchstart onmsgesturestart",function(e){e.preventDefault();e.stopPropagation();f.data({mCSB_buttonScrollLeft:setInterval(function(){var e=Math.round((Math.abs(Math.round(n.position().left))-f.data("scrollButtons_scrollSpeed"))/f.data("scrollAmount"));f.mCustomScrollbar("scrollTo",e,{moveDragger:true})},30)})});var v=function(e){e.preventDefault();e.stopPropagation();clearInterval(f.data("mCSB_buttonScrollLeft"))};u.bind("mouseup touchend onmsgestureend mouseout",v);f.data({bindEvent_buttonsContinuous_x:true})}}else{o.add(s).unbind("click");f.data({bindEvent_buttonsPixels_y:false});if(!f.data("bindEvent_buttonsContinuous_y")){o.bind("mousedown touchstart onmsgesturestart",function(e){e.preventDefault();e.stopPropagation();f.data({mCSB_buttonScrollDown:setInterval(function(){var e=Math.round((Math.abs(Math.round(n.position().top))+f.data("scrollButtons_scrollSpeed"))/f.data("scrollAmount"));f.mCustomScrollbar("scrollTo",e,{moveDragger:true})},30)})});var m=function(e){e.preventDefault();e.stopPropagation();clearInterval(f.data("mCSB_buttonScrollDown"))};o.bind("mouseup touchend onmsgestureend mouseout",m);s.bind("mousedown touchstart onmsgesturestart",function(e){e.preventDefault();e.stopPropagation();f.data({mCSB_buttonScrollUp:setInterval(function(){var e=Math.round((Math.abs(Math.round(n.position().top))-f.data("scrollButtons_scrollSpeed"))/f.data("scrollAmount"));f.mCustomScrollbar("scrollTo",e,{moveDragger:true})},30)})});var g=function(e){e.preventDefault();e.stopPropagation();clearInterval(f.data("mCSB_buttonScrollUp"))};s.bind("mouseup touchend onmsgestureend mouseout",g);f.data({bindEvent_buttonsContinuous_y:true})}}}}if(f.data("autoScrollOnFocus")){if(!f.data("bindEvent_focusin")){t.bind("focusin",function(){t.scrollTop(0).scrollLeft(0);var s=e(document.activeElement);if(s.is("input,textarea,select,button,a[tabindex],area,object")){if(f.data("horizontalScroll")){var o=n.position().left,u=s.position().left,a=t.width(),l=s.outerWidth();if(o+u>=0&&o+u<=a-l){}else{var c=u/f.data("scrollAmount");if(c>=r.width()-i.width()){c=r.width()-i.width()}i.css("left",c);f.mCustomScrollbar("scroll")}}else{var h=n.position().top,p=s.position().top,d=t.height(),v=s.outerHeight();if(h+p>=0&&h+p<=d-v){}else{var c=p/f.data("scrollAmount");if(c>=r.height()-i.height()){c=r.height()-i.height()}i.css("top",c);f.mCustomScrollbar("scroll")}}}});f.data({bindEvent_focusin:true})}}if(e(document).data("mCS-is-touch-device")){if(!f.data("bindEvent_scrollbar_touch")){var y,b;i.bind("touchstart onmsgesturestart",function(t){t.preventDefault();t.stopPropagation();var n=t.originalEvent.touches[0]||t.originalEvent.changedTouches[0],r=e(this),i=r.offset(),s=n.pageX-i.left,o=n.pageY-i.top;if(s<r.width()&&s>0&&o<r.height()&&o>0){y=o;b=s}});i.bind("touchmove onmsgesturechange",function(t){t.preventDefault();t.stopPropagation();var n=t.originalEvent.touches[0]||t.originalEvent.changedTouches[0],r=e(this),s=r.offset(),o=n.pageX-s.left,u=n.pageY-s.top;if(f.data("horizontalScroll")){f.mCustomScrollbar("scrollTo",i.position().left-b+o,{moveDragger:true})}else{f.mCustomScrollbar("scrollTo",i.position().top-y+u,{moveDragger:true})}});f.data({bindEvent_scrollbar_touch:true})}if(!f.data("bindEvent_content_touch")){var w,E,S,x,T,N,C;n.bind("touchstart onmsgesturestart",function(t){w=t.originalEvent.touches[0]||t.originalEvent.changedTouches[0];E=e(this);S=E.offset();x=w.pageX-S.left;T=w.pageY-S.top;N=T;C=x});n.bind("touchmove onmsgesturechange",function(t){t.preventDefault();t.stopPropagation();w=t.originalEvent.touches[0]||t.originalEvent.changedTouches[0];E=e(this).parent();S=E.offset();x=w.pageX-S.left;T=w.pageY-S.top;if(f.data("horizontalScroll")){f.mCustomScrollbar("scrollTo",C-x)}else{f.mCustomScrollbar("scrollTo",N-T)}});f.data({bindEvent_content_touch:true})}}},scroll:function(t){var n=e(this),r=n.find(".mCSB_dragger"),i=n.find(".mCSB_container"),s=n.find(".mCustomScrollBox");if(n.data("horizontalScroll")){var o=r.position().left,u=-o*n.data("scrollAmount"),a=i.position().left,f=Math.round(a-u)}else{var l=r.position().top,c=-l*n.data("scrollAmount"),h=i.position().top,p=Math.round(h-c)}if(e.browser.webkit){var d=(window.outerWidth-8)/window.innerWidth,v=d<.98||d>1.02}if(n.data("scrollInertia")===0||v){if(!t){n.mCustomScrollbar("callbacks","onScrollStart")}if(n.data("horizontalScroll")){i.css("left",u)}else{i.css("top",c)}if(!t){if(n.data("whileScrolling")){n.data("whileScrolling_Callback").call()}n.mCustomScrollbar("callbacks","onScroll")}n.data({mCS_Init:false})}else{if(!t){n.mCustomScrollbar("callbacks","onScrollStart")}if(n.data("horizontalScroll")){i.stop().animate({left:"-="+f},n.data("scrollInertia"),n.data("scrollEasing"),function(){if(!t){n.mCustomScrollbar("callbacks","onScroll")}n.data({mCS_Init:false})})}else{i.stop().animate({top:"-="+p},n.data("scrollInertia"),n.data("scrollEasing"),function(){if(!t){n.mCustomScrollbar("callbacks","onScroll")}n.data({mCS_Init:false})})}}},scrollTo:function(t,n){var r={moveDragger:false,callback:true},n=e.extend(r,n),i=e(this),s,o=i.find(".mCustomScrollBox"),u=o.children(".mCSB_container"),a=i.find(".mCSB_draggerContainer"),f=a.children(".mCSB_dragger"),l;if(t||t===0){if(typeof t==="number"){if(n.moveDragger){s=t}else{l=t;s=Math.round(l/i.data("scrollAmount"))}}else if(typeof t==="string"){var c;if(t==="top"){c=0}else if(t==="bottom"&&!i.data("horizontalScroll")){c=u.outerHeight()-o.height()}else if(t==="left"){c=0}else if(t==="right"&&i.data("horizontalScroll")){c=u.outerWidth()-o.width()}else if(t==="first"){c=i.find(".mCSB_container").find(":first")}else if(t==="last"){c=i.find(".mCSB_container").find(":last")}else{c=i.find(t)}if(c.length===1){if(i.data("horizontalScroll")){l=c.position().left}else{l=c.position().top}s=Math.ceil(l/i.data("scrollAmount"))}else{s=c}}if(s<0){s=0}if(i.data("horizontalScroll")){if(s>=a.width()-f.width()){s=a.width()-f.width()}f.css("left",s)}else{if(s>=a.height()-f.height()){s=a.height()-f.height()}f.css("top",s)}if(n.callback){i.mCustomScrollbar("scroll",false)}else{i.mCustomScrollbar("scroll",true)}}},callbacks:function(t){var n=e(this),r=n.find(".mCustomScrollBox"),i=n.find(".mCSB_container");switch(t){case"onScrollStart":if(!i.is(":animated")){n.data("onScrollStart_Callback").call()}break;case"onScroll":if(n.data("horizontalScroll")){var s=Math.round(i.position().left);if(s<0&&s<=r.width()-i.outerWidth()+n.data("onTotalScroll_Offset")){n.data("onTotalScroll_Callback").call()}else if(s>=-n.data("onTotalScroll_Offset")){n.data("onTotalScrollBack_Callback").call()}else{n.data("onScroll_Callback").call()}}else{var o=Math.round(i.position().top);if(o<0&&o<=r.height()-i.outerHeight()+n.data("onTotalScroll_Offset")){n.data("onTotalScroll_Callback").call()}else if(o>=-n.data("onTotalScroll_Offset")){n.data("onTotalScrollBack_Callback").call()}else{n.data("onScroll_Callback").call()}}break;case"whileScrolling":if(n.data("whileScrolling_Callback")&&!n.data("whileScrolling")){n.data({whileScrolling:setInterval(function(){if(i.is(":animated")&&!n.data("mCS_Init")){n.data("whileScrolling_Callback").call()}},n.data("whileScrolling_Interval"))})}break}},disable:function(t){var n=e(this),r=n.children(".mCustomScrollBox"),i=r.children(".mCSB_container"),s=r.children(".mCSB_scrollTools"),o=s.find(".mCSB_dragger");r.unbind("mousewheel focusin");if(t){if(n.data("horizontalScroll")){o.add(i).css("left",0)}else{o.add(i).css("top",0)}}s.css("display","none");i.addClass("mCS_no_scrollbar");n.data({bindEvent_mousewheel:false,bindEvent_focusin:false}).addClass("mCS_disabled")},destroy:function(){var t=e(this),n=t.find(".mCSB_container").html();t.find(".mCustomScrollBox").remove();t.html(n).removeClass("mCustomScrollbar _mCS_"+e(document).data("mCustomScrollbar-index")).addClass("mCS_destroyed")}};e.fn.mCustomScrollbar=function(n){if(t[n]){return t[n].apply(this,Array.prototype.slice.call(arguments,1))}else if(typeof n==="object"||!n){return t.init.apply(this,arguments)}else{e.error("Method "+n+" does not exist")}}})(jQuery);var iOSVersion=iOSVersion();if(iOSVersion>=6){(function(e){function u(t,n,r){function a(){if(o){o.apply(e,arguments);if(!u){delete n[s];o=null}}}var s,o=r[0],u=t===i;r[0]=a;s=t.apply(e,r);n[s]={args:r,created:Date.now(),cb:o,id:s};return s}function a(t,n,r,s,o){function c(){if(u.cb){u.cb.apply(e,arguments);if(!a){delete r[s];u.cb=null}}}var u=r[s];if(!u){return}var a=t===i;n(u.id);if(!a){var f=u.args[1];var l=Date.now()-u.created;if(l<0){l=0}f-=l;if(f<0){f=0}u.args[1]=f}u.args[0]=c;u.created=Date.now();u.id=t.apply(e,u.args)}var t={};var n={};var r=e.setTimeout;var i=e.setInterval;var s=e.clearTimeout;var o=e.clearInterval;if(!e.addEventListener){return false}e.setTimeout=function(){return u(r,t,arguments)};e.setInterval=function(){return u(i,n,arguments)};e.clearTimeout=function(e){var n=t[e];if(n){delete t[e];s(n.id)}};e.clearInterval=function(e){var t=n[e];if(t){delete n[e];o(t.id)}};var f=e;while(f.location!=f.parent.location){f=f.parent}f.addEventListener("scroll",function(){var e;for(e in t){a(r,s,t,e)}for(e in n){a(i,o,n,e)}})})(window)}

//jquery Transform
/*
 *
 * jqTransform
 * by mathieu vilaplana mvilaplana@dfc-e.com
 * Designer ghyslain armand garmand@dfc-e.com
 *
 *
 * Version 1.0 25.09.08
 * Version 1.1 06.08.09
 * Add event click on Checkbox and Radio
 * Auto calculate the size of a select element
 * Can now, disabled the elements
 * Correct bug in ff if click on select (overflow=hidden)
 * No need any more preloading !!
 *
 ******************************************** */

(function ($) {
    var defaultOptions = {
        preloadImg: true
    };
    var jqTransformImgPreloaded = false;

    var jqTransformPreloadHoverFocusImg = function (strImgUrl) {
        //guillemets to remove for ie
        strImgUrl = strImgUrl.replace(/^url\((.*)\)/, '$1').replace(/^\"(.*)\"$/, '$1');
        var imgHover = new Image();
        imgHover.src = strImgUrl.replace(/\.([a-zA-Z]*)$/, '-hover.$1');
        var imgFocus = new Image();
        imgFocus.src = strImgUrl.replace(/\.([a-zA-Z]*)$/, '-focus.$1');
    };


    /***************************
	  Labels
	***************************/
    var jqTransformGetLabel = function (objfield) {
        var selfForm = $(objfield.get(0).form);
        var oLabel = objfield.next();
        if (!oLabel.is('label')) {
            oLabel = objfield.prev();
            if (oLabel.is('label')) {
                var inputname = objfield.attr('id');
                if (inputname) {
                    oLabel = selfForm.find('label[for="' + inputname + '"]');
                }
            }
        }
        if (oLabel.is('label')) {
            return oLabel.css('cursor', 'pointer');
        }
        return false;
    };


    /* Apply document listener */
    var jqTransformAddDocumentListener = function () {
        $(document).mousedown(jqTransformCheckExternalClick);
    };

    /* Add a new handler for the reset action */
    var jqTransformReset = function (f) {
        var sel;
        $('.jqTransformSelectWrapper select', f).each(function () {
            sel = (this.selectedIndex < 0) ? 0 : this.selectedIndex;
            $('ul', $(this).parent()).each(function () {
                $('a:eq(' + sel + ')', this).click();
            });
        });
        $('a.jqTransformCheckbox, a.jqTransformRadio', f).removeClass('jqTransformChecked');
        $('input:checkbox, input:radio', f).each(function () {
            if (this.checked) {
                $('a', $(this).parent()).addClass('jqTransformChecked');
            }
        });
    };

    /***************************
	  Buttons
	 ***************************/
    $.fn.jqTransInputButton = function () {
        return this.each(function () {
            var newBtn = $('<button id="' + this.id + '" name="' + this.name + '" type="' + this.type + '" class="' + this.className + ' jqTransformButton"><span><span>' + $(this).attr('value') + '</span></span>')
                .hover(function () {
                    newBtn.addClass('jqTransformButton_hover');
                }, function () {
                    newBtn.removeClass('jqTransformButton_hover')
                })
                .mousedown(function () {
                    newBtn.addClass('jqTransformButton_click')
                })
                .mouseup(function () {
                    newBtn.removeClass('jqTransformButton_click')
                });
            $(this).replaceWith(newBtn);
        });
    };

    /***************************
	  Text Fields 
	 ***************************/
    $.fn.jqTransInputText = function () {
        return this.each(function () {
            var $input = $(this);

            if ($input.hasClass('jqtranformdone') || !$input.is('input')) {
                return;
            }
            $input.addClass('jqtranformdone');

            var oLabel = jqTransformGetLabel($(this));
            oLabel && oLabel.bind('click', function () {
                $input.focus();
            });

            var inputSize = $input.width();
            if ($input.attr('size')) {
                inputSize = $input.attr('size') * 10;
                $input.css('width', inputSize);
            }

            $input.addClass("jqTransformInput").wrap('<div class="jqTransformInputWrapper"><div class="jqTransformInputInner"><div></div></div></div>');
            var $wrapper = $input.parent().parent().parent();
            $wrapper.css("width", inputSize + 10);
            $input
                .focus(function () {
                    $wrapper.addClass("jqTransformInputWrapper_focus");
                })
                .blur(function () {
                    $wrapper.removeClass("jqTransformInputWrapper_focus");
                })
                .hover(function () {
                    $wrapper.addClass("jqTransformInputWrapper_hover");
                }, function () {
                    $wrapper.removeClass("jqTransformInputWrapper_hover");
                });

            /* If this is safari we need to add an extra class */
            $.browser.safari && $wrapper.addClass('jqTransformSafari');
            $.browser.safari && $input.css('width', $wrapper.width() + 16);
            this.wrapper = $wrapper;

        });
    };

    /***************************
	  Check Boxes 
	 ***************************/
    $.fn.jqTransCheckBox = function () {
        return this.each(function () {
            if ($(this).hasClass('jqTransformHidden')) {
                return;
            }

            var $input = $(this);
            var inputSelf = this;

            //set the click on the label
            var oLabel = jqTransformGetLabel($input);
            oLabel && oLabel.click(function () {
                aLink.trigger('click');
            });

            var aLink = $('<a href="#" class="jqTransformCheckbox"></a>');
            //wrap and add the link
            $input.addClass('jqTransformHidden').wrap('<span class="jqTransformCheckboxWrapper"></span>').parent().prepend(aLink);
            //on change, change the class of the link
            $input.change(function () {
                this.checked && aLink.addClass('jqTransformChecked') || aLink.removeClass('jqTransformChecked');
                return true;
            });
            // Click Handler, trigger the click and change event on the input
            aLink.click(function () {
                //do nothing if the original input is disabled
                if ($input.attr('disabled')) {
                    return false;
                }
                //trigger the envents on the input object
                $input.trigger('click').trigger("change");
                return false;
            });

            // set the default state
            this.checked && aLink.addClass('jqTransformChecked');
        });
    };
    /***************************
	  Radio Buttons 
	 ***************************/
    $.fn.jqTransRadio = function () {
        return this.each(function () {
            if ($(this).hasClass('jqTransformHidden')) {
                return;
            }

            var $input = $(this);
            var inputSelf = this;

            oLabel = jqTransformGetLabel($input);
            oLabel && oLabel.click(function () {
                aLink.trigger('click');
            });

            var aLink = $('<a href="#" class="jqTransformRadio" rel="' + this.name + '"></a>');
            $input.addClass('jqTransformHidden').wrap('<span class="jqTransformRadioWrapper"></span>').parent().prepend(aLink);

            $input.change(function () {
                inputSelf.checked && aLink.addClass('jqTransformChecked') || aLink.removeClass('jqTransformChecked');
                return true;
            });
            // Click Handler
            aLink.click(function () {
                if ($input.attr('disabled')) {
                    return false;
                }
                $input.trigger('click').trigger('change');

                // uncheck all others of same name input radio elements
                $('input[name="' + $input.attr('name') + '"]', inputSelf.form).not($input).each(function () {
                    $(this).attr('type') == 'radio' && $(this).trigger('change');
                });

                return false;
            });
            // set the default state
            inputSelf.checked && aLink.addClass('jqTransformChecked');
        });
    };

    /***************************
	  TextArea 
	 ***************************/
    $.fn.jqTransTextarea = function () {
        return this.each(function () {
            var textarea = $(this);

            if (textarea.hasClass('jqtransformdone')) {
                return;
            }
            textarea.addClass('jqtransformdone');

            oLabel = jqTransformGetLabel(textarea);
            oLabel && oLabel.click(function () {
                textarea.focus();
            });

            var strTable = '<table cellspacing="0" cellpadding="0" border="0" class="jqTransformTextarea">';
            strTable += '<tr><td id="jqTransformTextarea-tl"></td><td id="jqTransformTextarea-tm"></td><td id="jqTransformTextarea-tr"></td></tr>';
            strTable += '<tr><td id="jqTransformTextarea-ml">&nbsp;</td><td id="jqTransformTextarea-mm"><div></div></td><td id="jqTransformTextarea-mr">&nbsp;</td></tr>';
            strTable += '<tr><td id="jqTransformTextarea-bl"></td><td id="jqTransformTextarea-bm"></td><td id="jqTransformTextarea-br"></td></tr>';
            strTable += '</table>';
            var oTable = $(strTable)
                .insertAfter(textarea)
                .hover(function () {
                    !oTable.hasClass('jqTransformTextarea-focus') && oTable.addClass('jqTransformTextarea-hover');
                }, function () {
                    oTable.removeClass('jqTransformTextarea-hover');
                });

            textarea
                .focus(function () {
                    oTable.removeClass('jqTransformTextarea-hover').addClass('jqTransformTextarea-focus');
                })
                .blur(function () {
                    oTable.removeClass('jqTransformTextarea-focus');
                })
                .appendTo($('#jqTransformTextarea-mm div', oTable));
            this.oTable = oTable;
            if ($.browser.safari) {
                $('#jqTransformTextarea-mm', oTable)
                    .addClass('jqTransformSafariTextarea')
                    .find('div')
                    .css('height', textarea.height())
                    .css('width', textarea.width());
            }
        });
    };


    $.fn.jqTransform = function (options) {
        var opt = $.extend({}, defaultOptions, options);

        /* each form */
        return this.each(function () {
            var selfForm = $(this);
            if (selfForm.hasClass('jqtransformdone')) {
                return;
            }
            selfForm.addClass('jqtransformdone');

            //$('input:submit, input:reset, input[type="button"]', this).jqTransInputButton();			
            $('input:text, input:password', this).jqTransInputText();
            $('input:checkbox', this).jqTransCheckBox();
            $('input:radio', this).jqTransRadio();
            $('textarea', this).jqTransTextarea();


            //preloading dont needed anymore since normal, focus and hover image are the same one
            /*if(opt.preloadImg && !jqTransformImgPreloaded){
				jqTransformImgPreloaded = true;
				var oInputText = $('input:text:first', selfForm);
				if(oInputText.length > 0){
					//pour ie on eleve les ""
					var strWrapperImgUrl = oInputText.get(0).wrapper.css('background-image');
					jqTransformPreloadHoverFocusImg(strWrapperImgUrl);					
					var strInnerImgUrl = $('div.jqTransformInputInner',$(oInputText.get(0).wrapper)).css('background-image');
					jqTransformPreloadHoverFocusImg(strInnerImgUrl);
				}
				
				var oTextarea = $('textarea',selfForm);
				if(oTextarea.length > 0){
					var oTable = oTextarea.get(0).oTable;
					$('td',oTable).each(function(){
						var strImgBack = $(this).css('background-image');
						jqTransformPreloadHoverFocusImg(strImgBack);
					});
				}
			}*/


        }); /* End Form each */

    }; /* End the Plugin */

})(jQuery);

var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;
$(function () {
    $('form').jqTransform({
        imgPath: '../images/'
    });

    // Header Top DropDowns
    $('html').click(function () {
        $('.departReport > li').children('.hideShow').css({ 'visibility': 'hidden' });
        $('.departReport > li').removeClass('active');
        resetCount = 0;
    });

    $('.departReport > li').click(function () {
        if ($(this).find('.hideShow').css('visibility') == 'hidden') {
            $('.departReport > li').find('.hideShow').css({ 'visibility': 'hidden' });
            $('.departReport > li').removeClass('active');
            $(this).find('.hideShow').css({ 'visibility': 'visible' });
            $(this).addClass('active');
        }
        else {
            $(this).removeClass('active');
            $(this).find('.hideShow').css({ 'visibility': 'hidden' });
        }
        return false;
    });

    $('.xtabs .reminder').click(function () {
        $('.add-reminder').fadeIn();
        $('#calendar').hide();
    });

    $('.add-reminder .SubmitBtn').click(function () {
        $('.add-reminder').hide();
        $('#calendar').fadeIn();
    });

    $(".scrollBar").mCustomScrollbar({ scrollButtons: { enable: true} });

    $('#scroll-bar').perfectScrollbar({
        wheelSpeed: 20,
        wheelPropagation: false
    });

    $(".reportStatus ul.xtabs li").on('click', function () {
        $(".reportStatus ul.xtabs li").removeClass(" active");
        $(this).addClass("active");
        tgt = $(this).data("xtabs");
        $(".fc-button-" + tgt).trigger("click");
    });

    $(".datepicker").datepicker();

    // update Dialog
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "update": function () {
                //alert(currentUpdateEvent.title);
                var eventToUpdate = {
                    id: currentUpdateEvent.id,
                    title: $("#eventName").val(),
                    description: $("#eventDesc").val()
                };

                if (checkForSpecialChars(eventToUpdate.title) || checkForSpecialChars(eventToUpdate.description)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    PageMethods.UpdateEvent(eventToUpdate, updateSuccess);
                    $(this).dialog("close");

                    currentUpdateEvent.title = $("#eventName").val();
                    currentUpdateEvent.description = $("#eventDesc").val();
                    $('#calendar').fullCalendar('updateEvent', currentUpdateEvent);
                }

            },
            "delete": function () {

                if (confirm("do you really want to delete this event?")) {

                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                }

            }

        }
    });


    function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {

        if ($(this).data("qtip")) $(this).qtip("destroy");

        updateEventOnDropResize(event, allDay);



    }

    function eventResized(event, dayDelta, minuteDelta, revertFunc) {

        if ($(this).data("qtip")) $(this).qtip("destroy");

        updateEventOnDropResize(event);

    }
    function updateEventOnDropResize(event, allDay) {

        //alert("allday: " + allDay);
        var eventToUpdate = {
            id: event.id,
            start: event.start

        };

        if (allDay) {
            eventToUpdate.start.setHours(0, 0, 0);

        }

        if (event.end === null) {
            eventToUpdate.end = eventToUpdate.start;

        }
        else {
            eventToUpdate.end = event.end;
            if (allDay) {
                eventToUpdate.end.setHours(0, 0, 0);
            }
        }

        eventToUpdate.start = eventToUpdate.start.format("dd-MM-yyyy hh:mm:ss tt");
        eventToUpdate.end = eventToUpdate.end.format("dd-MM-yyyy hh:mm:ss tt");

        PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);

    }
    //add dialog
    $('#addDialog').dialog({
        
        autoOpen: false,
        width: 470,
        buttons: {
            "Add": function () {

                //alert("sent:" + addStartDate.format("dd-MM-yyyy hh:mm:ss tt") + "==" + addStartDate.toLocaleString());
                var eventToAdd = {
                    title: $("#addEventName").val(),
                    description: $("#addEventDesc").val(),
                    start: addStartDate.format("dd-MM-yyyy hh:mm:ss tt"),
                    end: addEndDate.format("dd-MM-yyyy hh:mm:ss tt")

                };

                if (checkForSpecialChars(eventToAdd.title) || checkForSpecialChars(eventToAdd.description)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    //alert("sending " + eventToAdd.title);

                    PageMethods.addEvent(eventToAdd, addSuccess);
                    $(this).dialog("close");
                }

            }

        }
    });

    var currentUpdateEvent;
    var addStartDate;
    var addEndDate;
    var globalAllDay;

    function updateEvent(event, element) {
        //alert(event.description);

        if ($(this).data("qtip")) $(this).qtip("destroy");

        currentUpdateEvent = event;

        $('#updatedialog').dialog('open');

        $("#eventName").val(event.title);
        $("#eventDesc").val(event.description);
        $("#eventId").val(event.id);
        $("#eventStart").text("" + event.start.toLocaleString());

        if (event.end === null) {
            $("#eventEnd").text("");
        }
        else {
            $("#eventEnd").text("" + event.end.toLocaleString());
        }

    }
    function selectDate(start, end, allDay) {

        $('#addDialog').dialog('open');


        $("#addEventStartDate").text("" + start.toLocaleString());
        $("#addEventEndDate").text("" + end.toLocaleString());


        addStartDate = start;
        addEndDate = end;
        globalAllDay = allDay;
        //alert(allDay);

    }

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();
    debugger;
    var calendar = $('#calendar').fullCalendar({
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        eventClick: updateEvent,
        selectable: true,
        selectHelper: true,
        select: selectDate,
        editable: true,
	events: "http://recruitment.axact.com/A2/JsonResponseNew.ashx",
        eventDrop: eventDropped,
        eventResize: eventResized,
        eventRender: function (event, element) {            
            element.qtip({
                content: event.description,
                position: { corner: { tooltip: 'bottomLeft', target: 'topRight'} }

            });
        }
    });

});


