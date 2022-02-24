var swup = new Swup();

function tinyMc() {
    tinymce.init({
        selector: "#blogContentArea",
        height: "250"
    });
}

function init() {
    if (document.querySelector("#blogContentArea")) {
        tinyMc();
    }
}

const monthsList = ["Jan", "Feb", "Mar", "Apr", "May","Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

var months = [
    {
        month: "Jan",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Feb",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Mar",
        counter: 6,
        bgColor: "Red"
    },
    {
        month: "Apr",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "May",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Jun",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Jul",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Aug",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Sep",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Oct",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Nov",
        counter: 0,
        bgColor: "Red"
    },
    {
        month: "Dec",
        counter: 0,
        bgColor: "Red"
    }
];

const createChart = async () => {

    var ctx = document.querySelector("#myChart").getContext("2d");

    const data = await fetch("/Admin/Home/Posts");

    const res = await data.json();

    for (let post of res.data) {
        const parsedDate = new Date(Date.parse(post.dateCreated));

        const month = parsedDate.getMonth();

        getMonth(month);

    }

    var myChart = new Chart(ctx,
        {
            type: "line",
            data: {
                labels: monthsList,
                datasets: [{
                    label: '# of Votes',
                    data: [
                        months[0].counter,
                        months[1].counter,
                        months[2].counter,
                        months[3].counter,
                        months[4].counter,
                        months[5].counter,
                        months[6].counter,
                        months[7].counter,
                        months[8].counter,
                        months[9].counter,
                        months[10].counter,
                        months[11].counter,
                    ],
                    backgroundColor: ["#17181a"],
                    borderWidth: 3
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
}

const getMonth = (currentPost) => {
    switch (currentPost) {
        case 1:
            months[0].counter += 1;
            break;
        case 2:
            months[1].counter += 1;
            break;
        case 3:
            months[2].counter += 1;
            break;
        case 4:
            months[3].counter += 1;
            break;
        case 5:
            months[4].counter += 1;
            break;
        case 6:
            months[5].counter += 1;
            break;
        case 7:
            months[6].counter += 1;
            break;
        case 8:
            months[7].counter += 1;
            break;
        case 9:
            months[8].counter += 1;
            break;
        case 10:
            months[9].counter += 1;
            break;
        case 11:
            months[10].counter += 1;
            break;
        case 12:
            months[11].counter += 1;
            break;
    }
}

createChart();

init();