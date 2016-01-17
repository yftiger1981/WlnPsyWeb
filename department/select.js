$.showInfo=function(text)
{
	if(text.isLastPage)
	    $('#more-photos').hide('fast');  
	else if($('#more-photos').css('display')=='none')
		$('#more-photos').show('fast');  
	    if(text.consulters)
           {
			$.each(text.consulters,function(index,item)
		     {
		       var username=item.username;
			   var level=item.prolevel;
			   var headPhoto=item.headPhoto;
			   var prefer=item.profession;
			   var selfIntro=item.selfIntro;  
			   var photo = $('#photo' + index);
			   photo.show('fast');
			   photo.children("#consulter").show('fast');
			   photo.children("#bussiness").hide('fast');
			   photo.children('div').children('.details').children('.description').text(selfIntro);
			   photo.children('div').children('img').attr('src',headPhoto);
			   photo.children("#consulter").children('#name').children('li').children('p').children('span').text(username);
			   photo.children("#consulter").children('#level').children('li').children('p').children('span').text(level);	 
			   photo.children("#consulter").children('#proference').children('li').children('p').children('span').text(prefer);	 	
		     });	
		   }
		   else if(text.bussiness)
		   {
		    $.each(text.bussiness,function(index,item)
		     {
		       var username=item.username;
			   var phone=item.phone;  
			   var intro=item.intro;
			   var Img=item.Img;
			   var photo=$('#photo'+index);
			   photo.show('fast');
			   photo.children("#consulter").hide('fast');
			   photo.children("#bussiness").show('fast');
			   photo.children('div').children('.details').children('.description').text(intro);
			   photo.children('div').children('img').attr('src',Img); 
			   photo.children("#bussiness").children('#name').children('li').children('p').children('span').text(username);
			   photo.children("#bussiness").children('#phone').children('li').children('p').children('span').text(phone);	    
		     });
		 }	
	}
	$.prevhide=function(pagenum)
	{
		if(pagenum==1)
		 $('#prev-photos').hide('fast');
		 else
		 if($('#prev-photos').css('display')=='none')
		   $('#prev-photos').show('fast');
	}

$(document).ready(function()
{
	     var optionvalue='consulter';
		 var pagenum=1;
		 for (var i = 0; i < 9; i++)
	      {
	          $('#photo' + i).show('fast');
	      }
		    $.post('select.ashx',{'role':optionvalue,'pagenum':pagenum},function(text){
	        $.showInfo(text)
		  },'json');
		  
	
	$('.consulterID').click(function()
	 {
		event.preventDefault();
		var parentID=$(this).parent('div').attr('id');
		var username=$(this).parent('div').children('#name').children('li').children('p').children('span').text();
		 if(parentID=="consulter")
		 {
		 window.open("consulterDetail.aspx?username="+username);
		 }
		 else
		 window.open("bussinessDetail.aspx?username="+username);
     });								 
									 
	 var pagenum=1;
	 if(pagenum==1)
	 {
	   $('#prev-photos').hide('fast');
	   $('#more-photos').show('fast');
	 }
	  $('.photo').each(function()
	  {
		$(this).hide('fast');
	  });
	  $('#option').change(function()
	  {
	      var optionvalue = $(this).val();
	      for (var i = 0; i < 9; i++)
	      {
	          $('#photo' + i).hide('fast');
	      }
		  $.post('select.ashx',{'role':optionvalue,'pagenum':pagenum},function(text){
	        $.showInfo(text)
		  },'json');
	  });
	  
    $('#more-photos').click(function()
	   {
		  for (var i = 0; i < 9; i++)
	      {
	          $('#photo' + i).hide('fast');
	      } 
	    pagenum++;
		$.prevhide(pagenum);
		var role=$('#option option:selected').val();
		$.post('select.ashx',{'role':role,'pagenum':pagenum},function(text){
				$.showInfo(text);													  
		  },'json');    
		});
	
   $('#prev-photos').click(function()
	{
        event.preventDefault();
		 for (var i = 0; i < 9; i++)
	      {
	          $('#photo' + i).hide('fast');
	      }
	    pagenum--;
		$.prevhide(pagenum);
		 var role=$('#option option:selected').val();
		 $.post('select.ashx',{'role':role,'pagenum':pagenum},function(text){
		    $.showInfo(text);
		  },'json');     
	});	    
 });