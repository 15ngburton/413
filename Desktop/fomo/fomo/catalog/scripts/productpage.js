$(function () {
  console.log("THIS");
  $(".thumbNail").onmouseover = function(){
    console.log(this);
  };
}(DMP_CONTEXT.get()))
