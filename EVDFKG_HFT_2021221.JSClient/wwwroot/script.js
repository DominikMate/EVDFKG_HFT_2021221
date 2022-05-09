let cpus = [];
let motherboards = [];
let rams = [];

let cpuIdToUpdate = -1;
let motherboardIdToUpdate = -1;
let ramIdToUpdate = -1;

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
        + t.series + "</td><td>" + `<button type="button" onclick="remove(${t.cpuId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.cpuId})">Update</button>` +"</td></tr>";
        console.log(t.brand);
    })

    document.getElementById('resultarea2').innerHTML = "";
    motherboards.forEach(t => {
        document.getElementById('resultarea2').innerHTML +=
            "<tr><td>" + t.brand + "</td><td>"
        + t.series + "</td><td>"
        + t.motherboardId + "</td><td>" + t.compatibleProcessors + "</td><td>" + t.cpuSocket + "</td><td>"
            + t.ramSlot + "</td><td>" + t.ramType + "</td><td>" + t.maxramSpeed + "</td><td>"
        + t.gpuInterface + "</td><td>" + `<button type="button" onclick="remove2(${t.motherboardId})">Delete</button>` + `<button type="button" onclick="showupdate2(${t.motherboardId})">Update</button>` + "</td></tr>";
        console.log(t.brand);
    })

    document.getElementById('resultarea3').innerHTML = "";
    rams.forEach(t => {
        document.getElementById('resultarea3').innerHTML +=
            "<tr><td>" + t.brand + "</td><td>"
            + t.series + "</td><td>"
        + t.ramId + "</td><td>" + t.ramSize + "</td><td>" + t.ramSpeed + "</td><td>"
            + t.ramType + "</td><td>" + t.casLatency + "</td><td>" + t.partNumber + "</td><td>"
        + `<button type="button" onclick="remove3(${t.ramId})">Delete</button>` + `<button type="button" onclick="showupdate3(${t.ramId})">Update</button>` + "</td></tr>";
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

function showupdate(id) {
    document.getElementById('cpubrandtoupdate').value = cpus.find(t => t['cpuId'] == id)['brand'];
    document.getElementById('cpuseriestoupdate').value = cpus.find(t => t['cpuId'] == id)['series'];
    document.getElementById('cpucoretoupdate').value = cpus.find(t => t['cpuId'] == id)['cpuCore'];
    document.getElementById('cpusockettoupdate').value = cpus.find(t => t['cpuId'] == id)['cpuSocket'];
    document.getElementById('cpuspeedtoupdate').value = cpus.find(t => t['cpuId'] == id)['cpuSpeed'];
    document.getElementById('cputhreadtoupdate').value = cpus.find(t => t['cpuId'] == id)['cpuThread'];
    document.getElementById('ramtypetoupdate').value = cpus.find(t => t['cpuId'] == id)['ramType'];
    document.getElementById('updateformdiv').style.display = 'flex';
    cpuIdToUpdate = id;
}
function showupdate2(id) {
    document.getElementById('motherboardseriestoupdate').value = motherboards.find(t => t['motherboardId'] == id)['series'];
    document.getElementById('motherboardbrandtoupdate').value = motherboards.find(t => t['motherboardId'] == id)['brand'];
    document.getElementById('motherboardcompatiblerocessorstoupdate').value = motherboards.find(t => t['motherboardId'] == id)['compatibleProcessors'];
    document.getElementById('motherboardcpusockettoupdate').value = motherboards.find(t => t['motherboardId'] == id)['cpuSocket'];
    document.getElementById('motherboardramslottoupdate').value = motherboards.find(t => t['motherboardId'] == id)['ramSlot'];
    document.getElementById('motherboardramtypetoupdate').value = motherboards.find(t => t['motherboardId'] == id)['ramType'];
    document.getElementById('motherboardmaxramspeedtoupdate').value = motherboards.find(t => t['motherboardId'] == id)['maxramSpeed'];
    document.getElementById('motherboardgpuinterfacetoupdate').value = motherboards.find(t => t['motherboardId'] == id)['gpuInterface'];
    document.getElementById('updateformdiv2').style.display = 'flex';
    motherboardIdToUpdate = id;
}
function showupdate3(id) {
    document.getElementById('ramseriestoupdate').value = rams.find(t => t['ramId'] == id)['series'];
    document.getElementById('rambrandtoupdate').value = rams.find(t => t['ramId'] == id)['brand'];
    document.getElementById('ramsizetoupdate').value = rams.find(t => t['ramId'] == id)['ramSize'];
    document.getElementById('ramspeedtoupdate').value = rams.find(t => t['ramId'] == id)['ramSpeed'];
    document.getElementById('casLatencytoupdate').value = rams.find(t => t['ramId'] == id)['casLatency'];
    document.getElementById('rampartnumbertoupdate').value = rams.find(t => t['ramId'] == id)['partNumber'];
    document.getElementById('ramtypeetoupdate').value = rams.find(t => t['ramId'] == id)['ramType'];
    document.getElementById('updateformdiv3').style.display = 'flex';
    ramIdToUpdate = id;
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

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let Cpuseries = document.getElementById("cpuseriestoupdate").value;
    let Cpubrand = document.getElementById("cpubrandtoupdate").value;
    let Cpucore = document.getElementById("cpucoretoupdate").value;
    let Cpusocket = document.getElementById("cpusockettoupdate").value;
    let Cpuspeed = document.getElementById("cpuspeedtoupdate").value;
    let Cputhread = document.getElementById("cputhreadtoupdate").value;
    let RamType = document.getElementById("ramtypetoupdate").value;

    fetch('http://localhost:9861/cpu', {
        method: 'PUT',
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
                ramType: RamType,
                cpuId: cpuIdToUpdate
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

function update2() {
    document.getElementById('updateformdiv2').style.display = 'none';
    let Motherboardseries = document.getElementById("motherboardseriestoupdate").value;
    let Motherboardbrand = document.getElementById("motherboardbrandtoupdate").value;
    let Motherboardcompatiblerocessors = document.getElementById("motherboardcompatiblerocessorstoupdate").value;
    let Motherboardcpusocket = document.getElementById("motherboardcpusockettoupdate").value;
    let Motherboardramslot = document.getElementById("motherboardramslottoupdate").value;
    let Motherboardramtype = document.getElementById("motherboardramtypetoupdate").value;
    let Motherboardmaxramspeed = document.getElementById("motherboardmaxramspeedtoupdate").value;
    let Motherboardgpuinterface = document.getElementById("motherboardgpuinterfacetoupdate").value;
    fetch('http://localhost:9861/motherboard', {
        method: 'PUT',
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
                gpuInterface: Motherboardgpuinterface,
                motherboardId: motherboardIdToUpdate
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
function update3() {
    document.getElementById('updateformdiv3').style.display = 'none';
    let Ramseries = document.getElementById("ramseriestoupdate").value;
    let Rambrand = document.getElementById("rambrandtoupdate").value;
    let Ramsize = document.getElementById("ramsizetoupdate").value;
    let Ramspeed = document.getElementById("ramspeedtoupdate").value;
    let Ramtype = document.getElementById("ramtypeetoupdate").value;
    let CasLatency = document.getElementById("casLatencytoupdate").value;
    let Rampartnumber = document.getElementById("rampartnumbertoupdate").value;
    fetch('http://localhost:9861/ram', {
        method: 'PUT',
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
                partNumber: Rampartnumber,
                ramId: ramIdToUpdate
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