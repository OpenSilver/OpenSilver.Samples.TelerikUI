﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Specialized;

namespace OpenSilver.Samples.TelerikUI
{
    /// <summary>
    /// This class organizes its children in such a way that it takes the smallest space possible.
    /// It is based on the Masonry layout (see: http://jsfiddle.net/WH8tW/7/).
    /// </summary>
    public class MasonryPanelWithProgressiveLoading : Panel
    {
        /// <summary>
        /// Initializes a new instance of MasonryPanel class.
        /// </summary>
        public MasonryPanelWithProgressiveLoading() : base()
        {
            ProgressiveRenderingChunkSize = 1;
            Children.CollectionChanged += OnChildrenCollectionChanged;
        }

        private void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var child in args.NewItems.OfType<FrameworkElement>())
                {
                    child.Loaded += OnChildLoaded;
                }
            }
        }

        private void OnChildLoaded(object sender, RoutedEventArgs e)
        {
            UpdateMasonryPanel();
        }

        void UpdateMasonryPanel()
        {
            object thisDiv = CSHTML5.Interop.GetDiv(this);

            CSHTML5.Interop.ExecuteJavaScript(@"
(function() { //we make this a function so that we can get a return type
    var thisInnerDiv = $0.children[0]; //this is the div that contains all the children.

    // Make sure the children all have an auto height to make sure masonry works properly:
    for (var i = 0; i < thisInnerDiv.children.length; i++) { 
        thisInnerDiv.children[i].style.height = 'auto';
    }

    var wall = new Masonry(thisInnerDiv, {
        isFitWidth: true
    });

    // Update the Masonry layout:
    wall.reload()

    return wall;
}())
", thisDiv);
        }

        /// <summary>
        /// This static constructor initializes the Masonry layout.
        /// </summary>
        static MasonryPanelWithProgressiveLoading()
        {
            CSHTML5.Interop.ExecuteJavaScript(@"/**
 * Vanilla Masonry v1.0.6
 * Dynamic layouts for the flip-side of CSS Floats
 * http://vanilla-masonry.desandro.com
 *
 * Licensed under the MIT license.
 * Copyright 2012 David DeSandro
 */
(function(e,t){""use strict"";function i(e){return new RegExp(""(^|\\s+)""+e+""(\\s+|$$)"")}function d(e,t,n){if(n.indexOf(""%"")===-1)return n;var r=e.style,i=r.width,s;return r.width=n,s=t.width,r.width=i,s}function v(e,t,n){var r=t!==""height"",i=r?e.offsetWidth:e.offsetHeight,s=r?""Left"":""Top"",o=r?""Right"":""Bottom"",u=f(e),a=parseFloat(u[""padding""+s])||0,l=parseFloat(u[""padding""+o])||0,c=parseFloat(u[""border""+s+""Width""])||0,h=parseFloat(u[""border""+o+""Width""])||0,v=u[""margin""+s],m=u[""margin""+o],g,y;p||(v=d(e,u,v),m=d(e,u,m)),g=parseFloat(v)||0,y=parseFloat(m)||0;if(i>0)n?i+=g+y:i-=a+l+c+h;else{i=u[t];if(i<0||i===null)i=e.style[t]||0;i=parseFloat(i)||0,n&&(i+=a+l+g+y+c+h)}return i}function m(t,n,r){t.addEventListener?t.addEventListener(n,r,!1):t.attachEvent&&(t[""e""+n+r]=r,t[n+r]=function(){t[""e""+n+r](e.event)},t.attachEvent(""on""+n,t[n+r]))}function g(e,t,n){e.removeEventListener?e.removeEventListener(t,n,!1):e.detachEvent&&(e.detachEvent(""on""+t,e[t+n]),e[t+n]=null,e[""e""+t+n]=null)}function y(e,t){if(!e)return;this.element=e,this.options={};for(var n in y.defaults)this.options[n]=y.defaults[n];for(n in t)this.options[n]=t[n];this._create(),this.build()}var n=e.document,r=""classList""in n.createElement(""div""),s=r?function(e,t){return e.classList.contains(t)}:function(e,t){return i(t).test(e.className)},o=r?function(e,t){e.classList.add(t)}:function(e,t){s(e,t)||(e.className=e.className+"" ""+t)},u=r?function(e,t){e.classList.remove(t)}:function(e,t){e.className=e.className.replace(i(t),"" "")},a=n.defaultView,f=a&&a.getComputedStyle?function(e){return a.getComputedStyle(e,null)}:function(e){return e.currentStyle},l=n.getElementsByTagName(""body"")[0],c=n.createElement(""div""),h=l||n.createElement(""body"");c.style.marginTop=""1%"",h.appendChild(c);var p=f(c).marginTop!==""1%"";h.removeChild(c);var b=[""position"",""height""];y.defaults={isResizable:!0,gutterWidth:0,isRTL:!1,isFitWidth:!1},y.prototype={_getBricks:function(e){var t;for(var n=0,r=e.length;n<r;n++)t=e[n],t.style.position=""absolute"",o(t,""masonry-brick""),this.bricks.push(t)},_create:function(){this.reloadItems();var t=this.element.style;this._originalStyle={};for(var n=0,r=b.length;n<r;n++){var i=b[n];this._originalStyle[i]=t[i]||""""}this.element.style.position=""relative"",this.horizontalDirection=this.options.isRTL?""right"":""left"",this.offset={};var s=f(this.element),u=this.options.isRTL?""paddingRight"":""paddingLeft"";this.offset.y=parseFloat(s.paddingTop)||0,this.offset.x=parseFloat(s[u])||0,this.isFluid=this.options.columnWidth&&typeof this.options.columnWidth==""function"";var a=this;setTimeout(function(){o(a.element,""masonry"")}),this.options.isResizable&&m(e,""resize"",function(){a._handleResize()})},build:function(e){this._getColumns(),this._reLayout(e)},_getColumns:function(){var e=this.options.isFitWidth?this.element.parentNode:this.element,t=v(e,""width"");this.columnWidth=this.isFluid?this.options.columnWidth(t):this.options.columnWidth||v(this.bricks[0],""width"",!0)||t,this.columnWidth+=this.options.gutterWidth,this.cols=Math.floor((t+this.options.gutterWidth)/this.columnWidth),this.cols=Math.max(this.cols,1)},reloadItems:function(){this.bricks=[],this._getBricks(this.element.children)},_reLayout:function(e){var t=this.cols;this.colYs=[];while(t--)this.colYs.push(0);this.layout(this.bricks,e)},layout:function(e,t){if(!e||!e.length)return;var n,r,i,s,o,u,a;for(var f=0,l=e.length;f<l;f++){n=e[f];if(n.nodeType!==1)continue;r=Math.ceil(v(n,""width"",!0)/this.columnWidth),r=Math.min(r,this.cols);if(r===1)a=this.colYs;else{i=this.cols+1-r,a=[];for(u=0;u<i;u++)o=this.colYs.slice(u,u+r),a[u]=Math.max.apply(Math,o)}var c=Math.min.apply(Math,a);for(var h=0,p=a.length;h<p;h++)if(a[h]===c)break;n.style.top=c+this.offset.y+""px"",n.style[this.horizontalDirection]=this.columnWidth*h+this.offset.x+""px"";var d=c+v(n,""height"",!0),m=this.cols+1-p;for(u=0;u<m;u++)this.colYs[h+u]=d}var g={};this.element.style.height=Math.max.apply(Math,this.colYs)+""px"";if(this.options.isFitWidth){var y=0;f=this.cols;while(--f){if(this.colYs[f]!==0)break;y++}this.element.style.width=(this.cols-y)*this.columnWidth-this.options.gutterWidth+""px""}t&&t.call(e)},_handleResize:function(){function t(){e.resize(),e._resizeTimeout=null}var e=this;this._resizeTimeout&&clearTimeout(this._resizeTimeout),this._resizeTimeout=setTimeout(t,100)},resize:function(){var e=this.cols;this._getColumns(),(this.isFluid||this.cols!==e)&&this._reLayout()},reload:function(e){this.reloadItems(),this.build(e)},appended:function(e,t,n){var r=this,i=function(){r._appended(e,n)};if(t){var s=v(this.element,""height"")+""px"";for(var o=0,u=e.length;o<u;o++)e[o].style.top=s;setTimeout(i,1)}else i()},_appended:function(e,t){this._getBricks(e),this.layout(e,t)},destroy:function(){var t;for(var n=0,r=this.bricks.length;n<r;n++)t=this.bricks[n],t.style.position="""",t.style.top="""",t.style.left="""",u(t,""masonry-brick"");var i=this.element.style;r=b.length;for(n=0;n<r;n++){var s=b[n];i[s]=this._originalStyle[s]}u(this.element,""masonry""),this.resizeHandler&&g(e,""resize"",this.resizeHandler)}},y.getWH=v,e.Masonry=y})(window);");
        }
    }
}
