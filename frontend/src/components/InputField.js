function InputField(prop){
  const className = prop.className;
  const type = prop.type;
  const label = prop.label;

  return (
  <div className={className}>
      <label>{label}</label>
      <input 
          type={type}
          name={className}
      ></input>
  </div>
  );
}

export default InputField;