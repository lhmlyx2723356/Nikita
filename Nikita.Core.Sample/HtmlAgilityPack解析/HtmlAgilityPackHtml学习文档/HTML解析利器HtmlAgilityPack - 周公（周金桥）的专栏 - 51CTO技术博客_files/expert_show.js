(function($){
	$(function(){
		$('.blogLeft').css({'overflow':'visible'});
		$('<div class="floatimg" style="display:none"></div>').hover(function(){
			$(this).show();
		}, function(){
			$(this).hide();
		}).appendTo('.moduleUser .title');

		var expert_info = [];//专家信息
		$('.blogLevel').each(function(){
			var info = $(this).attr('uid');
			$(this).hover(function(){
				
				//var pos = getPosition($(this), $('.floatimg'), conf);
				if (undefined == expert_info[info]) {
					$.post('/user/expert_show.php',{uid:info}, function(res){
						expert_info[info] = res;//$('.floatimg').html(info);
						$('.floatimg').html(expert_info[info]);
					});
				}else {
					$('.floatimg').html(expert_info[info]);
				}		
				$('.floatimg').fadeIn(300);
				
			},function(){
				$('.floatimg').hide();
			});
		});	
	});
})(jQuery);