function piece(pies, startFlavor, endFlavor) {
    const start = pies.indexOf(startFlavor);
    const end = pies.indexOf(endFlavor) + 1;
    const result = pies.slice(start, end);
    return result;
}

piece(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'
);

piece(['Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
);
