let cpus = [];
let motherboards = [];
let rams = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR()
{
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:9861/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CPUCreated", (user, message) => {
        getdata();
    });
    connection.on("CPUDeleted", (user, message) => {
        getdata();
    });
    connection.on("CPUUpdated", (user, message) => {
        getdata();
    });

    connection.on("MotherboardCreated", (user, message) => {
        getdata();
    });
    connection.on("MotherboardUpdated", (user, message) => {
        getdata();
    });
    connection.on("MotherboardDeleted", (user, message) => {
        getdata();
    });

    connection.on("RAMCreated", (user, message) => {
        getdata();
    });
    connection.on("RAMUpdated", (user, message) => {
        getdata();
    });
    connection.on("RAMDeleted", (user, message) => {
        getdata();
    });


    connection.onclose(async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata()
{
    await fetch('http://localhost:9861/cpu')
        .then(x => x.json())
        .then(y => {
            cpus = y;
            console.log(cpus);
            display();
        });

    await fetch('http://localhost:9861/motherboard')
        .then(x => x.json())
        .then(y => {
            motherboards = y;
            console.log(motherboards);
            display();
        });
    await fetch('http://localhost:9861/ram')
        .then(x => x.json())
        .then(y => {
            rams = y;
            console.log(rams);
            display();
        });
}


function display()
{
    document.getElementById('resultarea').innerHTML = "";
    cpus.forEach(t =>
    {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.brand + "</td><td>"
            + t.cpuCore + "</td><td>" + t.cpuId + "</td><td>" + t.cpuSocket + "</td><td>"
            + t.cpuSpeed + "</td><td>" + t.cpuThread + "</td><td>" + t.ramType + "</td><td>"
        + t.series + "</td><td>" + `<button type="button" onclick="remove(${t.cpuId})">Delete</button>` +"</td></tr>";
        console.log(t.brand);
    })

    document.getElementById('resultarea2').innerHTML = "";
    motherboards.forEach(t => {
        document.getElementById('resultarea2').innerHTML +=
            "<tr><td>" + t.brand + "</td><td>"
        + t.series + "</td><td>"
        + t.motherboardId + "</td><td>" + t.compatibleProcessors + "</td><td>" + t.cpuSocket + "</td><td>"
            + t.ramSlot + "</td><td>" + t.ramType + "</td><td>" + t.maxramSpeed + "</td><td>"
            + t.gpuInterface + "</td><td>" + `<button type="button" onclick="remove2(${t.motherboardId})">Delete</button>` + "</td></tr>";
        console.log(t.brand);
    })

    document.getElementById('resultarea3').innerHTML = "";
    rams.forEach(t => {
        document.getElementById('resultarea3').innerHTML +=
            "<tr><td>" + t.brand + "</td><td>"
            + t.series + "</td><td>"
        + t.ramId + "</td><td>" + t.ramSize + "</td><td>" + t.ramSpeed + "</td><td>"
            + t.ramType + "</td><td>" + t.casLatency + "</td><td>" + t.partNumber + "</td><td>"
            + `<button type="button" onclick="remove3(${t.ramId})">Delete</button>` + "</td></tr>";
        console.log(t.brand);
    })
}

function remove(id)
{
    fetch('http://localhost:9861/cpu/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function remove2(id) {
    fetch('http://localhost:9861/motherboard/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function remove3(id) {
    fetch('http://localhost:9861/ram/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function create() {
    let Cpuseries = document.getElementById("cpuseries").value;
    let Cpubrand = document.getElementById("cpubrand").value;
    let Cpucore = document.getElementById("cpucore").value;
    let Cpusocket = document.getElementById("cpusocket").value;
    let Cpuspeed = document.getElementById("cpuspeed").value;
    let Cputhread = document.getElementById("cputhread").value;
    let RamType = document.getElementById("ramtype").value;

    fetch('http://localhost:9861/cpu', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                series: Cpuseries,
                brand: Cpubrand,
                cpuCore: Cpucore,
                cpuSocket: Cpusocket,
                cpuSpeed: Cpuspeed,
                cpuThread: Cputhread,
                ramType: RamType

            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

   
}
function create2() {
    let Motherboardseries = document.getElementById("motherboardseries").value;
    let Motherboardbrand = document.getElementById("motherboardbrand").value;
    let Motherboardcompatiblerocessors = document.getElementById("motherboardcompatiblerocessors").value;
    let Motherboardcpusocket = document.getElementById("motherboardcpusocket").value;
    let Motherboardramslot = document.getElementById("motherboardramslot").value;
    let Motherboardramtype = document.getElementById("motherboardramtype").value;
    let Motherboardmaxramspeed = document.getElementById("motherboardmaxramspeed").value;
    let Motherboardgpuinterface = document.getElementById("motherboardgpuinterface").value;
    fetch('http://localhost:9861/motherboard', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                series: Motherboardseries,
                brand: Motherboardbrand,
                compatibleProcessors: Motherboardcompatiblerocessors,
                cpuSocket: Motherboardcpusocket,
                ramSlot: Motherboardramslot,
                ramType: Motherboardramtype,
                maxramSpeed: Motherboardmaxramspeed,
                gpuInterface: Motherboardgpuinterface
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });


}
function create3() {
    let Ramseries = document.getElementById("ramseries").value;
    let Rambrand = document.getElementById("rambrand").value;
    let Ramsize = document.getElementById("ramsize").value;
    let Ramspeed = document.getElementById("ramspeed").value;
    let Ramtype = document.getElementById("ramtype").value;
    let CasLatency = document.getElementById("casLatency").value;
    let Rampartnumber = document.getElementById("rampartnumber").value;
    fetch('http://localhost:9861/ram', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                series: Ramseries,
                brand: Rambrand,
                ramSize: Ramsize,
                ramSpeed: Ramspeed,
                ramType: Ramtype,
                casLatency: CasLatency,
                partNumber: Rampartnumber
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });


}