import { 
        StyleSheet,
        Text,
        SafeAreaView, 
        Dimensions,
        View,
        Image,
        TouchableHighlight} from 'react-native';



export default function SetLogoWithText(props){
    return <View style={styles.container}>
          <TouchableHighlight   onPress={()=>setCurrent(DashboardScreen)}>
          <Image source={require('./../../assets/logo.png')} style={styles.image} />
        </TouchableHighlight>
        <Text style={styles.text}>{props.header}</Text>
    </View>
}


const styles = StyleSheet.create({
  container: {
    position: 'absolute',
    left: 5,
    top: 5,
    flex: 1,
    backgroundColor: '#fff',
         justifyContent: 'center',
  },
    button :{
            flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
    },
  image: {
    flex: 1,
    resizeMode: 'contain',
    width: 75,
    height: 75
    },
    text: {
    position: 'absolute',
    left: (Dimensions.get('window').width / 2) - 70,
    top:0,
    textAlign: 'center', 
    fontSize: 44,
    marginTop:20,
    backgroundColor: 'white',
    color : '#ff5c33'
    }
});