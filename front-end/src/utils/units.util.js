const units = [
  {
    Id: 1,
    Description: "Kg"
  },
  {
    Id: 2,
    Description: "Lt"
  },
  {
    Id: 3,
    Description: "Ml"
  },
  {
    Id: 4,
    Description: "Mg"
  },
  {
    Id: 5,
    Description: "Un"
  }
];

export default {
  getAllUnitys(){
    return units;
  },
  
  getUnityDescription(id) {
    return units.find(unit => unit.Id == id).Description;
  },

  getUnityId(description) {
    return units.find(unit => unit.Description == description).Id;
  }
}