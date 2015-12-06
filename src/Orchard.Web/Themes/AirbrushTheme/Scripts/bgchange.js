$(document).ready(function () {
    try {
        var bgurl = localStorage.getItem("gburl");
        var bgdate = localStorage.getItem("bgdate");

        if (bgdate == null || bgdate == undefined) {
            bgdate = new Date()
            localStorage.setItem("bgdate", bgdate);
        } else {
            bgdate = new Date(bgdate);
        }

        var now = new Date();
        var needNew = !(now.getDay() == bgdate.getDay() && now.getMonth() == bgdate.getMonth())

        if (needNew || (bgurl == null || bgurl == undefined)) {
            var bgurl = "";
            var bgnumber = Math.floor(Math.random() * 6) + 1;
            switch (bgnumber) {
                case 1:
                    bgurl = "../Content/colorfull.jpg";
                    break;
                case 2:
                    bgurl = "../Content/colorful_flower.jpg";
                    break;
                case 3:
                    bgurl = "../Content/fireplacebg.jpg";
                    break;
                case 4:
                    bgurl = "../Content/loungebg.jpg";
                    break;
                case 5:
                    bgurl = "../Content/neonbg.jpg";
                    break;
                case 6:
                    bgurl = "../Content/casino.jpg";
                    break;
                default:
                    bgurl = "../Content/blue-texture.jpg";
                    break;
            }
            localStorage.setItem("bgurl", bgurl);
            localStorage.setItem("bgdate", new Date());
        }

        $("body").css("background-image", "url('" + bgurl + "')");


    } catch (err) {
        var xx = 0;
    }

    

})