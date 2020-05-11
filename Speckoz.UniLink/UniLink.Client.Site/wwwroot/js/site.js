﻿$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

function ChangeToLight() {
    ChangeLinkTheme("css/theme.light.css");
}
function ChangeToDark() {
    ChangeLinkTheme("css/theme.dark.css");
}

function ChangeLinkTheme(cssFile) {
    document.getElementById("clientThemeLink").setAttribute("href", cssFile);
}

function SendAlert(msg) {
    alert(msg);
}

function ShowModal(modalId) {
    $(document).ready(() => $('#' + modalId).modal('show'));
}

function HideModal(modalId) {
    $(document).ready(() => $('#' + modalId).modal('hide'));
}

function shoot(time) {
    const video = document.getElementById('video');
    //video.currentTime = time;
    video.currentTime += 0.25;

    const scaleFactor = 0.25;

    const w = video.videoWidth * scaleFactor;
    const h = video.videoHeight * scaleFactor;

    const canvas = document.getElementById('canvasid');
    canvas.width = w;
    canvas.height = h;

    const ctx = canvas.getContext('2d');
    ctx.drawImage(video, 0, 0, w, h);
}