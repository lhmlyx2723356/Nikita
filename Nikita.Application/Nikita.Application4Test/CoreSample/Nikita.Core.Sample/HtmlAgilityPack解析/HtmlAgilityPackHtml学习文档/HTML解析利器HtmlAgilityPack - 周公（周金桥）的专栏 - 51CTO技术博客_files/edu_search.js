$(document).ready(function(){
	$data = $('#article_edu_void').attr("rel");
	$type = "ArticeCourse";
	$url  = "/mod/edu_void.php";
	$.post($url,{info:$data,type:$type},function(data){
		if(data) {
			var data=eval("("+data+")");
			var data1 = data['data1'];
			var data2 = data['data2'];
			var link1 = data['link1']!="" ? data['link1']:"";
			var link2 = data['link2']!="" ? data['link2']:"";
			var who   = data['who'] != ""? data['who'] :"";
			var str   = "";
			var dis_a = data1!=""? '' : 'display:none;';
			var dis_b = data2!=""? '' : 'display:none;';
			var edu_jia = parseInt($("#edu_jia").val());
			if(data1 && 3==data1.length){
				dis_a += 'width:100%;';
			}
			if(data2) { 
				switch(data.length){
					case 1:
						dis_b += 'width:'+(1 * 244+edu_jia)+'px;';
					 break;
					case 2:
						dis_b += 'width:'+(2 * 244+edu_jia)+'px;';
					 break;
					case 3:
						dis_b += 'width:100%;';
						break;
				}
			}
			str+='<div class="box edu-col-a" style='+dis_a+'>';
			str+='<div class="title">'+who+'&#x7684;&#x89C6;&#x9891;&#x8BFE;&#x7A0B;';
			if(link1) {
				  str+='<a href='+link1+' target="_blank" style="float:right;">&#x66F4;&#x591A;</a>';
			}
			str+='</div>';
			str+='<div class="vbox" style="">';
			if(data1 && data1.length> 0){
				for(var j = 0 ; j<data1.length;j++){
					str+='<div class="vlist video-icon" style="margin: 2px 8px;">';
					str+='<a href="http://edu.51cto.com/course/course_id-'+data1[j].course_id+'.html" target="_blank"><img src="http://s2.51cto.com/'+data1[j].imageurl+'" height="63" width="86"></a>';
					str+='<dl>';
					str+='<dt> <a href="http://edu.51cto.com/course/course_id-'+data1[j].course_id+'.html" target="_blank" title="'+data1[j].title+'">'+data1[j].title+'(&#x5171;'+data1[j].lession_nums+'&#x8BFE;&#x65F6;)</a></dt>';
					str+='<dd>'+data1[j].play_nums+'&#x4EBA;&#x5B66;&#x4E60;</dd>';
					str+='</dl>';
					str+='<a class="i_video" href="http://edu.51cto.com/course/course_id-'+data1[j].course_id+'.html" target="_blank"></a>';
					str+='</div>';
				}
			}
			str+='<div class="clear hr10"></div>';
			str+='</div>';
			str+='</div>';
			str+='<div class="box edu-col-b" style='+dis_b+'>';
			str+='<div class="title"><a target="_blank" href="'+link2+'">&#x76F8;&#x5173;&#x89C6;&#x9891;&#x8BFE;&#x7A0B;</a>';
			if(link2){
				str+='<a href="'+link2+'" target="_blank" style="float:right;">&#x66F4;&#x591A;</a>';
			}
			str+='</div><div class="vbox" style="">';
			if(data2 && data2.length> 0){
				for(var i = 0; i< data2.length;i++){
					str+='<div class="vlist video-icon" style="margin: 2px 8px;">';
					str+='<a href="http://edu.51cto.com/course/course_id-'+data2[i].course_id+'.html?edu_recommend_adid=91" target="_blank"><img src="http://s2.51cto.com/'+data2[i].imageurl+'" height="63" width="86"></a>';
					str+='<dl>';
					str+='<dt> <a href="http://edu.51cto.com/course/course_id-'+data2[i].course_id+'.html?edu_recommend_adid=91" target="_blank" title="'+data2[i].title+'">'+data2[i].title+'(&#x5171;'+data2[i].lession_nums+'&#x8BFE;&#x65F6;)</a></dt>';
					str+='<dd>'+data2[i].play_nums+'&#x4EBA;&#x5B66;&#x4E60;</dd>';
					str+='</dl>';
					str+='<a class="i_video" href="http://edu.51cto.com/course/course_id-'+data2[i].course_id+'.html?edu_recommend_adid=91" target="_blank"></a>';
					str+='</div>';
				}
				str+='<div class="clear hr10"></div>';
				str+='</div></div>';
			}
			//插入html
			$(str).appendTo('.edu_insert');
 		}
	});
});