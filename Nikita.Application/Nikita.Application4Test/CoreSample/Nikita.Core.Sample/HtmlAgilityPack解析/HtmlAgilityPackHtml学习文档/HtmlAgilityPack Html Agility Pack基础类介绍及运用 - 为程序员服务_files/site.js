var host = location.hostname.indexOf('outofmemory.cn') > -1 ? 'outofmemory.cn' : 'oom.cn';
function setHomepage(url){
    if(!url)url = 'http://' + location.hostname + '/';
    if (window.sidebar){
        if(window.netscape){
            try{
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            } catch(e) {
                alert("this action was aviod by your browser，if you want to enable，please enter about:config in your address line,and change the value of signed.applets.codebase_principal_support to true");
            }
        }
        var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components. interfaces.nsIPrefBranch);
        prefs.setCharPref('browser.startup.homepage',url);
    }else{
        try{
            document.body.style.behavior='url(#default#homepage)';
            document.body.setHomePage(url);
        }catch(e){
            alert('抱歉，您的浏览器不支持自动设置首页，请手动设置！');
        }
    }
    $.ajax('/counter/increase',{'dataType':'json','type':'POST','data':{'k':'setHome'}});
}

$(function(){
    function hide(){$('div#divNavMore').css({'top':'-1000px'});$('.categoryNav .selected').removeClass('selected').addClass('more');}
    function out(e){var moveTo = e.relatedTarget;
        if($(moveTo).parents('div#divNavMore').length == 0) {
            hide();
        }
    }
    $('.categoryNav .more').hover(function(e){
        var li = $(this);
        var p = li.position();
        $('#divNavMore').css({'left':p.left+'px','top':p.top + li.height() - 2 + 'px'});
        li.removeClass('more').addClass('selected');
    },function(e){
        out(e);
    });

    $(document.body).click(function(e){
        hide();
    });

    $('#divNavMore').mouseout(function(ev){
        out(ev);
    });


    if($('#subNavArrow').length){
        var nav=$('#headNav');
        var navLeft = nav.position().left;
        var wrapLeft = ($(document.body).width()-$('.wrap').width())/2;
        if (wrapLeft - navLeft > 100){
            var marginLeft = wrapLeft-$('.logo').width()-$('.beta').width()-$('.siteSlogan').width()-20;
            nav.css({'margin-left':marginLeft+'px'});
        }
        var li = $('#headNav a.current').parent();
        var p = li.position();
        $('#subNavArrow').css({'left':p.left + li.width()/2 - 3 + 'px',
            'top':p.top + li.height() - 3 + 'px','display':'inline'});
    }

    var spaceWidth = $(document.body).width() - $('.wrap:first').width();
    var rBannerRight = (spaceWidth/2 - $('.rBanner').width())/2 + 'px';
    $('.rBanner').css({'right':rBannerRight});
    $('.lBanner').css({'left':rBannerRight});


    $('#subNavController').click(function(){
        var span = $(this);
        var tag = span.attr('tag');
        if(!tag) tag = 1;
        var nav = $('.subNav');
        if(tag == 1) {
            //要收缩
            nav.animate({'height':'46px'},300,'linear',function(){
                $('#subNavController').css({
                    'border-bottom-color':'red',
                    'border-top-color':'transparent',
                    'margin-top':'4px'
                });
            });
            span.attr('tag','0');
        }else{
            nav.animate({'height':'23px'},300,'linear',function(){
                $('#subNavController').css({
                    'border-bottom-color':'transparent',
                    'border-top-color':'red',
                    'margin-top':'8px'
                });
            });
            span.attr('tag','1' );
        }
    });
});
var doingCover = {
    show : function(trigger){
        trigger = $(trigger);
        var triggerPosition = trigger.position();
        var w = Math.max(trigger[0].offsetWidth,trigger.width());
        var h = Math.max(trigger[0].offsetHeight,trigger.height());
        $('<div class="coverDoing"><img src="/static/imgs/loading.gif" align="center" valign="absmiddle"/></div>').appendTo($(document.body))
            .css({'width':w+'px','height':h+'px','top':triggerPosition.top-5+'px',
                'left':triggerPosition.left-5+'px'});
        $('div.coverDoing img').css({'margin-top':(h-16)/2+'px'});
    },
    hide : function(){
        $('div.coverDoing').remove();
    }
};
function hotKeys() {
    var ua = navigator.userAgent.toLowerCase();
    var str = '';
    var isWebkit = (ua.indexOf('webkit') != - 1);
    var isMac = (ua.indexOf('mac') != - 1);

    if (ua.indexOf('konqueror') != - 1) {
        str = 'CTRL + B'; // Konqueror
    } else if (window.home || isWebkit || isMac) {
        str = (isMac ? 'Command/Cmd' : 'CTRL') + ' + D'; // Netscape, Safari, iCab, IE5/Mac
    }
    return ((str) ? '按 ' + str + '添加收藏.' : str);
}

function addToFavorites(a,title,url)
{
    title = title || document.title;
    url = url || location.href;
    if (window.sidebar) // Firefox
        window.sidebar.addPanel(title, url, '');
    else if(window.opera && window.print) // Opera
    {
        var elem = document.createElement('a');
        elem.setAttribute('href',url);
        elem.setAttribute('title',title);
        elem.setAttribute('rel','sidebar'); // required to work in opera 7+
        elem.click();
    }
    else if(document.all) // IE
        window.external.AddFavorite(url, title);
    else {
        alert(hotKeys());
    }
}
String.prototype.include = function(t) { return this.indexOf(t) >= 0 ? true : false; };
String.prototype.trim = function(){ var r = /^\s+|\s+$/g;return this.replace(r,'');};
String.prototype.unescHtml = function(){ var i,e={'&lt;':'<','&gt;':'>','&amp;':'&','&quot;':'"'},t=this; for(i in e) t=t.replace(new RegExp(i,'g'),e[i]); return t;};
String.prototype.escHtml = function(){ var i,e={'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;'},t=this; for(i in e) t=t.replace(new RegExp(i,'g'),e[i]); return t;};
String.prototype.escAttr = function(){var t = this; t = t.replace('"',"&quot;");return t;};
String.prototype.encodeURI = function(){var t = this;return encodeURIComponent(t);};
String.prototype.decodeURI = function(){var t = this;var t1 = decodeURIComponent(t); while(t != t1){t=t1;t1=decodeURIComponent(t);}return t;};
String.prototype.format = function(){var t=this;for(var i=0;i<arguments.length;i++){t = t.replace('{' + (i) + '}',arguments[i]);}return t;};
String.prototype.isEmail = function(){return /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/.test(this);};
String.prototype.startWith = function(str){var t=this;return t.indexOf(str) == 0;};
String.prototype.endWith = function(str){var t = this;return t.substring(t.length-str.length,t.length) == str;};
String.prototype.isUrl = function(){var reg = /^http:\/\/[A-Za-z0-9\-]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"\"])*$/;
    var t = this; return reg.test(t);};
String.prototype.isNumber = function(){var reg = /^[\d]*[.]?\d*$/;
    var t = this; return reg.test(t);};

var loginHost = document.domain.indexOf('oom.cn') > -1 ? 'http://oom.cn' : 'http://outofmemory.cn';
function showLoginBox(e){
    if(!window.loginUser.isGuest) return true;
    if($('#pop_win_login input#user').length>0) {
        if($('#pop_win_login:visible').length==0)$('#pop_win_login').show();
        $('#pop_win_login input#user').focus();
    }else{
        _showLoginBox('pleaseLogin', true)
    }
    e.stopPropagation();
    e.preventDefault();
    return false;
}

function _showLoginBox(type, returnThisPage) {
    var ajaxUrl =loginHost + '/user/loginBox?t=' + type;
    if (returnThisPage) ajaxUrl += '&returnUrl=' + encodeURIComponent(location.href);

    $.get(ajaxUrl, function(resp,status){
        $(resp).appendTo($(document.body));
        setTimeout(function(){
            var lwin =  Math.round(($(document.body).width() - $('.pop_win').width())/2);;
            $('.pop_win').css({'left':lwin+'px'});
            $('.pop_win_bg').css({'left':lwin-8+'px','height':$('.pop_win').height()+50+'px'});
            $('#pop_win_login input#user').focus();
            $('#pop_win_login button[type="submit"]').click(function(){
                $(this).hide('fast');
                $('<img src="/static/imgs/progress-dots.gif" border="0"/>').insertAfter($(this));
            });
        },1);
    });
}

window.popup = {close:function(){$('.pop_win_bg:last').remove();$('.pop_win:last').remove();},
    _adjustPopWin:function (w,h){
        $('.pop_win:last').css({'width':w+'px','height':h+'px','display':'block'});
        var lwin =  Math.round(($(document.body).width() - $('.pop_win:last').width())/2);
        var twin =  Math.round(($(window).height() - $('.pop_win:last').height())/2);
        var zBg = zIndex.get();
        var zWin = zIndex.get();
        $('.pop_win:last').css({
            'left':lwin+'px',
            'top':twin+'px',
            'display':'block',
            'visibility': 'visible',
            'z-index':zWin});
        $('.pop_win_bg:last').css({
            'width':$(document.body).width()+'px',
            'height':$(document.body).height()+'px',
            'left':'0','top':'0',
            '-webkit-border-radius':'0','-moz-border-radius':'0',
            'display':'block', 'visibility': 'visible','z-index':zBg});
    },
    createPopWin:function (title,url,popId,width,height,funcAfterAdjustWin){
        $('#'+popId+',#'+popId+'_w').remove();
        $.get(url, function(resp,status){
            var h ='<div class="pop_win_bg" id="'+popId+'_w"></div>';
            h+='<div class="pop_win" id="'+popId+'">';
            h+='<a onclick="window.popup.close()" href="javascript:;" class="pop_win_close">X</a>';
            h+='<h3>'+title+'</h3>';
            h+=resp;
            h+='</div>';
            $(h).appendTo($(document.body));
            setTimeout(function(){
                popup._adjustPopWin(width,height);
                if (typeof funcAfterAdjustWin == 'function') {
                    funcAfterAdjustWin();
                }
                $('.pop_win:last input:first').focus();
            },1);
        });
    }
};
window.popupTag = {timerLimit:4, width:260,height:157};

$(function(){
    $('#aCloseInfo').click(function(o){
        $(this).parent().remove();
    });
    var loadingImg = document.createElement('img');
    loadingImg.src ='/static/imgs/progress-dots.gif';

    $('.assertLogin').live('click',function(e){
        return showLoginBox(e);
    });
    var orss = $('link[type="application/rss+xml"]');
    if(orss.length){
        $('.rss').attr('href',orss.attr('href'));
    }

    function closeSettingsMenuDirectly(){
        $('#divSettings').hide('fast');
        $('.uSettings').removeClass('uSelected');
    }
    function closeSettingsMenu(e){
        if(!window.triggerTime) window.triggerTime = new Date().getTime();
        if(new Date().getTime() - window.triggerTime < 2000) return;
        var toEle = e ? e.relatedTarget : null;
        if(!toEle || $(toEle).parents('#divSettings').length == 0) {
            if(!$('.uSettings').hasClass('uSelected')) {
                closeSettingsMenuDirectly();
            }
        }
    }
    $('.uSettings').hover(function(e){
        if($('#divSettings').length==0){
            $('<div class="topMenu" id="divSettings" style="width:120px">'
                +'<ul>'
                +'<li><a href="http://'+host+'/user/followCategorySettings">关注分类</a></li>'
                +'<li><a href="http://'+host+'/user/followSettings">关注标签</a></li>'
                +'<li class="menuSperator"><hr/></li>'
                +'<li><a href="http://'+host+'/user/code/">管理我的代码</a></li>'
                +'<li><a href="http://'+host+'/user/code/draft/">代码草稿箱</a></li>'
                +'<li><a href="http://'+host+'/user/code/favorite/">代码收藏夹</a></li>'
                +'<li class="menuSperator"><hr/></li>'
                +'<li><a href="http://'+host+'/user/avatar">上传头像</a></li>'
                +'<li><a href="http://'+host+'/user/modifyPassword">修改密码</a></li>'
                +'<li class="menuSperator"><hr/></li>'
                +'<li><a href="http://'+host+'/user/logout">退出</a></li>'
                +'</ul>'
            +'</div>').appendTo($(document.body));
        }
        window.triggerTime = new Date().getTime();
        var o = $(this);
        var p = o.position();
        o.addClass('uSelected');
        var top =p.top + o.height()+$(window).scrollTop();
        $('#divSettings').css({'left':p.left - $('#divSettings').width() + o.width() + 'px','top':top + 'px','display':'block'});
    },function(e){
        closeSettingsMenu(e);
    });

    $(document.body).click(function(e){
       if($(this).parents('#divSettings').length == 0) {
           $('#divSettings').hide('fast');
           $('.uSettings').removeClass('uSelected');
       }
    });

    $('#divSettings').mouseout(function(e){
        closeSettingsMenu(e);
    });

    $('.uFollow,.uSettings').mouseover(closeMsgBox);
    $('.uFollow,.uMessage').mouseover(closeSettingsMenuDirectly);
    var otrigger = $('.msgBoxTrigger');
    var hasMsgBoxTrigger = otrigger.length>0;

    function closeMsgBox(){
        $('.messageBox').hide('slow');
        $('.msgBoxTrigger').removeClass('uSelected');
    }

    $(document.body).click(function(event){
        var o=$(event.target);
        if (o.parents('.messageBox').length==0) {
            closeMsgBox();
        }
    });
    if(hasMsgBoxTrigger){

        $('<div class="messageBox">'
            + '<div class="H"><span class="close">x</span>OutOfMemory.CN 消息中心</div>'
            + '<div class="B"><img src="/static/imgs/progress-dots.gif" class="loading"/></div>'
            + '<div class="F">'
            + '<a href="mailto:outofmemory.cn@gmail.com" class="floatRight">联系管理员</a>'
            + '</div>'
        + '</div>').appendTo($(document.body));

        //message box
        otrigger.mouseover(function(e){
            if(!otrigger.hasClass('uSelected'))otrigger.addClass('uSelected');
            var triggerPosition = otrigger.position();
            var msgBoxWidth = 506;
            var left = triggerPosition.left + msgBoxWidth;
            if(left > $(document).scrollLeft() + $(window).width()){
                //left = $(document).scrollLeft() + $(window).width() - msgBoxWidth - 20;
                left = triggerPosition.left - msgBoxWidth + 80;
            }else{
                left = triggerPosition.left-20;
            }

            $('.messageBox').css('left',left+'px').css('top',triggerPosition.top + $(window).scrollTop() +otrigger.height() +1 + 'px')
            $('.messageBox').show('fast');
            if(window.loginUser.isGuest){
                $('.messageBox .B').html('<div class="guest"><p>亲爱的访客，您好，这是一个程序员网站！</p><p>请<a href="'+loginHost+'/user/login" class="login">登录</a>，'
                +'如果您尚没有账户，请<a href="'+loginHost+'/user/rigister">注册</a>!</p><p>如果您不想注册，也可以通过<a href="'+loginHost+'/weibo/login" class="weibo-login">微博</a>'
                +'或<a href="'+loginHost+'/qq/login" class="qq-login">QQ</a>登录。</p><p> 登录后就可以查看消息中心的消息了！</p></div>');
            }else{
                if(!window.lastReadMessageTime || new Date().getTime() - window.lastReadMessageTime > 60*1000) {
                    window.lastReadMessageTime = new Date().getTime();
                    $('.messageBox .B').html('<img src="/static/imgs/progress-dots.gif" class="loading"/>');

                    /**修改为jsonp
                    $.ajax(loginHost+'/message/',{type:'POST',dataType:'html'}).done(function(response){
                        $('.messageBox .B').html(response);
                        //4秒后设置为已读
                        setTimeout(function(){
                            var data = '';
                            $('.messageBox li input[name=mid]').each(function(i,o){
                                if(data.length>0) data += '&';
                                data += 'mid=' + $(o).val();
                            });
                            $.ajax(loginHost+'/message/setRead',{type:'POST',data:data});
                        },4000);
                    });
                    */

                    $.getJSON(loginHost + '/message/?jsoncallback=?',{'type':'jsonp'}).done(function(data){
                        var h ;
                        if(data.length == 0) {
                            h = '<div class="noMsgs">抱歉，尚没有给您的消息！</div>';
                        }else{
                            h = '<ul>';
                            $(data).each(function(i,o){
                                h += '<li class="';
                                if ((o.flags & 2) == 2) h += 'hasRead';
                                else h += 'hasNotRead';
                                h += '">';
                                h += '<input type="hidden" name="mid" value="'+ o.id+'"/>';
                                h += '<h3 class="messageType_'+ o.messageType+'">';
                                h += o.subject;
                                if (o.body) {
                                    h += '<p>'+ o.body +'</p>'
                                }
                                h += '</li>';
                            });
                            h += '</ul>';
                        }
                        $('.messageBox .B').html(h);

                        setTimeout(function(){
                            var data = '';
                            $('.messageBox li input[name=mid]').each(function(i,o){
                                if(data.length>0) data += '&';
                                data += 'mid=' + $(o).val();
                            });
                            if (data) $.ajax(loginHost+'/message/setRead',{type:'get',data:data,dataType:'jsonp'});
                        },4000);
                    });
                }
            }
        });
        $('.messageBox .close').click(function(e){
            closeMsgBox();
        });
    }

    $('.searchBox input').focus(function(e){
        var trWidth = $('.topRight').width()
        var toWidth = 80 + trWidth + 'px';
        var textBox = $(this);
        $('.topRight').hide('fast',function(){
            textBox.animate({'width':toWidth},300);
        });
    }).blur(function(){
            var txtBox = $(this);
            $(this).animate({'width':'70px'},300,function(){
                $('#headRight').width($('.topRight').width() + 120);
                $('.topRight').show('fast');
                txtBox.parents('div.searchBox').css('width:90px');
            });

        }).keyup(function(e){
            if(e.which == 13) $(this).form.submit()
        });
    window.tagCache = {};
    window.tagMouseOver = function(o){
        var trigger = $(this);
        var tag = trigger.prop("tagName") == 'A' ? trigger.html().trim() : trigger.find('a').text().trim();

        window.popupTagTimer = 0;
        window.popupTagInterval = setInterval(function(){
            window.popupTagTimer += 1;
            if(window.popupTagTimer >= window.popupTag.timerLimit){
                var position = trigger.offset();
                var top;
                if(position.top + window.popupTag.height > $(document).scrollTop() + $(window).height()){
                    top = position.top - window.popupTag.height - 6;
                }else{
                    top = position.top + trigger.height() + 4;
                }
                var left;
                if(position.left + window.popupTag.width > $(document).scrollLeft() + $(window).width()) {
                    left = position.left - window.popupTag.width;
                }else{
                    left = position.left;
                }
                $('.tagPopup').remove();
                $('<div class="tagPopup"><img src="/static/imgs/progress-dots.gif" class="loading"/></div>').appendTo($(document.body))
                    .css('left',left+'px').css('top',top + 'px').show('fast');
                if(window.tagCache[tag]){
                    $('.tagPopup').html(window.tagCache[tag]);
                }else{
                    $.ajax('/tag/popup/' + encodeURIComponent(tag),{type:'GET',dataType:'html'}).done(function(response){
                        window.tagCache[tag] = response;
                        $('.tagPopup').html(response);
                    });
                }
                window.tagMouseOut();
            }
        },100);
    };
    window.tagMouseOut = function(){
        window.clearInterval(window.popupTagInterval);
        window.popupTagTimer=0;
    };
    //tag popup
    $('div.tag,a.tag').hover(window.tagMouseOver,window.tagMouseOut);

    $('A.followed,A.unFollow').live('click',function(e){
        var a = $(e.currentTarget);
        var href = a.attr('rel');
        var hasFollow = a.hasClass('followed');
        if ($('.tagPopup .loading').length==0){
            $('<img src="/static/imgs/progress-dots.gif" class="loading"/>').insertAfter('.tagPopup A:last');
        }
        $.ajax(href,{type:'POST',dataType:'json'}).done(function(response){
            window.tagCache = {};
            $('img.loading').remove();
            if(response.result) {
                if(hasFollow) {
                    a.removeClass('followed').addClass('unFollow');
                    a.attr('title','已取消关注，再次点击保持关注');
                }else {
                    a.removeClass('unFollow').addClass('followed');
                    a.attr('title','已关注，点击可以取消关注');
                }
            }else alert('非常抱歉，内部错误，未能正常操作');
        });

        //e.stopPropagation();
        e.preventDefault();
        return false;
    });
    $(document.body).click(function(ev){
        if($('div.tagPopup:visible').length) {
            var trigger = $(ev.target);
            if(trigger.parents('div.tagPopup').length > 0){
                return;
            }
            if(trigger.parents('.pop_win:visible').length>0) {
                return;
            }
            $('div.tagPopup').hide('fast');
        }
    });
});
/*$(window).scroll(function() {
    try{
        var $offset = $('.sidebarISO').last().offset();
        if($(window).scrollTop()>($offset.top)) {
            $('.sidebarISO').css('border-width',0);
            var top = $('.subNav').length>0 ? 50 : 42;
            var marginTop = $('.subNav').length>0 ? 10 : 5;
            $('.sidebarISO iframe').last().css({'text-align':'center',
                'border':'1px solid lightblue','position':'fixed','top': top + ($('.subNav').length > 0 ? $('.subNav').height() : 0) + 'px',
                'left':$offset.left+'px','margin-top':marginTop + 'px','z-index':'999'});
        } else {
            $('.sidebarISO').css('border-width',1);
            $('.sidebarISO iframe').last().css({'border':'none','position':'relative','top':'','left':'','margin-top':'0','z-index':'0'});
        }
    }catch(e){}
});
*/
Date.prototype.toRelativeTime = function(now_threshold) {
    var delta = new Date() - this;

    now_threshold = parseInt(now_threshold, 10);

    if (isNaN(now_threshold)) {
        now_threshold = 0;
    }

    if (delta <= now_threshold) {
        return '刚刚';
    }

    var units = null;
    var conversions = {
        '毫秒': 1, // ms    -> ms
        '秒': 1000,   // ms    -> sec
        '分钟': 60,     // sec   -> min
        '小时':   60,     // min   -> hour
        '天':    24,     // hour  -> day
        '月':  30,     // day   -> month (roughly)
        '年':   12      // month -> year
    };

    for (var key in conversions) {
        if (delta < conversions[key]) {
            break;
        } else {
            units = key; // keeps track of the selected key over the iteration
            delta = delta / conversions[key];
        }
    }

    // pluralize a unit when the difference is greater than 1.
    delta = Math.floor(delta);
    return [delta, units].join("") +'前';
};
$(function(){
    function toInt(str){return parseInt(str.replace(/^0?/,''));}
    $('.time').each(function(i,o){
        o=$(o);
        var strDate = o.html();
        var parts = strDate.split(' ');
        var ymd = parts[0].split('-');
        var hms = parts[1].split(':');
        var d = new Date(parseInt(ymd[0]),
            toInt(ymd[1])-1,
            toInt(ymd[2]),
            toInt(hms[0]),
            toInt(hms[1]),
            toInt(hms[2]));
        o.html(d.toRelativeTime(2000)).attr('title',strDate);
    });
});
$(function(){
    var pathname = location.pathname.toLowerCase();
    var isLoginOrRegisterPage = pathname.indexOf('/user/login')>-1 ||  pathname.indexOf('/user/register')>-1;
    var isOpenLoginErrorPage = pathname.indexOf('/loginerror')>-1;
    if (!isLoginOrRegisterPage && !isOpenLoginErrorPage){
        $('A.login').attr('href',loginHost+'/user/login?url=' + encodeURIComponent(location.href));
        $('A.weibo-login').attr('href',loginHost+'/weibo/login?returnUrl=' + encodeURIComponent(location.href));
        $('A.qq-login').attr('href',loginHost+'/qq/login?returnUrl=' + encodeURIComponent(location.href));
    }
});
$(function(){
    //当滚动条的位置处于距顶部100像素以下时，跳转链接出现，否则消失
    $(function () {
        $(window).scroll(function(){
            if ($(window).scrollTop()>100){
                $("#back-to-top").fadeIn(1500);
            }
            else
            {
                $("#back-to-top").fadeOut(1500);
            }
        });

        //当点击跳转链接后，回到页面顶部位置

        $("#back-to-top").click(function(){
            $('body,html').animate({scrollTop:0},1000);
            return false;
        });
    });
});
/*
* 智能机浏览器版本信息:
*/
var browser={
    versions:function(){
    var u = navigator.userAgent, app = navigator.appVersion;
    return {//移动终端浏览器版本信息
    trident: u.indexOf('Trident') > -1, //IE内核
    presto: u.indexOf('Presto') > -1, //opera内核
    webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
    gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核
    mobile: !!u.match(/AppleWebKit.*Mobile.*/)||!!u.match(/AppleWebKit/), //是否为移动终端
    ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
    android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
    iPhone: u.indexOf('iPhone') > -1 || u.indexOf('Mac') > -1, //是否为iPhone或者QQHD浏览器
    iPad: u.indexOf('iPad') > -1, //是否iPad
    webApp: u.indexOf('Safari') == -1 //是否web应该程序，没有头部与底部
    };
}(),
language:(navigator.browserLanguage || navigator.language).toLowerCase()
};

//top trigger menu
$(function(){
    $('.topMenuTrigger').hover(function(e){
        var o = $(this);
        o.addClass('topMenuTriggerSelected');
        var p = o.position();
        $('#divGlobalNavMenu').css({'left':p.left + 'px','top':p.top+ o.height()+'px','display':'block'});
        window.triggerTime = new Date().getTime();
    });
    function hideMenu(){
        $('.topMenu').hide('fast');
        $('.topMenuTriggerSelected').removeClass('topMenuTriggerSelected').addClass('topMenuTrigger');
    }
    $('#divGlobalNavMenu').mouseout(function(e){
        var passTime =new Date().getTime() - window.triggerTime;
        if(passTime < 2000) return;
        var toEle = e.relatedTarget;
        if($(toEle).parents('.topMenu').length == 0) {
            hideMenu();
        }
    });

    $(document.body).click(function(e){
        if($(e.currentTarget).parents('.topMenu').length==0) {
            hideMenu();
        }
    });
});


function upOrDown(type){
    $.post("/"+voteTargetType+"/"+voteTargetId+"/vote", { type: type },
        function (response, textStatus){
            doingCover.hide();
            // data 可以是 xmlDoc, jsonObj, html, text, 等等.
            //this; // 这个Ajax请求的选项配置信息，请参考jQuery.get()说到的this
            if(!response.success){
                alert(response.message);
            } else {
                var status = response.status;
                if (status == 1) {
                    $('.voteUp').removeClass('voteUp').addClass('votedUp');
                    $('.votedDown').removeClass('votedDown').addClass('voteDown');
                } else if (status == -1) {
                    $('.voteDown').removeClass('voteDown').addClass('votedDown');
                    $('.votedUp').removeClass('votedUp').addClass('voteUp');
                } else {
                    //表示顶踩被取消
                    $('.votedUp').removeClass('votedUp').addClass('voteUp');
                    $('.votedDown').removeClass('votedDown').addClass('voteDown');
                }
                $('.votes span').first().html(response.upCount||0);
                $('.votes span').last().html(response.downCount||0);
            }
        }, "json");
}

function onGetVoteStatus(response) {
    // data 可以是 xmlDoc, jsonObj, html, text, 等等.
    //this; // 这个Ajax请求的选项配置信息，请参考jQuery.get()说到的this
    if(response.success){
        var type = response.type;
        $(".voteUp").click(function(){

            if(!window.loginUser.isGuest){
                var trigger = this;
                doingCover.show(trigger);
                upOrDown(1);
            }
        });

        $(".voteDown").click(function(){
            if(!window.loginUser.isGuest){
                var trigger = this;
                doingCover.show(trigger);
                upOrDown(-1);
            }
        });

        if (type == "0") {
            //no up and no down
        } else if (type == "1") {
            $(".voteUp").removeClass('voteUp').addClass('votedUp');
            var votedMsg = '您顶过了，再次点击可以取消';
            $('.votedUp a').attr('title',votedMsg);
            $(".voteDown a").attr('title','您顶过了，改变了看法可以点踩');
            //用户已经顶过，再次点击顶时取消顶，再次点击踩时取消顶，加踩
        } else if (type == "-1") {
            $(".voteDown").removeClass('voteDown').addClass('votedDown');
            var votedMsg = '您踩过了，再次点击可以取消';
            $('.votedDown a').attr('title',votedMsg);
            $('.voteUp').attr('title','您踩过了，改变看法可以点顶');
            //用户已经踩过，再次点击顶取消踩加顶，再次点击踩时取消踩
        }
    } else {

    }
}

function externalLinkClick(e){
    var a = $(this);
    var href = a.prop('href');
	if(href.indexOf('javascript:') > -1) return;
    var maybeDownloadFileExtensions = ['.pdf','.zip','.rar','.doc','.docx','.xls','.xlsx','.ppt','.pptx','.exe','.msi','.rpm'];
    var isDownloadFile = false;
    for (var i=0;i<maybeDownloadFileExtensions.length;i++){
        if(href.toLowerCase().endWith(maybeDownloadFileExtensions[i])) {
            isDownloadFile = true;
            break;
        }
    }
    if(isDownloadFile) {
        return;
    }
    var linkHost = a.prop('hostname');
    if (linkHost.indexOf(host) == -1){
        a.attr('href','http://'+host+'/wr/?u=' + encodeURIComponent(href));
        a.attr('target','_blank');
    }
}

$(function(){
    $('.newComment textarea').bind('focus',function(e){
        showLoginBox(e);
    });
    $('.replyComment').click(function(ev){
        var trigger = $(this);
        var commentHtml = $('div.comment:first',trigger.parents('li:first')).html();
        var replyUserHref = trigger.next('a:first').attr('href');
        var replyUserName = trigger.next('a:first').html();
        var newH3 = $('div.newComment h3');
        $('div.newComment blockquote').remove();
        $('<blockquote class="replyContent"><div>'+commentHtml+'</div><a href="'+replyUserHref+'" class="replyUser">'
            +replyUserName+'</a></blockquote>').insertAfter(newH3);
        $('div.newComment textarea').focus();
        var replyId = $('a:first',trigger.parents('li:first')).attr('name').substring('comment-'.length);
        $('div.newComment input[name="replyId"]').val(replyId);
    });
    $('#btnComment').click(
        function(e){
            if(window.loginUser.isGuest) {
                showLoginBox(e);return;
            }
            $('#commentTip').html('');
            var btn = $(this);
            var form = btn.prop('form');
            var content =  $('textarea',$(form)).val();
            if(content=='' || content.length < 5){
                $('#commentTip').html('评论内容太少了呀').css('color','red');
                return;
            }
            $(this).attr('disabled',true);
            $('<span class="submitting">提交中...</span>').insertAfter($(this));
            var replyId =$('input[name="replyId"]',$(form)).val();
            var title =  $('input[name="title"]',$(form)).val();
            var data = 'targetId=' + $('input[name="targetId"]',$(form)).val()
                + '&title='+ encodeURIComponent(title)
                + '&content='+ encodeURIComponent(content)
                + '&replyId=' + replyId;
            if ($('.newComment #captcha').length>0){
                data += '&captcha=' + $('.newComment #captcha').val();
            }

            $.ajax({url:form.action,dataType:'json',type:'POST',data:data}).done(function(response){
                if(response.success){
                    var commentList = $('.comments ul')
                    if(!commentList.length){
                        $('<h3>评论</h3>').appendTo($('.comments'));
                        commentList = $('<ul></ul>').appendTo($('.comments'));
                    }
                    $('<li>'
                        + (replyId ? '<blockquote class="replyContent">' + $('div.newComment blockquote.replyContent').html() + '</blockquote>':'')
                        +'<div class="comment md">'+content+'</div>'
                        + '<div class="commentFoot">您刚刚发表</div></li>').appendTo(commentList);
                    $('textarea',$(form)).val('');
                    $(form).prev('blockquote.replyContent').remove();
                    $('input[name="replyId"]').val('');
                    $('#commentTip').html('提交成功了').css({'color':'green'});
                    $('.captchaWrapper').remove();
                }else{
                    $('#commentTip').html(response.message).css({'color':'red'});
                }

                $('.submitting').remove();
                $('#btnComment').attr('disabled',false);
            });
        }
    );
});
function loadCss(url){
    var cb = function() {
        var l = document.createElement('link'); l.rel = 'stylesheet';
        l.href = url;
        var h = document.getElementsByTagName('head')[0]; h.parentNode.insertBefore(l, h);
    };
    var raf = requestAnimationFrame || mozRequestAnimationFrame ||
        webkitRequestAnimationFrame || msRequestAnimationFrame;
    if (raf) raf(cb);
    else window.addEventListener('load', cb);
}

var zIndex = {
    current:9999,
    get:function(){
        return ++zIndex.current;
    }
};
function showCommentCaptcha(){
    var otxt = $('.newComment textarea').focus(function(e){
        if($('.newComment #captcha').length==0){
            var h = '<div class="p4 captchaWrapper"><div class="p2"><label for="captcha">验证码：</label></div>'
                +  '<img alt="看不清？点击更换验证码图片" title="看不清？点击更换验证码图片" src="/captcha?'+new Date().getTime()
                + '" onclick="this.src=&quot;/captcha?&quot; + new Date().getTime()"/><br/><input size="4" maxlength="4" type="text" id="captcha" name="captcha"/>'
                + '</div>';

            $(h).insertBefore($('.newComment p:last'));
            setTimeout(function(){enableAutoCheckCaptcha('captcha');},100);
        }
    });
}

$('img').bind('error',function(e){
    var img=$(this);
    var src = img.attr('src');
    if (src.startWith('http://') && src.indexOf(host) == -1) {
        img.attr('src', 'http://ju.' + host + '/imgr?src=' + encodeURIComponent(src));
    }else{
        if (!src.startWith('http://') || src.indexOf(host) > -1) {
            if(src != src.toLowerCase()) {
                img.attr('src', src.toLowerCase());
            }
        }
    }
});

function enableAutoCheckCaptcha(id, callback){
    var dashId = '#' + id;
    $(dashId).live('keyup', function(e){
        var o = $(dashId);
        var val = o.val();
        if (val.length==4) {
            var name =o.attr('name');
            if($('.captchaStatus',o.parents('form')).length>0) return;

            $('<span class="captchaStatus checking"><img src="/static/imgs/progress-dots.gif"/></span>')
                .insertAfter(o);
            $('.captchaStatus',o.parents('form')).remove();
            $.post('/captcha?k=' + name, {'captcha': val}, function(data, status, jqXHR){
                $('.captchaStatus').remove();
                var h = data.result ? '<span title="验证通过" class="captchaStatus correct">正确</span>'
                    : '<span title="错误验证码" class="captchaStatus incorrect">错误</span>';
                $(h).insertAfter($(dashId));
                if (callback && typeof callback == 'function') callback(data);
            }, 'json');
        }else{
            $('.captchaStatus').remove();
        }
    });
}
// if user is guest, show login please tip
var isTools = location.pathname.length>7 && location.pathname.substring(0,7) == '/tools/';
var isPC = typeof window.deviceType == 'undefined' || window.deviceType != 'mobile';
if(isPC && (!isTools) ) {
$(function(e){
    var pathname = location.pathname.toLowerCase();
    if (pathname == '/user/login' || pathname == '/user/register') return;
    var hasShown = false;
    var cookie = 'loginBox';
    if (typeof $.cookie != 'function') {
        $.getScript('/static/js/jquery-cookie.js', function(){
            hasShown = $.cookie(cookie) == '1';
            __showLoginBox();
        })
    } else{
        hasShown = $.cookie(cookie) == '1';
        __showLoginBox();
    }

    function __showLoginBox(){
        if ($('div.userStatus').length==0)return;
        if (window.loginUser.isGuest && !hasShown) {
            setTimeout(function(){
                if(window.loginUser.isGuest){
                    if($('input:focus,select:focus').length==0) {
                        _showLoginBox('loginWillbeBetter', false);
                        $.cookie(cookie, 1, {expires:1,path:'/', domain:host});
                    }
                }
            }, 8*1000);
        }
    }
});
}