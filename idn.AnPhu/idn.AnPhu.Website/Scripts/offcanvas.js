+function(b){var c=function(e,d){this.$element=b(e);this.options=b.extend({},c.DEFAULTS,d);this.state=null;this.placement=null;if(this.options.recalc){this.calcClone();b(window).on("resize",b.proxy(this.recalc,this))}if(this.options.autohide){b(document).on("click",b.proxy(this.autohide,this))}if(this.options.toggle){this.toggle()}if(this.options.disablescrolling){this.options.disableScrolling=this.options.disablescrolling;delete this.options.disablescrolling}};c.DEFAULTS={toggle:true,placement:"auto",autohide:true,recalc:true,disableScrolling:true};c.prototype.offset=function(){switch(this.placement){case"left":case"right":return this.$element.outerWidth();case"top":case"bottom":return this.$element.outerHeight()}};c.prototype.calcPlacement=function(){if(this.options.placement!=="auto"){this.placement=this.options.placement;return}if(!this.$element.hasClass("in")){this.$element.css("visiblity","hidden !important").addClass("in")}var d=b(window).width()/this.$element.width();var e=b(window).height()/this.$element.height();var f=this.$element;function g(i,h){if(f.css(h)==="auto"){return i}if(f.css(i)==="auto"){return h}var k=parseInt(f.css(i),10);var j=parseInt(f.css(h),10);return k>j?h:i}this.placement=d>=e?g("left","right"):g("top","bottom");if(this.$element.css("visibility")==="hidden !important"){this.$element.removeClass("in").css("visiblity","")}};c.prototype.opposite=function(d){switch(d){case"top":return"bottom";case"left":return"right";case"bottom":return"top";case"right":return"left"}};c.prototype.getCanvasElements=function(){var d=this.options.canvas?b(this.options.canvas):this.$element;var e=d.find("*").filter(function(){return b(this).css("position")==="fixed"}).not(this.options.exclude);return d.add(e)};c.prototype.slide=function(f,h,i){if(!b.support.transition){var e={};e[this.placement]="+="+h;return f.animate(e,350,i)}var d=this.placement;var g=this.opposite(d);f.each(function(){if(b(this).css(d)!=="auto"){b(this).css(d,(parseInt(b(this).css(d),10)||0)+h)}if(b(this).css(g)!=="auto"){b(this).css(g,(parseInt(b(this).css(g),10)||0)-h)}});this.$element.one(b.support.transition.end,i).emulateTransitionEnd(350)};c.prototype.disableScrolling=function(){var d=b("body").width();var f="padding-"+this.opposite(this.placement);if(b("body").data("offcanvas-style")===undefined){b("body").data("offcanvas-style",b("body").attr("style")||"")}b("body").css("overflow","hidden");if(b("body").width()>d){var e=parseInt(b("body").css(f),10)+b("body").width()-d;setTimeout(function(){b("body").css(f,e)},1)}};c.prototype.show=function(){if(this.state){return}var e=b.Event("show.bs.offcanvas");this.$element.trigger(e);if(e.isDefaultPrevented()){return}this.state="slide-in";this.calcPlacement();var g=this.getCanvasElements();var f=this.placement;var h=this.opposite(f);var i=this.offset();if(g.index(this.$element)!==-1){b(this.$element).data("offcanvas-style",b(this.$element).attr("style")||"");this.$element.css(f,-1*i);this.$element.css(f)}g.addClass("canvas-sliding").each(function(){if(b(this).data("offcanvas-style")===undefined){b(this).data("offcanvas-style",b(this).attr("style")||"")}if(b(this).css("position")==="static"){b(this).css("position","relative")}if((b(this).css(f)==="auto"||b(this).css(f)==="0px")&&(b(this).css(h)==="auto"||b(this).css(h)==="0px")){b(this).css(f,0)}});if(this.options.disableScrolling){this.disableScrolling()}var d=function(){if(this.state!="slide-in"){return}this.state="slid";g.removeClass("canvas-sliding").addClass("canvas-slid");this.$element.trigger("shown.bs.offcanvas")};setTimeout(b.proxy(function(){this.$element.addClass("in");this.slide(g,i,b.proxy(d,this))},this),1)};c.prototype.hide=function(f){if(this.state!=="slid"){return}var e=b.Event("hide.bs.offcanvas");this.$element.trigger(e);if(e.isDefaultPrevented()){return}this.state="slide-out";var h=b(".canvas-slid");var g=this.placement;var i=-1*this.offset();var d=function(){if(this.state!="slide-out"){return}this.state=null;this.placement=null;this.$element.removeClass("in");h.removeClass("canvas-sliding");h.add(this.$element).add("body").each(function(){b(this).attr("style",b(this).data("offcanvas-style")).removeData("offcanvas-style")});this.$element.trigger("hidden.bs.offcanvas")};h.removeClass("canvas-slid").addClass("canvas-sliding");setTimeout(b.proxy(function(){this.slide(h,i,b.proxy(d,this))},this),1)};c.prototype.toggle=function(){if(this.state==="slide-in"||this.state==="slide-out"){return}this[this.state==="slid"?"hide":"show"]()};c.prototype.calcClone=function(){this.$calcClone=this.$element.clone().html("").addClass("offcanvas-clone").removeClass("in").appendTo(b("body"))};c.prototype.recalc=function(){if(this.$calcClone.css("display")==="none"||(this.state!=="slid"&&this.state!=="slide-in")){return}this.state=null;this.placement=null;var d=this.getCanvasElements();this.$element.removeClass("in");d.removeClass("canvas-slid");d.add(this.$element).add("body").each(function(){b(this).attr("style",b(this).data("offcanvas-style")).removeData("offcanvas-style")})};c.prototype.autohide=function(d){if(b(d.target).closest(this.$element).length===0){this.hide()}};var a=b.fn.offcanvas;b.fn.offcanvas=function(d){return this.each(function(){var g=b(this);var f=g.data("bs.offcanvas");var e=b.extend({},c.DEFAULTS,g.data(),typeof d==="object"&&d);if(!f){g.data("bs.offcanvas",(f=new c(this,e)))}if(typeof d==="string"){f[d]()}})};b.fn.offcanvas.Constructor=c;b.fn.offcanvas.noConflict=function(){b.fn.offcanvas=a;return this};b(document).on("click.bs.offcanvas.data-api","[data-toggle=offcanvas]",function(k){var j=b(this),d;var i=j.attr("data-target")||k.preventDefault()||(d=j.attr("href"))&&d.replace(/.*(?=#[^\s]+$)/,"");var g=b(i);var h=g.data("bs.offcanvas");var f=h?"toggle":j.data();k.stopPropagation();if(h){h.toggle()}else{g.offcanvas(f)}})}(window.jQuery);