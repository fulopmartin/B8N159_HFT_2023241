let awards = [];
let wines = [];
let wineries = [];
let stats = [];

let awardIdUpdate = -1;
let wineIdUpdate = -1;
let wineryIdUpdate = -1;


getAwardsData();
//getWineData();
//getWineryData();

document.getElementById('welcomeDiv').style.display = 'block';
document.getElementById('awardDiv').style.display = 'none';
document.getElementById('wineDiv').style.display = 'none';
document.getElementById('wineryDiv').style.display = 'none';
document.getElementById('staticticsDiv').style.display = 'none';


function mainMenu() {
    document.getElementById('welcomeDiv').style.display = 'block';    
    document.getElementById('awardDiv').style.display = 'none';    
    document.getElementById('wineDiv').style.display = 'none';
    document.getElementById('wineryDiv').style.display = 'none';
    document.getElementById('staticticsDiv').style.display = 'none';   
}

// #region Award
function awardsMenu() {
    document.getElementById('welcomeDiv').style.display = 'none';
    document.getElementById('awardDiv').style.display = 'block';
    resetAwardsMenu();

    document.getElementById('wineDiv').style.display = 'none';
    document.getElementById('wineryDiv').style.display = 'none';
    document.getElementById('staticticsDiv').style.display = 'none';

    getAwardsData();
}
async function getAwardsData() {
    await fetch('http://localhost:5874/award')
        .then(x => x.json())
        .then(y => {
            awards = y;            
            displayAwards();
        });
}

function refreshAwardsTable() {
    getAwardsData();
}
 
function displayAwards() {
    document.getElementById('awardresults').innerHTML = '';
    awards.forEach(t => {
        document.getElementById('awardresults').innerHTML +=
            "<tr><td>" + t.awardId + "</td>" +
            "<td>" + t.awardName + "</td>" +
            "<td>" + t.awardYear + "</td>" +
            "<td>" + t.wineId + "</td>" +
        `<td><button type="button" onclick=removeAward('${t.awardId}')>Delete</button></td>` +
        `<td><button type="button" onclick=showupdateMenu('${t.awardId}')>Update</button></td></tr>`;
    });
}

function addAward() {
    let awardname = document.getElementById('addawardname').value;
    let awardyear = document.getElementById('addawardyear').value;
    let wineid = document.getElementById('addawardwineid').value;

    fetch('http://localhost:5874/award', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            { awardName: awardname,awardYear: awardyear,wineId:wineid }
        )
    }).then(response => {
        if (!response.ok) {
            return response.json();
        }
    }).then(data => {
        if (data != undefined) {
            console.log(data);
            
            if (data.msg != undefined) {
                throw new Error(data.msg);
            }
            if (data.status != undefined && data.status != 200) {
                throw new Error(data.title)
            }
        }
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });

    getAwardsData();
    resetAwardsMenu();    
}

function removeAward(id) {
    fetch('http://localhost:5874/award/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    }).then(response => {
        if (!response.ok) {
            return response.json();
        }
        else {
            getAwardsData();
        }
    }).then(data => {
        if (data != undefined) {
            console.log(data);
            if (data.msg != undefined) {
                throw new Error(data.msg);
            }
            if (data.status != undefined && data.status != 200) {
                throw new Error(data.title)
            }
        }
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });
}

function resetAwardsMenu() {
    document.getElementById('addawardname').value = '';
    document.getElementById('addawardyear').value = '';
    document.getElementById('addawardwineid').value = '';

    document.getElementById('updateawardname').value = '';
    document.getElementById('updateawardyear').value = '';
    document.getElementById('updateawardwineid').value = '';
    awardIdUpdate = -1;

    document.getElementById('awardAddDiv').style.display = 'block';
    document.getElementById('awardUpdateDiv').style.display = 'none';
    getAwardsData();

}

function showupdateMenu(id) {
    document.getElementById('awardAddDiv').style.display = 'none';
    document.getElementById('awardUpdateDiv').style.display = 'block';

    let a = awards.find(t => t.awardId == id);
    awardIdUpdate = id;

    document.getElementById('updateawardname').value = a.awardName;
    document.getElementById('updateawardyear').value = a.awardYear;
    document.getElementById('updateawardwineid').value = a.wineId;
}

function updateAward() {
    let awardnametoupdate = document.getElementById('updateawardname').value;
    let awardyeartoupdate = document.getElementById('updateawardyear').value;
    let awardwineidtoupdate = document.getElementById('updateawardwineid').value;


    fetch('http://localhost:5874/award', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                awardId: awardIdUpdate,
                awardName: awardnametoupdate,
                awardYear: awardyeartoupdate,
                wineId: awardwineidtoupdate
            }
        )
    }).then(response => {
        if (!response.ok) {
            return response.json();
        }
    }).then(data => {
        if (data != undefined) {
            console.log(data);
            if (data.msg != undefined) {
                throw new Error(data.msg);
            }
            if (data.status != undefined && data.status != 200) {
                throw new Error(data.title)
            }
        }
    }).catch(error => {
        console.error(error);
        alert(error.message);
    });

    awardIdUpdate = -1;
    getAwardsData();
    resetAwardsMenu();    
}
//#endregion


// #region Wine

// #endregion