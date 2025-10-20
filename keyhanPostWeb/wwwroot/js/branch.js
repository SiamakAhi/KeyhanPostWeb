
$(document).ready(function () {

    $(document).on('click', '.path-city', function () {
        var target = $(this).data('target');
        

        $('.branch-list > li').each(function(){
            $(this).removeClass('selected');
        });

        $('li[name='+target+ ']') .each(function(){
             $(this).addClass('selected');
        })
    });


    //$('.branch-list > li').hover(function () {
      
    //    var target = $(this).attr('name');
    //    $('.path-city[data-target=' + target + ']').css("fill", "yellow");
       
    //}, function () {
    //    var target = $(this).attr('name');
    //    $('.path-city[data-target=' + target + ']').css("fill", "blue");
    //}
    //)
})