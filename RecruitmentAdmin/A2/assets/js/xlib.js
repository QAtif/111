
/*! Comment by atif hussain*/
/* Main Jquery */
/*! jQuery v1.8.3 jquery.com | jquery.org/license */
//(function(e,t){function _(e){var t=M[e]={};return v.each(e.split(y),function(e,n){t[n]=!0}),t}function H(e,n,r){if(r===t&&e.nodeType===1){var i="data-"+n.replace(P,"-$1").toLowerCase();r=e.getAttribute(i);if(typeof r=="string"){try{r=r==="true"?!0:r==="false"?!1:r==="null"?null:+r+""===r?+r:D.test(r)?v.parseJSON(r):r}catch(s){}v.data(e,n,r)}else r=t}return r}function B(e){var t;for(t in e){if(t==="data"&&v.isEmptyObject(e[t]))continue;if(t!=="toJSON")return!1}return!0}function et(){return!1}function tt(){return!0}function ut(e){return!e||!e.parentNode||e.parentNode.nodeType===11}function at(e,t){do e=e[t];while(e&&e.nodeType!==1);return e}function ft(e,t,n){t=t||0;if(v.isFunction(t))return v.grep(e,function(e,r){var i=!!t.call(e,r,e);return i===n});if(t.nodeType)return v.grep(e,function(e,r){return e===t===n});if(typeof t=="string"){var r=v.grep(e,function(e){return e.nodeType===1});if(it.test(t))return v.filter(t,r,!n);t=v.filter(t,r)}return v.grep(e,function(e,r){return v.inArray(e,t)>=0===n})}function lt(e){var t=ct.split("|"),n=e.createDocumentFragment();if(n.createElement)while(t.length)n.createElement(t.pop());return n}function Lt(e,t){return e.getElementsByTagName(t)[0]||e.appendChild(e.ownerDocument.createElement(t))}function At(e,t){if(t.nodeType!==1||!v.hasData(e))return;var n,r,i,s=v._data(e),o=v._data(t,s),u=s.events;if(u){delete o.handle,o.events={};for(n in u)for(r=0,i=u[n].length;r<i;r++)v.event.add(t,n,u[n][r])}o.data&&(o.data=v.extend({},o.data))}function Ot(e,t){var n;if(t.nodeType!==1)return;t.clearAttributes&&t.clearAttributes(),t.mergeAttributes&&t.mergeAttributes(e),n=t.nodeName.toLowerCase(),n==="object"?(t.parentNode&&(t.outerHTML=e.outerHTML),v.support.html5Clone&&e.innerHTML&&!v.trim(t.innerHTML)&&(t.innerHTML=e.innerHTML)):n==="input"&&Et.test(e.type)?(t.defaultChecked=t.checked=e.checked,t.value!==e.value&&(t.value=e.value)):n==="option"?t.selected=e.defaultSelected:n==="input"||n==="textarea"?t.defaultValue=e.defaultValue:n==="script"&&t.text!==e.text&&(t.text=e.text),t.removeAttribute(v.expando)}function Mt(e){return typeof e.getElementsByTagName!="undefined"?e.getElementsByTagName("*"):typeof e.querySelectorAll!="undefined"?e.querySelectorAll("*"):[]}function _t(e){Et.test(e.type)&&(e.defaultChecked=e.checked)}function Qt(e,t){if(t in e)return t;var n=t.charAt(0).toUpperCase()+t.slice(1),r=t,i=Jt.length;while(i--){t=Jt[i]+n;if(t in e)return t}return r}function Gt(e,t){return e=t||e,v.css(e,"display")==="none"||!v.contains(e.ownerDocument,e)}function Yt(e,t){var n,r,i=[],s=0,o=e.length;for(;s<o;s++){n=e[s];if(!n.style)continue;i[s]=v._data(n,"olddisplay"),t?(!i[s]&&n.style.display==="none"&&(n.style.display=""),n.style.display===""&&Gt(n)&&(i[s]=v._data(n,"olddisplay",nn(n.nodeName)))):(r=Dt(n,"display"),!i[s]&&r!=="none"&&v._data(n,"olddisplay",r))}for(s=0;s<o;s++){n=e[s];if(!n.style)continue;if(!t||n.style.display==="none"||n.style.display==="")n.style.display=t?i[s]||"":"none"}return e}function Zt(e,t,n){var r=Rt.exec(t);return r?Math.max(0,r[1]-(n||0))+(r[2]||"px"):t}function en(e,t,n,r){var i=n===(r?"border":"content")?4:t==="width"?1:0,s=0;for(;i<4;i+=2)n==="margin"&&(s+=v.css(e,n+$t[i],!0)),r?(n==="content"&&(s-=parseFloat(Dt(e,"padding"+$t[i]))||0),n!=="margin"&&(s-=parseFloat(Dt(e,"border"+$t[i]+"Width"))||0)):(s+=parseFloat(Dt(e,"padding"+$t[i]))||0,n!=="padding"&&(s+=parseFloat(Dt(e,"border"+$t[i]+"Width"))||0));return s}function tn(e,t,n){var r=t==="width"?e.offsetWidth:e.offsetHeight,i=!0,s=v.support.boxSizing&&v.css(e,"boxSizing")==="border-box";if(r<=0||r==null){r=Dt(e,t);if(r<0||r==null)r=e.style[t];if(Ut.test(r))return r;i=s&&(v.support.boxSizingReliable||r===e.style[t]),r=parseFloat(r)||0}return r+en(e,t,n||(s?"border":"content"),i)+"px"}function nn(e){if(Wt[e])return Wt[e];var t=v("<"+e+">").appendTo(i.body),n=t.css("display");t.remove();if(n==="none"||n===""){Pt=i.body.appendChild(Pt||v.extend(i.createElement("iframe"),{frameBorder:0,width:0,height:0}));if(!Ht||!Pt.createElement)Ht=(Pt.contentWindow||Pt.contentDocument).document,Ht.write("<!doctype html><html><body>"),Ht.close();t=Ht.body.appendChild(Ht.createElement(e)),n=Dt(t,"display"),i.body.removeChild(Pt)}return Wt[e]=n,n}function fn(e,t,n,r){var i;if(v.isArray(t))v.each(t,function(t,i){n||sn.test(e)?r(e,i):fn(e+"["+(typeof i=="object"?t:"")+"]",i,n,r)});else if(!n&&v.type(t)==="object")for(i in t)fn(e+"["+i+"]",t[i],n,r);else r(e,t)}function Cn(e){return function(t,n){typeof t!="string"&&(n=t,t="*");var r,i,s,o=t.toLowerCase().split(y),u=0,a=o.length;if(v.isFunction(n))for(;u<a;u++)r=o[u],s=/^\+/.test(r),s&&(r=r.substr(1)||"*"),i=e[r]=e[r]||[],i[s?"unshift":"push"](n)}}function kn(e,n,r,i,s,o){s=s||n.dataTypes[0],o=o||{},o[s]=!0;var u,a=e[s],f=0,l=a?a.length:0,c=e===Sn;for(;f<l&&(c||!u);f++)u=a[f](n,r,i),typeof u=="string"&&(!c||o[u]?u=t:(n.dataTypes.unshift(u),u=kn(e,n,r,i,u,o)));return(c||!u)&&!o["*"]&&(u=kn(e,n,r,i,"*",o)),u}function Ln(e,n){var r,i,s=v.ajaxSettings.flatOptions||{};for(r in n)n[r]!==t&&((s[r]?e:i||(i={}))[r]=n[r]);i&&v.extend(!0,e,i)}function An(e,n,r){var i,s,o,u,a=e.contents,f=e.dataTypes,l=e.responseFields;for(s in l)s in r&&(n[l[s]]=r[s]);while(f[0]==="*")f.shift(),i===t&&(i=e.mimeType||n.getResponseHeader("content-type"));if(i)for(s in a)if(a[s]&&a[s].test(i)){f.unshift(s);break}if(f[0]in r)o=f[0];else{for(s in r){if(!f[0]||e.converters[s+" "+f[0]]){o=s;break}u||(u=s)}o=o||u}if(o)return o!==f[0]&&f.unshift(o),r[o]}function On(e,t){var n,r,i,s,o=e.dataTypes.slice(),u=o[0],a={},f=0;e.dataFilter&&(t=e.dataFilter(t,e.dataType));if(o[1])for(n in e.converters)a[n.toLowerCase()]=e.converters[n];for(;i=o[++f];)if(i!=="*"){if(u!=="*"&&u!==i){n=a[u+" "+i]||a["* "+i];if(!n)for(r in a){s=r.split(" ");if(s[1]===i){n=a[u+" "+s[0]]||a["* "+s[0]];if(n){n===!0?n=a[r]:a[r]!==!0&&(i=s[0],o.splice(f--,0,i));break}}}if(n!==!0)if(n&&e["throws"])t=n(t);else try{t=n(t)}catch(l){return{state:"parsererror",error:n?l:"No conversion from "+u+" to "+i}}}u=i}return{state:"success",data:t}}function Fn(){try{return new e.XMLHttpRequest}catch(t){}}function In(){try{return new e.ActiveXObject("Microsoft.XMLHTTP")}catch(t){}}function $n(){return setTimeout(function(){qn=t},0),qn=v.now()}function Jn(e,t){v.each(t,function(t,n){var r=(Vn[t]||[]).concat(Vn["*"]),i=0,s=r.length;for(;i<s;i++)if(r[i].call(e,t,n))return})}function Kn(e,t,n){var r,i=0,s=0,o=Xn.length,u=v.Deferred().always(function(){delete a.elem}),a=function(){var t=qn||$n(),n=Math.max(0,f.startTime+f.duration-t),r=n/f.duration||0,i=1-r,s=0,o=f.tweens.length;for(;s<o;s++)f.tweens[s].run(i);return u.notifyWith(e,[f,i,n]),i<1&&o?n:(u.resolveWith(e,[f]),!1)},f=u.promise({elem:e,props:v.extend({},t),opts:v.extend(!0,{specialEasing:{}},n),originalProperties:t,originalOptions:n,startTime:qn||$n(),duration:n.duration,tweens:[],createTween:function(t,n,r){var i=v.Tween(e,f.opts,t,n,f.opts.specialEasing[t]||f.opts.easing);return f.tweens.push(i),i},stop:function(t){var n=0,r=t?f.tweens.length:0;for(;n<r;n++)f.tweens[n].run(1);return t?u.resolveWith(e,[f,t]):u.rejectWith(e,[f,t]),this}}),l=f.props;Qn(l,f.opts.specialEasing);for(;i<o;i++){r=Xn[i].call(f,e,l,f.opts);if(r)return r}return Jn(f,l),v.isFunction(f.opts.start)&&f.opts.start.call(e,f),v.fx.timer(v.extend(a,{anim:f,queue:f.opts.queue,elem:e})),f.progress(f.opts.progress).done(f.opts.done,f.opts.complete).fail(f.opts.fail).always(f.opts.always)}function Qn(e,t){var n,r,i,s,o;for(n in e){r=v.camelCase(n),i=t[r],s=e[n],v.isArray(s)&&(i=s[1],s=e[n]=s[0]),n!==r&&(e[r]=s,delete e[n]),o=v.cssHooks[r];if(o&&"expand"in o){s=o.expand(s),delete e[r];for(n in s)n in e||(e[n]=s[n],t[n]=i)}else t[r]=i}}function Gn(e,t,n){var r,i,s,o,u,a,f,l,c,h=this,p=e.style,d={},m=[],g=e.nodeType&&Gt(e);n.queue||(l=v._queueHooks(e,"fx"),l.unqueued==null&&(l.unqueued=0,c=l.empty.fire,l.empty.fire=function(){l.unqueued||c()}),l.unqueued++,h.always(function(){h.always(function(){l.unqueued--,v.queue(e,"fx").length||l.empty.fire()})})),e.nodeType===1&&("height"in t||"width"in t)&&(n.overflow=[p.overflow,p.overflowX,p.overflowY],v.css(e,"display")==="inline"&&v.css(e,"float")==="none"&&(!v.support.inlineBlockNeedsLayout||nn(e.nodeName)==="inline"?p.display="inline-block":p.zoom=1)),n.overflow&&(p.overflow="hidden",v.support.shrinkWrapBlocks||h.done(function(){p.overflow=n.overflow[0],p.overflowX=n.overflow[1],p.overflowY=n.overflow[2]}));for(r in t){s=t[r];if(Un.exec(s)){delete t[r],a=a||s==="toggle";if(s===(g?"hide":"show"))continue;m.push(r)}}o=m.length;if(o){u=v._data(e,"fxshow")||v._data(e,"fxshow",{}),"hidden"in u&&(g=u.hidden),a&&(u.hidden=!g),g?v(e).show():h.done(function(){v(e).hide()}),h.done(function(){var t;v.removeData(e,"fxshow",!0);for(t in d)v.style(e,t,d[t])});for(r=0;r<o;r++)i=m[r],f=h.createTween(i,g?u[i]:0),d[i]=u[i]||v.style(e,i),i in u||(u[i]=f.start,g&&(f.end=f.start,f.start=i==="width"||i==="height"?1:0))}}function Yn(e,t,n,r,i){return new Yn.prototype.init(e,t,n,r,i)}function Zn(e,t){var n,r={height:e},i=0;t=t?1:0;for(;i<4;i+=2-t)n=$t[i],r["margin"+n]=r["padding"+n]=e;return t&&(r.opacity=r.width=e),r}function tr(e){return v.isWindow(e)?e:e.nodeType===9?e.defaultView||e.parentWindow:!1}var n,r,i=e.document,s=e.location,o=e.navigator,u=e.jQuery,a=e.$,f=Array.prototype.push,l=Array.prototype.slice,c=Array.prototype.indexOf,h=Object.prototype.toString,p=Object.prototype.hasOwnProperty,d=String.prototype.trim,v=function(e,t){return new v.fn.init(e,t,n)},m=/[\-+]?(?:\d*\.|)\d+(?:[eE][\-+]?\d+|)/.source,g=/\S/,y=/\s+/,b=/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g,w=/^(?:[^#<]*(<[\w\W]+>)[^>]*$|#([\w\-]*)$)/,E=/^<(\w+)\s*\/?>(?:<\/\1>|)$/,S=/^[\],:{}\s]*$/,x=/(?:^|:|,)(?:\s*\[)+/g,T=/\\(?:["\\\/bfnrt]|u[\da-fA-F]{4})/g,N=/"[^"\\\r\n]*"|true|false|null|-?(?:\d\d*\.|)\d+(?:[eE][\-+]?\d+|)/g,C=/^-ms-/,k=/-([\da-z])/gi,L=function(e,t){return(t+"").toUpperCase()},A=function(){i.addEventListener?(i.removeEventListener("DOMContentLoaded",A,!1),v.ready()):i.readyState==="complete"&&(i.detachEvent("onreadystatechange",A),v.ready())},O={};v.fn=v.prototype={constructor:v,init:function(e,n,r){var s,o,u,a;if(!e)return this;if(e.nodeType)return this.context=this[0]=e,this.length=1,this;if(typeof e=="string"){e.charAt(0)==="<"&&e.charAt(e.length-1)===">"&&e.length>=3?s=[null,e,null]:s=w.exec(e);if(s&&(s[1]||!n)){if(s[1])return n=n instanceof v?n[0]:n,a=n&&n.nodeType?n.ownerDocument||n:i,e=v.parseHTML(s[1],a,!0),E.test(s[1])&&v.isPlainObject(n)&&this.attr.call(e,n,!0),v.merge(this,e);o=i.getElementById(s[2]);if(o&&o.parentNode){if(o.id!==s[2])return r.find(e);this.length=1,this[0]=o}return this.context=i,this.selector=e,this}return!n||n.jquery?(n||r).find(e):this.constructor(n).find(e)}return v.isFunction(e)?r.ready(e):(e.selector!==t&&(this.selector=e.selector,this.context=e.context),v.makeArray(e,this))},selector:"",jquery:"1.8.3",length:0,size:function(){return this.length},toArray:function(){return l.call(this)},get:function(e){return e==null?this.toArray():e<0?this[this.length+e]:this[e]},pushStack:function(e,t,n){var r=v.merge(this.constructor(),e);return r.prevObject=this,r.context=this.context,t==="find"?r.selector=this.selector+(this.selector?" ":"")+n:t&&(r.selector=this.selector+"."+t+"("+n+")"),r},each:function(e,t){return v.each(this,e,t)},ready:function(e){return v.ready.promise().done(e),this},eq:function(e){return e=+e,e===-1?this.slice(e):this.slice(e,e+1)},first:function(){return this.eq(0)},last:function(){return this.eq(-1)},slice:function(){return this.pushStack(l.apply(this,arguments),"slice",l.call(arguments).join(","))},map:function(e){return this.pushStack(v.map(this,function(t,n){return e.call(t,n,t)}))},end:function(){return this.prevObject||this.constructor(null)},push:f,sort:[].sort,splice:[].splice},v.fn.init.prototype=v.fn,v.extend=v.fn.extend=function(){var e,n,r,i,s,o,u=arguments[0]||{},a=1,f=arguments.length,l=!1;typeof u=="boolean"&&(l=u,u=arguments[1]||{},a=2),typeof u!="object"&&!v.isFunction(u)&&(u={}),f===a&&(u=this,--a);for(;a<f;a++)if((e=arguments[a])!=null)for(n in e){r=u[n],i=e[n];if(u===i)continue;l&&i&&(v.isPlainObject(i)||(s=v.isArray(i)))?(s?(s=!1,o=r&&v.isArray(r)?r:[]):o=r&&v.isPlainObject(r)?r:{},u[n]=v.extend(l,o,i)):i!==t&&(u[n]=i)}return u},v.extend({noConflict:function(t){return e.$===v&&(e.$=a),t&&e.jQuery===v&&(e.jQuery=u),v},isReady:!1,readyWait:1,holdReady:function(e){e?v.readyWait++:v.ready(!0)},ready:function(e){if(e===!0?--v.readyWait:v.isReady)return;if(!i.body)return setTimeout(v.ready,1);v.isReady=!0;if(e!==!0&&--v.readyWait>0)return;r.resolveWith(i,[v]),v.fn.trigger&&v(i).trigger("ready").off("ready")},isFunction:function(e){return v.type(e)==="function"},isArray:Array.isArray||function(e){return v.type(e)==="array"},isWindow:function(e){return e!=null&&e==e.window},isNumeric:function(e){return!isNaN(parseFloat(e))&&isFinite(e)},type:function(e){return e==null?String(e):O[h.call(e)]||"object"},isPlainObject:function(e){if(!e||v.type(e)!=="object"||e.nodeType||v.isWindow(e))return!1;try{if(e.constructor&&!p.call(e,"constructor")&&!p.call(e.constructor.prototype,"isPrototypeOf"))return!1}catch(n){return!1}var r;for(r in e);return r===t||p.call(e,r)},isEmptyObject:function(e){var t;for(t in e)return!1;return!0},error:function(e){throw new Error(e)},parseHTML:function(e,t,n){var r;return!e||typeof e!="string"?null:(typeof t=="boolean"&&(n=t,t=0),t=t||i,(r=E.exec(e))?[t.createElement(r[1])]:(r=v.buildFragment([e],t,n?null:[]),v.merge([],(r.cacheable?v.clone(r.fragment):r.fragment).childNodes)))},parseJSON:function(t){if(!t||typeof t!="string")return null;t=v.trim(t);if(e.JSON&&e.JSON.parse)return e.JSON.parse(t);if(S.test(t.replace(T,"@").replace(N,"]").replace(x,"")))return(new Function("return "+t))();v.error("Invalid JSON: "+t)},parseXML:function(n){var r,i;if(!n||typeof n!="string")return null;try{e.DOMParser?(i=new DOMParser,r=i.parseFromString(n,"text/xml")):(r=new ActiveXObject("Microsoft.XMLDOM"),r.async="false",r.loadXML(n))}catch(s){r=t}return(!r||!r.documentElement||r.getElementsByTagName("parsererror").length)&&v.error("Invalid XML: "+n),r},noop:function(){},globalEval:function(t){t&&g.test(t)&&(e.execScript||function(t){e.eval.call(e,t)})(t)},camelCase:function(e){return e.replace(C,"ms-").replace(k,L)},nodeName:function(e,t){return e.nodeName&&e.nodeName.toLowerCase()===t.toLowerCase()},each:function(e,n,r){var i,s=0,o=e.length,u=o===t||v.isFunction(e);if(r){if(u){for(i in e)if(n.apply(e[i],r)===!1)break}else for(;s<o;)if(n.apply(e[s++],r)===!1)break}else if(u){for(i in e)if(n.call(e[i],i,e[i])===!1)break}else for(;s<o;)if(n.call(e[s],s,e[s++])===!1)break;return e},trim:d&&!d.call("\ufeff\u00a0")?function(e){return e==null?"":d.call(e)}:function(e){return e==null?"":(e+"").replace(b,"")},makeArray:function(e,t){var n,r=t||[];return e!=null&&(n=v.type(e),e.length==null||n==="string"||n==="function"||n==="regexp"||v.isWindow(e)?f.call(r,e):v.merge(r,e)),r},inArray:function(e,t,n){var r;if(t){if(c)return c.call(t,e,n);r=t.length,n=n?n<0?Math.max(0,r+n):n:0;for(;n<r;n++)if(n in t&&t[n]===e)return n}return-1},merge:function(e,n){var r=n.length,i=e.length,s=0;if(typeof r=="number")for(;s<r;s++)e[i++]=n[s];else while(n[s]!==t)e[i++]=n[s++];return e.length=i,e},grep:function(e,t,n){var r,i=[],s=0,o=e.length;n=!!n;for(;s<o;s++)r=!!t(e[s],s),n!==r&&i.push(e[s]);return i},map:function(e,n,r){var i,s,o=[],u=0,a=e.length,f=e instanceof v||a!==t&&typeof a=="number"&&(a>0&&e[0]&&e[a-1]||a===0||v.isArray(e));if(f)for(;u<a;u++)i=n(e[u],u,r),i!=null&&(o[o.length]=i);else for(s in e)i=n(e[s],s,r),i!=null&&(o[o.length]=i);return o.concat.apply([],o)},guid:1,proxy:function(e,n){var r,i,s;return typeof n=="string"&&(r=e[n],n=e,e=r),v.isFunction(e)?(i=l.call(arguments,2),s=function(){return e.apply(n,i.concat(l.call(arguments)))},s.guid=e.guid=e.guid||v.guid++,s):t},access:function(e,n,r,i,s,o,u){var a,f=r==null,l=0,c=e.length;if(r&&typeof r=="object"){for(l in r)v.access(e,n,l,r[l],1,o,i);s=1}else if(i!==t){a=u===t&&v.isFunction(i),f&&(a?(a=n,n=function(e,t,n){return a.call(v(e),n)}):(n.call(e,i),n=null));if(n)for(;l<c;l++)n(e[l],r,a?i.call(e[l],l,n(e[l],r)):i,u);s=1}return s?e:f?n.call(e):c?n(e[0],r):o},now:function(){return(new Date).getTime()}}),v.ready.promise=function(t){if(!r){r=v.Deferred();if(i.readyState==="complete")setTimeout(v.ready,1);else if(i.addEventListener)i.addEventListener("DOMContentLoaded",A,!1),e.addEventListener("load",v.ready,!1);else{i.attachEvent("onreadystatechange",A),e.attachEvent("onload",v.ready);var n=!1;try{n=e.frameElement==null&&i.documentElement}catch(s){}n&&n.doScroll&&function o(){if(!v.isReady){try{n.doScroll("left")}catch(e){return setTimeout(o,50)}v.ready()}}()}}return r.promise(t)},v.each("Boolean Number String Function Array Date RegExp Object".split(" "),function(e,t){O["[object "+t+"]"]=t.toLowerCase()}),n=v(i);var M={};v.Callbacks=function(e){e=typeof e=="string"?M[e]||_(e):v.extend({},e);var n,r,i,s,o,u,a=[],f=!e.once&&[],l=function(t){n=e.memory&&t,r=!0,u=s||0,s=0,o=a.length,i=!0;for(;a&&u<o;u++)if(a[u].apply(t[0],t[1])===!1&&e.stopOnFalse){n=!1;break}i=!1,a&&(f?f.length&&l(f.shift()):n?a=[]:c.disable())},c={add:function(){if(a){var t=a.length;(function r(t){v.each(t,function(t,n){var i=v.type(n);i==="function"?(!e.unique||!c.has(n))&&a.push(n):n&&n.length&&i!=="string"&&r(n)})})(arguments),i?o=a.length:n&&(s=t,l(n))}return this},remove:function(){return a&&v.each(arguments,function(e,t){var n;while((n=v.inArray(t,a,n))>-1)a.splice(n,1),i&&(n<=o&&o--,n<=u&&u--)}),this},has:function(e){return v.inArray(e,a)>-1},empty:function(){return a=[],this},disable:function(){return a=f=n=t,this},disabled:function(){return!a},lock:function(){return f=t,n||c.disable(),this},locked:function(){return!f},fireWith:function(e,t){return t=t||[],t=[e,t.slice?t.slice():t],a&&(!r||f)&&(i?f.push(t):l(t)),this},fire:function(){return c.fireWith(this,arguments),this},fired:function(){return!!r}};return c},v.extend({Deferred:function(e){var t=[["resolve","done",v.Callbacks("once memory"),"resolved"],["reject","fail",v.Callbacks("once memory"),"rejected"],["notify","progress",v.Callbacks("memory")]],n="pending",r={state:function(){return n},always:function(){return i.done(arguments).fail(arguments),this},then:function(){var e=arguments;return v.Deferred(function(n){v.each(t,function(t,r){var s=r[0],o=e[t];i[r[1]](v.isFunction(o)?function(){var e=o.apply(this,arguments);e&&v.isFunction(e.promise)?e.promise().done(n.resolve).fail(n.reject).progress(n.notify):n[s+"With"](this===i?n:this,[e])}:n[s])}),e=null}).promise()},promise:function(e){return e!=null?v.extend(e,r):r}},i={};return r.pipe=r.then,v.each(t,function(e,s){var o=s[2],u=s[3];r[s[1]]=o.add,u&&o.add(function(){n=u},t[e^1][2].disable,t[2][2].lock),i[s[0]]=o.fire,i[s[0]+"With"]=o.fireWith}),r.promise(i),e&&e.call(i,i),i},when:function(e){var t=0,n=l.call(arguments),r=n.length,i=r!==1||e&&v.isFunction(e.promise)?r:0,s=i===1?e:v.Deferred(),o=function(e,t,n){return function(r){t[e]=this,n[e]=arguments.length>1?l.call(arguments):r,n===u?s.notifyWith(t,n):--i||s.resolveWith(t,n)}},u,a,f;if(r>1){u=new Array(r),a=new Array(r),f=new Array(r);for(;t<r;t++)n[t]&&v.isFunction(n[t].promise)?n[t].promise().done(o(t,f,n)).fail(s.reject).progress(o(t,a,u)):--i}return i||s.resolveWith(f,n),s.promise()}}),v.support=function(){var t,n,r,s,o,u,a,f,l,c,h,p=i.createElement("div");p.setAttribute("className","t"),p.innerHTML="  <link/><table></table><a href='/a'>a</a><input type='checkbox'/>",n=p.getElementsByTagName("*"),r=p.getElementsByTagName("a")[0];if(!n||!r||!n.length)return{};s=i.createElement("select"),o=s.appendChild(i.createElement("option")),u=p.getElementsByTagName("input")[0],r.style.cssText="top:1px;float:left;opacity:.5",t={leadingWhitespace:p.firstChild.nodeType===3,tbody:!p.getElementsByTagName("tbody").length,htmlSerialize:!!p.getElementsByTagName("link").length,style:/top/.test(r.getAttribute("style")),hrefNormalized:r.getAttribute("href")==="/a",opacity:/^0.5/.test(r.style.opacity),cssFloat:!!r.style.cssFloat,checkOn:u.value==="on",optSelected:o.selected,getSetAttribute:p.className!=="t",enctype:!!i.createElement("form").enctype,html5Clone:i.createElement("nav").cloneNode(!0).outerHTML!=="<:nav></:nav>",boxModel:i.compatMode==="CSS1Compat",submitBubbles:!0,changeBubbles:!0,focusinBubbles:!1,deleteExpando:!0,noCloneEvent:!0,inlineBlockNeedsLayout:!1,shrinkWrapBlocks:!1,reliableMarginRight:!0,boxSizingReliable:!0,pixelPosition:!1},u.checked=!0,t.noCloneChecked=u.cloneNode(!0).checked,s.disabled=!0,t.optDisabled=!o.disabled;try{delete p.test}catch(d){t.deleteExpando=!1}!p.addEventListener&&p.attachEvent&&p.fireEvent&&(p.attachEvent("onclick",h=function(){t.noCloneEvent=!1}),p.cloneNode(!0).fireEvent("onclick"),p.detachEvent("onclick",h)),u=i.createElement("input"),u.value="t",u.setAttribute("type","radio"),t.radioValue=u.value==="t",u.setAttribute("checked","checked"),u.setAttribute("name","t"),p.appendChild(u),a=i.createDocumentFragment(),a.appendChild(p.lastChild),t.checkClone=a.cloneNode(!0).cloneNode(!0).lastChild.checked,t.appendChecked=u.checked,a.removeChild(u),a.appendChild(p);if(p.attachEvent)for(l in{submit:!0,change:!0,focusin:!0})f="on"+l,c=f in p,c||(p.setAttribute(f,"return;"),c=typeof p[f]=="function"),t[l+"Bubbles"]=c;return v(function(){var n,r,s,o,u="padding:0;margin:0;border:0;display:block;overflow:hidden;",a=i.getElementsByTagName("body")[0];if(!a)return;n=i.createElement("div"),n.style.cssText="visibility:hidden;border:0;width:0;height:0;position:static;top:0;margin-top:1px",a.insertBefore(n,a.firstChild),r=i.createElement("div"),n.appendChild(r),r.innerHTML="<table><tr><td></td><td>t</td></tr></table>",s=r.getElementsByTagName("td"),s[0].style.cssText="padding:0;margin:0;border:0;display:none",c=s[0].offsetHeight===0,s[0].style.display="",s[1].style.display="none",t.reliableHiddenOffsets=c&&s[0].offsetHeight===0,r.innerHTML="",r.style.cssText="box-sizing:border-box;-moz-box-sizing:border-box;-webkit-box-sizing:border-box;padding:1px;border:1px;display:block;width:4px;margin-top:1%;position:absolute;top:1%;",t.boxSizing=r.offsetWidth===4,t.doesNotIncludeMarginInBodyOffset=a.offsetTop!==1,e.getComputedStyle&&(t.pixelPosition=(e.getComputedStyle(r,null)||{}).top!=="1%",t.boxSizingReliable=(e.getComputedStyle(r,null)||{width:"4px"}).width==="4px",o=i.createElement("div"),o.style.cssText=r.style.cssText=u,o.style.marginRight=o.style.width="0",r.style.width="1px",r.appendChild(o),t.reliableMarginRight=!parseFloat((e.getComputedStyle(o,null)||{}).marginRight)),typeof r.style.zoom!="undefined"&&(r.innerHTML="",r.style.cssText=u+"width:1px;padding:1px;display:inline;zoom:1",t.inlineBlockNeedsLayout=r.offsetWidth===3,r.style.display="block",r.style.overflow="visible",r.innerHTML="<div></div>",r.firstChild.style.width="5px",t.shrinkWrapBlocks=r.offsetWidth!==3,n.style.zoom=1),a.removeChild(n),n=r=s=o=null}),a.removeChild(p),n=r=s=o=u=a=p=null,t}();var D=/(?:\{[\s\S]*\}|\[[\s\S]*\])$/,P=/([A-Z])/g;v.extend({cache:{},deletedIds:[],uuid:0,expando:"jQuery"+(v.fn.jquery+Math.random()).replace(/\D/g,""),noData:{embed:!0,object:"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000",applet:!0},hasData:function(e){return e=e.nodeType?v.cache[e[v.expando]]:e[v.expando],!!e&&!B(e)},data:function(e,n,r,i){if(!v.acceptData(e))return;var s,o,u=v.expando,a=typeof n=="string",f=e.nodeType,l=f?v.cache:e,c=f?e[u]:e[u]&&u;if((!c||!l[c]||!i&&!l[c].data)&&a&&r===t)return;c||(f?e[u]=c=v.deletedIds.pop()||v.guid++:c=u),l[c]||(l[c]={},f||(l[c].toJSON=v.noop));if(typeof n=="object"||typeof n=="function")i?l[c]=v.extend(l[c],n):l[c].data=v.extend(l[c].data,n);return s=l[c],i||(s.data||(s.data={}),s=s.data),r!==t&&(s[v.camelCase(n)]=r),a?(o=s[n],o==null&&(o=s[v.camelCase(n)])):o=s,o},removeData:function(e,t,n){if(!v.acceptData(e))return;var r,i,s,o=e.nodeType,u=o?v.cache:e,a=o?e[v.expando]:v.expando;if(!u[a])return;if(t){r=n?u[a]:u[a].data;if(r){v.isArray(t)||(t in r?t=[t]:(t=v.camelCase(t),t in r?t=[t]:t=t.split(" ")));for(i=0,s=t.length;i<s;i++)delete r[t[i]];if(!(n?B:v.isEmptyObject)(r))return}}if(!n){delete u[a].data;if(!B(u[a]))return}o?v.cleanData([e],!0):v.support.deleteExpando||u!=u.window?delete u[a]:u[a]=null},_data:function(e,t,n){return v.data(e,t,n,!0)},acceptData:function(e){var t=e.nodeName&&v.noData[e.nodeName.toLowerCase()];return!t||t!==!0&&e.getAttribute("classid")===t}}),v.fn.extend({data:function(e,n){var r,i,s,o,u,a=this[0],f=0,l=null;if(e===t){if(this.length){l=v.data(a);if(a.nodeType===1&&!v._data(a,"parsedAttrs")){s=a.attributes;for(u=s.length;f<u;f++)o=s[f].name,o.indexOf("data-")||(o=v.camelCase(o.substring(5)),H(a,o,l[o]));v._data(a,"parsedAttrs",!0)}}return l}return typeof e=="object"?this.each(function(){v.data(this,e)}):(r=e.split(".",2),r[1]=r[1]?"."+r[1]:"",i=r[1]+"!",v.access(this,function(n){if(n===t)return l=this.triggerHandler("getData"+i,[r[0]]),l===t&&a&&(l=v.data(a,e),l=H(a,e,l)),l===t&&r[1]?this.data(r[0]):l;r[1]=n,this.each(function(){var t=v(this);t.triggerHandler("setData"+i,r),v.data(this,e,n),t.triggerHandler("changeData"+i,r)})},null,n,arguments.length>1,null,!1))},removeData:function(e){return this.each(function(){v.removeData(this,e)})}}),v.extend({queue:function(e,t,n){var r;if(e)return t=(t||"fx")+"queue",r=v._data(e,t),n&&(!r||v.isArray(n)?r=v._data(e,t,v.makeArray(n)):r.push(n)),r||[]},dequeue:function(e,t){t=t||"fx";var n=v.queue(e,t),r=n.length,i=n.shift(),s=v._queueHooks(e,t),o=function(){v.dequeue(e,t)};i==="inprogress"&&(i=n.shift(),r--),i&&(t==="fx"&&n.unshift("inprogress"),delete s.stop,i.call(e,o,s)),!r&&s&&s.empty.fire()},_queueHooks:function(e,t){var n=t+"queueHooks";return v._data(e,n)||v._data(e,n,{empty:v.Callbacks("once memory").add(function(){v.removeData(e,t+"queue",!0),v.removeData(e,n,!0)})})}}),v.fn.extend({queue:function(e,n){var r=2;return typeof e!="string"&&(n=e,e="fx",r--),arguments.length<r?v.queue(this[0],e):n===t?this:this.each(function(){var t=v.queue(this,e,n);v._queueHooks(this,e),e==="fx"&&t[0]!=="inprogress"&&v.dequeue(this,e)})},dequeue:function(e){return this.each(function(){v.dequeue(this,e)})},delay:function(e,t){return e=v.fx?v.fx.speeds[e]||e:e,t=t||"fx",this.queue(t,function(t,n){var r=setTimeout(t,e);n.stop=function(){clearTimeout(r)}})},clearQueue:function(e){return this.queue(e||"fx",[])},promise:function(e,n){var r,i=1,s=v.Deferred(),o=this,u=this.length,a=function(){--i||s.resolveWith(o,[o])};typeof e!="string"&&(n=e,e=t),e=e||"fx";while(u--)r=v._data(o[u],e+"queueHooks"),r&&r.empty&&(i++,r.empty.add(a));return a(),s.promise(n)}});var j,F,I,q=/[\t\r\n]/g,R=/\r/g,U=/^(?:button|input)$/i,z=/^(?:button|input|object|select|textarea)$/i,W=/^a(?:rea|)$/i,X=/^(?:autofocus|autoplay|async|checked|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|selected)$/i,V=v.support.getSetAttribute;v.fn.extend({attr:function(e,t){return v.access(this,v.attr,e,t,arguments.length>1)},removeAttr:function(e){return this.each(function(){v.removeAttr(this,e)})},prop:function(e,t){return v.access(this,v.prop,e,t,arguments.length>1)},removeProp:function(e){return e=v.propFix[e]||e,this.each(function(){try{this[e]=t,delete this[e]}catch(n){}})},addClass:function(e){var t,n,r,i,s,o,u;if(v.isFunction(e))return this.each(function(t){v(this).addClass(e.call(this,t,this.className))});if(e&&typeof e=="string"){t=e.split(y);for(n=0,r=this.length;n<r;n++){i=this[n];if(i.nodeType===1)if(!i.className&&t.length===1)i.className=e;else{s=" "+i.className+" ";for(o=0,u=t.length;o<u;o++)s.indexOf(" "+t[o]+" ")<0&&(s+=t[o]+" ");i.className=v.trim(s)}}}return this},removeClass:function(e){var n,r,i,s,o,u,a;if(v.isFunction(e))return this.each(function(t){v(this).removeClass(e.call(this,t,this.className))});if(e&&typeof e=="string"||e===t){n=(e||"").split(y);for(u=0,a=this.length;u<a;u++){i=this[u];if(i.nodeType===1&&i.className){r=(" "+i.className+" ").replace(q," ");for(s=0,o=n.length;s<o;s++)while(r.indexOf(" "+n[s]+" ")>=0)r=r.replace(" "+n[s]+" "," ");i.className=e?v.trim(r):""}}}return this},toggleClass:function(e,t){var n=typeof e,r=typeof t=="boolean";return v.isFunction(e)?this.each(function(n){v(this).toggleClass(e.call(this,n,this.className,t),t)}):this.each(function(){if(n==="string"){var i,s=0,o=v(this),u=t,a=e.split(y);while(i=a[s++])u=r?u:!o.hasClass(i),o[u?"addClass":"removeClass"](i)}else if(n==="undefined"||n==="boolean")this.className&&v._data(this,"__className__",this.className),this.className=this.className||e===!1?"":v._data(this,"__className__")||""})},hasClass:function(e){var t=" "+e+" ",n=0,r=this.length;for(;n<r;n++)if(this[n].nodeType===1&&(" "+this[n].className+" ").replace(q," ").indexOf(t)>=0)return!0;return!1},val:function(e){var n,r,i,s=this[0];if(!arguments.length){if(s)return n=v.valHooks[s.type]||v.valHooks[s.nodeName.toLowerCase()],n&&"get"in n&&(r=n.get(s,"value"))!==t?r:(r=s.value,typeof r=="string"?r.replace(R,""):r==null?"":r);return}return i=v.isFunction(e),this.each(function(r){var s,o=v(this);if(this.nodeType!==1)return;i?s=e.call(this,r,o.val()):s=e,s==null?s="":typeof s=="number"?s+="":v.isArray(s)&&(s=v.map(s,function(e){return e==null?"":e+""})),n=v.valHooks[this.type]||v.valHooks[this.nodeName.toLowerCase()];if(!n||!("set"in n)||n.set(this,s,"value")===t)this.value=s})}}),v.extend({valHooks:{option:{get:function(e){var t=e.attributes.value;return!t||t.specified?e.value:e.text}},select:{get:function(e){var t,n,r=e.options,i=e.selectedIndex,s=e.type==="select-one"||i<0,o=s?null:[],u=s?i+1:r.length,a=i<0?u:s?i:0;for(;a<u;a++){n=r[a];if((n.selected||a===i)&&(v.support.optDisabled?!n.disabled:n.getAttribute("disabled")===null)&&(!n.parentNode.disabled||!v.nodeName(n.parentNode,"optgroup"))){t=v(n).val();if(s)return t;o.push(t)}}return o},set:function(e,t){var n=v.makeArray(t);return v(e).find("option").each(function(){this.selected=v.inArray(v(this).val(),n)>=0}),n.length||(e.selectedIndex=-1),n}}},attrFn:{},attr:function(e,n,r,i){var s,o,u,a=e.nodeType;if(!e||a===3||a===8||a===2)return;if(i&&v.isFunction(v.fn[n]))return v(e)[n](r);if(typeof e.getAttribute=="undefined")return v.prop(e,n,r);u=a!==1||!v.isXMLDoc(e),u&&(n=n.toLowerCase(),o=v.attrHooks[n]||(X.test(n)?F:j));if(r!==t){if(r===null){v.removeAttr(e,n);return}return o&&"set"in o&&u&&(s=o.set(e,r,n))!==t?s:(e.setAttribute(n,r+""),r)}return o&&"get"in o&&u&&(s=o.get(e,n))!==null?s:(s=e.getAttribute(n),s===null?t:s)},removeAttr:function(e,t){var n,r,i,s,o=0;if(t&&e.nodeType===1){r=t.split(y);for(;o<r.length;o++)i=r[o],i&&(n=v.propFix[i]||i,s=X.test(i),s||v.attr(e,i,""),e.removeAttribute(V?i:n),s&&n in e&&(e[n]=!1))}},attrHooks:{type:{set:function(e,t){if(U.test(e.nodeName)&&e.parentNode)v.error("type property can't be changed");else if(!v.support.radioValue&&t==="radio"&&v.nodeName(e,"input")){var n=e.value;return e.setAttribute("type",t),n&&(e.value=n),t}}},value:{get:function(e,t){return j&&v.nodeName(e,"button")?j.get(e,t):t in e?e.value:null},set:function(e,t,n){if(j&&v.nodeName(e,"button"))return j.set(e,t,n);e.value=t}}},propFix:{tabindex:"tabIndex",readonly:"readOnly","for":"htmlFor","class":"className",maxlength:"maxLength",cellspacing:"cellSpacing",cellpadding:"cellPadding",rowspan:"rowSpan",colspan:"colSpan",usemap:"useMap",frameborder:"frameBorder",contenteditable:"contentEditable"},prop:function(e,n,r){var i,s,o,u=e.nodeType;if(!e||u===3||u===8||u===2)return;return o=u!==1||!v.isXMLDoc(e),o&&(n=v.propFix[n]||n,s=v.propHooks[n]),r!==t?s&&"set"in s&&(i=s.set(e,r,n))!==t?i:e[n]=r:s&&"get"in s&&(i=s.get(e,n))!==null?i:e[n]},propHooks:{tabIndex:{get:function(e){var n=e.getAttributeNode("tabindex");return n&&n.specified?parseInt(n.value,10):z.test(e.nodeName)||W.test(e.nodeName)&&e.href?0:t}}}}),F={get:function(e,n){var r,i=v.prop(e,n);return i===!0||typeof i!="boolean"&&(r=e.getAttributeNode(n))&&r.nodeValue!==!1?n.toLowerCase():t},set:function(e,t,n){var r;return t===!1?v.removeAttr(e,n):(r=v.propFix[n]||n,r in e&&(e[r]=!0),e.setAttribute(n,n.toLowerCase())),n}},V||(I={name:!0,id:!0,coords:!0},j=v.valHooks.button={get:function(e,n){var r;return r=e.getAttributeNode(n),r&&(I[n]?r.value!=="":r.specified)?r.value:t},set:function(e,t,n){var r=e.getAttributeNode(n);return r||(r=i.createAttribute(n),e.setAttributeNode(r)),r.value=t+""}},v.each(["width","height"],function(e,t){v.attrHooks[t]=v.extend(v.attrHooks[t],{set:function(e,n){if(n==="")return e.setAttribute(t,"auto"),n}})}),v.attrHooks.contenteditable={get:j.get,set:function(e,t,n){t===""&&(t="false"),j.set(e,t,n)}}),v.support.hrefNormalized||v.each(["href","src","width","height"],function(e,n){v.attrHooks[n]=v.extend(v.attrHooks[n],{get:function(e){var r=e.getAttribute(n,2);return r===null?t:r}})}),v.support.style||(v.attrHooks.style={get:function(e){return e.style.cssText.toLowerCase()||t},set:function(e,t){return e.style.cssText=t+""}}),v.support.optSelected||(v.propHooks.selected=v.extend(v.propHooks.selected,{get:function(e){var t=e.parentNode;return t&&(t.selectedIndex,t.parentNode&&t.parentNode.selectedIndex),null}})),v.support.enctype||(v.propFix.enctype="encoding"),v.support.checkOn||v.each(["radio","checkbox"],function(){v.valHooks[this]={get:function(e){return e.getAttribute("value")===null?"on":e.value}}}),v.each(["radio","checkbox"],function(){v.valHooks[this]=v.extend(v.valHooks[this],{set:function(e,t){if(v.isArray(t))return e.checked=v.inArray(v(e).val(),t)>=0}})});var $=/^(?:textarea|input|select)$/i,J=/^([^\.]*|)(?:\.(.+)|)$/,K=/(?:^|\s)hover(\.\S+|)\b/,Q=/^key/,G=/^(?:mouse|contextmenu)|click/,Y=/^(?:focusinfocus|focusoutblur)$/,Z=function(e){return v.event.special.hover?e:e.replace(K,"mouseenter$1 mouseleave$1")};v.event={add:function(e,n,r,i,s){var o,u,a,f,l,c,h,p,d,m,g;if(e.nodeType===3||e.nodeType===8||!n||!r||!(o=v._data(e)))return;r.handler&&(d=r,r=d.handler,s=d.selector),r.guid||(r.guid=v.guid++),a=o.events,a||(o.events=a={}),u=o.handle,u||(o.handle=u=function(e){return typeof v=="undefined"||!!e&&v.event.triggered===e.type?t:v.event.dispatch.apply(u.elem,arguments)},u.elem=e),n=v.trim(Z(n)).split(" ");for(f=0;f<n.length;f++){l=J.exec(n[f])||[],c=l[1],h=(l[2]||"").split(".").sort(),g=v.event.special[c]||{},c=(s?g.delegateType:g.bindType)||c,g=v.event.special[c]||{},p=v.extend({type:c,origType:l[1],data:i,handler:r,guid:r.guid,selector:s,needsContext:s&&v.expr.match.needsContext.test(s),namespace:h.join(".")},d),m=a[c];if(!m){m=a[c]=[],m.delegateCount=0;if(!g.setup||g.setup.call(e,i,h,u)===!1)e.addEventListener?e.addEventListener(c,u,!1):e.attachEvent&&e.attachEvent("on"+c,u)}g.add&&(g.add.call(e,p),p.handler.guid||(p.handler.guid=r.guid)),s?m.splice(m.delegateCount++,0,p):m.push(p),v.event.global[c]=!0}e=null},global:{},remove:function(e,t,n,r,i){var s,o,u,a,f,l,c,h,p,d,m,g=v.hasData(e)&&v._data(e);if(!g||!(h=g.events))return;t=v.trim(Z(t||"")).split(" ");for(s=0;s<t.length;s++){o=J.exec(t[s])||[],u=a=o[1],f=o[2];if(!u){for(u in h)v.event.remove(e,u+t[s],n,r,!0);continue}p=v.event.special[u]||{},u=(r?p.delegateType:p.bindType)||u,d=h[u]||[],l=d.length,f=f?new RegExp("(^|\\.)"+f.split(".").sort().join("\\.(?:.*\\.|)")+"(\\.|$)"):null;for(c=0;c<d.length;c++)m=d[c],(i||a===m.origType)&&(!n||n.guid===m.guid)&&(!f||f.test(m.namespace))&&(!r||r===m.selector||r==="**"&&m.selector)&&(d.splice(c--,1),m.selector&&d.delegateCount--,p.remove&&p.remove.call(e,m));d.length===0&&l!==d.length&&((!p.teardown||p.teardown.call(e,f,g.handle)===!1)&&v.removeEvent(e,u,g.handle),delete h[u])}v.isEmptyObject(h)&&(delete g.handle,v.removeData(e,"events",!0))},customEvent:{getData:!0,setData:!0,changeData:!0},trigger:function(n,r,s,o){if(!s||s.nodeType!==3&&s.nodeType!==8){var u,a,f,l,c,h,p,d,m,g,y=n.type||n,b=[];if(Y.test(y+v.event.triggered))return;y.indexOf("!")>=0&&(y=y.slice(0,-1),a=!0),y.indexOf(".")>=0&&(b=y.split("."),y=b.shift(),b.sort());if((!s||v.event.customEvent[y])&&!v.event.global[y])return;n=typeof n=="object"?n[v.expando]?n:new v.Event(y,n):new v.Event(y),n.type=y,n.isTrigger=!0,n.exclusive=a,n.namespace=b.join("."),n.namespace_re=n.namespace?new RegExp("(^|\\.)"+b.join("\\.(?:.*\\.|)")+"(\\.|$)"):null,h=y.indexOf(":")<0?"on"+y:"";if(!s){u=v.cache;for(f in u)u[f].events&&u[f].events[y]&&v.event.trigger(n,r,u[f].handle.elem,!0);return}n.result=t,n.target||(n.target=s),r=r!=null?v.makeArray(r):[],r.unshift(n),p=v.event.special[y]||{};if(p.trigger&&p.trigger.apply(s,r)===!1)return;m=[[s,p.bindType||y]];if(!o&&!p.noBubble&&!v.isWindow(s)){g=p.delegateType||y,l=Y.test(g+y)?s:s.parentNode;for(c=s;l;l=l.parentNode)m.push([l,g]),c=l;c===(s.ownerDocument||i)&&m.push([c.defaultView||c.parentWindow||e,g])}for(f=0;f<m.length&&!n.isPropagationStopped();f++)l=m[f][0],n.type=m[f][1],d=(v._data(l,"events")||{})[n.type]&&v._data(l,"handle"),d&&d.apply(l,r),d=h&&l[h],d&&v.acceptData(l)&&d.apply&&d.apply(l,r)===!1&&n.preventDefault();return n.type=y,!o&&!n.isDefaultPrevented()&&(!p._default||p._default.apply(s.ownerDocument,r)===!1)&&(y!=="click"||!v.nodeName(s,"a"))&&v.acceptData(s)&&h&&s[y]&&(y!=="focus"&&y!=="blur"||n.target.offsetWidth!==0)&&!v.isWindow(s)&&(c=s[h],c&&(s[h]=null),v.event.triggered=y,s[y](),v.event.triggered=t,c&&(s[h]=c)),n.result}return},dispatch:function(n){n=v.event.fix(n||e.event);var r,i,s,o,u,a,f,c,h,p,d=(v._data(this,"events")||{})[n.type]||[],m=d.delegateCount,g=l.call(arguments),y=!n.exclusive&&!n.namespace,b=v.event.special[n.type]||{},w=[];g[0]=n,n.delegateTarget=this;if(b.preDispatch&&b.preDispatch.call(this,n)===!1)return;if(m&&(!n.button||n.type!=="click"))for(s=n.target;s!=this;s=s.parentNode||this)if(s.disabled!==!0||n.type!=="click"){u={},f=[];for(r=0;r<m;r++)c=d[r],h=c.selector,u[h]===t&&(u[h]=c.needsContext?v(h,this).index(s)>=0:v.find(h,this,null,[s]).length),u[h]&&f.push(c);f.length&&w.push({elem:s,matches:f})}d.length>m&&w.push({elem:this,matches:d.slice(m)});for(r=0;r<w.length&&!n.isPropagationStopped();r++){a=w[r],n.currentTarget=a.elem;for(i=0;i<a.matches.length&&!n.isImmediatePropagationStopped();i++){c=a.matches[i];if(y||!n.namespace&&!c.namespace||n.namespace_re&&n.namespace_re.test(c.namespace))n.data=c.data,n.handleObj=c,o=((v.event.special[c.origType]||{}).handle||c.handler).apply(a.elem,g),o!==t&&(n.result=o,o===!1&&(n.preventDefault(),n.stopPropagation()))}}return b.postDispatch&&b.postDispatch.call(this,n),n.result},props:"attrChange attrName relatedNode srcElement altKey bubbles cancelable ctrlKey currentTarget eventPhase metaKey relatedTarget shiftKey target timeStamp view which".split(" "),fixHooks:{},keyHooks:{props:"char charCode key keyCode".split(" "),filter:function(e,t){return e.which==null&&(e.which=t.charCode!=null?t.charCode:t.keyCode),e}},mouseHooks:{props:"button buttons clientX clientY fromElement offsetX offsetY pageX pageY screenX screenY toElement".split(" "),filter:function(e,n){var r,s,o,u=n.button,a=n.fromElement;return e.pageX==null&&n.clientX!=null&&(r=e.target.ownerDocument||i,s=r.documentElement,o=r.body,e.pageX=n.clientX+(s&&s.scrollLeft||o&&o.scrollLeft||0)-(s&&s.clientLeft||o&&o.clientLeft||0),e.pageY=n.clientY+(s&&s.scrollTop||o&&o.scrollTop||0)-(s&&s.clientTop||o&&o.clientTop||0)),!e.relatedTarget&&a&&(e.relatedTarget=a===e.target?n.toElement:a),!e.which&&u!==t&&(e.which=u&1?1:u&2?3:u&4?2:0),e}},fix:function(e){if(e[v.expando])return e;var t,n,r=e,s=v.event.fixHooks[e.type]||{},o=s.props?this.props.concat(s.props):this.props;e=v.Event(r);for(t=o.length;t;)n=o[--t],e[n]=r[n];return e.target||(e.target=r.srcElement||i),e.target.nodeType===3&&(e.target=e.target.parentNode),e.metaKey=!!e.metaKey,s.filter?s.filter(e,r):e},special:{load:{noBubble:!0},focus:{delegateType:"focusin"},blur:{delegateType:"focusout"},beforeunload:{setup:function(e,t,n){v.isWindow(this)&&(this.onbeforeunload=n)},teardown:function(e,t){this.onbeforeunload===t&&(this.onbeforeunload=null)}}},simulate:function(e,t,n,r){var i=v.extend(new v.Event,n,{type:e,isSimulated:!0,originalEvent:{}});r?v.event.trigger(i,null,t):v.event.dispatch.call(t,i),i.isDefaultPrevented()&&n.preventDefault()}},v.event.handle=v.event.dispatch,v.removeEvent=i.removeEventListener?function(e,t,n){e.removeEventListener&&e.removeEventListener(t,n,!1)}:function(e,t,n){var r="on"+t;e.detachEvent&&(typeof e[r]=="undefined"&&(e[r]=null),e.detachEvent(r,n))},v.Event=function(e,t){if(!(this instanceof v.Event))return new v.Event(e,t);e&&e.type?(this.originalEvent=e,this.type=e.type,this.isDefaultPrevented=e.defaultPrevented||e.returnValue===!1||e.getPreventDefault&&e.getPreventDefault()?tt:et):this.type=e,t&&v.extend(this,t),this.timeStamp=e&&e.timeStamp||v.now(),this[v.expando]=!0},v.Event.prototype={preventDefault:function(){this.isDefaultPrevented=tt;var e=this.originalEvent;if(!e)return;e.preventDefault?e.preventDefault():e.returnValue=!1},stopPropagation:function(){this.isPropagationStopped=tt;var e=this.originalEvent;if(!e)return;e.stopPropagation&&e.stopPropagation(),e.cancelBubble=!0},stopImmediatePropagation:function(){this.isImmediatePropagationStopped=tt,this.stopPropagation()},isDefaultPrevented:et,isPropagationStopped:et,isImmediatePropagationStopped:et},v.each({mouseenter:"mouseover",mouseleave:"mouseout"},function(e,t){v.event.special[e]={delegateType:t,bindType:t,handle:function(e){var n,r=this,i=e.relatedTarget,s=e.handleObj,o=s.selector;if(!i||i!==r&&!v.contains(r,i))e.type=s.origType,n=s.handler.apply(this,arguments),e.type=t;return n}}}),v.support.submitBubbles||(v.event.special.submit={setup:function(){if(v.nodeName(this,"form"))return!1;v.event.add(this,"click._submit keypress._submit",function(e){var n=e.target,r=v.nodeName(n,"input")||v.nodeName(n,"button")?n.form:t;r&&!v._data(r,"_submit_attached")&&(v.event.add(r,"submit._submit",function(e){e._submit_bubble=!0}),v._data(r,"_submit_attached",!0))})},postDispatch:function(e){e._submit_bubble&&(delete e._submit_bubble,this.parentNode&&!e.isTrigger&&v.event.simulate("submit",this.parentNode,e,!0))},teardown:function(){if(v.nodeName(this,"form"))return!1;v.event.remove(this,"._submit")}}),v.support.changeBubbles||(v.event.special.change={setup:function(){if($.test(this.nodeName)){if(this.type==="checkbox"||this.type==="radio")v.event.add(this,"propertychange._change",function(e){e.originalEvent.propertyName==="checked"&&(this._just_changed=!0)}),v.event.add(this,"click._change",function(e){this._just_changed&&!e.isTrigger&&(this._just_changed=!1),v.event.simulate("change",this,e,!0)});return!1}v.event.add(this,"beforeactivate._change",function(e){var t=e.target;$.test(t.nodeName)&&!v._data(t,"_change_attached")&&(v.event.add(t,"change._change",function(e){this.parentNode&&!e.isSimulated&&!e.isTrigger&&v.event.simulate("change",this.parentNode,e,!0)}),v._data(t,"_change_attached",!0))})},handle:function(e){var t=e.target;if(this!==t||e.isSimulated||e.isTrigger||t.type!=="radio"&&t.type!=="checkbox")return e.handleObj.handler.apply(this,arguments)},teardown:function(){return v.event.remove(this,"._change"),!$.test(this.nodeName)}}),v.support.focusinBubbles||v.each({focus:"focusin",blur:"focusout"},function(e,t){var n=0,r=function(e){v.event.simulate(t,e.target,v.event.fix(e),!0)};v.event.special[t]={setup:function(){n++===0&&i.addEventListener(e,r,!0)},teardown:function(){--n===0&&i.removeEventListener(e,r,!0)}}}),v.fn.extend({on:function(e,n,r,i,s){var o,u;if(typeof e=="object"){typeof n!="string"&&(r=r||n,n=t);for(u in e)this.on(u,n,r,e[u],s);return this}r==null&&i==null?(i=n,r=n=t):i==null&&(typeof n=="string"?(i=r,r=t):(i=r,r=n,n=t));if(i===!1)i=et;else if(!i)return this;return s===1&&(o=i,i=function(e){return v().off(e),o.apply(this,arguments)},i.guid=o.guid||(o.guid=v.guid++)),this.each(function(){v.event.add(this,e,i,r,n)})},one:function(e,t,n,r){return this.on(e,t,n,r,1)},off:function(e,n,r){var i,s;if(e&&e.preventDefault&&e.handleObj)return i=e.handleObj,v(e.delegateTarget).off(i.namespace?i.origType+"."+i.namespace:i.origType,i.selector,i.handler),this;if(typeof e=="object"){for(s in e)this.off(s,n,e[s]);return this}if(n===!1||typeof n=="function")r=n,n=t;return r===!1&&(r=et),this.each(function(){v.event.remove(this,e,r,n)})},bind:function(e,t,n){return this.on(e,null,t,n)},unbind:function(e,t){return this.off(e,null,t)},live:function(e,t,n){return v(this.context).on(e,this.selector,t,n),this},die:function(e,t){return v(this.context).off(e,this.selector||"**",t),this},delegate:function(e,t,n,r){return this.on(t,e,n,r)},undelegate:function(e,t,n){return arguments.length===1?this.off(e,"**"):this.off(t,e||"**",n)},trigger:function(e,t){return this.each(function(){v.event.trigger(e,t,this)})},triggerHandler:function(e,t){if(this[0])return v.event.trigger(e,t,this[0],!0)},toggle:function(e){var t=arguments,n=e.guid||v.guid++,r=0,i=function(n){var i=(v._data(this,"lastToggle"+e.guid)||0)%r;return v._data(this,"lastToggle"+e.guid,i+1),n.preventDefault(),t[i].apply(this,arguments)||!1};i.guid=n;while(r<t.length)t[r++].guid=n;return this.click(i)},hover:function(e,t){return this.mouseenter(e).mouseleave(t||e)}}),v.each("blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error contextmenu".split(" "),function(e,t){v.fn[t]=function(e,n){return n==null&&(n=e,e=null),arguments.length>0?this.on(t,null,e,n):this.trigger(t)},Q.test(t)&&(v.event.fixHooks[t]=v.event.keyHooks),G.test(t)&&(v.event.fixHooks[t]=v.event.mouseHooks)}),function(e,t){function nt(e,t,n,r){n=n||[],t=t||g;var i,s,a,f,l=t.nodeType;if(!e||typeof e!="string")return n;if(l!==1&&l!==9)return[];a=o(t);if(!a&&!r)if(i=R.exec(e))if(f=i[1]){if(l===9){s=t.getElementById(f);if(!s||!s.parentNode)return n;if(s.id===f)return n.push(s),n}else if(t.ownerDocument&&(s=t.ownerDocument.getElementById(f))&&u(t,s)&&s.id===f)return n.push(s),n}else{if(i[2])return S.apply(n,x.call(t.getElementsByTagName(e),0)),n;if((f=i[3])&&Z&&t.getElementsByClassName)return S.apply(n,x.call(t.getElementsByClassName(f),0)),n}return vt(e.replace(j,"$1"),t,n,r,a)}function rt(e){return function(t){var n=t.nodeName.toLowerCase();return n==="input"&&t.type===e}}function it(e){return function(t){var n=t.nodeName.toLowerCase();return(n==="input"||n==="button")&&t.type===e}}function st(e){return N(function(t){return t=+t,N(function(n,r){var i,s=e([],n.length,t),o=s.length;while(o--)n[i=s[o]]&&(n[i]=!(r[i]=n[i]))})})}function ot(e,t,n){if(e===t)return n;var r=e.nextSibling;while(r){if(r===t)return-1;r=r.nextSibling}return 1}function ut(e,t){var n,r,s,o,u,a,f,l=L[d][e+" "];if(l)return t?0:l.slice(0);u=e,a=[],f=i.preFilter;while(u){if(!n||(r=F.exec(u)))r&&(u=u.slice(r[0].length)||u),a.push(s=[]);n=!1;if(r=I.exec(u))s.push(n=new m(r.shift())),u=u.slice(n.length),n.type=r[0].replace(j," ");for(o in i.filter)(r=J[o].exec(u))&&(!f[o]||(r=f[o](r)))&&(s.push(n=new m(r.shift())),u=u.slice(n.length),n.type=o,n.matches=r);if(!n)break}return t?u.length:u?nt.error(e):L(e,a).slice(0)}function at(e,t,r){var i=t.dir,s=r&&t.dir==="parentNode",o=w++;return t.first?function(t,n,r){while(t=t[i])if(s||t.nodeType===1)return e(t,n,r)}:function(t,r,u){if(!u){var a,f=b+" "+o+" ",l=f+n;while(t=t[i])if(s||t.nodeType===1){if((a=t[d])===l)return t.sizset;if(typeof a=="string"&&a.indexOf(f)===0){if(t.sizset)return t}else{t[d]=l;if(e(t,r,u))return t.sizset=!0,t;t.sizset=!1}}}else while(t=t[i])if(s||t.nodeType===1)if(e(t,r,u))return t}}function ft(e){return e.length>1?function(t,n,r){var i=e.length;while(i--)if(!e[i](t,n,r))return!1;return!0}:e[0]}function lt(e,t,n,r,i){var s,o=[],u=0,a=e.length,f=t!=null;for(;u<a;u++)if(s=e[u])if(!n||n(s,r,i))o.push(s),f&&t.push(u);return o}function ct(e,t,n,r,i,s){return r&&!r[d]&&(r=ct(r)),i&&!i[d]&&(i=ct(i,s)),N(function(s,o,u,a){var f,l,c,h=[],p=[],d=o.length,v=s||dt(t||"*",u.nodeType?[u]:u,[]),m=e&&(s||!t)?lt(v,h,e,u,a):v,g=n?i||(s?e:d||r)?[]:o:m;n&&n(m,g,u,a);if(r){f=lt(g,p),r(f,[],u,a),l=f.length;while(l--)if(c=f[l])g[p[l]]=!(m[p[l]]=c)}if(s){if(i||e){if(i){f=[],l=g.length;while(l--)(c=g[l])&&f.push(m[l]=c);i(null,g=[],f,a)}l=g.length;while(l--)(c=g[l])&&(f=i?T.call(s,c):h[l])>-1&&(s[f]=!(o[f]=c))}}else g=lt(g===o?g.splice(d,g.length):g),i?i(null,o,g,a):S.apply(o,g)})}function ht(e){var t,n,r,s=e.length,o=i.relative[e[0].type],u=o||i.relative[" "],a=o?1:0,f=at(function(e){return e===t},u,!0),l=at(function(e){return T.call(t,e)>-1},u,!0),h=[function(e,n,r){return!o&&(r||n!==c)||((t=n).nodeType?f(e,n,r):l(e,n,r))}];for(;a<s;a++)if(n=i.relative[e[a].type])h=[at(ft(h),n)];else{n=i.filter[e[a].type].apply(null,e[a].matches);if(n[d]){r=++a;for(;r<s;r++)if(i.relative[e[r].type])break;return ct(a>1&&ft(h),a>1&&e.slice(0,a-1).join("").replace(j,"$1"),n,a<r&&ht(e.slice(a,r)),r<s&&ht(e=e.slice(r)),r<s&&e.join(""))}h.push(n)}return ft(h)}function pt(e,t){var r=t.length>0,s=e.length>0,o=function(u,a,f,l,h){var p,d,v,m=[],y=0,w="0",x=u&&[],T=h!=null,N=c,C=u||s&&i.find.TAG("*",h&&a.parentNode||a),k=b+=N==null?1:Math.E;T&&(c=a!==g&&a,n=o.el);for(;(p=C[w])!=null;w++){if(s&&p){for(d=0;v=e[d];d++)if(v(p,a,f)){l.push(p);break}T&&(b=k,n=++o.el)}r&&((p=!v&&p)&&y--,u&&x.push(p))}y+=w;if(r&&w!==y){for(d=0;v=t[d];d++)v(x,m,a,f);if(u){if(y>0)while(w--)!x[w]&&!m[w]&&(m[w]=E.call(l));m=lt(m)}S.apply(l,m),T&&!u&&m.length>0&&y+t.length>1&&nt.uniqueSort(l)}return T&&(b=k,c=N),x};return o.el=0,r?N(o):o}function dt(e,t,n){var r=0,i=t.length;for(;r<i;r++)nt(e,t[r],n);return n}function vt(e,t,n,r,s){var o,u,f,l,c,h=ut(e),p=h.length;if(!r&&h.length===1){u=h[0]=h[0].slice(0);if(u.length>2&&(f=u[0]).type==="ID"&&t.nodeType===9&&!s&&i.relative[u[1].type]){t=i.find.ID(f.matches[0].replace($,""),t,s)[0];if(!t)return n;e=e.slice(u.shift().length)}for(o=J.POS.test(e)?-1:u.length-1;o>=0;o--){f=u[o];if(i.relative[l=f.type])break;if(c=i.find[l])if(r=c(f.matches[0].replace($,""),z.test(u[0].type)&&t.parentNode||t,s)){u.splice(o,1),e=r.length&&u.join("");if(!e)return S.apply(n,x.call(r,0)),n;break}}}return a(e,h)(r,t,s,n,z.test(e)),n}function mt(){}var n,r,i,s,o,u,a,f,l,c,h=!0,p="undefined",d=("sizcache"+Math.random()).replace(".",""),m=String,g=e.document,y=g.documentElement,b=0,w=0,E=[].pop,S=[].push,x=[].slice,T=[].indexOf||function(e){var t=0,n=this.length;for(;t<n;t++)if(this[t]===e)return t;return-1},N=function(e,t){return e[d]=t==null||t,e},C=function(){var e={},t=[];return N(function(n,r){return t.push(n)>i.cacheLength&&delete e[t.shift()],e[n+" "]=r},e)},k=C(),L=C(),A=C(),O="[\\x20\\t\\r\\n\\f]",M="(?:\\\\.|[-\\w]|[^\\x00-\\xa0])+",_=M.replace("w","w#"),D="([*^$|!~]?=)",P="\\["+O+"*("+M+")"+O+"*(?:"+D+O+"*(?:(['\"])((?:\\\\.|[^\\\\])*?)\\3|("+_+")|)|)"+O+"*\\]",H=":("+M+")(?:\\((?:(['\"])((?:\\\\.|[^\\\\])*?)\\2|([^()[\\]]*|(?:(?:"+P+")|[^:]|\\\\.)*|.*))\\)|)",B=":(even|odd|eq|gt|lt|nth|first|last)(?:\\("+O+"*((?:-\\d)?\\d*)"+O+"*\\)|)(?=[^-]|$)",j=new RegExp("^"+O+"+|((?:^|[^\\\\])(?:\\\\.)*)"+O+"+$","g"),F=new RegExp("^"+O+"*,"+O+"*"),I=new RegExp("^"+O+"*([\\x20\\t\\r\\n\\f>+~])"+O+"*"),q=new RegExp(H),R=/^(?:#([\w\-]+)|(\w+)|\.([\w\-]+))$/,U=/^:not/,z=/[\x20\t\r\n\f]*[+~]/,W=/:not\($/,X=/h\d/i,V=/input|select|textarea|button/i,$=/\\(?!\\)/g,J={ID:new RegExp("^#("+M+")"),CLASS:new RegExp("^\\.("+M+")"),NAME:new RegExp("^\\[name=['\"]?("+M+")['\"]?\\]"),TAG:new RegExp("^("+M.replace("w","w*")+")"),ATTR:new RegExp("^"+P),PSEUDO:new RegExp("^"+H),POS:new RegExp(B,"i"),CHILD:new RegExp("^:(only|nth|first|last)-child(?:\\("+O+"*(even|odd|(([+-]|)(\\d*)n|)"+O+"*(?:([+-]|)"+O+"*(\\d+)|))"+O+"*\\)|)","i"),needsContext:new RegExp("^"+O+"*[>+~]|"+B,"i")},K=function(e){var t=g.createElement("div");try{return e(t)}catch(n){return!1}finally{t=null}},Q=K(function(e){return e.appendChild(g.createComment("")),!e.getElementsByTagName("*").length}),G=K(function(e){return e.innerHTML="<a href='#'></a>",e.firstChild&&typeof e.firstChild.getAttribute!==p&&e.firstChild.getAttribute("href")==="#"}),Y=K(function(e){e.innerHTML="<select></select>";var t=typeof e.lastChild.getAttribute("multiple");return t!=="boolean"&&t!=="string"}),Z=K(function(e){return e.innerHTML="<div class='hidden e'></div><div class='hidden'></div>",!e.getElementsByClassName||!e.getElementsByClassName("e").length?!1:(e.lastChild.className="e",e.getElementsByClassName("e").length===2)}),et=K(function(e){e.id=d+0,e.innerHTML="<a name='"+d+"'></a><div name='"+d+"'></div>",y.insertBefore(e,y.firstChild);var t=g.getElementsByName&&g.getElementsByName(d).length===2+g.getElementsByName(d+0).length;return r=!g.getElementById(d),y.removeChild(e),t});try{x.call(y.childNodes,0)[0].nodeType}catch(tt){x=function(e){var t,n=[];for(;t=this[e];e++)n.push(t);return n}}nt.matches=function(e,t){return nt(e,null,null,t)},nt.matchesSelector=function(e,t){return nt(t,null,null,[e]).length>0},s=nt.getText=function(e){var t,n="",r=0,i=e.nodeType;if(i){if(i===1||i===9||i===11){if(typeof e.textContent=="string")return e.textContent;for(e=e.firstChild;e;e=e.nextSibling)n+=s(e)}else if(i===3||i===4)return e.nodeValue}else for(;t=e[r];r++)n+=s(t);return n},o=nt.isXML=function(e){var t=e&&(e.ownerDocument||e).documentElement;return t?t.nodeName!=="HTML":!1},u=nt.contains=y.contains?function(e,t){var n=e.nodeType===9?e.documentElement:e,r=t&&t.parentNode;return e===r||!!(r&&r.nodeType===1&&n.contains&&n.contains(r))}:y.compareDocumentPosition?function(e,t){return t&&!!(e.compareDocumentPosition(t)&16)}:function(e,t){while(t=t.parentNode)if(t===e)return!0;return!1},nt.attr=function(e,t){var n,r=o(e);return r||(t=t.toLowerCase()),(n=i.attrHandle[t])?n(e):r||Y?e.getAttribute(t):(n=e.getAttributeNode(t),n?typeof e[t]=="boolean"?e[t]?t:null:n.specified?n.value:null:null)},i=nt.selectors={cacheLength:50,createPseudo:N,match:J,attrHandle:G?{}:{href:function(e){return e.getAttribute("href",2)},type:function(e){return e.getAttribute("type")}},find:{ID:r?function(e,t,n){if(typeof t.getElementById!==p&&!n){var r=t.getElementById(e);return r&&r.parentNode?[r]:[]}}:function(e,n,r){if(typeof n.getElementById!==p&&!r){var i=n.getElementById(e);return i?i.id===e||typeof i.getAttributeNode!==p&&i.getAttributeNode("id").value===e?[i]:t:[]}},TAG:Q?function(e,t){if(typeof t.getElementsByTagName!==p)return t.getElementsByTagName(e)}:function(e,t){var n=t.getElementsByTagName(e);if(e==="*"){var r,i=[],s=0;for(;r=n[s];s++)r.nodeType===1&&i.push(r);return i}return n},NAME:et&&function(e,t){if(typeof t.getElementsByName!==p)return t.getElementsByName(name)},CLASS:Z&&function(e,t,n){if(typeof t.getElementsByClassName!==p&&!n)return t.getElementsByClassName(e)}},relative:{">":{dir:"parentNode",first:!0}," ":{dir:"parentNode"},"+":{dir:"previousSibling",first:!0},"~":{dir:"previousSibling"}},preFilter:{ATTR:function(e){return e[1]=e[1].replace($,""),e[3]=(e[4]||e[5]||"").replace($,""),e[2]==="~="&&(e[3]=" "+e[3]+" "),e.slice(0,4)},CHILD:function(e){return e[1]=e[1].toLowerCase(),e[1]==="nth"?(e[2]||nt.error(e[0]),e[3]=+(e[3]?e[4]+(e[5]||1):2*(e[2]==="even"||e[2]==="odd")),e[4]=+(e[6]+e[7]||e[2]==="odd")):e[2]&&nt.error(e[0]),e},PSEUDO:function(e){var t,n;if(J.CHILD.test(e[0]))return null;if(e[3])e[2]=e[3];else if(t=e[4])q.test(t)&&(n=ut(t,!0))&&(n=t.indexOf(")",t.length-n)-t.length)&&(t=t.slice(0,n),e[0]=e[0].slice(0,n)),e[2]=t;return e.slice(0,3)}},filter:{ID:r?function(e){return e=e.replace($,""),function(t){return t.getAttribute("id")===e}}:function(e){return e=e.replace($,""),function(t){var n=typeof t.getAttributeNode!==p&&t.getAttributeNode("id");return n&&n.value===e}},TAG:function(e){return e==="*"?function(){return!0}:(e=e.replace($,"").toLowerCase(),function(t){return t.nodeName&&t.nodeName.toLowerCase()===e})},CLASS:function(e){var t=k[d][e+" "];return t||(t=new RegExp("(^|"+O+")"+e+"("+O+"|$)"))&&k(e,function(e){return t.test(e.className||typeof e.getAttribute!==p&&e.getAttribute("class")||"")})},ATTR:function(e,t,n){return function(r,i){var s=nt.attr(r,e);return s==null?t==="!=":t?(s+="",t==="="?s===n:t==="!="?s!==n:t==="^="?n&&s.indexOf(n)===0:t==="*="?n&&s.indexOf(n)>-1:t==="$="?n&&s.substr(s.length-n.length)===n:t==="~="?(" "+s+" ").indexOf(n)>-1:t==="|="?s===n||s.substr(0,n.length+1)===n+"-":!1):!0}},CHILD:function(e,t,n,r){return e==="nth"?function(e){var t,i,s=e.parentNode;if(n===1&&r===0)return!0;if(s){i=0;for(t=s.firstChild;t;t=t.nextSibling)if(t.nodeType===1){i++;if(e===t)break}}return i-=r,i===n||i%n===0&&i/n>=0}:function(t){var n=t;switch(e){case"only":case"first":while(n=n.previousSibling)if(n.nodeType===1)return!1;if(e==="first")return!0;n=t;case"last":while(n=n.nextSibling)if(n.nodeType===1)return!1;return!0}}},PSEUDO:function(e,t){var n,r=i.pseudos[e]||i.setFilters[e.toLowerCase()]||nt.error("unsupported pseudo: "+e);return r[d]?r(t):r.length>1?(n=[e,e,"",t],i.setFilters.hasOwnProperty(e.toLowerCase())?N(function(e,n){var i,s=r(e,t),o=s.length;while(o--)i=T.call(e,s[o]),e[i]=!(n[i]=s[o])}):function(e){return r(e,0,n)}):r}},pseudos:{not:N(function(e){var t=[],n=[],r=a(e.replace(j,"$1"));return r[d]?N(function(e,t,n,i){var s,o=r(e,null,i,[]),u=e.length;while(u--)if(s=o[u])e[u]=!(t[u]=s)}):function(e,i,s){return t[0]=e,r(t,null,s,n),!n.pop()}}),has:N(function(e){return function(t){return nt(e,t).length>0}}),contains:N(function(e){return function(t){return(t.textContent||t.innerText||s(t)).indexOf(e)>-1}}),enabled:function(e){return e.disabled===!1},disabled:function(e){return e.disabled===!0},checked:function(e){var t=e.nodeName.toLowerCase();return t==="input"&&!!e.checked||t==="option"&&!!e.selected},selected:function(e){return e.parentNode&&e.parentNode.selectedIndex,e.selected===!0},parent:function(e){return!i.pseudos.empty(e)},empty:function(e){var t;e=e.firstChild;while(e){if(e.nodeName>"@"||(t=e.nodeType)===3||t===4)return!1;e=e.nextSibling}return!0},header:function(e){return X.test(e.nodeName)},text:function(e){var t,n;return e.nodeName.toLowerCase()==="input"&&(t=e.type)==="text"&&((n=e.getAttribute("type"))==null||n.toLowerCase()===t)},radio:rt("radio"),checkbox:rt("checkbox"),file:rt("file"),password:rt("password"),image:rt("image"),submit:it("submit"),reset:it("reset"),button:function(e){var t=e.nodeName.toLowerCase();return t==="input"&&e.type==="button"||t==="button"},input:function(e){return V.test(e.nodeName)},focus:function(e){var t=e.ownerDocument;return e===t.activeElement&&(!t.hasFocus||t.hasFocus())&&!!(e.type||e.href||~e.tabIndex)},active:function(e){return e===e.ownerDocument.activeElement},first:st(function(){return[0]}),last:st(function(e,t){return[t-1]}),eq:st(function(e,t,n){return[n<0?n+t:n]}),even:st(function(e,t){for(var n=0;n<t;n+=2)e.push(n);return e}),odd:st(function(e,t){for(var n=1;n<t;n+=2)e.push(n);return e}),lt:st(function(e,t,n){for(var r=n<0?n+t:n;--r>=0;)e.push(r);return e}),gt:st(function(e,t,n){for(var r=n<0?n+t:n;++r<t;)e.push(r);return e})}},f=y.compareDocumentPosition?function(e,t){return e===t?(l=!0,0):(!e.compareDocumentPosition||!t.compareDocumentPosition?e.compareDocumentPosition:e.compareDocumentPosition(t)&4)?-1:1}:function(e,t){if(e===t)return l=!0,0;if(e.sourceIndex&&t.sourceIndex)return e.sourceIndex-t.sourceIndex;var n,r,i=[],s=[],o=e.parentNode,u=t.parentNode,a=o;if(o===u)return ot(e,t);if(!o)return-1;if(!u)return 1;while(a)i.unshift(a),a=a.parentNode;a=u;while(a)s.unshift(a),a=a.parentNode;n=i.length,r=s.length;for(var f=0;f<n&&f<r;f++)if(i[f]!==s[f])return ot(i[f],s[f]);return f===n?ot(e,s[f],-1):ot(i[f],t,1)},[0,0].sort(f),h=!l,nt.uniqueSort=function(e){var t,n=[],r=1,i=0;l=h,e.sort(f);if(l){for(;t=e[r];r++)t===e[r-1]&&(i=n.push(r));while(i--)e.splice(n[i],1)}return e},nt.error=function(e){throw new Error("Syntax error, unrecognized expression: "+e)},a=nt.compile=function(e,t){var n,r=[],i=[],s=A[d][e+" "];if(!s){t||(t=ut(e)),n=t.length;while(n--)s=ht(t[n]),s[d]?r.push(s):i.push(s);s=A(e,pt(i,r))}return s},g.querySelectorAll&&function(){var e,t=vt,n=/'|\\/g,r=/\=[\x20\t\r\n\f]*([^'"\]]*)[\x20\t\r\n\f]*\]/g,i=[":focus"],s=[":active"],u=y.matchesSelector||y.mozMatchesSelector||y.webkitMatchesSelector||y.oMatchesSelector||y.msMatchesSelector;K(function(e){e.innerHTML="<select><option selected=''></option></select>",e.querySelectorAll("[selected]").length||i.push("\\["+O+"*(?:checked|disabled|ismap|multiple|readonly|selected|value)"),e.querySelectorAll(":checked").length||i.push(":checked")}),K(function(e){e.innerHTML="<p test=''></p>",e.querySelectorAll("[test^='']").length&&i.push("[*^$]="+O+"*(?:\"\"|'')"),e.innerHTML="<input type='hidden'/>",e.querySelectorAll(":enabled").length||i.push(":enabled",":disabled")}),i=new RegExp(i.join("|")),vt=function(e,r,s,o,u){if(!o&&!u&&!i.test(e)){var a,f,l=!0,c=d,h=r,p=r.nodeType===9&&e;if(r.nodeType===1&&r.nodeName.toLowerCase()!=="object"){a=ut(e),(l=r.getAttribute("id"))?c=l.replace(n,"\\$&"):r.setAttribute("id",c),c="[id='"+c+"'] ",f=a.length;while(f--)a[f]=c+a[f].join("");h=z.test(e)&&r.parentNode||r,p=a.join(",")}if(p)try{return S.apply(s,x.call(h.querySelectorAll(p),0)),s}catch(v){}finally{l||r.removeAttribute("id")}}return t(e,r,s,o,u)},u&&(K(function(t){e=u.call(t,"div");try{u.call(t,"[test!='']:sizzle"),s.push("!=",H)}catch(n){}}),s=new RegExp(s.join("|")),nt.matchesSelector=function(t,n){n=n.replace(r,"='$1']");if(!o(t)&&!s.test(n)&&!i.test(n))try{var a=u.call(t,n);if(a||e||t.document&&t.document.nodeType!==11)return a}catch(f){}return nt(n,null,null,[t]).length>0})}(),i.pseudos.nth=i.pseudos.eq,i.filters=mt.prototype=i.pseudos,i.setFilters=new mt,nt.attr=v.attr,v.find=nt,v.expr=nt.selectors,v.expr[":"]=v.expr.pseudos,v.unique=nt.uniqueSort,v.text=nt.getText,v.isXMLDoc=nt.isXML,v.contains=nt.contains}(e);var nt=/Until$/,rt=/^(?:parents|prev(?:Until|All))/,it=/^.[^:#\[\.,]*$/,st=v.expr.match.needsContext,ot={children:!0,contents:!0,next:!0,prev:!0};v.fn.extend({find:function(e){var t,n,r,i,s,o,u=this;if(typeof e!="string")return v(e).filter(function(){for(t=0,n=u.length;t<n;t++)if(v.contains(u[t],this))return!0});o=this.pushStack("","find",e);for(t=0,n=this.length;t<n;t++){r=o.length,v.find(e,this[t],o);if(t>0)for(i=r;i<o.length;i++)for(s=0;s<r;s++)if(o[s]===o[i]){o.splice(i--,1);break}}return o},has:function(e){var t,n=v(e,this),r=n.length;return this.filter(function(){for(t=0;t<r;t++)if(v.contains(this,n[t]))return!0})},not:function(e){return this.pushStack(ft(this,e,!1),"not",e)},filter:function(e){return this.pushStack(ft(this,e,!0),"filter",e)},is:function(e){return!!e&&(typeof e=="string"?st.test(e)?v(e,this.context).index(this[0])>=0:v.filter(e,this).length>0:this.filter(e).length>0)},closest:function(e,t){var n,r=0,i=this.length,s=[],o=st.test(e)||typeof e!="string"?v(e,t||this.context):0;for(;r<i;r++){n=this[r];while(n&&n.ownerDocument&&n!==t&&n.nodeType!==11){if(o?o.index(n)>-1:v.find.matchesSelector(n,e)){s.push(n);break}n=n.parentNode}}return s=s.length>1?v.unique(s):s,this.pushStack(s,"closest",e)},index:function(e){return e?typeof e=="string"?v.inArray(this[0],v(e)):v.inArray(e.jquery?e[0]:e,this):this[0]&&this[0].parentNode?this.prevAll().length:-1},add:function(e,t){var n=typeof e=="string"?v(e,t):v.makeArray(e&&e.nodeType?[e]:e),r=v.merge(this.get(),n);return this.pushStack(ut(n[0])||ut(r[0])?r:v.unique(r))},addBack:function(e){return this.add(e==null?this.prevObject:this.prevObject.filter(e))}}),v.fn.andSelf=v.fn.addBack,v.each({parent:function(e){var t=e.parentNode;return t&&t.nodeType!==11?t:null},parents:function(e){return v.dir(e,"parentNode")},parentsUntil:function(e,t,n){return v.dir(e,"parentNode",n)},next:function(e){return at(e,"nextSibling")},prev:function(e){return at(e,"previousSibling")},nextAll:function(e){return v.dir(e,"nextSibling")},prevAll:function(e){return v.dir(e,"previousSibling")},nextUntil:function(e,t,n){return v.dir(e,"nextSibling",n)},prevUntil:function(e,t,n){return v.dir(e,"previousSibling",n)},siblings:function(e){return v.sibling((e.parentNode||{}).firstChild,e)},children:function(e){return v.sibling(e.firstChild)},contents:function(e){return v.nodeName(e,"iframe")?e.contentDocument||e.contentWindow.document:v.merge([],e.childNodes)}},function(e,t){v.fn[e]=function(n,r){var i=v.map(this,t,n);return nt.test(e)||(r=n),r&&typeof r=="string"&&(i=v.filter(r,i)),i=this.length>1&&!ot[e]?v.unique(i):i,this.length>1&&rt.test(e)&&(i=i.reverse()),this.pushStack(i,e,l.call(arguments).join(","))}}),v.extend({filter:function(e,t,n){return n&&(e=":not("+e+")"),t.length===1?v.find.matchesSelector(t[0],e)?[t[0]]:[]:v.find.matches(e,t)},dir:function(e,n,r){var i=[],s=e[n];while(s&&s.nodeType!==9&&(r===t||s.nodeType!==1||!v(s).is(r)))s.nodeType===1&&i.push(s),s=s[n];return i},sibling:function(e,t){var n=[];for(;e;e=e.nextSibling)e.nodeType===1&&e!==t&&n.push(e);return n}});var ct="abbr|article|aside|audio|bdi|canvas|data|datalist|details|figcaption|figure|footer|header|hgroup|mark|meter|nav|output|progress|section|summary|time|video",ht=/ jQuery\d+="(?:null|\d+)"/g,pt=/^\s+/,dt=/<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/gi,vt=/<([\w:]+)/,mt=/<tbody/i,gt=/<|&#?\w+;/,yt=/<(?:script|style|link)/i,bt=/<(?:script|object|embed|option|style)/i,wt=new RegExp("<(?:"+ct+")[\\s/>]","i"),Et=/^(?:checkbox|radio)$/,St=/checked\s*(?:[^=]|=\s*.checked.)/i,xt=/\/(java|ecma)script/i,Tt=/^\s*<!(?:\[CDATA\[|\-\-)|[\]\-]{2}>\s*$/g,Nt={option:[1,"<select multiple='multiple'>","</select>"],legend:[1,"<fieldset>","</fieldset>"],thead:[1,"<table>","</table>"],tr:[2,"<table><tbody>","</tbody></table>"],td:[3,"<table><tbody><tr>","</tr></tbody></table>"],col:[2,"<table><tbody></tbody><colgroup>","</colgroup></table>"],area:[1,"<map>","</map>"],_default:[0,"",""]},Ct=lt(i),kt=Ct.appendChild(i.createElement("div"));Nt.optgroup=Nt.option,Nt.tbody=Nt.tfoot=Nt.colgroup=Nt.caption=Nt.thead,Nt.th=Nt.td,v.support.htmlSerialize||(Nt._default=[1,"X<div>","</div>"]),v.fn.extend({text:function(e){return v.access(this,function(e){return e===t?v.text(this):this.empty().append((this[0]&&this[0].ownerDocument||i).createTextNode(e))},null,e,arguments.length)},wrapAll:function(e){if(v.isFunction(e))return this.each(function(t){v(this).wrapAll(e.call(this,t))});if(this[0]){var t=v(e,this[0].ownerDocument).eq(0).clone(!0);this[0].parentNode&&t.insertBefore(this[0]),t.map(function(){var e=this;while(e.firstChild&&e.firstChild.nodeType===1)e=e.firstChild;return e}).append(this)}return this},wrapInner:function(e){return v.isFunction(e)?this.each(function(t){v(this).wrapInner(e.call(this,t))}):this.each(function(){var t=v(this),n=t.contents();n.length?n.wrapAll(e):t.append(e)})},wrap:function(e){var t=v.isFunction(e);return this.each(function(n){v(this).wrapAll(t?e.call(this,n):e)})},unwrap:function(){return this.parent().each(function(){v.nodeName(this,"body")||v(this).replaceWith(this.childNodes)}).end()},append:function(){return this.domManip(arguments,!0,function(e){(this.nodeType===1||this.nodeType===11)&&this.appendChild(e)})},prepend:function(){return this.domManip(arguments,!0,function(e){(this.nodeType===1||this.nodeType===11)&&this.insertBefore(e,this.firstChild)})},before:function(){if(!ut(this[0]))return this.domManip(arguments,!1,function(e){this.parentNode.insertBefore(e,this)});if(arguments.length){var e=v.clean(arguments);return this.pushStack(v.merge(e,this),"before",this.selector)}},after:function(){if(!ut(this[0]))return this.domManip(arguments,!1,function(e){this.parentNode.insertBefore(e,this.nextSibling)});if(arguments.length){var e=v.clean(arguments);return this.pushStack(v.merge(this,e),"after",this.selector)}},remove:function(e,t){var n,r=0;for(;(n=this[r])!=null;r++)if(!e||v.filter(e,[n]).length)!t&&n.nodeType===1&&(v.cleanData(n.getElementsByTagName("*")),v.cleanData([n])),n.parentNode&&n.parentNode.removeChild(n);return this},empty:function(){var e,t=0;for(;(e=this[t])!=null;t++){e.nodeType===1&&v.cleanData(e.getElementsByTagName("*"));while(e.firstChild)e.removeChild(e.firstChild)}return this},clone:function(e,t){return e=e==null?!1:e,t=t==null?e:t,this.map(function(){return v.clone(this,e,t)})},html:function(e){return v.access(this,function(e){var n=this[0]||{},r=0,i=this.length;if(e===t)return n.nodeType===1?n.innerHTML.replace(ht,""):t;if(typeof e=="string"&&!yt.test(e)&&(v.support.htmlSerialize||!wt.test(e))&&(v.support.leadingWhitespace||!pt.test(e))&&!Nt[(vt.exec(e)||["",""])[1].toLowerCase()]){e=e.replace(dt,"<$1></$2>");try{for(;r<i;r++)n=this[r]||{},n.nodeType===1&&(v.cleanData(n.getElementsByTagName("*")),n.innerHTML=e);n=0}catch(s){}}n&&this.empty().append(e)},null,e,arguments.length)},replaceWith:function(e){return ut(this[0])?this.length?this.pushStack(v(v.isFunction(e)?e():e),"replaceWith",e):this:v.isFunction(e)?this.each(function(t){var n=v(this),r=n.html();n.replaceWith(e.call(this,t,r))}):(typeof e!="string"&&(e=v(e).detach()),this.each(function(){var t=this.nextSibling,n=this.parentNode;v(this).remove(),t?v(t).before(e):v(n).append(e)}))},detach:function(e){return this.remove(e,!0)},domManip:function(e,n,r){e=[].concat.apply([],e);var i,s,o,u,a=0,f=e[0],l=[],c=this.length;if(!v.support.checkClone&&c>1&&typeof f=="string"&&St.test(f))return this.each(function(){v(this).domManip(e,n,r)});if(v.isFunction(f))return this.each(function(i){var s=v(this);e[0]=f.call(this,i,n?s.html():t),s.domManip(e,n,r)});if(this[0]){i=v.buildFragment(e,this,l),o=i.fragment,s=o.firstChild,o.childNodes.length===1&&(o=s);if(s){n=n&&v.nodeName(s,"tr");for(u=i.cacheable||c-1;a<c;a++)r.call(n&&v.nodeName(this[a],"table")?Lt(this[a],"tbody"):this[a],a===u?o:v.clone(o,!0,!0))}o=s=null,l.length&&v.each(l,function(e,t){t.src?v.ajax?v.ajax({url:t.src,type:"GET",dataType:"script",async:!1,global:!1,"throws":!0}):v.error("no ajax"):v.globalEval((t.text||t.textContent||t.innerHTML||"").replace(Tt,"")),t.parentNode&&t.parentNode.removeChild(t)})}return this}}),v.buildFragment=function(e,n,r){var s,o,u,a=e[0];return n=n||i,n=!n.nodeType&&n[0]||n,n=n.ownerDocument||n,e.length===1&&typeof a=="string"&&a.length<512&&n===i&&a.charAt(0)==="<"&&!bt.test(a)&&(v.support.checkClone||!St.test(a))&&(v.support.html5Clone||!wt.test(a))&&(o=!0,s=v.fragments[a],u=s!==t),s||(s=n.createDocumentFragment(),v.clean(e,n,s,r),o&&(v.fragments[a]=u&&s)),{fragment:s,cacheable:o}},v.fragments={},v.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(e,t){v.fn[e]=function(n){var r,i=0,s=[],o=v(n),u=o.length,a=this.length===1&&this[0].parentNode;if((a==null||a&&a.nodeType===11&&a.childNodes.length===1)&&u===1)return o[t](this[0]),this;for(;i<u;i++)r=(i>0?this.clone(!0):this).get(),v(o[i])[t](r),s=s.concat(r);return this.pushStack(s,e,o.selector)}}),v.extend({clone:function(e,t,n){var r,i,s,o;v.support.html5Clone||v.isXMLDoc(e)||!wt.test("<"+e.nodeName+">")?o=e.cloneNode(!0):(kt.innerHTML=e.outerHTML,kt.removeChild(o=kt.firstChild));if((!v.support.noCloneEvent||!v.support.noCloneChecked)&&(e.nodeType===1||e.nodeType===11)&&!v.isXMLDoc(e)){Ot(e,o),r=Mt(e),i=Mt(o);for(s=0;r[s];++s)i[s]&&Ot(r[s],i[s])}if(t){At(e,o);if(n){r=Mt(e),i=Mt(o);for(s=0;r[s];++s)At(r[s],i[s])}}return r=i=null,o},clean:function(e,t,n,r){var s,o,u,a,f,l,c,h,p,d,m,g,y=t===i&&Ct,b=[];if(!t||typeof t.createDocumentFragment=="undefined")t=i;for(s=0;(u=e[s])!=null;s++){typeof u=="number"&&(u+="");if(!u)continue;if(typeof u=="string")if(!gt.test(u))u=t.createTextNode(u);else{y=y||lt(t),c=t.createElement("div"),y.appendChild(c),u=u.replace(dt,"<$1></$2>"),a=(vt.exec(u)||["",""])[1].toLowerCase(),f=Nt[a]||Nt._default,l=f[0],c.innerHTML=f[1]+u+f[2];while(l--)c=c.lastChild;if(!v.support.tbody){h=mt.test(u),p=a==="table"&&!h?c.firstChild&&c.firstChild.childNodes:f[1]==="<table>"&&!h?c.childNodes:[];for(o=p.length-1;o>=0;--o)v.nodeName(p[o],"tbody")&&!p[o].childNodes.length&&p[o].parentNode.removeChild(p[o])}!v.support.leadingWhitespace&&pt.test(u)&&c.insertBefore(t.createTextNode(pt.exec(u)[0]),c.firstChild),u=c.childNodes,c.parentNode.removeChild(c)}u.nodeType?b.push(u):v.merge(b,u)}c&&(u=c=y=null);if(!v.support.appendChecked)for(s=0;(u=b[s])!=null;s++)v.nodeName(u,"input")?_t(u):typeof u.getElementsByTagName!="undefined"&&v.grep(u.getElementsByTagName("input"),_t);if(n){m=function(e){if(!e.type||xt.test(e.type))return r?r.push(e.parentNode?e.parentNode.removeChild(e):e):n.appendChild(e)};for(s=0;(u=b[s])!=null;s++)if(!v.nodeName(u,"script")||!m(u))n.appendChild(u),typeof u.getElementsByTagName!="undefined"&&(g=v.grep(v.merge([],u.getElementsByTagName("script")),m),b.splice.apply(b,[s+1,0].concat(g)),s+=g.length)}return b},cleanData:function(e,t){var n,r,i,s,o=0,u=v.expando,a=v.cache,f=v.support.deleteExpando,l=v.event.special;for(;(i=e[o])!=null;o++)if(t||v.acceptData(i)){r=i[u],n=r&&a[r];if(n){if(n.events)for(s in n.events)l[s]?v.event.remove(i,s):v.removeEvent(i,s,n.handle);a[r]&&(delete a[r],f?delete i[u]:i.removeAttribute?i.removeAttribute(u):i[u]=null,v.deletedIds.push(r))}}}}),function(){var e,t;v.uaMatch=function(e){e=e.toLowerCase();var t=/(chrome)[ \/]([\w.]+)/.exec(e)||/(webkit)[ \/]([\w.]+)/.exec(e)||/(opera)(?:.*version|)[ \/]([\w.]+)/.exec(e)||/(msie) ([\w.]+)/.exec(e)||e.indexOf("compatible")<0&&/(mozilla)(?:.*? rv:([\w.]+)|)/.exec(e)||[];return{browser:t[1]||"",version:t[2]||"0"}},e=v.uaMatch(o.userAgent),t={},e.browser&&(t[e.browser]=!0,t.version=e.version),t.chrome?t.webkit=!0:t.webkit&&(t.safari=!0),v.browser=t,v.sub=function(){function e(t,n){return new e.fn.init(t,n)}v.extend(!0,e,this),e.superclass=this,e.fn=e.prototype=this(),e.fn.constructor=e,e.sub=this.sub,e.fn.init=function(r,i){return i&&i instanceof v&&!(i instanceof e)&&(i=e(i)),v.fn.init.call(this,r,i,t)},e.fn.init.prototype=e.fn;var t=e(i);return e}}();var Dt,Pt,Ht,Bt=/alpha\([^)]*\)/i,jt=/opacity=([^)]*)/,Ft=/^(top|right|bottom|left)$/,It=/^(none|table(?!-c[ea]).+)/,qt=/^margin/,Rt=new RegExp("^("+m+")(.*)$","i"),Ut=new RegExp("^("+m+")(?!px)[a-z%]+$","i"),zt=new RegExp("^([-+])=("+m+")","i"),Wt={BODY:"block"},Xt={position:"absolute",visibility:"hidden",display:"block"},Vt={letterSpacing:0,fontWeight:400},$t=["Top","Right","Bottom","Left"],Jt=["Webkit","O","Moz","ms"],Kt=v.fn.toggle;v.fn.extend({css:function(e,n){return v.access(this,function(e,n,r){return r!==t?v.style(e,n,r):v.css(e,n)},e,n,arguments.length>1)},show:function(){return Yt(this,!0)},hide:function(){return Yt(this)},toggle:function(e,t){var n=typeof e=="boolean";return v.isFunction(e)&&v.isFunction(t)?Kt.apply(this,arguments):this.each(function(){(n?e:Gt(this))?v(this).show():v(this).hide()})}}),v.extend({cssHooks:{opacity:{get:function(e,t){if(t){var n=Dt(e,"opacity");return n===""?"1":n}}}},cssNumber:{fillOpacity:!0,fontWeight:!0,lineHeight:!0,opacity:!0,orphans:!0,widows:!0,zIndex:!0,zoom:!0},cssProps:{"float":v.support.cssFloat?"cssFloat":"styleFloat"},style:function(e,n,r,i){if(!e||e.nodeType===3||e.nodeType===8||!e.style)return;var s,o,u,a=v.camelCase(n),f=e.style;n=v.cssProps[a]||(v.cssProps[a]=Qt(f,a)),u=v.cssHooks[n]||v.cssHooks[a];if(r===t)return u&&"get"in u&&(s=u.get(e,!1,i))!==t?s:f[n];o=typeof r,o==="string"&&(s=zt.exec(r))&&(r=(s[1]+1)*s[2]+parseFloat(v.css(e,n)),o="number");if(r==null||o==="number"&&isNaN(r))return;o==="number"&&!v.cssNumber[a]&&(r+="px");if(!u||!("set"in u)||(r=u.set(e,r,i))!==t)try{f[n]=r}catch(l){}},css:function(e,n,r,i){var s,o,u,a=v.camelCase(n);return n=v.cssProps[a]||(v.cssProps[a]=Qt(e.style,a)),u=v.cssHooks[n]||v.cssHooks[a],u&&"get"in u&&(s=u.get(e,!0,i)),s===t&&(s=Dt(e,n)),s==="normal"&&n in Vt&&(s=Vt[n]),r||i!==t?(o=parseFloat(s),r||v.isNumeric(o)?o||0:s):s},swap:function(e,t,n){var r,i,s={};for(i in t)s[i]=e.style[i],e.style[i]=t[i];r=n.call(e);for(i in t)e.style[i]=s[i];return r}}),e.getComputedStyle?Dt=function(t,n){var r,i,s,o,u=e.getComputedStyle(t,null),a=t.style;return u&&(r=u.getPropertyValue(n)||u[n],r===""&&!v.contains(t.ownerDocument,t)&&(r=v.style(t,n)),Ut.test(r)&&qt.test(n)&&(i=a.width,s=a.minWidth,o=a.maxWidth,a.minWidth=a.maxWidth=a.width=r,r=u.width,a.width=i,a.minWidth=s,a.maxWidth=o)),r}:i.documentElement.currentStyle&&(Dt=function(e,t){var n,r,i=e.currentStyle&&e.currentStyle[t],s=e.style;return i==null&&s&&s[t]&&(i=s[t]),Ut.test(i)&&!Ft.test(t)&&(n=s.left,r=e.runtimeStyle&&e.runtimeStyle.left,r&&(e.runtimeStyle.left=e.currentStyle.left),s.left=t==="fontSize"?"1em":i,i=s.pixelLeft+"px",s.left=n,r&&(e.runtimeStyle.left=r)),i===""?"auto":i}),v.each(["height","width"],function(e,t){v.cssHooks[t]={get:function(e,n,r){if(n)return e.offsetWidth===0&&It.test(Dt(e,"display"))?v.swap(e,Xt,function(){return tn(e,t,r)}):tn(e,t,r)},set:function(e,n,r){return Zt(e,n,r?en(e,t,r,v.support.boxSizing&&v.css(e,"boxSizing")==="border-box"):0)}}}),v.support.opacity||(v.cssHooks.opacity={get:function(e,t){return jt.test((t&&e.currentStyle?e.currentStyle.filter:e.style.filter)||"")?.01*parseFloat(RegExp.$1)+"":t?"1":""},set:function(e,t){var n=e.style,r=e.currentStyle,i=v.isNumeric(t)?"alpha(opacity="+t*100+")":"",s=r&&r.filter||n.filter||"";n.zoom=1;if(t>=1&&v.trim(s.replace(Bt,""))===""&&n.removeAttribute){n.removeAttribute("filter");if(r&&!r.filter)return}n.filter=Bt.test(s)?s.replace(Bt,i):s+" "+i}}),v(function(){v.support.reliableMarginRight||(v.cssHooks.marginRight={get:function(e,t){return v.swap(e,{display:"inline-block"},function(){if(t)return Dt(e,"marginRight")})}}),!v.support.pixelPosition&&v.fn.position&&v.each(["top","left"],function(e,t){v.cssHooks[t]={get:function(e,n){if(n){var r=Dt(e,t);return Ut.test(r)?v(e).position()[t]+"px":r}}}})}),v.expr&&v.expr.filters&&(v.expr.filters.hidden=function(e){return e.offsetWidth===0&&e.offsetHeight===0||!v.support.reliableHiddenOffsets&&(e.style&&e.style.display||Dt(e,"display"))==="none"},v.expr.filters.visible=function(e){return!v.expr.filters.hidden(e)}),v.each({margin:"",padding:"",border:"Width"},function(e,t){v.cssHooks[e+t]={expand:function(n){var r,i=typeof n=="string"?n.split(" "):[n],s={};for(r=0;r<4;r++)s[e+$t[r]+t]=i[r]||i[r-2]||i[0];return s}},qt.test(e)||(v.cssHooks[e+t].set=Zt)});var rn=/%20/g,sn=/\[\]$/,on=/\r?\n/g,un=/^(?:color|date|datetime|datetime-local|email|hidden|month|number|password|range|search|tel|text|time|url|week)$/i,an=/^(?:select|textarea)/i;v.fn.extend({serialize:function(){return v.param(this.serializeArray())},serializeArray:function(){return this.map(function(){return this.elements?v.makeArray(this.elements):this}).filter(function(){return this.name&&!this.disabled&&(this.checked||an.test(this.nodeName)||un.test(this.type))}).map(function(e,t){var n=v(this).val();return n==null?null:v.isArray(n)?v.map(n,function(e,n){return{name:t.name,value:e.replace(on,"\r\n")}}):{name:t.name,value:n.replace(on,"\r\n")}}).get()}}),v.param=function(e,n){var r,i=[],s=function(e,t){t=v.isFunction(t)?t():t==null?"":t,i[i.length]=encodeURIComponent(e)+"="+encodeURIComponent(t)};n===t&&(n=v.ajaxSettings&&v.ajaxSettings.traditional);if(v.isArray(e)||e.jquery&&!v.isPlainObject(e))v.each(e,function(){s(this.name,this.value)});else for(r in e)fn(r,e[r],n,s);return i.join("&").replace(rn,"+")};var ln,cn,hn=/#.*$/,pn=/^(.*?):[ \t]*([^\r\n]*)\r?$/mg,dn=/^(?:about|app|app\-storage|.+\-extension|file|res|widget):$/,vn=/^(?:GET|HEAD)$/,mn=/^\/\//,gn=/\?/,yn=/<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>/gi,bn=/([?&])_=[^&]*/,wn=/^([\w\+\.\-]+:)(?:\/\/([^\/?#:]*)(?::(\d+)|)|)/,En=v.fn.load,Sn={},xn={},Tn=["*/"]+["*"];try{cn=s.href}catch(Nn){cn=i.createElement("a"),cn.href="",cn=cn.href}ln=wn.exec(cn.toLowerCase())||[],v.fn.load=function(e,n,r){if(typeof e!="string"&&En)return En.apply(this,arguments);if(!this.length)return this;var i,s,o,u=this,a=e.indexOf(" ");return a>=0&&(i=e.slice(a,e.length),e=e.slice(0,a)),v.isFunction(n)?(r=n,n=t):n&&typeof n=="object"&&(s="POST"),v.ajax({url:e,type:s,dataType:"html",data:n,complete:function(e,t){r&&u.each(r,o||[e.responseText,t,e])}}).done(function(e){o=arguments,u.html(i?v("<div>").append(e.replace(yn,"")).find(i):e)}),this},v.each("ajaxStart ajaxStop ajaxComplete ajaxError ajaxSuccess ajaxSend".split(" "),function(e,t){v.fn[t]=function(e){return this.on(t,e)}}),v.each(["get","post"],function(e,n){v[n]=function(e,r,i,s){return v.isFunction(r)&&(s=s||i,i=r,r=t),v.ajax({type:n,url:e,data:r,success:i,dataType:s})}}),v.extend({getScript:function(e,n){return v.get(e,t,n,"script")},getJSON:function(e,t,n){return v.get(e,t,n,"json")},ajaxSetup:function(e,t){return t?Ln(e,v.ajaxSettings):(t=e,e=v.ajaxSettings),Ln(e,t),e},ajaxSettings:{url:cn,isLocal:dn.test(ln[1]),global:!0,type:"GET",contentType:"application/x-www-form-urlencoded; charset=UTF-8",processData:!0,async:!0,accepts:{xml:"application/xml, text/xml",html:"text/html",text:"text/plain",json:"application/json, text/javascript","*":Tn},contents:{xml:/xml/,html:/html/,json:/json/},responseFields:{xml:"responseXML",text:"responseText"},converters:{"* text":e.String,"text html":!0,"text json":v.parseJSON,"text xml":v.parseXML},flatOptions:{context:!0,url:!0}},ajaxPrefilter:Cn(Sn),ajaxTransport:Cn(xn),ajax:function(e,n){function T(e,n,s,a){var l,y,b,w,S,T=n;if(E===2)return;E=2,u&&clearTimeout(u),o=t,i=a||"",x.readyState=e>0?4:0,s&&(w=An(c,x,s));if(e>=200&&e<300||e===304)c.ifModified&&(S=x.getResponseHeader("Last-Modified"),S&&(v.lastModified[r]=S),S=x.getResponseHeader("Etag"),S&&(v.etag[r]=S)),e===304?(T="notmodified",l=!0):(l=On(c,w),T=l.state,y=l.data,b=l.error,l=!b);else{b=T;if(!T||e)T="error",e<0&&(e=0)}x.status=e,x.statusText=(n||T)+"",l?d.resolveWith(h,[y,T,x]):d.rejectWith(h,[x,T,b]),x.statusCode(g),g=t,f&&p.trigger("ajax"+(l?"Success":"Error"),[x,c,l?y:b]),m.fireWith(h,[x,T]),f&&(p.trigger("ajaxComplete",[x,c]),--v.active||v.event.trigger("ajaxStop"))}typeof e=="object"&&(n=e,e=t),n=n||{};var r,i,s,o,u,a,f,l,c=v.ajaxSetup({},n),h=c.context||c,p=h!==c&&(h.nodeType||h instanceof v)?v(h):v.event,d=v.Deferred(),m=v.Callbacks("once memory"),g=c.statusCode||{},b={},w={},E=0,S="canceled",x={readyState:0,setRequestHeader:function(e,t){if(!E){var n=e.toLowerCase();e=w[n]=w[n]||e,b[e]=t}return this},getAllResponseHeaders:function(){return E===2?i:null},getResponseHeader:function(e){var n;if(E===2){if(!s){s={};while(n=pn.exec(i))s[n[1].toLowerCase()]=n[2]}n=s[e.toLowerCase()]}return n===t?null:n},overrideMimeType:function(e){return E||(c.mimeType=e),this},abort:function(e){return e=e||S,o&&o.abort(e),T(0,e),this}};d.promise(x),x.success=x.done,x.error=x.fail,x.complete=m.add,x.statusCode=function(e){if(e){var t;if(E<2)for(t in e)g[t]=[g[t],e[t]];else t=e[x.status],x.always(t)}return this},c.url=((e||c.url)+"").replace(hn,"").replace(mn,ln[1]+"//"),c.dataTypes=v.trim(c.dataType||"*").toLowerCase().split(y),c.crossDomain==null&&(a=wn.exec(c.url.toLowerCase()),c.crossDomain=!(!a||a[1]===ln[1]&&a[2]===ln[2]&&(a[3]||(a[1]==="http:"?80:443))==(ln[3]||(ln[1]==="http:"?80:443)))),c.data&&c.processData&&typeof c.data!="string"&&(c.data=v.param(c.data,c.traditional)),kn(Sn,c,n,x);if(E===2)return x;f=c.global,c.type=c.type.toUpperCase(),c.hasContent=!vn.test(c.type),f&&v.active++===0&&v.event.trigger("ajaxStart");if(!c.hasContent){c.data&&(c.url+=(gn.test(c.url)?"&":"?")+c.data,delete c.data),r=c.url;if(c.cache===!1){var N=v.now(),C=c.url.replace(bn,"$1_="+N);c.url=C+(C===c.url?(gn.test(c.url)?"&":"?")+"_="+N:"")}}(c.data&&c.hasContent&&c.contentType!==!1||n.contentType)&&x.setRequestHeader("Content-Type",c.contentType),c.ifModified&&(r=r||c.url,v.lastModified[r]&&x.setRequestHeader("If-Modified-Since",v.lastModified[r]),v.etag[r]&&x.setRequestHeader("If-None-Match",v.etag[r])),x.setRequestHeader("Accept",c.dataTypes[0]&&c.accepts[c.dataTypes[0]]?c.accepts[c.dataTypes[0]]+(c.dataTypes[0]!=="*"?", "+Tn+"; q=0.01":""):c.accepts["*"]);for(l in c.headers)x.setRequestHeader(l,c.headers[l]);if(!c.beforeSend||c.beforeSend.call(h,x,c)!==!1&&E!==2){S="abort";for(l in{success:1,error:1,complete:1})x[l](c[l]);o=kn(xn,c,n,x);if(!o)T(-1,"No Transport");else{x.readyState=1,f&&p.trigger("ajaxSend",[x,c]),c.async&&c.timeout>0&&(u=setTimeout(function(){x.abort("timeout")},c.timeout));try{E=1,o.send(b,T)}catch(k){if(!(E<2))throw k;T(-1,k)}}return x}return x.abort()},active:0,lastModified:{},etag:{}});var Mn=[],_n=/\?/,Dn=/(=)\?(?=&|$)|\?\?/,Pn=v.now();v.ajaxSetup({jsonp:"callback",jsonpCallback:function(){var e=Mn.pop()||v.expando+"_"+Pn++;return this[e]=!0,e}}),v.ajaxPrefilter("json jsonp",function(n,r,i){var s,o,u,a=n.data,f=n.url,l=n.jsonp!==!1,c=l&&Dn.test(f),h=l&&!c&&typeof a=="string"&&!(n.contentType||"").indexOf("application/x-www-form-urlencoded")&&Dn.test(a);if(n.dataTypes[0]==="jsonp"||c||h)return s=n.jsonpCallback=v.isFunction(n.jsonpCallback)?n.jsonpCallback():n.jsonpCallback,o=e[s],c?n.url=f.replace(Dn,"$1"+s):h?n.data=a.replace(Dn,"$1"+s):l&&(n.url+=(_n.test(f)?"&":"?")+n.jsonp+"="+s),n.converters["script json"]=function(){return u||v.error(s+" was not called"),u[0]},n.dataTypes[0]="json",e[s]=function(){u=arguments},i.always(function(){e[s]=o,n[s]&&(n.jsonpCallback=r.jsonpCallback,Mn.push(s)),u&&v.isFunction(o)&&o(u[0]),u=o=t}),"script"}),v.ajaxSetup({accepts:{script:"text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"},contents:{script:/javascript|ecmascript/},converters:{"text script":function(e){return v.globalEval(e),e}}}),v.ajaxPrefilter("script",function(e){e.cache===t&&(e.cache=!1),e.crossDomain&&(e.type="GET",e.global=!1)}),v.ajaxTransport("script",function(e){if(e.crossDomain){var n,r=i.head||i.getElementsByTagName("head")[0]||i.documentElement;return{send:function(s,o){n=i.createElement("script"),n.async="async",e.scriptCharset&&(n.charset=e.scriptCharset),n.src=e.url,n.onload=n.onreadystatechange=function(e,i){if(i||!n.readyState||/loaded|complete/.test(n.readyState))n.onload=n.onreadystatechange=null,r&&n.parentNode&&r.removeChild(n),n=t,i||o(200,"success")},r.insertBefore(n,r.firstChild)},abort:function(){n&&n.onload(0,1)}}}});var Hn,Bn=e.ActiveXObject?function(){for(var e in Hn)Hn[e](0,1)}:!1,jn=0;v.ajaxSettings.xhr=e.ActiveXObject?function(){return!this.isLocal&&Fn()||In()}:Fn,function(e){v.extend(v.support,{ajax:!!e,cors:!!e&&"withCredentials"in e})}(v.ajaxSettings.xhr()),v.support.ajax&&v.ajaxTransport(function(n){if(!n.crossDomain||v.support.cors){var r;return{send:function(i,s){var o,u,a=n.xhr();n.username?a.open(n.type,n.url,n.async,n.username,n.password):a.open(n.type,n.url,n.async);if(n.xhrFields)for(u in n.xhrFields)a[u]=n.xhrFields[u];n.mimeType&&a.overrideMimeType&&a.overrideMimeType(n.mimeType),!n.crossDomain&&!i["X-Requested-With"]&&(i["X-Requested-With"]="XMLHttpRequest");try{for(u in i)a.setRequestHeader(u,i[u])}catch(f){}a.send(n.hasContent&&n.data||null),r=function(e,i){var u,f,l,c,h;try{if(r&&(i||a.readyState===4)){r=t,o&&(a.onreadystatechange=v.noop,Bn&&delete Hn[o]);if(i)a.readyState!==4&&a.abort();else{u=a.status,l=a.getAllResponseHeaders(),c={},h=a.responseXML,h&&h.documentElement&&(c.xml=h);try{c.text=a.responseText}catch(p){}try{f=a.statusText}catch(p){f=""}!u&&n.isLocal&&!n.crossDomain?u=c.text?200:404:u===1223&&(u=204)}}}catch(d){i||s(-1,d)}c&&s(u,f,c,l)},n.async?a.readyState===4?setTimeout(r,0):(o=++jn,Bn&&(Hn||(Hn={},v(e).unload(Bn)),Hn[o]=r),a.onreadystatechange=r):r()},abort:function(){r&&r(0,1)}}}});var qn,Rn,Un=/^(?:toggle|show|hide)$/,zn=new RegExp("^(?:([-+])=|)("+m+")([a-z%]*)$","i"),Wn=/queueHooks$/,Xn=[Gn],Vn={"*":[function(e,t){var n,r,i=this.createTween(e,t),s=zn.exec(t),o=i.cur(),u=+o||0,a=1,f=20;if(s){n=+s[2],r=s[3]||(v.cssNumber[e]?"":"px");if(r!=="px"&&u){u=v.css(i.elem,e,!0)||n||1;do a=a||".5",u/=a,v.style(i.elem,e,u+r);while(a!==(a=i.cur()/o)&&a!==1&&--f)}i.unit=r,i.start=u,i.end=s[1]?u+(s[1]+1)*n:n}return i}]};v.Animation=v.extend(Kn,{tweener:function(e,t){v.isFunction(e)?(t=e,e=["*"]):e=e.split(" ");var n,r=0,i=e.length;for(;r<i;r++)n=e[r],Vn[n]=Vn[n]||[],Vn[n].unshift(t)},prefilter:function(e,t){t?Xn.unshift(e):Xn.push(e)}}),v.Tween=Yn,Yn.prototype={constructor:Yn,init:function(e,t,n,r,i,s){this.elem=e,this.prop=n,this.easing=i||"swing",this.options=t,this.start=this.now=this.cur(),this.end=r,this.unit=s||(v.cssNumber[n]?"":"px")},cur:function(){var e=Yn.propHooks[this.prop];return e&&e.get?e.get(this):Yn.propHooks._default.get(this)},run:function(e){var t,n=Yn.propHooks[this.prop];return this.options.duration?this.pos=t=v.easing[this.easing](e,this.options.duration*e,0,1,this.options.duration):this.pos=t=e,this.now=(this.end-this.start)*t+this.start,this.options.step&&this.options.step.call(this.elem,this.now,this),n&&n.set?n.set(this):Yn.propHooks._default.set(this),this}},Yn.prototype.init.prototype=Yn.prototype,Yn.propHooks={_default:{get:function(e){var t;return e.elem[e.prop]==null||!!e.elem.style&&e.elem.style[e.prop]!=null?(t=v.css(e.elem,e.prop,!1,""),!t||t==="auto"?0:t):e.elem[e.prop]},set:function(e){v.fx.step[e.prop]?v.fx.step[e.prop](e):e.elem.style&&(e.elem.style[v.cssProps[e.prop]]!=null||v.cssHooks[e.prop])?v.style(e.elem,e.prop,e.now+e.unit):e.elem[e.prop]=e.now}}},Yn.propHooks.scrollTop=Yn.propHooks.scrollLeft={set:function(e){e.elem.nodeType&&e.elem.parentNode&&(e.elem[e.prop]=e.now)}},v.each(["toggle","show","hide"],function(e,t){var n=v.fn[t];v.fn[t]=function(r,i,s){return r==null||typeof r=="boolean"||!e&&v.isFunction(r)&&v.isFunction(i)?n.apply(this,arguments):this.animate(Zn(t,!0),r,i,s)}}),v.fn.extend({fadeTo:function(e,t,n,r){return this.filter(Gt).css("opacity",0).show().end().animate({opacity:t},e,n,r)},animate:function(e,t,n,r){var i=v.isEmptyObject(e),s=v.speed(t,n,r),o=function(){var t=Kn(this,v.extend({},e),s);i&&t.stop(!0)};return i||s.queue===!1?this.each(o):this.queue(s.queue,o)},stop:function(e,n,r){var i=function(e){var t=e.stop;delete e.stop,t(r)};return typeof e!="string"&&(r=n,n=e,e=t),n&&e!==!1&&this.queue(e||"fx",[]),this.each(function(){var t=!0,n=e!=null&&e+"queueHooks",s=v.timers,o=v._data(this);if(n)o[n]&&o[n].stop&&i(o[n]);else for(n in o)o[n]&&o[n].stop&&Wn.test(n)&&i(o[n]);for(n=s.length;n--;)s[n].elem===this&&(e==null||s[n].queue===e)&&(s[n].anim.stop(r),t=!1,s.splice(n,1));(t||!r)&&v.dequeue(this,e)})}}),v.each({slideDown:Zn("show"),slideUp:Zn("hide"),slideToggle:Zn("toggle"),fadeIn:{opacity:"show"},fadeOut:{opacity:"hide"},fadeToggle:{opacity:"toggle"}},function(e,t){v.fn[e]=function(e,n,r){return this.animate(t,e,n,r)}}),v.speed=function(e,t,n){var r=e&&typeof e=="object"?v.extend({},e):{complete:n||!n&&t||v.isFunction(e)&&e,duration:e,easing:n&&t||t&&!v.isFunction(t)&&t};r.duration=v.fx.off?0:typeof r.duration=="number"?r.duration:r.duration in v.fx.speeds?v.fx.speeds[r.duration]:v.fx.speeds._default;if(r.queue==null||r.queue===!0)r.queue="fx";return r.old=r.complete,r.complete=function(){v.isFunction(r.old)&&r.old.call(this),r.queue&&v.dequeue(this,r.queue)},r},v.easing={linear:function(e){return e},swing:function(e){return.5-Math.cos(e*Math.PI)/2}},v.timers=[],v.fx=Yn.prototype.init,v.fx.tick=function(){var e,n=v.timers,r=0;qn=v.now();for(;r<n.length;r++)e=n[r],!e()&&n[r]===e&&n.splice(r--,1);n.length||v.fx.stop(),qn=t},v.fx.timer=function(e){e()&&v.timers.push(e)&&!Rn&&(Rn=setInterval(v.fx.tick,v.fx.interval))},v.fx.interval=13,v.fx.stop=function(){clearInterval(Rn),Rn=null},v.fx.speeds={slow:600,fast:200,_default:400},v.fx.step={},v.expr&&v.expr.filters&&(v.expr.filters.animated=function(e){return v.grep(v.timers,function(t){return e===t.elem}).length});var er=/^(?:body|html)$/i;v.fn.offset=function(e){if(arguments.length)return e===t?this:this.each(function(t){v.offset.setOffset(this,e,t)});var n,r,i,s,o,u,a,f={top:0,left:0},l=this[0],c=l&&l.ownerDocument;if(!c)return;return(r=c.body)===l?v.offset.bodyOffset(l):(n=c.documentElement,v.contains(n,l)?(typeof l.getBoundingClientRect!="undefined"&&(f=l.getBoundingClientRect()),i=tr(c),s=n.clientTop||r.clientTop||0,o=n.clientLeft||r.clientLeft||0,u=i.pageYOffset||n.scrollTop,a=i.pageXOffset||n.scrollLeft,{top:f.top+u-s,left:f.left+a-o}):f)},v.offset={bodyOffset:function(e){var t=e.offsetTop,n=e.offsetLeft;return v.support.doesNotIncludeMarginInBodyOffset&&(t+=parseFloat(v.css(e,"marginTop"))||0,n+=parseFloat(v.css(e,"marginLeft"))||0),{top:t,left:n}},setOffset:function(e,t,n){var r=v.css(e,"position");r==="static"&&(e.style.position="relative");var i=v(e),s=i.offset(),o=v.css(e,"top"),u=v.css(e,"left"),a=(r==="absolute"||r==="fixed")&&v.inArray("auto",[o,u])>-1,f={},l={},c,h;a?(l=i.position(),c=l.top,h=l.left):(c=parseFloat(o)||0,h=parseFloat(u)||0),v.isFunction(t)&&(t=t.call(e,n,s)),t.top!=null&&(f.top=t.top-s.top+c),t.left!=null&&(f.left=t.left-s.left+h),"using"in t?t.using.call(e,f):i.css(f)}},v.fn.extend({position:function(){if(!this[0])return;var e=this[0],t=this.offsetParent(),n=this.offset(),r=er.test(t[0].nodeName)?{top:0,left:0}:t.offset();return n.top-=parseFloat(v.css(e,"marginTop"))||0,n.left-=parseFloat(v.css(e,"marginLeft"))||0,r.top+=parseFloat(v.css(t[0],"borderTopWidth"))||0,r.left+=parseFloat(v.css(t[0],"borderLeftWidth"))||0,{top:n.top-r.top,left:n.left-r.left}},offsetParent:function(){return this.map(function(){var e=this.offsetParent||i.body;while(e&&!er.test(e.nodeName)&&v.css(e,"position")==="static")e=e.offsetParent;return e||i.body})}}),v.each({scrollLeft:"pageXOffset",scrollTop:"pageYOffset"},function(e,n){var r=/Y/.test(n);v.fn[e]=function(i){return v.access(this,function(e,i,s){var o=tr(e);if(s===t)return o?n in o?o[n]:o.document.documentElement[i]:e[i];o?o.scrollTo(r?v(o).scrollLeft():s,r?s:v(o).scrollTop()):e[i]=s},e,i,arguments.length,null)}}),v.each({Height:"height",Width:"width"},function(e,n){v.each({padding:"inner"+e,content:n,"":"outer"+e},function(r,i){v.fn[i]=function(i,s){var o=arguments.length&&(r||typeof i!="boolean"),u=r||(i===!0||s===!0?"margin":"border");return v.access(this,function(n,r,i){var s;return v.isWindow(n)?n.document.documentElement["client"+e]:n.nodeType===9?(s=n.documentElement,Math.max(n.body["scroll"+e],s["scroll"+e],n.body["offset"+e],s["offset"+e],s["client"+e])):i===t?v.css(n,r,i,u):v.style(n,r,i,u)},n,o?i:t,o,null)}})}),e.jQuery=e.$=v,typeof define=="function"&&define.amd&&define.amd.jQuery&&define("jquery",[],function(){return v})})(window);
/* Main Jquery Ends */
/*! End Comment by atif hussain */

//document.getElementById("jqcheck").style.display = "none";
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
/*! function (e) {
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
}(jQuery);*/

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

$(function () {
    $('form.usetransform').jqTransform({
        imgPath: '../images/'
    });
});


