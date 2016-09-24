jQuery.cookie = function(name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
        // CAUTION: Needed to parenthesize options.path and options.domain
        // in the following expressions, otherwise they evaluate to undefined
        // in the packed version for some reason...
        var path = options.path ? '; path=' + (options.path) : '';
        var domain = options.domain ? '; domain=' + (options.domain) : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};
var COOKIE_TAGS = 'itags';
function loadInstresting(){
    var instresting=[];
    var exists = $.cookie(COOKIE_TAGS);

    if(exists){
        var arr = exists.split('-');
        if(arr){
            for(var item in arr){
                if(!item)continue;
                var kv = item.split('_');
                if(kv.length!=2)continue;
                var tid = parseInt(kv[0]);
                var times = parseInt(kv[1]);
                if(tid && times)
                    instresting.push({'tid':tid,'times':times});
            }
        }
    }
    return instresting;
}
function addInstresting(instresting,tid){
    tid = parseInt(tid);
    var increase=false;
    for(var i= 0;i<instresting.length;i++){
        var item=instresting[i];
        if(item.tid == tid){
            item.times = item.times+1;
            increase=true;
            break;
        }
    }
    if(!increase){
        instresting.push({'tid':tid,'times':1});
    }
    return instresting;
}
function saveInstresting(instresting){
    for(var i=0;i<instresting.length-1;i++){
        var iVal = instresting[i];
        for(var j=i+1;j<instresting.length;j++) {
            var jVal=instresting[j];
            if(jVal.times>iVal.times){
                var temp = iVal;
                instresting[i]=jVal;
                instresting[j]=temp;
            }
        }
    }
    if(instresting.length>10){
        instresting.length=10;
    }
    var cookieValue='';
    for(var i= 0;i<instresting.length;i++){
        var item=instresting[i];
        var val = item.tid.toString() + '_' + item.times.toString();
        if(cookieValue != '') cookieValue+='-';
        cookieValue+=val;
    }
    $.cookie(COOKIE_TAGS,cookieValue,{'expires':365,'path':'/','domain':'outofmemory.cn'});
}

function addGuessTabItem(){
    var interesting = loadInstresting();
    if (interesting.length>0){
        $('<a href="/interesting/">猜您喜欢</a> ').appendTo($('.tabs'));
    }
}

/**share**/
(function(eleContainer) { //实现方法
    var eleTitle = document.getElementsByTagName("title")[0];
    eleContainer = eleContainer || document;
    var funGetSelectTxt = function() { //获取选中文字
        var txt = "";
        if(document.selection) {
            txt = document.selection.createRange().text; // IE
        } else {
            txt = document.getSelection();
        }
        return txt.toString();
    };
    var eleShare,eleShare2;
    document.onmouseup = function(e) { //限定容器若有文字被选中
        e = e || window.event;
        if($('#imgSinaShare').length==0){
            $('<IMG class="img_sina_share" id="imgSinaShare" title="将选中内容分享到新浪微博" '
                + ' src="/static/imgs/sina-share.gif"/><IMG class="img_qq_share" id="imgQqShare"'
                + ' title="将选中内容分享到腾讯微博" src="/static/imgs/qq-share.gif"/>').appendTo($(eleContainer));
        }
        eleShare = document.getElementById("imgSinaShare"); //新浪微博图标
        eleShare2 = document.getElementById("imgQqShare"); //腾讯微博图标
        var txt = funGetSelectTxt(), sh = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;
        var left = (e.clientX - 40 < 0) ? e.clientX + 20 : e.clientX - 40, top = (e.clientY - 40 < 0) ? e.clientY + sh + 20 : e.clientY + sh - 40;
        if (txt) {
            eleShare.style.display = "inline";
            eleShare.style.left = left + "px";
            eleShare.style.top = top + "px";
            eleShare2.style.display = "inline";
            eleShare2.style.left = left + 30 + "px";
            eleShare2.style.top = top + "px";

            eleShare.onclick = function() { //点击新浪微博图标
                var txt = funGetSelectTxt(), title = (eleTitle && eleTitle.innerHTML)? eleTitle.innerHTML : "未命名页面";
                if (txt) {
                    window.open('http://v.t.sina.com.cn/share/share.php?title='
                        + encodeURIComponent(txt + '→来自页面"' + title) + '&url=' + encodeURIComponent(window.location.href));
                }
            };
            eleShare2.onclick = function() { //点击腾讯微博图标
                var txt = funGetSelectTxt(), title = (eleTitle && eleTitle.innerHTML)? eleTitle.innerHTML : "未命名页面";
                if (txt) {
                    window.open( 'http://v.t.qq.com/share/share.php?title='
                        + encodeURIComponent(txt + '→来自页面"' + title)
                        + '&url=' + encodeURIComponent(window.location.href));
                }
            };
        } else {
            eleShare.style.display = "none";
            eleShare2.style.display = "none";
        }
    };

})(document.body);


var instresting = loadInstresting();
//将本页中存在的标签记录到instresting中
$('.tagWrap').each(function(i,o){
    var a = $('a',$(o));
    var tid = a.attr('id').substring(3);
    instresting=addInstresting(instresting,tid);
});
saveInstresting(instresting);
$(function(){
    $('.md img').each(function(i,o){
        if($(o).width()>740) $(o).width(740);
    });
});

$('.newComment textarea').bind('focus',function(e){
    showLoginBox(e);
});



//load favorite status
function onGetFavoriteCodeStatus(response){
    if(response===true){
        $('.favorite').addClass('favorited').attr('title','这个代码已经添加到您的收藏夹了，再次点击可以取消收藏');
    }else{
        $('.favorite').addClass('unfavorited').attr('title','这个代码对您有用？收藏它吧！');
    }
    $('.favorite').click(function(e){
        if(window.loginUser.isGuest)return;
        var actionType = $(this).hasClass('favorited') ? 'remove' : 'add';
        var trigger = $(this);
        doingCover.show(trigger);
        $.post('/code-snippet/' + codeId + '/favorite',{type:actionType},function(response,status){
            doingCover.hide();
            if(response.success){
                if(actionType == 'remove'){
                    $('.favorite').removeClass('favorited').addClass('unfavorited').attr('title','这个代码对您有用？收藏它吧！');
                    $('.favoriteBox .num').html(parseInt($('.favoriteBox .num').html())-1);
                }else{
                    $('.favorite').removeClass('unfavorited').addClass('favorited').attr('title',
                        '这个代码已经添加到您的收藏夹了，再次点击可以取消收藏');
                    $('.favoriteBox .num').html(parseInt($('.favoriteBox .num').html())+1);
                }
            }else{
                alert(response.message);
            }
        },'json');
    })
}

$('.deleteCode').click(function(e){
    var trigger = $(this);

    var confirmDiv = $('<div class="confirmDeleteWrap">您确认要删除吗？'
        +' <a href="javascript:void(0)" class="confirmDelete">确认</a> '
        +'<a href="javascript:void(0)" class="cancelDelete">取消</a></div>').appendTo($(document.body));
    var left = trigger.position().left +trigger.width() - confirmDiv.width() +  'px';
    var top = trigger.position().top + trigger.height() + 'px';
    confirmDiv.css({'left':left,'top':top,'display':'none'}).show('fast');
    $('.confirmDelete',confirmDiv).click(function(e){
        if(window.loginUser.isGuest){
            showLoginBox(e);
            return;
        }
        //real delete
        $.post('/code-snippet/'+codeId+'/delete',null,function(response,status){
            if(response.success){
                history.back();
            }else{
                alert(response.message);
            }
        },'json');
    });

    $('.cancelDelete',confirmDiv).click(function(e){
        $('.confirmDeleteWrap').remove();
    });
});
$(prettyPrint);


/**
(function() {
    $.get("/code-snippet/"+codeId+"/upordown",
        function (response, textStatus){
            onGetVoteStatus(response);
        }, "json");
})();
*/

var shareCode = '<div class="bshare-custom" style="float:right"><a title="分享到新浪微博" class="bshare-sinaminiblog"></a><a title="分享到QQ空间" class="bshare-qzone" href="javascript:void(0);"></a><a title="分享到人人网" class="bshare-renren"></a><a title="分享到腾讯微博" class="bshare-qqmb"></a><a title="分享到开心网" class="bshare-kaixin001" href="javascript:void(0);"></a><a title="分享到豆瓣" class="bshare-douban"></a><a title="更多平台" class="bshare-more bshare-more-icon more-style-addthis"></a></div><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/buttonLite.js#style=-1&amp;uuid=&amp;pophcol=2&amp;lang=zh"></script><script type="text/javascript" charset="utf-8" src="http://static.bshare.cn/b/bshareC0.js"></script>';
$(function(ev){
    var votes = $('.votes');
    if(votes.length) {
        //remove for too slow
        //$(shareCode).insertBefore(votes);
    }
    var tagList = $('.content .tagList');
    if(tagList.length) {
        //remove for too slow
        //$(shareCode).insertBefore(tagList);
    }else{
        //remove for too slow
        //$(shareCode).insertBefore($('.content').first());
    }
});

//rebuild tags below content
$(function(){
    var tags = $('p.tags strong').text();
    var tagArr = tags.split(',');
    var html = '';
    $(tagArr).each(function(i,tag){
        html += ('<div class="tag" title="'+tag+'"><div class="ar"></div><div class="co">'
            + '<a href="/code-snippet/tagged/'+ encodeURIComponent(tag) +'" class="name">'
            + '<strong>'+tag+'</strong>'
            +'</a></div></div>');
    });
    if(html){
        html = '<div class="tagList">' + html + '</div>';
        ele = $(html).insertBefore($('p.tags'));
        //tag popup
        $('div.tag',ele).hover(window.tagMouseOver,window.tagMouseOut);

        $('p.tags').remove();
    }
});