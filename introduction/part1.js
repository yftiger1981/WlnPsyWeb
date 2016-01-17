
$(document).ready(function () {
    var $books = $('#books').cycle({
        timeout: 2000,
        speed: 200,
    });
   /* if ($.cookie('cyclePaused')) {
        $books.cycle('pause');
    }*/
  <!--  var $controls = $('<div id="books-controls"></div>').insertAfter($books);-->
	$('#pausebtn').click(function{
		 $books.cycle('toggle');
		var $paused=$('ul:paused');
		if($paused.length)
		    {
			$('#pausebtn').text('恢复');
			}
			else
			$('#pausebtn').text('停止');
          });
   /* $('<button>停止滚动</button>').click(function (event) {
        event.preventDefault();
        $books.cycle('pause');
        $.cookie('cyclePaused', 'y');
    }).appendTo($controls);
    $('<button>恢复滚动</button>').click(function (event) {
        event.preventDefault();
        var $paused = $('ul:paused');
        if ($paused.length) {
            $paused.cycle('resume');
            $.cookie('cyclePaused', null);
        }
        else {
            $(this).effect('shake', {
                distance: 10
            });
        }
    }).appendTo($controls);*/

    $books.hover(function () {
        $books.find('.title').animate({
            backgroundColor: '#eee',
            color: '#000'
        }, 1000);
    }, function () {
        $books.find('.title').animate({
            backgroundColor: '#000',
            color: '#fff'
        }, 1000);
    });
});